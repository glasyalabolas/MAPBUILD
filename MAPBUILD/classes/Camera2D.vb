Public Class Camera2D
  Public Sub New()
  End Sub

  Public Sub New(c As Vec2)
    Center = c
  End Sub

  Public Sub New(c As Vec2, vp As Vec2)
    Center = c : Viewport = vp
  End Sub

  Public ReadOnly Property TopLeft() As Vec2
    Get
      Return (New Vec2(Center.x - Viewport.x * 0.5, Center.y - Viewport.y * 0.5))
    End Get
  End Property

  Public ReadOnly Property BottomRight() As Vec2
    Get
      Return (New Vec2(Center.x + Viewport.x * 0.5, Center.y + Viewport.y * 0.5))
    End Get
  End Property

  Public Center As New Vec2()
  Public Viewport As New Vec2()
End Class
