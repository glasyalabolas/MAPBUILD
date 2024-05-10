Public Class VertexMode
  Inherits ModeBase

  Public Sub New()
    SetName("Vertex mode")
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    Dim newModeArgs = New ModeChangedEventArgs() With {
      .Mode = New PolyDrawMode2()}

    OnModeChanged(Me, newModeArgs)

    newModeArgs.Mode.OnMouseDoubleClick(e, modifierKeys)
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _ldragging) Then
      _closestVertexId = FindClosestVertexId(_mp)
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldelta = SnapToGrid(_mp) - _lstart

        If (_closestVertexId <> NOT_FOUND) Then

          Layer.VertexById(_closestVertexId).Pos = SnapToGrid(_lstart + _ldelta)
          SetHelpText("Drag vertex to move, delta: " & _ldelta.ToString())
        End If
      Else
        If (_closestVertexId <> NOT_FOUND) Then
          _ldragging = True
          _lstart = Layer.VertexById(_closestVertexId)
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs)
    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _closestVertexId = NOT_FOUND

        SetHelpText("")
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim inv = Camera.Transform().Inversed()
    Dim proj = Camera.Projection()

    For i As Integer = 0 To Layer.Vertices - 1
      Dim p = proj * inv * Layer.Vertex(i)

      If (InsideView(p)) Then
        If (GridSize / Camera.Zoom >= 10.0) Then
          If (_closestVertexId = Layer.Vertex(i).Id) Then
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
  Private _closestVertexId As Integer = NOT_FOUND
End Class
