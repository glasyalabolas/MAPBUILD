Public Class Map
  Public ReadOnly Property VertexCount() As Integer
    Get
      Return (_vertex.Count)
    End Get
  End Property

  Public ReadOnly Property Vertex(index As Integer) As Vec2
    Get
      Return (_vertex(index))
    End Get
  End Property

  Public Sub AddVertex(v As Vec2)
    _vertex.Add(v)
  End Sub

  Private _vertex As New List(Of Vec2)
End Class
