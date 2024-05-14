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

  Public TopLeft As Vec2
  Public BottomRight As Vec2
End Class
