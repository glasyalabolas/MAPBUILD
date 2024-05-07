Option Infer On

Imports System.IO

Public Class frmMain
  Public Shared Sub Main(args() As String)
    Application.SetHighDpiMode(HighDpiMode.SystemAware)
    'Application.EnableVisualStyles()
    Application.Run(New frmMain)
  End Sub

  Public Property BlockSize() As Single
    Get
      Return (_blockSize)
    End Get

    Set(value As Single)
      _blockSize = Fix(value)

      If (_mode IsNot Nothing) Then
        _mode.BlockSize = _blockSize
      End If

      lblBlockSize.Text = _blockSize.ToString()
    End Set
  End Property

  Public Property Mode() As IMode
    Get
      Return (_mode)
    End Get

    Set(value As IMode)
      _mode = value
      _mode.BlockSize = BlockSize
      _mode.Layer = Map.SelectedLayer

      mvView.Mode = _mode
      '      mvView.Map = _map
    End Set
  End Property

  Public Property Map() As Map
    Get
      Return (_map)
    End Get

    Set(value As Map)
      _map = value
      _map.SelectLayer(0)

      mvView.Mode = _mode
      mvView.Map = _map
    End Set
  End Property

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    BlockSize = 64

    Map = New Map()
    '_map.SelectLayer(0)

    Mode = New VertexMode() With {
      .BlockSize = BlockSize,
      .Layer = Map.SelectedLayer}

    'mvView.Mode = _mode
    'mvView.Map = _map

    pnlSide.Hide()

    pnlStatus.BackColor = VGAColors.Blue
    pnlStatus.ForeColor = VGAColors.Cyan

    frmTools.Location = New Point(Location.X + Size.Width - frmTools.Width - 50, Location.Y + 100)
    frmTools.Show(Me)
  End Sub

  Private Sub frmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    _mode?.OnKeyPressed(e)

    If (e.KeyData = Keys.A) Then
      BlockSize = Math.Min(512, Int(BlockSize * 2))
    End If

    If (e.KeyData = Keys.Z) Then
      BlockSize = Math.Max(2, Int(BlockSize / 2))
    End If
  End Sub

  Private Sub mvView_ModeChanged(sender As Object, e As EventArgs) Handles mvView.ModeChanged
    lblMode.Text = _mode?.Name
    lblHelp.Text = _mode?.HelpText
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    _mode = e.Mode
    mvView.Mode = _mode
  End Sub

  Private Sub _mode_HelpTextChanged(sender As Object, e As EventArgs) Handles _mode.HelpTextChanged
    lblHelp.Text = _mode.HelpText
  End Sub

  Private Sub _map_SelectedLayerChanged(sender As Object, e As SelectedLayerChangedEventArgs) Handles _map.SelectedLayerChanged
    lblLayer.Text = e.Layer.Name
  End Sub

  Private Sub _mode_BlockSizeChanged(sender As Object, e As EventArgs) Handles _mode.BlockSizeChanged
    mvView.Refresh()
  End Sub

  Public Sub ExecuteCommand(c As ICommand)
    c.Execute()

    _undoStack.Push(c)
  End Sub

  Public Sub Undo()
    Dim c = _undoStack.Pop()

    c.Undo()
  End Sub

  Private WithEvents _mode As IMode
  Private WithEvents _map As New Map()
  Private _blockSize As Single
  Private _undoStack As New Stack(Of ICommand)

  Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
    SaveMap(_map)
  End Sub

  Private Sub SaveMap(m As Map)
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

  Private Function LoadMap() As Map
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

  Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
    Dim m = LoadMap()

    If (m IsNot Nothing) Then
      Map = m
    End If
  End Sub
End Class
