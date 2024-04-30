Option Infer On

Public Class Vec2
  Public Sub New()
    x = 0.0! : y = 0.0!
  End Sub

  Public Sub New(nX As Single, nY As Single)
    x = nX : y = nY
  End Sub

  Public Sub New(nv As Vec2)
    x = nv.x : y = nv.y
  End Sub

  Public Shared Function Zero() As Vec2
    Return (New Vec2(0.0!, 0.0!))
  End Function

  Public Function Clone() As Vec2
    Return (New Vec2(x, y))
  End Function

  Public Function IsEqual(v As Vec2) As Boolean
    Return (x = v.x AndAlso y = v.y)
  End Function

  ''' <summary>
  ''' Returns the length of the vector.
  ''' </summary>
  ''' <returns></returns>
  Public Function Length() As Single
    Return (Math.Sqrt(x ^ 2 + y ^ 2))
  End Function

  ''' <summary>
  ''' <para>Returns the squared length of the vector.</para>
  ''' <para>Useful for distance comparisons, as it avoids a square root.</para>
  ''' </summary>
  ''' <returns></returns>
  Public Function LengthSq() As Single
    Return (x ^ 2 + y ^ 2)
  End Function

  ''' <summary>
  ''' Normalizes the vector.
  ''' </summary>
  ''' <returns></returns>
  Public Function Normalize() As Vec2
    Dim dst As Single = x * x + y * y

    If (dst > 0) Then
      Dim l As Single = 1.0! / Math.Sqrt(dst)

      x *= l : y *= l
    End If

    Return (Me)
  End Function

  ''' <summary>
  ''' Returns a normalized vector of same length as this instance.
  ''' </summary>
  ''' <returns></returns>
  Public Function Normalized() As Vec2
    Dim dst As Single = x * x + y * y

    If (dst > 0) Then
      Dim l As Single = 1.0! / Length()

      Return (New Vec2(x * l, y * l))
    End If

    Return (New Vec2(0, 0))
  End Function

  ''' <summary>
  ''' Returns the dot product of this vector with another one.
  ''' </summary>
  ''' <param name="v"></param>
  ''' <returns></returns>
  Public Function Dot(v As Vec2) As Single
    Return (x * v.x + y * v.y)
  End Function

  ''' <summary>
  ''' Returns the cross product of this vector with another one.
  ''' </summary>
  ''' <param name="v"></param>
  ''' <returns></returns>
  Public Function Cross(v As Vec2) As Single
    Return (x * v.y - y * v.x)
  End Function

  Public Function TurnLeft() As Vec2
    Dim tx As Single = x
    x = y : y = -tx
    Return (Me)
  End Function

  Public Function TurnedLeft() As Vec2
    Return (New Vec2(y, -x))
  End Function

  Public Function TurnRight() As Vec2
    Dim tx As Single = x
    x = -y : y = tx
    Return (Me)
  End Function

  Public Function TurnedRight() As Vec2
    Return (New Vec2(-y, x))
  End Function

  Public Function Angle() As Single
    Return (Math.Atan2(y, x))
  End Function

  Public Function Rotate(a As Single) As Vec2
    Dim si As Single = Math.Sin(a), co As Single = Math.Cos(a)
    Dim px As Single = x, py As Single = y

    x = px * co - py * si : y = px * si + py * co

    Return (Me)
  End Function

  Public Function Rotated(a As Single) As Vec2
    Dim si As Single = Math.Sin(a), co = Math.Cos(a)

    Return (New Vec2(x * co - y * si, x * si + y * co))
  End Function

  Public Function LookAt(v As Vec2) As Vec2
    Dim nv = (v - Me).Normalize() * Length()
    x = nv.x : y = nv.y
    Return (Me)
  End Function

  Public Function LookingAt(v As Vec2) As Vec2
    Return ((v - Me).Normalize() * Length())
  End Function
  Public Function Sign() As Vec2
    Return (New Vec2(Math.Sign(x), Math.Sign(y)))
  End Function

  Public Function SetLength(l As Single) As Vec2
    Dim nv = New Vec2(x, y).Normalize() * l
    x = nv.x : y = nv.y
    Return (Me)
  End Function

  Public Function OfLength(l As Single) As Vec2
    Return (New Vec2(x, y).Normalize() * l)
  End Function

  Public Function Rotate(a As Single, pivot As Vec2) As Vec2
    Dim rv = (Me - pivot).Rotate(a) + pivot

    x = rv.x : y = rv.y

    Return (Me)
  End Function

  Public Function Rotated(a As Single, pivot As Vec2) As Vec2
    Dim rv = (Me - pivot).Rotate(a) + pivot

    Return (New Vec2(rv.x, rv.y))
  End Function

  Public Function Interpolated(v As Vec2, t As Single) As Vec2
    Return (Me * (1.0F - t) + v * t)
  End Function

  Public Function DistanceTo(v As Vec2) As Single
    Return ((Me - v).Length())
  End Function

  Public Function DistanceToSq(v As Vec2) As Single
    Return ((Me - v).LengthSq())
  End Function

  Public Overrides Function ToString() As String
    Return (Number(x) & "," & Number(y))
  End Function

  Public Shared Operator +(lhs As Vec2, rhs As Vec2) As Vec2
    Return (New Vec2(lhs.x + rhs.x, lhs.y + rhs.y))
  End Operator

  Public Shared Operator -(lhs As Vec2, rhs As Vec2) As Vec2
    Return (New Vec2(lhs.x - rhs.x, lhs.y - rhs.y))
  End Operator

  Public Shared Operator *(lhs As Vec2, rhs As Vec2) As Vec2
    Return (New Vec2(lhs.x * rhs.x, lhs.y * rhs.y))
  End Operator

  Public Shared Operator *(lhs As Vec2, rhs As Single) As Vec2
    Return (New Vec2(lhs.x * rhs, lhs.y * rhs))
  End Operator

  Public Shared Operator *(lhs As Single, rhs As Vec2) As Vec2
    Return (New Vec2(rhs.x * lhs, rhs.y * lhs))
  End Operator

  Public Shared Operator /(lhs As Vec2, rhs As Vec2) As Vec2
    Return (New Vec2(lhs.x / rhs.x, lhs.y / rhs.y))
  End Operator

  Public Shared Operator /(lhs As Vec2, rhs As Single) As Vec2
    Return (New Vec2(lhs.x / rhs, lhs.y / rhs))
  End Operator

  Public Shared Operator -(rhs As Vec2) As Vec2
    Return (New Vec2(-rhs.x, -rhs.y))
  End Operator

  Public Shared Widening Operator CType(lhs As Vec2) As Point
    Return (New Point(Int(lhs.x), Int(lhs.y)))
  End Operator

  Public Shared Widening Operator CType(lhs As Vec2) As PointF
    Return (New PointF(lhs.x, lhs.y))
  End Operator

  Public Shared Widening Operator CType(lhs As Vec2) As String
    Return (Number(lhs.x) & "," & Number(lhs.y))
  End Operator

  Public x As Single, y As Single
End Class
