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

    RenderThings(g, VGAColors.DarkGray)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    For i As Integer = 0 To Layer.Sectors - 1
      RenderSector(g, Layer.Sector(i), T, VGAColors.LightGray)
    Next

    If (SelectedCount > 0) Then
      For i As Integer = 0 To SelectedCount - 1
        RenderSector(g, Layer.SectorById(Selected(i)), T, VGAColors.LightRed)
      Next
    End If

    If (HighlightedId <> NOT_FOUND) Then
      RenderSector(g, Layer.SectorById(HighlightedId), T, VGAColors.Yellow)
    End If

    RenderVertices(g, VGAColors.LightGray)
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (HighlightedId <> NOT_FOUND) Then
      Dim s = Layer.SectorById(HighlightedId)

      If (e.KeyCode = Keys.Q) Then
        s.Rotate(Rad(-15))
      End If

      If (e.KeyCode = Keys.W) Then
        s.Rotate(Rad(15))
      End If
    End If

    OnRefresh()
  End Sub

  Protected Overrides Function FindNearestId() As MAP_ID
    Return (Layer.PointInSector(MousePos))
  End Function

  Protected Overrides Sub OnSelect(e As Rect, removeFromSelection As Boolean)
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

  Protected Overrides Sub OnDrag(id As MAP_ID, delta As Vec2)
    DragSector(Layer.SectorById(id), delta)
  End Sub

  Protected Overrides Sub OnDragSelection(selected As List(Of MAP_ID), delta As Vec2)
    For i As Integer = 0 To selected.Count - 1
      DragSector(Layer.SectorById(selected(i)), delta)
    Next
  End Sub

  Private Sub DragSector(s As Sector, delta As Vec2)
    Dim vertices As New List(Of MAP_ID)

    For i As Integer = 0 To s.LineDefs - 1
      Dim ld = Layer.LineDefById(s.LineDef(i))
      Dim p0 = ld.GetP0.Id
      Dim p1 = ld.GetP1.Id

      '' Don't move already moved vertices twice
      If (Not vertices.Contains(p0)) Then
        ld.GetP0.Pos += delta
        vertices.Add(p0)
      End If

      If (Not vertices.Contains(p1)) Then
        ld.GetP1.Pos += delta
        vertices.Add(p1)
      End If
    Next
  End Sub
End Class
