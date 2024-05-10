Option Infer On

Public Class Sector
  Private Const NOT_FOUND As Integer = -1

  Public ReadOnly Property LineDefs() As Integer
    Get
      Return (_lineDefs.Count)
    End Get
  End Property

  Public ReadOnly Property LineDef(index As Integer) As Integer
    Get
      Return (_lineDefs(index))
    End Get
  End Property

  Public Sub AddLineDef(id As Integer)
    _lineDefs.Add(id)

    Dim ld = Layer.LineDefById(id)

    AddHandler ld.LineDefSplit, AddressOf OnLineDefSplit
    AddHandler ld.LineDefDeleted, AddressOf OnLineDefDeleted
  End Sub

  Public Sub RemoveLineDef(id As Integer)
    For i As Integer = 0 To _lineDefs.Count - 1
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

    If (_lineDefs.Count > 2) Then
      For i As Integer = 0 To _lineDefs.Count - 1
        Dim ld = Layer.LineDefById(_lineDefs(i))
        Dim p1 = Layer.VertexById(ld.P0).Pos
        Dim p2 = Layer.VertexById(ld.P1).Pos

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

  Public Function FindLineDefByVertex(vId As Integer) As Integer
    For i As Integer = 0 To _lineDefs.Count - 1
      Dim ld = Layer.LineDefById(_lineDefs(i))

      If (ld.P0 = vId OrElse ld.P1 = vId) Then
        Return (i)
      End If
    Next

    Return (NOT_FOUND)
  End Function

  Private Sub OnLineDefSplit(sender As LineDef, newId As Integer)
    For i As Integer = 0 To _lineDefs.Count - 1
      If (sender.Id = _lineDefs(i)) Then
        _lineDefs.Insert(i + 1, newId)
        Exit For
      End If
    Next
  End Sub

  Private Sub OnLineDefDeleted(sender As LineDef)
    For i As Integer = 0 To _lineDefs.Count - 1
      If (sender.Id = _lineDefs(i)) Then
        _lineDefs.RemoveAt(i)
        Exit For
      End If
    Next

    If (_lineDefs.Count = 0) Then
      Layer.DeleteSector(Id)
    End If
  End Sub

  Public Id As Integer
  Public Layer As Layer

  Private _lineDefs As New List(Of Integer)
End Class
