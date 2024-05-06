Public Class Layer
  Private Const NOT_FOUND As Integer = -1

  Public Name As String

  Public Property Visible() As Boolean

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

  Public ReadOnly Property Vertex(index As Integer) As Vertex
    Get
      Return (_vertex(index))
    End Get
  End Property

  Public Property VertexById(id As Integer) As Vertex
    Get
      Return (_vertex(FindVertexByID(id)))
    End Get

    Set(value As Vertex)
      Dim index = FindVertexByID(id)

      _vertex(index) = value
      _vertex(index).Id = id
    End Set
  End Property

  Public ReadOnly Property LineDef(index As Integer) As LineDef
    Get
      Return (_lineDef(index))
    End Get
  End Property

  Public ReadOnly Property LineDefById(id As Integer) As LineDef
    Get
      Return (_lineDef(FindLineDefByID(id)))
    End Get
  End Property

  Public ReadOnly Property Sector(index As Integer) As Sector
    Get
      Return (_sector(index))
    End Get
  End Property

  Public Function AddVertex(v As Vec2) As Integer
    Dim newVertex As New Vertex(v)

    _vertex.Add(newVertex)

    If (_vertexIDs.Count = 0) Then
      newVertex.Id = _vertex.Count - 1
    Else
      newVertex.Id = _vertexIDs.Pop()
    End If

    Return (newVertex.Id)
  End Function

  Public Function AddLineDef(ld As LineDef) As Integer
    _lineDef.Add(ld)
    ld.Layer = Me

    If (_lineDefIDs.Count = 0) Then
      ld.Id = _lineDef.Count - 1
    Else
      ld.Id = _lineDefIDs.Pop()
    End If

    Return (ld.Id)
  End Function

  Public Function AddSector(s As Sector) As Integer
    _sector.Add(s)

    Return (_sector.Count - 1)
  End Function

  Public Sub DeleteVertex(id As Integer)
    Dim index As Integer = FindVertexByID(id)

    _vertexIDs.Push(id)
    _vertex.RemoveAt(Index)
  End Sub

  Public Sub DeleteLineDef(id As Integer)
    Dim index As Integer = FindLineDefByID(id)

    Dim P0 = _lineDef(index).p0
    Dim P1 = _lineDef(index).p1

    _lineDefIDs.Push(id)
    _lineDef.RemoveAt(index)

    Dim refsP0 = CountVertexReferences(P0)
    Dim refsP1 = CountVertexReferences(P1)

    '' Remove 'dangling' vertices if there's any
    If (refsP0 = 0) Then
      DeleteVertex(P0)
    End If

    If (refsP1 = 0) Then
      DeleteVertex(P1)
    End If
  End Sub

  ''' <summary>
  ''' Returns the vertex index, given its id.
  ''' </summary>
  ''' <param name="id">The id of the vertex to find.</param>
  ''' <returns></returns>
  Private Function FindVertexByID(id As Integer) As Integer
    For i As Integer = 0 To _vertex.Count - 1
      If (_vertex(i).Id = id) Then
        Return (i)
      End If
    Next

    Return (NOT_FOUND)
  End Function

  ''' <summary>
  ''' Returns the linedef index, given its id.
  ''' </summary>
  ''' <param name="id">The id of the linedef to find.</param>
  ''' <returns></returns>
  Private Function FindLineDefByID(id As Integer) As Integer
    For i As Integer = 0 To _lineDef.Count - 1
      If (_lineDef(i).Id = id) Then
        Return (i)
      End If
    Next

    Return (NOT_FOUND)
  End Function

  ''' <summary>
  ''' Returns a list of the visible lines for this layer, as viewed through the specified camera.
  ''' </summary>
  ''' <param name="cam">The camera to use as clipping region.</param>
  ''' <returns></returns>
  Public Function GetVisibleLines(cam As Camera2D) As List(Of Integer)
    Dim l = New List(Of Integer)

    Dim tl = cam.TopLeft()
    Dim br = cam.BottomRight()

    For i As Integer = 0 To _lineDef.Count - 1
      With _lineDef(i)
        Dim p0 = _vertex(FindVertexByID(.p0))
        Dim p1 = _vertex(FindVertexByID(.p1))

        If (Maths.LiangBarsky(
          tl.x, tl.y, br.x, br.y, p0.Pos.x, p0.Pos.y, p1.Pos.x, p1.Pos.y)) Then

          l.Add(i)
        End If
      End With
    Next

    Return (l)
  End Function

  Public Function CountVertexReferences(id As Integer) As Integer
    Dim result As Integer

    For i As Integer = 0 To _lineDef.Count - 1
      If (_lineDef(i).p0 = id OrElse _lineDef(i).p1 = id) Then
        result += 1
      End If
    Next

    Return (result)
  End Function

  Private _vertex As New List(Of Vertex)
  Private _lineDef As New List(Of LineDef)
  Private _sector As New List(Of Sector)

  Private _vertexIDs As New Stack(Of Integer)
  Private _lineDefIDs As New Stack(Of Integer)
End Class
