Option Infer On

'' Defines a line in parametric form (point + direction)
Public Class ParamLine
  Public Sub New()
    p0 = New Vec2(0, 0) : dir = New Vec2(0, 0)
  End Sub

  Public Sub New(np0 As Vec2)
    p0 = np0 : dir = New Vec2(0, 0)
  End Sub

  Public Sub New(nP0 As Vec2, nDir As Vec2)
    p0 = nP0 : dir = nDir.Normalized()
  End Sub

  Public Function GetPoint(dist As Single) As Vec2
    Return (p0 + dir * dist)
  End Function

  Public Function Normal() As Vec2
    Return (dir.TurnedLeft())
  End Function

  Public Function PointTo(p As Vec2) As ParamLine
    dir = (p - p0).Normalize()
    Return (Me)
  End Function

  Public Function Interpolate(t As Single, l As Single) As Vec2
    Return (((1.0! - t) * p0 + t * (p0 + dir * l)))
  End Function

  ''' <summary>
  ''' Defines the starting point of the line.
  ''' </summary>
  Public p0 As Vec2
  ''' <summary>
  ''' Defines the direction of the line. Note that this vector should be
  ''' normalized.
  ''' </summary>
  Public dir As Vec2
End Class
