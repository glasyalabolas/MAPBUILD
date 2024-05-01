Public Class LineDef
  Public Sub New()
  End Sub

  Public Sub New(nP0 As Vec2, nP1 As Vec2)
    p0 = nP0 : p1 = nP1
  End Sub

  Public p0 As Vec2
  Public p1 As Vec2
End Class
