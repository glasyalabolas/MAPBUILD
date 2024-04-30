Public Class DrawLinesMode
  Inherits ModeBase

  Public Sub New(m As Map, c As Camera2D)
    SetName("Line mode")

    _map = m
    _cam = c
  End Sub

  Private _map As Map
  Private _cam As Camera2D
End Class
