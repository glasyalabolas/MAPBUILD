Public Class frmDebug
  Public Shared Sub Main(args() As String)
    Application.EnableVisualStyles()
    Application.SetHighDpiMode(HighDpiMode.SystemAware)
    Application.Run(New frmDebug)
  End Sub

  Private Sub frmDebug_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    _mode = New VertexMode(_map)

    For i As Integer = 1 To 100
      Dim p0 = New Vec2(Rng(-5000, 5000), Rng(-5000, 5000))
      Dim p1 = New Vec2(Rng(-5000, 5000), Rng(-5000, 5000))

      _map.AddVertex(p0)
      _map.AddVertex(p1)
      _map.AddLineDef(_map.VertexCount - 1, _map.VertexCount - 2)
    Next

    _map.AddVertex(New Vec2(0, 0))

    MapView1.Mode = _mode
    MapView1.Map = _map
  End Sub

  Private Sub frmDebug_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    _mode?.OnKeyPressed(e)
  End Sub

  Private Sub MapView1_MapMouseMove(sender As Object, p As Vec2) Handles MapView1.MapMouseMove
    Dim bs = New Vec2(MapView1.BlockSize, MapView1.BlockSize)

    With MapView1.Camera
      Dim tl = .TopLeft()
      Dim br = .BottomRight()

      ToolStripStatusLabel1.Text = "Mouse: " & p.ToString() &
      " TL: " & tl.ToString() & " BR: " & br.ToString() &
      " Pos: " & .Position.ToString() &
      " BlockSize: " & (.Scaling().Inversed() * bs).ToString()

      Dim startP = New Vec2(tl.x \ bs.x, tl.y \ bs.y) * bs

      Debug.Print("startP: " & startP.ToString())
    End With
  End Sub

  Private Sub LinesAndVectorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinesAndVectorsToolStripMenuItem.Click
    '_mode = New VectorDebugMode(picDisplay.Width, picDisplay.Height)
  End Sub

  Private Sub PolygonsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PolygonsToolStripMenuItem.Click
    _mode = New PolyDebugMode()
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    _mode = e.Mode
    MapView1.Mode = _mode
  End Sub

  Private WithEvents _mode As IMode
  Private _map As New Map()
End Class
