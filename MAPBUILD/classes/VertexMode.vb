Option Infer On

Public Class VertexMode
  Inherits ModeBase

  Public Sub New(m As Map)
    _map = m

    BlockSize = 32
  End Sub

  Public Property BlockSize() As Integer

  Public Overrides Sub OnRender(g As Graphics, cam As Camera2D)
    Dim inv = cam.Transform().Inversed()

    For i As Integer = 0 To _map.LineCount - 1
      With _map.Line(i)
        Dim p1 = cam.Projection * inv * _map.Vertex(.p0)
        Dim p2 = cam.Projection * inv * _map.Vertex(.p1)

        g.DrawLine(Pens.White, p1, p2)
      End With
    Next

    Dim p = cam.Projection * inv * _map.Vertex(_map.VertexCount - 1)
    RenderPoint(g, p, 3, Color.Red)
  End Sub

  Private _map As Map
End Class
