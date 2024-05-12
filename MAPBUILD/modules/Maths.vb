Public Module Maths
  Private Const RAD_TO_DEG As Single = 180.0! / Math.PI
  Private Const DEG_TO_RAD As Single = Math.PI / 180.0!

  ''' <summary>
  ''' Converts an angle expressed in degrees to radians.
  ''' </summary>
  ''' <param name="a">The angle expressed in degrees.</param>
  ''' <returns></returns>
  Public Function Rad(a As Single) As Single
    Return (a * DEG_TO_RAD)
  End Function

  ''' <summary>
  ''' Converts an angle expressed in radians to degrees.
  ''' </summary>
  ''' <param name="a">The angle expressed in radians.</param>
  ''' <returns></returns>
  Public Function Deg(a As Single) As Single
    Return (a * RAD_TO_DEG)
  End Function

  Public Function Normalized(v As Vec2) As Vec2
    Return (v.Normalized())
  End Function

  Public Function Wrap(x As Single, x_min As Single, x_max As Single) As Single
    Return (Math.IEEERemainder(Math.IEEERemainder((x - x_min), (x_max - x_min)) + (x_max - x_min), (x_max - x_min)) + x_min)
  End Function

  Public Function Wrap(x As Long, x_min As Long, x_max As Long) As Long
    Return (((((x - x_min) Mod (x_max - x_min)) + (x_max - x_min)) Mod (x_max - x_min)) + x_min)
  End Function

  Public Function Wrap(v As Vec2, x1 As Single, y1 As Single, x2 As Single, y2 As Single) As Vec2
    Return (New Vec2(Wrap(v.x, x1, x2), Wrap(v.y, y1, y2)))
  End Function

  Public Function Remap(
    x As Single, start1 As Single, end1 As Single, start2 As Single, end2 As Single) As Single

    Return ((x - start1) * (end2 - start2) / (end1 - start1) + start2)
  End Function
  Public Function Rng(aMin As Integer, aMax As Integer) As Integer
    Return (Int(Rnd() * ((aMax + 1) - aMin) + aMin))
  End Function

  Public Function Rng(aMin As Double, aMax As Double) As Double
    Return (Rnd() * (aMax - aMin) + aMin)
  End Function

  Public Function LiangBarsky(
    xmin As Single, ymin As Single, xmax As Single, ymax As Single,
    x0 As Single, y0 As Single, x1 As Single, y1 As Single,
    Optional ByRef t0 As Single = 0, Optional ByRef t1 As Single = 1) As Boolean

    t0 = 0 : t1 = 1

    Dim dx As Single = x1 - x0, dy As Single = y1 - y0
    Dim p As Single, q As Single, r As Single

    For edge As Integer = 0 To 3
      If (edge = 0) Then p = -dx : q = -(xmin - x0)
      If (edge = 1) Then p = dx : q = (xmax - x0)
      If (edge = 2) Then p = -dy : q = -(ymin - y0)
      If (edge = 3) Then p = dy : q = (ymax - y0)

      r = q / p

      If (p = 0 AndAlso q < 0) Then
        Return (False)
      End If

      If (p < 0) Then
        If (r > t1) Then
          Return (False)
        Else
          If (r > t0) Then t0 = r
        End If
      ElseIf (p > 0) Then
        If (r < t0) Then
          Return (False)
        Else
          If (r < t1) Then t1 = r
        End If
      End If
    Next

    Return (True)
  End Function

  Public Function CoincidentLines(lP0 As Vec2, lP1 As Vec2, oP0 As Vec2, oP1 As Vec2) As Boolean
    Dim den As Single =
      (oP1.y - oP0.y) * (lP1.x - lP0.x) - (oP1.x - oP0.x) * (lP1.y - lP0.y)

    Dim ua As Single = ((oP1.x - oP0.x) * (lP0.y - oP0.y) - (oP1.y - oP0.y) * (lP0.x - oP0.x)) ' / den
    Dim ub As Single = ((lP1.x - lP0.x) * (lP0.y - oP0.y) - (lP1.y - lP0.y) * (lP0.x - oP0.x)) ' / den

    Return (den = 0.0 AndAlso (ua = 0.0 AndAlso ub = 0.0))
  End Function
End Module
