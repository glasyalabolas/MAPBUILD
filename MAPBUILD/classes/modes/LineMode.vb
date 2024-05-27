Option Infer On

Imports MAP_ID = System.Int32

Public Class LineMode
  Inherits ModeBase

  Public Sub New()
    SetName("Line mode")
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseClick(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      If (modifierKeys And Keys.Control) Then
        If (_closestPoint IsNot Nothing) Then
          '' Split linedef at the closest point
          Dim ld = Layer.LineDefById(_closestLineDefId)
          Dim nv = SnapToGrid(_closestPoint)
          Dim nvId = Layer.AddVertex(nv)

          Dim nldId = Layer.AddLineDef(New LineDef(nvId, ld.P1))

          ld.P1 = nvId
          ld.OnLineDefSplit(nldId)
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _ldragging AndAlso Not Selecting) Then
      _closestLineDefId = FindClosestLineDefId(_mp)
      _closestPoint = Nothing
    End If

    If (Not _ldragging) Then
      If (_closestLineDefId <> NOT_FOUND) Then
        _closestPoint = Layer.LineDefById(_closestLineDefId).GetClosestPoint(_mp)
      End If
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging AndAlso Not Selecting) Then
        _ldelta = SnapToGrid(_mp) - _lstart
        _lstart = SnapToGrid(_mp)

        _vertices.Clear()

        If (SelectedCount > 0) Then
          '' Drag selection
          For i As Integer = 0 To SelectedCount - 1
            Dim ld = Layer.LineDefById(Selected(i))

            DragLineDef(ld)
          Next

          If (_closestLineDefId <> NOT_FOUND AndAlso Not IsSelected(_closestLineDefId)) Then
            '' Drag the closest linedef too even if it's not selected
            DragLineDef(Layer.LineDefById(_closestLineDefId))
          End If
        Else
          '' Drag individual linedef
          If (_closestLineDefId <> NOT_FOUND) Then
            DragLineDef(Layer.LineDefById(_closestLineDefId))
          End If
        End If
      Else
        If (_closestLineDefId <> NOT_FOUND) Then
          _ldragging = True
          _lstart = SnapToGrid(_closestPoint)
        End If
      End If
    End If

    If (_closestLineDefId = NOT_FOUND) Then
      MyBase.OnMouseMove(e, modifierKeys)
    End If
  End Sub

  Private Sub DragLineDef(ld As LineDef)
    Dim p0 = ld.GetP0.Id
    Dim p1 = ld.GetP1.Id

    '' Don't move already moved vertices twice
    If (Not _vertices.Contains(p0)) Then
      ld.GetP0.Pos += _ldelta
      _vertices.Add(p0)
    End If

    If (Not _vertices.Contains(p1)) Then
      ld.GetP1.Pos += _ldelta
      _vertices.Add(p1)
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseUp(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _closestLineDefId = NOT_FOUND

        SetHelpText("")
      Else
        If (_closestLineDefId <> NOT_FOUND) Then
          If (modifierKeys And UNSELECT_SINGLE_KEY) Then
            RemoveSelected(_closestLineDefId)
          Else
            AddToSelection(_closestLineDefId)
          End If

          OnRefresh()
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    RenderLines(g, VGAColors.LightGray)
    RenderVertices(g, VGAColors.DarkGray)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    If (SelectedCount > 0) Then
      For i As Integer = 0 To SelectedCount - 1
        Dim ld = Layer.LineDefById(Selected(i))
        Dim pp0 = T * ld.GetP0.Pos
        Dim pp1 = T * ld.GetP1.Pos

        RenderLineDef(g, pp0, pp1, 10.0 / Camera.Zoom, VGAColors.LightRed)
      Next
    End If

    If (_closestLineDefId <> NOT_FOUND) Then
      Dim ld = Layer.LineDefById(_closestLineDefId)
      Dim pp0 = T * ld.GetP0.Pos
      Dim pp1 = T * ld.GetP1.Pos

      RenderLineDef(g, pp0, pp1, 10.0 / Camera.Zoom, VGAColors.Yellow)
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (e.KeyCode = Keys.Delete) Then
      If (_closestLineDefId <> NOT_FOUND) Then
        Dim ld = Layer.LineDefById(_closestLineDefId)

        ld.OnLineDefDeleted()

        Layer.DeleteLineDef(_closestLineDefId)

        _closestLineDefId = NOT_FOUND

        OnRefresh()
      End If
    End If
  End Sub

  Protected Overrides Sub OnSelect(e As Rect, modifierKeys As Keys)
    Dim selectionClear As Boolean = Not CBool(modifierKeys And ADD_TO_SELECTION_KEY)
    Dim removeFromSelection As Boolean = modifierKeys And REMOVE_FROM_SELECTION_KEY

    If (selectionClear AndAlso Not removeFromSelection) Then
      ClearSelection()
    End If

    For i As Integer = 0 To Layer.LineDefs - 1
      Dim ld = Layer.LineDef(i)

      Dim p0 = ld.GetP0.Pos
      Dim p1 = ld.GetP1.Pos

      If (e.Inside(p0) AndAlso e.Inside(p1)) Then
        Dim selected As Boolean = IsSelected(ld.Id)

        If (Not selected) Then
          AddToSelection(ld.Id)
        ElseIf (removefromselection) Then
          RemoveSelected(ld.Id)
        End If
      End If
    Next
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean

  Private _closestLineDefId As Integer = NOT_FOUND
  Private _closestPoint As Vec2

  Private _vertices As New List(Of MAP_ID)
End Class
