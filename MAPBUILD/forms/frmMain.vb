Option Infer On

Public Class frmMain
  Public Shared Sub Main(args() As String)
    Application.SetHighDpiMode(HighDpiMode.SystemAware)
    'Application.EnableVisualStyles()
    Application.Run(New frmMain)
  End Sub

  Public Property GridSize() As Single
    Get
      Return (_gridSize)
    End Get

    Set(value As Single)
      _gridSize = Fix(value)

      If (_mode IsNot Nothing) Then
        _mode.GridSize = _gridSize
      End If

      lblGridSize.Text = _gridSize.ToString()
    End Set
  End Property

  Public Property Mode() As IMode
    Get
      Return (_mode)
    End Get

    Set(value As IMode)
      _mode = value
      _mode.GridSize = GridSize
      _mode.Layer = Map.SelectedLayer

      mvView.Mode = _mode
      mdiTools.Mode = Mode
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
    GridSize = 64

    Map = New Map()

    Mode = New VertexMode() With {
      .GridSize = GridSize,
      .Layer = Map.SelectedLayer}

    pnlStatus.BackColor = VGAColors.Blue
    pnlStatus.ForeColor = VGAColors.Cyan

    'frmTools.Location = New Point(Location.X + Size.Width - frmTools.Width - 50, Location.Y + 100)
    'frmTools.Show(Me)

    'mdiTools.Location = New Point(Location.X + Size.Width - mdiTools.Width - 50, Location.Y + 100)
    'mdiTools.MapView = mvView
    'mdiTools.Show(Me)

    'ClipperTest.Show()
    frmPanel.BackColor = VGAColors.Blue
    frmPanel.ForeColor = VGAColors.Cyan
    frmPanel.Location = New Point(0, 0)
    frmPanel.ShowInTaskbar = False
    frmPanel.TopLevel = False

    Panel1.Controls.Add(frmPanel)
    frmPanel.Visible = True
  End Sub

  Private Sub frmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    Mode?.OnKeyPressed(e, Control.ModifierKeys)

    If (e.KeyData = Keys.A) Then
      GridSize = Math.Min(512, Int(GridSize * 2))
    End If

    If (e.KeyData = Keys.Z) Then
      GridSize = Math.Max(2, Int(GridSize / 2))
    End If
  End Sub

  Private Sub mvView_ModeChanged(sender As Object, e As EventArgs) Handles mvView.ModeChanged
    lblMode.Text = Mode?.Name
    lblHelp.Text = Mode?.HelpText
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    Mode = e.Mode
    mvView.Mode = Mode
    mdiTools.Mode = Mode
  End Sub

  Private Sub _mode_HelpTextChanged(sender As Object, e As EventArgs) Handles _mode.HelpTextChanged
    lblHelp.Text = Mode.HelpText
  End Sub

  Private Sub _map_SelectedLayerChanged(sender As Object, e As SelectedLayerChangedEventArgs) Handles _map.SelectedLayerChanged
    lblLayer.Text = e.Layer.Name
  End Sub

  Private Sub _mode_BlockSizeChanged(sender As Object, e As EventArgs) Handles _mode.GridSizeChanged
    mvView.Refresh()
  End Sub

  Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
    SaveMap(Map)
  End Sub

  Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
    Dim m = LoadMap()

    If (m IsNot Nothing) Then
      Map = m

      Mode = New VertexMode() With {
        .GridSize = GridSize,
        .Layer = Map.SelectedLayer}
    Else
      Debug.Print("Error loading map")
    End If
  End Sub

  Public Sub ExecuteCommand(c As ICommand)
    c.Execute()

    _undoStack.Push(c)
  End Sub

  Public Sub Undo()
    Dim c = _undoStack.Pop()

    c.Undo()
  End Sub

  Private Sub _mode_ModeStarted(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeStarted
    _modeStack.Push(Mode)
  End Sub

  Private Sub _mode_ModeFinished(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeFinished
    Mode = _modeStack.Pop()
    mvView.Mode = Mode
    mdiTools.Mode = Mode
  End Sub

  Private Sub VertexModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VertexModeToolStripMenuItem.Click
    Mode = New VertexMode()
  End Sub

  Private Sub LinedefModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinedefModeToolStripMenuItem.Click
    Mode = New LineMode()
  End Sub

  Private Sub SectorModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SectorModeToolStripMenuItem.Click
    Mode = New SectorMode()
  End Sub

  Private WithEvents _mode As IMode
  Private WithEvents _map As Map
  Private _gridSize As Single
  Private _undoStack As New Stack(Of ICommand)
  Private _modeStack As New Stack(Of IMode)
End Class
