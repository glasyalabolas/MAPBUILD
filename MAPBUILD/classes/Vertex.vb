Imports MAP_ID = System.Int32

Public Class Vertex
  Public Sub New()
  End Sub

  Public Sub New(p As Vec2)
    Pos = p
  End Sub

  Public Sub New(nId As MAP_ID, p As Vec2)
    Id = nId : Pos = p
  End Sub

  Public Shared Widening Operator CType(lhs As Vertex) As Vec2
    Return (lhs.Pos)
  End Operator

  Public Pos As New Vec2
  Public Id As MAP_ID
End Class
