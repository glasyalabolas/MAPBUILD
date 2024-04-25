Option Infer On
Imports System.Numerics

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

  Public Function Direction() As Vec2
    Return ((p1 - p0).Normalize)
  End Function

  Public Function LookAt(p As Vec2) As LineSeg
    Dim midPoint = p0.Interpolated(p1, 0.5!)
    Dim normal = (p - midPoint).Normalize()
    Dim dir = normal.TurnLeft()

    Dim hl As Single = Length() * 0.5!

    p0 = midPoint - dir * hl
    p1 = midPoint + dir * hl

    Return (Me)
  End Function

  Public Function GetClosestPoint(p As Vec2) As Vec2
    Dim lsq As Single = LengthSq()

    If (lsq = 0) Then
      Return (p0.Clone())
    End If

    Dim u As Single = Math.Clamp(
      ((p.x - p0.x) * (p1.x - p0.x) + (p.y - p0.y) * (p1.y - p0.y)) / lsq, 0.0!, 1.0!)

    Return (New Vec2(
      p0.x + u * (p1.x - p0.x),
      p0.y + u * (p1.y - p0.y)))
  End Function

  Public Function Intersect(ls As LineSeg, ByRef outP As Vec2) As Boolean
    Dim den As Single =
      (ls.p1.y - ls.p0.y) * (p1.x - p0.x) - (ls.p1.x - ls.p0.x) * (p1.y - p0.y)

    If (den = 0) Then Return (False)

    Dim ua As Single =
      ((ls.p1.x - ls.p0.x) * (p0.y - ls.p0.y) - (ls.p1.y - ls.p0.y) * (p0.x - ls.p0.x)) / den
    Dim ub As Single =
      ((p1.x - p0.x) * (p0.y - ls.p0.y) - (p1.y - p0.y) * (p0.x - ls.p0.x)) / den

    If (ua >= 0 AndAlso ua <= 1 AndAlso ub >= 0 AndAlso ub <= 1) Then
      outP = New Vec2(p0.x + ua * (p1.x - p0.x), p0.y + ua * (p1.y - p0.y))
      Return (True)
    End If

    Return (False)
  End Function

  Public p0 As Vec2, p1 As Vec2
End Class
