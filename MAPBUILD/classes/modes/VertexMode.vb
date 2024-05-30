Imports MAP_ID = System.Int32

Public Class VertexMode
  Inherits ModeBase

  Public Sub New()
    SetName("Vertex mode")
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

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    RenderThings(g, VGAColors.DarkGray)
    RenderLines(g, VGAColors.DarkGray)
    RenderVertices(g, VGAColors.LightCyan)

    If (HighlightedId <> NOT_FOUND) Then
      Dim T = Camera.Projection() * Camera.Transform().Inversed()
      Dim p = T * Layer.VertexById(HighlightedId).Pos
      Dim z As Single = 1.0 / Camera.Zoom
      Dim pen = New Pen(VGAColors.White)
      Dim sz As Single = Math.Min(10.0, 10.0 * z)

      g.DrawRectangle(pen, New Rectangle(p.x - sz * 0.5 - 2, p.y - sz * 0.5 - 2, sz + 3, sz + 3))
    End If

    If (SelectedCount > 0) Then
      Dim T = Camera.Projection() * Camera.Transform().Inversed()
      Dim z As Single = 1.0 / Camera.Zoom

      For i As Integer = 0 To SelectedCount - 1
        Dim p = T * Layer.VertexById(Selected(i)).Pos

        If (InsideView(p)) Then
          RenderVertex(g, p, Math.Min(MAX_VERTEX_SIZE, MAX_VERTEX_SIZE * z), VGAColors.LightRed)
        End If
      Next
    End If
  End Sub

  Protected Overrides Function FindNearestId() As MAP_ID
    Dim closest As Single = Single.MaxValue
    Dim result As MAP_ID = NOT_FOUND
    Dim minDist As Single = VERTEX_NEAR_DISTANCE * Camera.Zoom

    For i As Integer = 0 To Layer.Vertices - 1
      Dim dist As Single = MousePos.DistanceToSq(Layer.Vertex(i))

      If (dist < closest AndAlso dist <= minDist) Then
        closest = dist
        result = Layer.Vertex(i).Id
      End If
    Next

    Return (result)
  End Function

  Protected Overrides Sub OnSelect(e As Rect, removeFromSelection As Boolean)
    For i As Integer = 0 To Layer.Vertices - 1
      If (e.Inside(Layer.Vertex(i))) Then
        Dim selected As Boolean = IsSelected(Layer.Vertex(i).Id)

        If (Not selected) Then
          AddToSelection(Layer.Vertex(i).Id)
        ElseIf (removeFromSelection) Then
          RemoveSelected(Layer.Vertex(i).Id)
        End If
      End If
    Next
  End Sub

  Protected Overrides Sub OnDrag(id As MAP_ID, delta As Vec2)
    Layer.VertexById(id).Pos += delta
  End Sub

  Protected Overrides Sub OnDragSelection(selected As List(Of MAP_ID), delta As Vec2)
    For i As Integer = 0 To selected.Count - 1
      Layer.VertexById(selected(i)).Pos += delta
    Next
  End Sub
End Class
