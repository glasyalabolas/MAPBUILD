Public Class VertexMode
  Inherits ModeBase

  Public Sub New()
    SetName("Vertex mode")
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
    Dim newModeArgs = New ModeChangedEventArgs() With {
      .Mode = New PolyDrawMode()}

    OnModeChanged(Me, newModeArgs)

    newModeArgs.Mode.OnMouseDoubleClick(e)
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _ldragging) Then
      _closestVertexIdx = FindClosestVertexIndex(_mp)
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldelta = SnapToGrid(_mp) - _lstart

        If (_closestVertexIdx <> NOT_FOUND) Then
          Map.SelectedLayer.Vertex(_closestVertexIdx) = SnapToGrid(_lstart + _ldelta)
          SetHelpText("Drag vertex to move, delta: " & _ldelta.ToString())
        End If
      Else
        If (_closestVertexIdx <> NOT_FOUND) Then
          _ldragging = True
          _lstart = Map.SelectedLayer.Vertex(_closestVertexIdx)
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs)
    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _closestVertexIdx = NOT_FOUND
        SetHelpText("")
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim inv = Camera.Transform().Inversed()
    Dim proj = Camera.Projection()

    For i As Integer = 0 To Map.SelectedLayer.Vertices - 1
      Dim p = proj * inv * Map.SelectedLayer.Vertex(i)

      If (InsideView(p)) Then
        If (BlockSize / Camera.Zoom >= 10.0) Then
          If (_closestVertexIdx = i) Then
            RenderVertex(g, p, VGAColors.Yellow)
          Else
            RenderVertex(g, p, VGAColors.LightRed)
          End If
        End If
      End If
    Next
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean
  Private _closestVertexIdx As Integer = NOT_FOUND
End Class
