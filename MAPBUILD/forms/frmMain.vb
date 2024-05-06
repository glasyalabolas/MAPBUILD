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
      _mode.BlockSize = _blockSize
      _mode.Layer = _map.SelectedLayer

      mvView.Mode = _mode
      mvView.Map = _map
    End Set
  End Property

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    BlockSize = 64

    _map.SelectLayer(0)

    _mode = New VertexMode() With {
      .BlockSize = _blockSize,
      .Layer = _map.SelectedLayer}

    mvView.Mode = _mode
    mvView.Map = _map

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
End Class
