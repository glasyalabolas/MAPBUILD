Public Class Layer
  Public Name As String

  Public ReadOnly Property Vertices() As Integer
    Get
      Return (_vertex.Count)
    End Get
  End Property

  Public ReadOnly Property LineDefs() As Integer
    Get
      Return (_lineDef.Count)
    End Get
  End Property

  Public ReadOnly Property Sectors() As Integer
    Get
      Return (_sector.Count)
    End Get
  End Property

  Public ReadOnly Property Vertex(index As Integer) As Vec2
    Get
      Return (_vertex(index))
    End Get
  End Property

  Public ReadOnly Property LineDef(index As Integer) As LineDef
    Get
      Return (_lineDef(index))
    End Get
  End Property

  Public ReadOnly Property Sector(index As Integer) As Sector
    Get
      Return (_sector(index))
    End Get
  End Property

  Public Sub AddVertex(v As Vec2)
    _vertex.Add(v)
  End Sub

  Public Sub AddLineDef(ld As LineDef)
    _lineDef.Add(ld)
  End Sub

  Public Sub AddSector(s As Sector)
    _sector.Add(s)
  End Sub

  Public Function FindClosestVertex(p As Vec2) As Integer
    Dim result As Integer = -1 '' Not found
    Dim closest = Integer.MaxValue

    For i As Integer = 0 To _vertex.Count - 1
      Dim dist = p.DistanceToSq(_vertex(i))

      If (dist < closest) Then
        result = i
        closest = dist
      End If
    Next

    Return (result)
  End Function

  Private _vertex As New List(Of Vec2)
  Private _lineDef As New List(Of LineDef)
  Private _sector As New List(Of Sector)
End Class
