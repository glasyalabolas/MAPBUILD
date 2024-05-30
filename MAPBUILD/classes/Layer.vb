Option Infer On

Imports MAP_ID = System.Int32

Public Class Layer
  Private Const NOT_FOUND As MAP_ID = -1

  Public Sub New()
    Visible = True
  End Sub

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

  Public ReadOnly Property Things() As Integer
    Get
      Return (_thing.Count)
    End Get
  End Property

  Public ReadOnly Property Vertex(index As Integer) As Vertex
    Get
      Return (_vertex(index))
    End Get
  End Property

  Public Property VertexById(id As MAP_ID) As Vertex
    Get
      Return (FindVertexByID(id))
    End Get

    Set(value As Vertex)
      Dim v = FindVertexByID(id)

      Dim index As Integer = _vertex.IndexOf(v)

      _vertex(index) = value
      _vertex(index).Id = id

      _vertexById.Remove(v.Id)
      _vertexById.Add(id, _vertex(index))
    End Set
  End Property

  Public ReadOnly Property LineDef(index As Integer) As LineDef
    Get
      Return (_lineDef(index))
    End Get
  End Property

  Public ReadOnly Property LineDefById(id As MAP_ID) As LineDef
    Get
      Return (FindLineDefByID(id))
    End Get
  End Property

  Public ReadOnly Property Sector(index As Integer) As Sector
    Get
      Return (_sector(index))
    End Get
  End Property

  Public ReadOnly Property SectorById(id As MAP_ID) As Sector
    Get
      Return (FindSectorById(id))
    End Get
  End Property

  Public ReadOnly Property Thing(index As Integer) As Thing
    Get
      Return (_thing(index))
    End Get
  End Property

  Public ReadOnly Property ThingById(id As MAP_ID) As Thing
    Get
      Return (FindThingById(id))
    End Get
  End Property

  Public Function AddVertex(v As Vec2) As MAP_ID
    Dim newVertex As New Vertex(v)

    _vertex.Add(newVertex)

    If (_vertexIDs.Count = 0) Then
      newVertex.Id = _vertex.Count - 1
    Else
      newVertex.Id = _vertexIDs.Pop()
    End If

    _vertexById.Add(newVertex.Id, newVertex)

    Return (newVertex.Id)
  End Function

  Public Sub AddVertex(v As Vec2, id As MAP_ID)
    Dim newVertex As New Vertex(v) With {.Id = id}

    _vertex.Add(newVertex)
    _vertexById.Add(newVertex.Id, newVertex)
  End Sub

  Public Function AddLineDef(ld As LineDef) As MAP_ID
    _lineDef.Add(ld)
    ld.Layer = Me

    If (_lineDefIDs.Count = 0) Then
      ld.Id = _lineDef.Count - 1
    Else
      ld.Id = _lineDefIDs.Pop()
    End If

    _lineDefById.Add(ld.Id, ld)

    Return (ld.Id)
  End Function

  Public Sub AddLineDef(ld As LineDef, id As MAP_ID)
    ld.Id = id
    ld.Layer = Me

    _lineDef.Add(ld)
    _lineDefById.Add(ld.Id, ld)
  End Sub

  Public Function AddSector(s As Sector) As MAP_ID
    _sector.Add(s)
    s.Layer = Me

    If (_sectorIDs.Count = 0) Then
      s.Id = _sector.Count - 1
    Else
      s.Id = _sectorIDs.Pop()
    End If

    _sectorById.Add(s.Id, s)

    Return (s.Id)
  End Function

  Public Sub AddSector(s As Sector, id As MAP_ID)
    s.Id = id
    s.Layer = Me

    _sector.Add(s)
    _sectorById.Add(s.Id, s)
  End Sub

  Public Function AddThing(t As Thing) As MAP_ID
    _thing.Add(t)

    If (_thingIDs.Count = 0) Then
      t.Id = _thing.Count - 1
    Else
      t.Id = _thingIDs.Pop()
    End If

    _thingById.Add(t.Id, t)

    Return (t.Id)
  End Function

  Public Sub AddThing(t As Thing, id As MAP_ID)
    t.Id = id

    _thing.Add(t)
    _thingById.Add(t.Id, t)
  End Sub

  Public Sub DeleteVertex(id As MAP_ID)
    Dim v = _vertexById(id)

    _vertexIDs.Push(id)
    _vertex.Remove(v)
    _vertexById.Remove(id)
  End Sub

  Public Sub DeleteLineDef(id As MAP_ID)
    Dim ld = _lineDefById(id)

    Dim P0 = ld.P0
    Dim P1 = ld.P1

    _lineDefIDs.Push(id)
    _lineDef.Remove(ld)
    _lineDefById.Remove(id)

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

  Public Sub DeleteSector(id As MAP_ID)
    _sectorIDs.Push(id)
    _sector.Remove(_sectorById(id))
    _sectorById.Remove(id)
  End Sub

  Public Sub DeleteThing(id As MAP_ID)
    _thingIDs.Push(id)
    _thing.Remove(_thingById(id))
    _thingById.Remove(id)
  End Sub

  Private Function FindVertexByID(id As MAP_ID) As Vertex
    Return (IIf(_vertexById.ContainsKey(id), _vertexById(id), Nothing))
  End Function

  Private Function FindLineDefByID(id As MAP_ID) As LineDef
    Return (IIf(_lineDefById.ContainsKey(id), _lineDefById(id), Nothing))
  End Function

  Private Function FindSectorById(id As MAP_ID) As Sector
    Return (IIf(_sectorById.ContainsKey(id), _sectorById(id), Nothing))
  End Function

  Private Function FindThingById(id As MAP_ID) As Thing
    Return (IIf(_thingById.ContainsKey(id), _thingById(id), Nothing))
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
        Dim p0 = FindVertexByID(.P0)
        Dim p1 = FindVertexByID(.P1)

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
      If (_lineDef(i).P0 = id OrElse _lineDef(i).P1 = id) Then
        result += 1
      End If
    Next

    Return (result)
  End Function

  Private Function GetSectorIndex(sID As MAP_ID) As Integer
    For i As Integer = 0 To _sector.Count - 1
      If (_sector(i).Id = sID) Then
        Return (i)
      End If
    Next

    '' Should never happen
    Return (NOT_FOUND)
  End Function

  Public Function PointInSector2(p As Vec2) As MAP_ID
    Dim sectors As New List(Of MAP_ID)

    For i As Integer = 0 To _sector.Count - 1
      If (_sector(i).Inside(p)) Then
        sectors.Add(_sector(i).Id)
      End If
    Next

    Dim sID As MAP_ID = NOT_FOUND
    Dim closest As Single = Single.MaxValue

    For i As Integer = 0 To sectors.Count - 1
      Dim s = SectorById(sectors(i))

      For w As Integer = 0 To s.LineDefs - 1
        Dim dist = p.DistanceToSq(LineDefById(s.LineDef(w)).GetClosestPoint(p))

        If (dist < closest) Then
          closest = dist
          sID = s.Id
        End If
      Next
    Next

    Return (sID)
  End Function

  Public Function PointInSector(p As Vec2) As MAP_ID
    Dim sectors As New List(Of Sector)

    For i As Integer = 0 To _sector.Count - 1
      If (_sector(i).Inside(p)) Then
        sectors.Add(_sector(i))
      End If
    Next

    Dim sID As MAP_ID = NOT_FOUND
    Dim closest As Single = Single.MaxValue

    For i As Integer = 0 To sectors.Count - 1
      Dim s = sectors(i)
      Dim centroid = s.GetCentroid()
      Dim bb = s.GetBoundingBox()

      Dim dist = bb.TopLeft.DistanceToSq(bb.BottomRight) * 0.7 + p.DistanceToSq(centroid) * 0.3

      If (dist < closest) Then
        closest = dist
        sID = s.Id
      End If
    Next

    Return (sID)
  End Function

  '' Lists for easy traversal
  Private _vertex As New List(Of Vertex)
  Private _lineDef As New List(Of LineDef)
  Private _sector As New List(Of Sector)
  Private _thing As New List(Of Thing)

  '' Dictionaries for quick lookups by Id
  Private _vertexById As New Dictionary(Of MAP_ID, Vertex)
  Private _lineDefById As New Dictionary(Of MAP_ID, LineDef)
  Private _sectorById As New Dictionary(Of MAP_ID, Sector)
  Private _thingById As New Dictionary(Of MAP_ID, Thing)

  '' Stacks used to recycle Ids
  Private _vertexIDs As New Stack(Of MAP_ID)
  Private _lineDefIDs As New Stack(Of MAP_ID)
  Private _sectorIDs As New Stack(Of MAP_ID)
  Private _thingIDs As New Stack(Of MAP_ID)


End Class
