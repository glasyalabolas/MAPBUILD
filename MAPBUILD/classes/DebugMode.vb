Public Class DebugMode
  Inherits ModeBase

  Public Overrides Sub OnRender(g As Graphics)
    g.Clear(Color.FromArgb(255, Rnd() * 255, Rnd() * 255, Rnd() * 255))
  End Sub
End Class
