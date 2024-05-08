Public Class SectorMode
  Inherits ModeBase

  Public Sub New()
    SetName("Sector mode")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    Dim p = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    _highlightedSectorId = NOT_FOUND

    For i As Integer = 0 To Layer.Sectors - 1
      If (Layer.Sector(i).Inside(p)) Then
        _highlightedSectorId = Layer.Sector(i).Id
      End If
    Next
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim inv = Camera.Transform().Inversed()
    Dim proj = Camera.Projection()

    For i As Integer = 0 To Layer.Sectors - 1
      For j As Integer = 0 To Layer.Sector(i).LineDefs - 1
        Dim ld = Layer.LineDefById(Layer.Sector(i).LineDef(j))

        Dim p0 = proj * inv * Layer.VertexById(ld.p0)
        Dim p1 = proj * inv * Layer.VertexById(ld.p1)

        Dim cells = ld.Traverse(GridSize)

        For cell As Integer = 0 To cells.Count - 1
          Dim cP0 = proj * inv * New Vec2(cells(cell).X * GridSize, cells(cell).Y * GridSize)
          Dim sz As Single = GridSize / Camera.Zoom

          g.DrawRectangle(VGAColors.CyanPen,
            New Rectangle(cP0.x, cP0.y, sz, sz))
        Next

        If (Layer.Sector(i).Id = _highlightedSectorId) Then
          RenderLineDef(g, p0, p1, Color.Yellow)
        Else
          RenderLineDef(g, p0, p1, Color.Red)
        End If
      Next
    Next
  End Sub

  Private _highlightedSectorId As Integer = NOT_FOUND
End Class
