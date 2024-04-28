Public Class Map
  Public ReadOnly Property VertexCount() As Integer
    Get
      Return (_vertex.Count)
    End Get
  End Property

  Public ReadOnly Property LineCount() As Integer
    Get
      Return (_lines.Count)
    End Get
  End Property

  Public ReadOnly Property Vertex(index As Integer) As Vec2
    Get
      Return (_vertex(index))
    End Get
  End Property

  Public ReadOnly Property Line(index As Integer) As LineDef
    Get
      Return (_lines(index))
    End Get
  End Property

  Public Sub AddVertex(v As Vec2)
    _vertex.Add(v)
  End Sub

  Public Sub AddLineDef(p0 As Integer, p1 As Integer)
    _lines.Add(New LineDef(p0, p1))
  End Sub

  Private _vertex As New List(Of Vec2)
  Private _lines As New List(Of LineDef)
End Class
