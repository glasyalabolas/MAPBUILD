Public Class SectorMode
  Inherits ModeBase

  Public Sub New()
    SetName("Sector mode")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    Dim p = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    _highlightedSectorId = NOT_FOUND

    For i As Integer = 0 To Layer.Sectors - 1
      If (Layer.Sector(i).IsClosed()) Then
        If (Layer.Sector(i).Inside(p)) Then
          _highlightedSectorId = Layer.Sector(i).Id

          SetHelpText("Sector #: " & Layer.Sector(i).Id)
        End If
      End If
    Next
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    For i As Integer = 0 To Layer.Sectors - 1
      For j As Integer = 0 To Layer.Sector(i).LineDefs - 1
        Dim ld = Layer.LineDefById(Layer.Sector(i).LineDef(j))

        Dim p0 = T * Layer.VertexById(ld.P0)
        Dim p1 = T * Layer.VertexById(ld.P1)

        If (Layer.Sector(i).Id = _highlightedSectorId) Then
          RenderLineDef(g, p0, p1, Color.Yellow)
        Else
          RenderLineDef(g, p0, p1, Color.Red)
        End If
      Next

      Dim centroid = Layer.Sector(i).GetCentroid()

      RenderVertex(g, T * centroid, 7.0 / Camera.Zoom, VGAColors.Magenta)
    Next
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
    End If

    OnRefresh()
  End Sub

  Private _highlightedSectorId As Integer = NOT_FOUND
End Class
