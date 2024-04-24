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
End Module
