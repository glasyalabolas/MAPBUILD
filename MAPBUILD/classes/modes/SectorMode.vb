Option Infer On

Imports MAP_ID = System.Int32

Public Class SectorMode
  Inherits ModeBase

  Public Sub New()
    SetName("Sector mode")
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseDoubleClick(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      ClearSelection()

      OnModeStarted()

      Dim newModeArgs = New ModeChangedEventArgs() With {
        .Mode = New PolyDrawMode()}

      OnModeChanged(Me, newModeArgs)

      newModeArgs.Mode.OnMouseDoubleClick(e, modifierKeys)
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseUp(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _highlightedSectorId = NOT_FOUND

        SetHelpText("")
      Else
        If (_highlightedSectorId <> NOT_FOUND) Then
          If (modifierKeys And UNSELECT_SINGLE_KEY) Then
            RemoveSelected(_highlightedSectorId)
          Else
            AddToSelection(_highlightedSectorId)
          End If

          OnRefresh()
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    Dim sID As MAP_ID = Layer.PointInSector(_mp)

    If (sID <> _highlightedSectorId AndAlso Not Selecting AndAlso Not _ldragging) Then
      _highlightedSectorId = sID

      If (_highlightedSectorId <> NOT_FOUND) Then
        OnModeEvent(Layer.SectorById(_highlightedSectorId),
          ModeEventType.EVENT_SECTOR_HIGHLIGHTED)

        SetHelpText("Sector #: " & Layer.SectorById(_highlightedSectorId).Id)
      End If
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging AndAlso Not Selecting) Then
        _ldelta = SnapToGrid(_mp) - _lstart
        _lstart = SnapToGrid(_mp)

        If (SelectedCount > 0) Then
          '' Drag selection
          For i As Integer = 0 To SelectedCount - 1
            Dim ld = Layer.SectorById(Selected(i))

            DragSector(ld)
          Next

          If (_highlightedSectorId <> NOT_FOUND AndAlso Not IsSelected(_highlightedSectorId)) Then
            '' Drag the highlighted sector too even if it's not selected
            DragSector(Layer.SectorById(_highlightedSectorId))
          End If
        Else
          '' Drag individual sector
          If (_highlightedSectorId <> NOT_FOUND) Then
            DragSector(Layer.SectorById(_highlightedSectorId))
          End If
        End If
      Else
        If (_highlightedSectorId <> NOT_FOUND) Then
          _ldragging = True
          _lstart = SnapToGrid(_mp)
        End If
      End If
    End If

    If (_highlightedSectorId = NOT_FOUND) Then
      MyBase.OnMouseMove(e, modifierKeys)
    End If
  End Sub

  Private Sub RenderSector(g As Graphics, s As Sector, T As Mat3, c As Color)
    For j As Integer = 0 To s.LineDefs - 1
      Dim ld = Layer.LineDefById(s.LineDef(j))

      Dim p0 = T * ld.GetP0().Pos
      Dim p1 = T * ld.GetP1().Pos

      RenderLineDef(g, p0, p1, 10.0 / Camera.Zoom, c)
    Next
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    For i As Integer = 0 To Layer.Sectors - 1
      RenderSector(g, Layer.Sector(i), T, VGAColors.LightGray)
    Next

    If (SelectedCount > 0) Then
      For i As Integer = 0 To SelectedCount - 1
        RenderSector(g, Layer.SectorById(Selected(i)), T, VGAColors.LightRed)
      Next
    End If

    If (_highlightedSectorId <> NOT_FOUND) Then
      RenderSector(g, Layer.SectorById(_highlightedSectorId), T, VGAColors.Yellow)
    End If

    RenderVertices(g, VGAColors.LightGray)
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (_highlightedSectorId <> NOT_FOUND) Then
      Dim s = Layer.SectorById(_highlightedSectorId)

      If (e.KeyCode = Keys.Q) Then
        s.Rotate(Rad(-15))
      End If

      If (e.KeyCode = Keys.W) Then
        s.Rotate(Rad(15))
      End If

      If (e.KeyCode = Keys.PageDown) Then
        Layer.BringToFront(_highlightedSectorId)
        SetHelpText("Sector #" & _highlightedSectorId & " brought to front")
      End If

      If (e.KeyCode = Keys.PageUp) Then
        Layer.SendToBack(_highlightedSectorId)
        SetHelpText("Sector #" & _highlightedSectorId & " sent to back")
      End If
    End If

    OnRefresh()
  End Sub

  Protected Overrides Sub OnSelect(e As Rect, modifierKeys As Keys)
    Dim selectionClear As Boolean = Not CBool(modifierKeys And ADD_TO_SELECTION_KEY)
    Dim removeFromSelection As Boolean = modifierKeys And REMOVE_FROM_SELECTION_KEY

    If (selectionClear AndAlso Not removeFromSelection) Then
      ClearSelection()
    End If

    For i As Integer = 0 To Layer.Sectors - 1
      Dim s = Layer.Sector(i)

      Dim inside As Boolean = True

      For j As Integer = 0 To s.Vertices - 1
        Dim v = Layer.VertexById(s.Vertex(j)).Pos

        inside = inside AndAlso e.Inside(v)
      Next

      If (inside) Then
        Dim selected As Boolean = IsSelected(s.Id)

        If (Not selected) Then
          AddToSelection(s.Id)
        ElseIf (removeFromSelection) Then
          RemoveSelected(s.Id)
        End If
      End If
    Next
  End Sub

  Private Sub DragSector(s As Sector)
    Dim vertices As New List(Of MAP_ID)

    For i As Integer = 0 To s.LineDefs - 1
      Dim ld = Layer.LineDefById(s.LineDef(i))
      Dim p0 = ld.GetP0.Id
      Dim p1 = ld.GetP1.Id

      '' Don't move already moved vertices twice
      If (Not vertices.Contains(p0)) Then
        ld.GetP0.Pos += _ldelta
        vertices.Add(p0)
      End If

      If (Not vertices.Contains(p1)) Then
        ld.GetP1.Pos += _ldelta
        vertices.Add(p1)
      End If
    Next
  End Sub

  Private _highlightedSectorId As Integer = NOT_FOUND
  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean
End Class
