Option Infer On

Public Class Poly
  Public ReadOnly Property Count() As Integer
    Get
      Return (_points.Count)
    End Get
  End Property

  Default Public ReadOnly Property Item(index As Integer) As Vec2
    Get
      Return (_points(Wrap(index, 0, _points.Count)))
    End Get
  End Property

  Public Sub Add(v As Vec2)
    _points.Add(v)
  End Sub

  Public Function Inside(p As Vec2) As Integer
    Dim count As Integer = 0

    If (_points.Count > 2) Then
      Dim p1 As Vec2 = _points(0), p2 As Vec2

      For i As Integer = 1 To _points.Count
        p2 = _points(i Mod _points.Count)

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

        p1 = p2
      Next
    End If

    Return (count And 1)
  End Function

  Private _points As New List(Of Vec2)
End Class
