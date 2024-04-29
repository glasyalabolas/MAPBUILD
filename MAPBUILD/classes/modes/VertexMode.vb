Option Infer On

Public Class VertexMode
  Inherits ModeBase

  Public Sub New(m As Map)
    _map = m
  End Sub

  Public Overrides Sub OnRender(g As Graphics, cam As Camera2D)
  End Sub

  Private _map As Map
End Class
