Public Class DEPPolyDrawMode
  Inherits ModeBase

  Public Sub New()
    SetName("Poly draw mode")
    SetHelpText("Double click to start a line")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    If (_drawing) Then
      _ep = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))
    End If
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    If (Not _drawing) Then
      _sp = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))

      Dim cv As Integer = FindClosestVertexId(_sp)

      If (cv <> NOT_FOUND) Then
        Debug.Print("Vertex already present")
      End If

      _startVertexId = Layer.AddVertex(_sp)
      _lineDefs.Clear()

      _drawing = True
    End If
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
    If (_drawing) Then
      If (e.Button And MouseButtons.Left) Then
        '' Ignore zero length segments
        If ((_ep - _sp).LengthSq > 0) Then
          '' Close poly if end point = start point
          If (IsClosestVertex(
            _ep, Layer.VertexById(_startVertexId).Pos)) Then

            Dim ld = New LineDef(_lastVertexId, _startVertexId)

            '' Close poly
            _lineDefs.Add(Layer.AddLineDef(ld))

            _drawing = False
            _lastVertexId = NOT_FOUND
            _startVertexId = NOT_FOUND

            Dim s = New Sector()
            Layer.AddSector(s)

            For i As Integer = 0 To _lineDefs.Count - 1
              s.AddLineDef(_lineDefs(i))
            Next

            OnModeChanged(Me, New ModeChangedEventArgs() With {
              .Mode = New VertexMode()})
          Else
            '' New segment
            Dim prevVertexID As Integer = IIf(
              _lastVertexId = NOT_FOUND, _startVertexId, _lastVertexId)

            _lastVertexId = Layer.AddVertex(_ep.Clone())

            Dim ld = New LineDef(prevVertexID, _lastVertexId)

            _lineDefs.Add(Layer.AddLineDef(ld))

            _ep = _sp
            _sp = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))
          End If
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (e.KeyCode = Keys.Escape) Then
      If (_drawing) Then
        _drawing = False
        _startVertexId = NOT_FOUND
        _lastVertexId = NOT_FOUND

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

  Private _sp As Vec2, _ep As Vec2
  Private _startVertexId As Integer = NOT_FOUND
  Private _lastVertexId As Integer = NOT_FOUND
  Private _drawing As Boolean
  Private _lineDefs As New List(Of Integer)
End Class
