
Public Class Mat3
  Public Sub New()
    a = 1.0 : b = 0.0 : c = 0.0
    d = 0.0 : e = 1.0 : f = 0.0
    g = 0.0 : h = 0.0 : i = 1.0
  End Sub

  Public Function Determinant() As Single
    Dim det As Single =
      (a * e * i + b * f * g + d * h * c - g * e * c - d * b * i - h * f * a)

    Return (IIf(det = 0.0, 1.0, det))
  End Function

  Public Function Inversed() As Mat3
    Dim det As Single = Determinant()

    '' If the determinant is 0, the matrix has no inverse
    Dim rDet As Single = 1.0 / det

    '' Computes the inverse via Laplace Cofactor Expansion
    Return (New Mat3() With {
      .a = (e * i - h * f) * rDet, .b = (-b * i + h * c) * rDet, .c = (b * f - e * c) * rDet,
      .d = (-d * i + g * f) * rDet, .e = (a * i - g * c) * rDet, .f = (-a * f + d * c) * rDet,
      .g = (d * h - g * e) * rDet, .h = (-a * h + g * b) * rDet, .i = (a * e - d * b) * rDet})
  End Function

  Public Shared Function Translation(v As Vec2) As Mat3
    Return (New Mat3() With {
      .a = 1.0, .b = 0.0, .c = v.x,
      .d = 0.0, .e = 1.0, .f = v.y,
      .g = 0.0, .h = 0.0, .i = 1.0})
  End Function
  Public Shared Function Rotation(a As Single) As Mat3
    'Dim theta As Single = Rad(a)
    Dim co As Single = Math.Cos(a)
    Dim si As Single = Math.Sin(a)

    Return (New Mat3() With {
      .a = co, .b = -si, .c = 0.0,
      .d = si, .e = co, .f = 0.0,
      .g = 0.0, .h = 0.0, .i = 1.0})
  End Function

  Public Shared Function Scaling(v As Vec2) As Mat3
    Return (New Mat3() With {
      .a = v.x, .b = 0.0, .c = 0.0,
      .d = 0.0, .e = v.y, .f = 0.0,
      .g = 0.0, .h = 0.0, .i = 1.0})
  End Function

  Public Shared Operator *(A As Mat3, B As Mat3) As Mat3
    Return (New Mat3() With {
      .a = A.a * B.a + A.b * B.d + A.c * B.g, .b = A.a * B.b + A.b * B.e + A.c * B.h, .c = A.a * B.c + A.b * B.f + A.c * B.i,
      .d = A.d * B.a + A.e * B.d + A.f * B.g, .e = A.d * B.b + A.e * B.e + A.f * B.h, .f = A.d * B.c + A.e * B.f + A.f * B.i,
      .g = A.g * B.a + A.h * B.d + A.i * B.g, .h = A.g * B.b + A.h * B.e + A.i * B.h, .i = A.g * B.c + A.h * B.f + A.i * B.i})
  End Operator

  '' Multiply a matrix with a column vector, resulting in a column vector
  Public Shared Operator *(A As Mat3, v As Vec2) As Vec2
    Return (New Vec2(
      A.a * v.x + A.b * v.y + A.c * 1.0,
      A.d * v.x + A.e * v.y + A.f * 1.0))
  End Operator

  '' Multiply a vector with a row matrix, resulting in a row vector
  Public Shared Operator *(v As Vec2, A As Mat3) As Vec2
    Return (New Vec2(
      A.a * v.x + A.d * v.y + A.g * 1.0,
      A.b * v.x + A.e * v.y + A.h * 1.0))
  End Operator

  Public a As Single, b As Single, c As Single
  Public d As Single, e As Single, f As Single
  Public g As Single, h As Single, i As Single
End Class
