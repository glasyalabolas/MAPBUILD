Option Infer On

Public Class OperationsDebugMode
  Inherits ModeBase

  Public Sub New()
    SetName("Op debug mode")
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim inv = Camera.Transform().Inversed()
    Dim proj = Camera.Projection()

    For i As Integer = 0 To Layer.Sectors - 1
      For j As Integer = 0 To Layer.Sector(i).LineDefs - 1
        Dim ld = Layer.LineDefById(Layer.Sector(i).LineDef(j))

        Dim p0 = proj * inv * Layer.VertexById(ld.P0)
        Dim p1 = proj * inv * Layer.VertexById(ld.P1)

        'If (Layer.Sector(i).Id = _highlightedSectorId) Then
        '  RenderLineDef(g, p0, p1, Color.Yellow)
        'Else
        RenderLineDef(g, p0, p1, Color.LightGray)
        'End If
      Next
    Next
  End Sub
End Class
