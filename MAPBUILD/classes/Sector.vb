Option Infer On

Public Class Sector
  Public ReadOnly Property LineDefs() As Integer
    Get
      Return (_lineDefs.Count)
    End Get
  End Property

  Public ReadOnly Property LineDef(index As Integer) As Integer
    Get
      Return (_lineDefs(index))
    End Get
  End Property

  Public Sub AddLineDef(id As Integer)
    _lineDefs.Add(id)
  End Sub

  Public Function Inside(p As Vec2) As Boolean
    Dim count As Integer = 0

    If (_lineDefs.Count > 2) Then
      For i As Integer = 0 To _lineDefs.Count - 1
        Dim ld = Layer.LineDefById(_lineDefs(i))
        Dim p1 = Layer.VertexById(ld.P0).Pos
        Dim p2 = Layer.VertexById(ld.P1).Pos

        If (p.y > Math.Min(p1.y, p2.y)) Then
          If (p.y <= Math.Max(p1.y, p2.y)) Then
            If (p.x <= Math.Max(p1.x, p2.x)) Then
              If (p1.y <> p2.y) Then
                Dim xinters As Single = (p.y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) + p1.x

                If (p1.x = p2.x OrElse p.x <= xinters) Then count += 1
              End If
            End If
          End If
        End If
      Next
    End If

    Return (count And 1)
  End Function

  Public Id As Integer
  Public Layer As Layer

  Private _lineDefs As New List(Of Integer)
End Class
