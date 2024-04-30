Public Class frmMain
  Public Shared Sub Main(args() As String)
    Application.SetHighDpiMode(HighDpiMode.SystemAware)
    'Application.EnableVisualStyles()
    Application.Run(New frmMain)
  End Sub

  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    _blockSize = 64

    _mode = New DrawLinesMode(_map, mvView.Camera, _blockSize)

    For i As Integer = 1 To 100
      Dim p0 = New Vec2(Rng(-5000, 5000), Rng(-5000, 5000))
      Dim p1 = New Vec2(Rng(-5000, 5000), Rng(-5000, 5000))

      _map.AddVertex(p0)
      _map.AddVertex(p1)
      _map.AddLineDef(New LineDef(_map.Vertices - 1, _map.Vertices - 2))
    Next

    mvView.Mode = _mode
    mvView.Map = _map
    mvView.BlockSize = _blockSize

    pnlSide.Hide()

    ssStatus.BackColor = VGAColors.Blue
    ssStatus.ForeColor = VGAColors.Cyan

    frmTools.AddHandlers(mvView)

    frmTools.Location = New Point(Location.X + Size.Width - frmTools.Width - 50, Location.Y + 100)
    frmTools.Show(Me)
  End Sub

  Private Sub frmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    _mode?.OnKeyPressed(e)
  End Sub

  Private Sub mvView_BlockSizeChanged(sender As Object, e As EventArgs) Handles mvView.BlockSizeChanged
    tsslBlockSize.Text = DirectCast(sender, MapView).BlockSize.ToString()
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    _mode = e.Mode

    mvView.Mode = _mode
    tsslMode.Text = _mode.Name
  End Sub

  Private Sub _map_SelectedLayerChanged(sender As Object, e As SelectedLayerChangedEventArgs) Handles _map.SelectedLayerChanged
    tsslLayer.Text = e.Layer.Name
  End Sub

  Private WithEvents _mode As IMode
  Private WithEvents _map As New Map()
  Private _blockSize As Integer
End Class
