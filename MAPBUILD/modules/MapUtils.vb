Imports System.IO

Public Module MapUtils

  Public Sub SaveMap(m As Map)
    Dim saveDialog As New SaveFileDialog() With {
      .Filter = "MAP files (*.map)|*.map"}

    If (saveDialog.ShowDialog() = DialogResult.OK) Then
      Using writer As New BinaryWriter(saveDialog.OpenFile())
        writer.Write(m.Layers)

        For lay As Integer = 0 To m.Layers - 1
          writer.Write(m.Layer(lay).Vertices)

          For vert As Integer = 0 To m.Layer(lay).Vertices - 1
            With m.Layer(lay).Vertex(vert)
              writer.Write(.Id)
              writer.Write(.Pos.x)
              writer.Write(.Pos.y)
            End With
          Next

          writer.Write(m.Layer(lay).LineDefs)

          For ld As Integer = 0 To m.Layer(lay).LineDefs - 1
            With m.Layer(lay).LineDef(ld)
              writer.Write(.Id)
              writer.Write(.P0)
              writer.Write(.P1)
            End With
          Next

          writer.Write(m.Layer(lay).Sectors)

          For sec As Integer = 0 To m.Layer(lay).Sectors - 1
            With m.Layer(lay).Sector(sec)
              writer.Write(.Id)
              writer.Write(.LineDefs)

              For sld As Integer = 0 To m.Layer(lay).Sector(sec).LineDefs - 1
                writer.Write(m.Layer(lay).Sector(sec).LineDef(sld))
              Next
            End With
          Next
        Next
      End Using
    End If
  End Sub

  Public Function LoadMap() As Map
    Dim m As Map = Nothing

    Dim openDialog As New OpenFileDialog() With {
      .Filter = "MAP files (*.map)|*.map"}
    If (openDialog.ShowDialog() = DialogResult.OK) Then
      m = New Map()

      m.DisableEvents()

      Using reader As New BinaryReader(openDialog.OpenFile())
        Dim layers As Integer = reader.ReadInt32()

        For i As Integer = 0 To layers - 1
          m.AddLayer()
        Next

        For lay As Integer = 0 To layers - 1
          m.SelectLayer(lay)

          Dim verts As Integer = reader.ReadInt32()

          For v As Integer = 0 To verts - 1
            Dim vId As Integer = reader.ReadInt32()
            Dim vX As Single = reader.ReadSingle()
            Dim vY As Single = reader.ReadSingle()

            m.SelectedLayer.AddVertex(New Vec2(vX, vY), vId)
          Next

          Dim lineDefs As Integer = reader.ReadInt32()

          For ld As Integer = 0 To lineDefs - 1
            Dim ldId As Integer = reader.ReadInt32()
            Dim ldP0 As Integer = reader.ReadInt32()
            Dim ldP1 As Integer = reader.ReadInt32()

            m.SelectedLayer.AddLineDef(New LineDef(ldP0, ldP1), ldId)
          Next

          Dim sectors As Integer = reader.ReadInt32()

          For sec As Integer = 0 To sectors - 1
            Dim sId As Integer = reader.ReadInt32()
            Dim sLdefs As Integer = reader.ReadInt32()

            m.SelectedLayer.AddSector(New Sector(), sId)

            For secLd As Integer = 0 To sLdefs - 1
              Dim ld As Integer = reader.ReadInt32()

              m.SelectedLayer.Sector(sec).AddLineDef(ld)
            Next
          Next
        Next
      End Using

      m.EnableEvents()
    End If

    Return (m)
  End Function
End Module
