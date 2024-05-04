Public Class LineDef
  Public Sub New()
    p0 = -1 : p1 = -1
  End Sub

  Public Sub New(nP0 As Integer, nP1 As Integer)
    p0 = nP0 : p1 = nP1
  End Sub

  Public Function Length() As Single
    With Map.SelectedLayer
      Return ((.Vertex(p1) - .Vertex(p0)).Length)
    End With
  End Function

  Public Function LengthSq() As Single
    With Map.SelectedLayer
      Return ((.Vertex(p1) - .Vertex(p0)).LengthSq)
    End With
  End Function

  Public Function Interpolate(t As Single) As Vec2
    With Map.SelectedLayer
      Return (((1.0! - t) * .Vertex(p0) + t * .Vertex(p1)))
    End With
  End Function

  Public Function Normal() As Vec2
    With Map.SelectedLayer
      Return ((.Vertex(p1) - .Vertex(p0)).Normalize().TurnLeft())
    End With
  End Function

  Public Function PointTo(p As Vec2) As LineDef
    With Map.SelectedLayer
      Dim dir = (p - .Vertex(p0)).Normalize()

      .Vertex(p1) = .Vertex(p0) + dir * Length()
    End With

    Return (Me)
  End Function

  Public Function Direction() As Vec2
    With Map.SelectedLayer
      Return ((.Vertex(p1) - .Vertex(p0)).Normalize)
    End With
  End Function

  Public Function LookAt(p As Vec2) As LineDef
    With Map.SelectedLayer
      Dim midPoint = .Vertex(p0).Interpolated(.Vertex(p1), 0.5!)
      Dim normal = (p - midPoint).Normalize()
      Dim dir = normal.TurnLeft()

      Dim hl As Single = Length() * 0.5!

      .Vertex(p0) = midPoint - dir * hl
      .Vertex(p1) = midPoint + dir * hl
    End With

    Return (Me)
  End Function

  Public Function GetClosestPoint(p As Vec2) As Vec2
    Dim lsq As Single = LengthSq()

    With Map.SelectedLayer
      If (lsq = 0) Then
        Return (.Vertex(p0).Clone())
      End If

      Dim u As Single = Math.Clamp(
        ((p.x - .Vertex(p0).x) * (.Vertex(p1).x - .Vertex(p0).x) +
         (p.y - .Vertex(p0).y) * (.Vertex(p1).y - .Vertex(p0).y)) / lsq,
         0.0!, 1.0!)

      Return (New Vec2(
        .Vertex(p0).x + u * (.Vertex(p1).x - .Vertex(p0).x),
        .Vertex(p0).y + u * (.Vertex(p1).y - .Vertex(p0).y)))
    End With
  End Function

  Public p0 As Integer
  Public p1 As Integer
  Public Map As Map
End Class
