Public Class Rect
  Public Sub New()

  End Sub

  Public Sub New(tl As Vec2, br As Vec2)
    TopLeft = tl
    BottomRight = br

    If (TopLeft.x > BottomRight.x) Then
      Dim tmp As Single = BottomRight.x

      BottomRight.x = TopLeft.x
      TopLeft.x = tmp
    End If

    If (TopLeft.y > BottomRight.y) Then
      Dim tmp As Single = BottomRight.y

      BottomRight.y = TopLeft.y
      TopLeft.y = tmp
    End If
  End Sub

  Public Function Clone() As Rect
    Return (New Rect(TopLeft.Clone(), BottomRight.Clone()))
  End Function

  Public Function Inside(p As Vec2) As Boolean
    Return (p.x >= TopLeft.x AndAlso p.x <= BottomRight.x AndAlso
      p.y >= TopLeft.y AndAlso p.y <= BottomRight.y)
  End Function

  Public TopLeft As Vec2
  Public BottomRight As Vec2
End Class
