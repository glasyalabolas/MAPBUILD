Public Class LineDef
  Public Sub New()
    p0 = -1 : p1 = -1
  End Sub

  Public Sub New(nP0 As Integer, nP1 As Integer)
    p0 = nP0 : p1 = nP1
  End Sub

  Public Function Length() As Single
    Return ((Layer.VertexById(p1).Pos - Layer.VertexById(p0).Pos).Length)
  End Function

  Public Function LengthSq() As Single
    Return ((Layer.VertexById(p1).Pos - Layer.VertexById(p0).Pos).LengthSq)
  End Function

  Public Function Interpolate(t As Single) As Vec2
    Return (((1.0! - t) * Layer.VertexById(p0).Pos + t * Layer.VertexById(p1).Pos))
  End Function

  Public Function Normal() As Vec2
    Return ((Layer.VertexById(p1).Pos - Layer.VertexById(p0).Pos).Normalize().TurnLeft())
  End Function

  Public Function PointTo(p As Vec2) As LineDef
    Dim dir = (p - Layer.VertexById(p0).Pos).Normalize()

    Layer.VertexById(p1).Pos = New Vec2(Layer.VertexById(p0).Pos + dir * Length())

    Return (Me)
  End Function

  Public Function Direction() As Vec2
    Return ((Layer.VertexById(p1).Pos - Layer.VertexById(p0).Pos).Normalize)
  End Function

  Public Function LookAt(p As Vec2) As LineDef
    Dim midPoint = Layer.VertexById(p0).Pos.Interpolated(Layer.VertexById(p1).Pos, 0.5!)
    Dim normal = (p - midPoint).Normalize()
    Dim dir = normal.TurnLeft()

    Dim hl As Single = Length() * 0.5!

    Layer.VertexById(p0).Pos = midPoint - dir * hl
    Layer.VertexById(p1).Pos = midPoint + dir * hl

    Return (Me)
  End Function

  Public Function GetClosestPoint(p As Vec2) As Vec2
    Dim lsq As Single = LengthSq()

    If (lsq = 0) Then
      Return (Layer.VertexById(p0).Pos.Clone())
    End If

    Dim u As Single = Math.Clamp(
      ((p.x - Layer.VertexById(p0).Pos.x) * (Layer.VertexById(p1).Pos.x - Layer.VertexById(p0).Pos.x) +
        (p.y - Layer.VertexById(p0).Pos.y) * (Layer.VertexById(p1).Pos.y - Layer.VertexById(p0).Pos.y)) / lsq,
        0.0!, 1.0!)

    Return (New Vec2(
      Layer.VertexById(p0).Pos.x + u * (Layer.VertexById(p1).Pos.x - Layer.VertexById(p0).Pos.x),
      Layer.VertexById(p0).Pos.y + u * (Layer.VertexById(p1).Pos.y - Layer.VertexById(p0).Pos.y)))
  End Function

  Public p0 As Integer
  Public p1 As Integer
  Public Id As Integer
  Public Layer As Layer
End Class
