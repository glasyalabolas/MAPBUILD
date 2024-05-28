Option Infer On

Imports MAP_ID = System.Int32

Public Class Thing
  Public Sub New()
  End Sub

  Public Sub New(p As Vec2)
    Pos = p
  End Sub

  Public Sub New(nID As MAP_ID, p As Vec2)
    Id = nID
    Pos = p
  End Sub

  Public Pos As Vec2
  Public Size As Single
  Public Id As MAP_ID
End Class
