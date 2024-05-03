Public Class LineDef
  Public Sub New()
    p0 = -1 : p1 = -1
  End Sub

  Public Sub New(nP0 As Integer, nP1 As Integer)
    p0 = nP0 : p1 = nP1
  End Sub

  Public p0 As Integer
  Public p1 As Integer
End Class
