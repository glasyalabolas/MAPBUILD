Option Infer On

Public Class LineDef
  Public Enum InsideSectorResult
    Outside
    PartiallyInside
    Inside
  End Enum

  Public Sub New()
    P0 = -1 : P1 = -1
  End Sub

  Public Sub New(nP0 As Integer, nP1 As Integer)
    P0 = nP0 : P1 = nP1
  End Sub

  Public Sub New(nId As Integer, nP0 As Integer, nP1 As Integer)
    Id = nId : P0 = nP0 : P1 = nP1
  End Sub

  Public Function Length() As Single
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).Length)
  End Function

  Public Function LengthSq() As Single
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).LengthSq)
  End Function

  Public Function Interpolate(t As Single) As Vec2
    Return (((1.0! - t) * Layer.VertexById(P0).Pos + t * Layer.VertexById(P1).Pos))
  End Function

  Public Function Normal() As Vec2
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).Normalize().TurnLeft())
  End Function

  Public Function PointTo(p As Vec2) As LineDef
    Dim dir = (p - Layer.VertexById(P0).Pos).Normalize()

    Layer.VertexById(P1).Pos = New Vec2(Layer.VertexById(P0).Pos + dir * Length())

    Return (Me)
  End Function

  Public Function Direction() As Vec2
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).Normalize)
  End Function

  Public Function LookAt(p As Vec2) As LineDef
    Dim midPoint = Layer.VertexById(P0).Pos.Interpolated(Layer.VertexById(P1).Pos, 0.5!)
    Dim normal = (p - midPoint).Normalize()
    Dim dir = normal.TurnLeft()

    Dim hl As Single = Length() * 0.5!

    Layer.VertexById(P0).Pos = midPoint - dir * hl
    Layer.VertexById(P1).Pos = midPoint + dir * hl

    Return (Me)
  End Function

  Public Function GetClosestPoint(p As Vec2) As Vec2
    Dim lsq As Single = LengthSq()

    If (lsq = 0) Then
      Return (Layer.VertexById(P0).Pos.Clone())
    End If

    Dim u As Single = Math.Clamp(
      ((p.x - Layer.VertexById(P0).Pos.x) * (Layer.VertexById(P1).Pos.x - Layer.VertexById(P0).Pos.x) +
        (p.y - Layer.VertexById(P0).Pos.y) * (Layer.VertexById(P1).Pos.y - Layer.VertexById(P0).Pos.y)) / lsq,
        0.0!, 1.0!)

    Return (New Vec2(
      Layer.VertexById(P0).Pos.x + u * (Layer.VertexById(P1).Pos.x - Layer.VertexById(P0).Pos.x),
      Layer.VertexById(P0).Pos.y + u * (Layer.VertexById(P1).Pos.y - Layer.VertexById(P0).Pos.y)))
  End Function

  Public Function Intersects(ld As LineDef, ByRef outP As Vec2,
    Optional ByRef ua As Single = 0.0, Optional ByRef ub As Single = 0.0) As Boolean

    Dim lP0 = Layer.VertexById(P0).Pos
    Dim lP1 = Layer.VertexById(P1).Pos

    Dim oP0 = Layer.VertexById(ld.P0).Pos
    Dim oP1 = Layer.VertexById(ld.P1).Pos

    Dim den As Single =
      (oP1.y - oP0.y) * (lP1.x - lP0.x) - (oP1.x - oP0.x) * (lP1.y - lP0.y)

    If (den = 0) Then Return (False)

    ua = ((oP1.x - oP0.x) * (lP0.y - oP0.y) - (oP1.y - oP0.y) * (lP0.x - oP0.x)) / den
    ub = ((lP1.x - lP0.x) * (lP0.y - oP0.y) - (lP1.y - lP0.y) * (lP0.x - oP0.x)) / den

    If (ua >= 0 AndAlso ua <= 1 AndAlso ub >= 0 AndAlso ub <= 1) Then
      outP = New Vec2(lP0.x + ua * (lP1.x - lP0.x), lP0.y + ua * (lP1.y - lP0.y))
      Return (True)
    End If

    Return (False)
  End Function

  Public Function Inside(s As Sector) As InsideSectorResult
    Dim v1 = Layer.VertexById(P0)
    Dim v2 = Layer.VertexById(P1)

    Dim r1 As Boolean = s.Inside(v1)
    Dim r2 As Boolean = s.Inside(v2)

    Return (IIf(r1 AndAlso r2, InsideSectorResult.Inside, IIf(
      r1 OrElse r2, InsideSectorResult.PartiallyInside, InsideSectorResult.Outside)))
  End Function

  Public P0 As Integer
  Public P1 As Integer
  Public Id As Integer
  Public Layer As Layer
End Class
