Public Class Layer
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

  Public Property Vertex(index As Integer) As Vec2
    Get
      Return (_vertex(index))
    End Get

    Set(value As Vec2)
      _vertex(index) = value
    End Set
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

  Public Function AddVertex(v As Vec2) As Integer
    _vertex.Add(v)

    Return (_vertex.Count - 1)
  End Function

  Public Function AddLineDef(ld As LineDef) As Integer
    _lineDef.Add(ld)

    Return (_lineDef.Count - 1)
  End Function

  Public Function AddSector(s As Sector) As Integer
    _sector.Add(s)

    Return (_sector.Count - 1)
  End Function

  Public Function IndexOf(v As Vec2) As Integer
    Return (_vertex.IndexOf(v))
  End Function

  Public Function IndexOf(ld As LineDef) As Integer
    Return (_lineDef.IndexOf(ld))
  End Function

  Public Function IndexOf(s As Sector) As Integer
    Return (_sector.IndexOf(s))
  End Function

  Public Function GetVisibleLines(cam As Camera2D) As List(Of LineDef)
    Dim l = New List(Of LineDef)

    Dim tl = cam.TopLeft()
    Dim br = cam.BottomRight()

    For i As Integer = 0 To _lineDef.Count - 1
      With _lineDef(i)
        Dim p0 = _vertex(.p0)
        Dim p1 = _vertex(.p1)

        If (Maths.LiangBarsky(
          tl.x, tl.y, br.x, br.y, p0.x, p0.y, p1.x, p1.y)) Then

          l.Add(_lineDef(i))
        End If
      End With
    Next

    Return (l)
  End Function

  Private _vertex As New List(Of Vec2)
  Private _lineDef As New List(Of LineDef)
  Private _sector As New List(Of Sector)
End Class
