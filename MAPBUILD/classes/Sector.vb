Option Infer On

Imports MAP_ID = System.Int32

Public Class Sector
  Private Const NOT_FOUND As Integer = -1

  Public ReadOnly Property Vertices() As Integer
    Get
      Return (_vertices.Count)
    End Get
  End Property

  Public ReadOnly Property LineDefs() As Integer
    Get
      Return (_lineDefs.Count)
    End Get
  End Property

  Public ReadOnly Property Vertex(index As Integer) As MAP_ID
    Get
      Return (_vertices(index))
    End Get
  End Property

  Public ReadOnly Property LineDef(index As Integer) As MAP_ID
    Get
      Return (_lineDefs(index))
    End Get
  End Property

  Public ReadOnly Property GetLineDef(index As Integer) As LineDef
    Get
      Return (Layer.LineDefById(_lineDefs(index)))
    End Get
  End Property

  Public Sub AddLineDef(id As MAP_ID)
    _lineDefs.Add(id)

    Dim ld = Layer.LineDefById(id)

    If (Not _vertices.Contains(ld.P0)) Then
      _vertices.Add(ld.P0)
    End If

    If (Not _vertices.Contains(ld.P1)) Then
      _vertices.Add(ld.P1)
    End If

    AddHandler ld.LineDefSplit, AddressOf OnLineDefSplit
    AddHandler ld.LineDefDeleted, AddressOf OnLineDefDeleted
  End Sub

  Public Sub RemoveLineDef(id As MAP_ID)
    For i As Integer = 0 To LineDefs - 1
      If (_lineDefs(i) = id) Then
        _lineDefs.RemoveAt(i)

        Dim ld = Layer.LineDefById(id)

        RemoveHandler ld.LineDefSplit, AddressOf OnLineDefSplit
        RemoveHandler ld.LineDefDeleted, AddressOf OnLineDefDeleted

        Exit For
      End If
    Next
  End Sub

  Public Function Inside(p As Vec2) As Boolean
    Dim count As Integer = 0

    If (LineDefs > 2) Then
      For i As Integer = 0 To LineDefs - 1
        Dim ld = Layer.LineDefById(_lineDefs(i))
        Dim p1 = ld.GetP0.Pos
        Dim p2 = ld.GetP1.Pos

        If (p.y > Math.Min(p1.y, p2.y)) Then
          If (p.y <= Math.Max(p1.y, p2.y)) Then
            If (p.x <= Math.Max(p1.x, p2.x)) Then
              If (p1.y <> p2.y) Then
                Dim xinters As Single = (p.y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) + p1.x

                If (p1.x = p2.x OrElse p.x <= xinters) Then count += 1
              End If
            End If
          End If
        End If
      Next
    End If

    Return (count And 1)
  End Function

  Public Function FindLineDefByVertex(vId As MAP_ID) As Integer
    For i As Integer = 0 To LineDefs - 1
      Dim ld = Layer.LineDefById(_lineDefs(i))

      If (ld.P0 = vId OrElse ld.P1 = vId) Then
        Return (i)
      End If
    Next

    Return (NOT_FOUND)
  End Function

  Private Sub OnLineDefSplit(sender As LineDef, newId As MAP_ID)
    For i As Integer = 0 To LineDefs - 1
      If (sender.Id = _lineDefs(i)) Then
        _lineDefs.Insert(i + 1, newId)

        Dim newLd = Layer.LineDefById(newId)
        _vertices.Add(newLd.P0)
        Exit For
      End If
    Next
  End Sub

  Private Sub OnLineDefDeleted(sender As LineDef)
    For i As Integer = 0 To _lineDefs.Count - 1
      If (sender.Id = _lineDefs(i)) Then
        RemoveLineDef(sender.Id)
        Exit For
      End If
    Next

    If (LineDefs = 0) Then
      Layer.DeleteSector(Id)
    End If
  End Sub

  Public Function IsClosed() As Boolean
    Return (Vertices - LineDefs = 0)
  End Function

  Public Function GetCentroid() As Vec2
    Dim centroid As New Vec2()

    For i As Integer = 0 To Vertices - 1
      Dim v = Layer.VertexById(_vertices(i))

      centroid += v.Pos
    Next

    Return (centroid / _vertices.Count)
  End Function

  Public Function GetBoundingBox() As Rect
    Dim maxX As Single = Single.MinValue
    Dim maxY As Single = Single.MinValue
    Dim minX As Single = Single.MaxValue
    Dim minY As Single = Single.MaxValue

    For i As Integer = 0 To Vertices - 1
      Dim v = Layer.VertexById(_vertices(i)).Pos

      minX = Math.Min(minX, v.x)
      minY = Math.Min(minY, v.y)
      maxX = Math.Max(maxX, v.x)
      maxY = Math.Max(maxY, v.y)
    Next

    Return (New Rect(New Vec2(minX, minY), New Vec2(maxX, maxY)))
  End Function

  Public Sub Rotate(a As Single)
    Dim c = GetCentroid()

    Dim T = Mat3.Translation(New Vec2(c.x, c.y)) *
      Mat3.Rotation(a) * Mat3.Translation(New Vec2(-c.x, -c.y))

    For i As Integer = 0 To Vertices - 1
      Dim v = Layer.VertexById(_vertices(i))

      v.Pos = T * New Vec2(v.Pos.x, v.Pos.y)
    Next
  End Sub

  Public Function WallsPointingInwards() As Boolean
    Dim result As Boolean = True

    For i As Integer = 0 To LineDefs - 1
      Dim ld = Layer.LineDefById(_lineDefs(i))

      If (Not ld.FacesInside(Me)) Then
        Return (False)
      End If
    Next

    Return (result)
  End Function

  Public Sub InvertWalls()
    For i As Integer = 0 To LineDefs - 1
      Dim ld = Layer.LineDefById(_lineDefs(i))

      Dim tmp = ld.P0
      ld.P0 = ld.P1
      ld.P1 = tmp
    Next
  End Sub

  Public Id As MAP_ID
  Public Layer As Layer
  Public TopHeight As Single
  Public BottomHeight As Single

  Private _vertices As New List(Of MAP_ID)
  Private _lineDefs As New List(Of MAP_ID)
End Class
