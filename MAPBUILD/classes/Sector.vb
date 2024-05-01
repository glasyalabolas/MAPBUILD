Public Class Sector
  Public ReadOnly Property LineDefs() As Integer
    Get
      Return (_lineDefs.Count)
    End Get
  End Property

  Public ReadOnly Property LineDef(index As Integer) As LineDef
    Get
      Return (_lineDefs(index))
    End Get
  End Property

  Public Sub AddLineDef(ld As LineDef)
    _lineDefs.Add(ld)
  End Sub

  Private _lineDefs As New List(Of LineDef)
End Class
