Public Class PolyDebugMode
  Inherits ModeBase

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = New Vec2(e.X, e.Y)
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
    _poly.Add(New Vec2(e.X, e.Y))
  End Sub

  Public Overrides Sub OnProcess()
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim c = Color.Red

    If (_poly.Inside(_mp)) Then
      c = Color.Yellow
    End If

    RenderPoly(g, _poly, c)
  End Sub

  Private _mp As New Vec2()
  Private _poly As New Poly()
End Class
