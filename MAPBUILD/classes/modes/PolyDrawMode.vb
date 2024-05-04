Public Class PolyDrawMode
  Inherits ModeBase

  Public Sub New()
    SetName("Poly draw mode")
    SetHelpText("Double click to start a line")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs)
    If (_drawing) Then
      _ep = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))
    End If
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
    If (Not _drawing) Then
      _lineDefs.Clear()

      _sp = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))

      _startVertexIndex = Map.SelectedLayer.AddVertex(_sp)

      _drawing = True
    End If
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs)
    If (_drawing) Then
      If (e.Button And MouseButtons.Left) Then
        Dim ls = New LineSeg(_sp, _ep)

        '' Ignore zero length segments
        If (ls.LengthSq > 0) Then
          '' Close poly if end point = start point
          If (IsClosestVertex(
            _ep, Map.SelectedLayer.Vertex(_startVertexIndex))) Then

            Dim s = New Sector()

            For i As Integer = 0 To _lineDefs.Count - 1
              s.AddLineDef(_lineDefs(i))
            Next

            Dim ld = New LineDef(
              _startVertexIndex, Map.SelectedLayer.Vertices - 1) With {
                .Map = Map}

            '' Close poly
            Map.SelectedLayer.AddLineDef(ld)

            s.AddLineDef(ld)

            Map.SelectedLayer.AddSector(s)

            _drawing = False

            OnModeChanged(Me, New ModeChangedEventArgs() With {
              .Mode = New VertexMode()})
          Else
            '' New segment
            Map.SelectedLayer.AddVertex(_ep.Clone())

            Dim ld = New LineDef(
              Map.SelectedLayer.Vertices - 2,
              Map.SelectedLayer.Vertices - 1) With {
                .Map = Map}

            Map.SelectedLayer.AddLineDef(ld)

            _lineDefs.Add(ld)

            _ep = _sp
            _sp = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))
          End If
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs)
    If (e.KeyCode = Keys.Escape) Then
      If (_drawing) Then
        _drawing = False

        OnRefresh()
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    If (_drawing) Then
      Dim inv = Camera.Transform.Inversed()
      Dim proj = Camera.Projection()

      Dim p0 = proj * inv * _sp
      Dim p1 = proj * inv * _ep

      g.DrawLine(VGAColors.LightBluePen, p0, p1)
    End If
  End Sub

  Private _lineDefs As New List(Of LineDef)
  Private _sp As Vec2, _ep As Vec2
  Private _startVertexIndex As Integer
  Private _drawing As Boolean
End Class
