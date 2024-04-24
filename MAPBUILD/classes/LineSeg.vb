Option Infer On

''' <summary>
''' Defines a line segment by two endpoints.
''' </summary>
Public Class LineSeg
  Public Sub New()
    p0 = New Vec2(0, 0) : p1 = New Vec2(0, 0)
  End Sub

  Public Sub New(nP0 As Vec2, nP1 As Vec2)
    p0 = nP0 : p1 = nP1
  End Sub

  Public Function Length() As Single
    Return ((p1 - p0).Length())
  End Function

  Public Function LengthSq() As Single
    Return ((p1 - p0).LengthSq())
  End Function

  Public Function Interpolate(t As Single) As Vec2
    Return (((1.0! - t) * p0 + t * p1))
  End Function

  Public Function Normal() As Vec2
    Return ((p1 - p0).Normalize().TurnLeft())
  End Function

  Public Function PointTo(p As Vec2) As LineSeg
    Dim dir = (p - p0).Normalize()

    p1 = p0 + dir * Length()

    Return (Me)
  End Function

  Public Function OrientTowards(p As Vec2) As LineSeg

    Return (Me)
  End Function

  Public p0 As Vec2, p1 As Vec2
End Class
