Public Class LineMode
  Inherits ModeBase

  Public Sub New()
    SetName("Line mode")
  End Sub

  'Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
  '  Dim newModeArgs = New ModeChangedEventArgs() With {
  '    .Mode = New PolyDrawMode()}

  '  OnModeChanged(Me, newModeArgs)

  '  newModeArgs.Mode.OnMouseDoubleClick(e)
  'End Sub
  Public Overrides Sub OnMouseClick(e As MouseEventArgs)
    If (e.Button And MouseButtons.Left) Then
      If (GetAsyncKeyState(Keys.ControlKey)) Then
        Debug.Print("Split vertex")
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _ldragging) Then
      _closestLineDefIdx = FindClosestLineDefIndex(_mp)

      If (_closestLineDefIdx <> NOT_FOUND) Then
        _closestPoint = Map.SelectedLayer.LineDef(_closestLineDefIdx).GetClosestPoint(_mp)
      End If
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldelta = SnapToGrid(_mp) - _lstart

        If (_closestPoint IsNot Nothing) Then
          With Map.SelectedLayer
            Dim p0 = .Vertex(.LineDef(_closestLineDefIdx).p0)
            Dim p1 = .Vertex(.LineDef(_closestLineDefIdx).p1)

            .Vertex(.LineDef(_closestLineDefIdx).p0) = SnapToGrid(_lp0start + _ldelta)
            .Vertex(.LineDef(_closestLineDefIdx).p1) = SnapToGrid(_lp1start + _ldelta)
          End With
        End If
      Else
        If (_closestLineDefIdx <> NOT_FOUND) Then
          _ldragging = True
          _lstart = SnapToGrid(_closestPoint)
          _lp0start = Map.SelectedLayer.Vertex(Map.SelectedLayer.LineDef(_closestLineDefIdx).p0)
          _lp1start = Map.SelectedLayer.Vertex(Map.SelectedLayer.LineDef(_closestLineDefIdx).p1)
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs)
    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _closestLineDefIdx = NOT_FOUND
        SetHelpText("")
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim inv = Camera.Transform().Inversed()
    Dim proj = Camera.Projection()

    If (_closestLineDefIdx <> NOT_FOUND) Then
      With Map.SelectedLayer
        Dim p0 = proj * inv * .Vertex(.LineDef(_closestLineDefIdx).p0)
        Dim p1 = proj * inv * .Vertex(.LineDef(_closestLineDefIdx).p1)

        RenderLineDef(g, p0, p1, Color.Yellow)
      End With

      If (_closestPoint IsNot Nothing AndAlso Not _ldragging) Then
        Dim p = proj * inv * _closestPoint

        RenderVertex(g, p, VGAColors.LightRed)
      End If
    End If
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _lp0start As Vec2
  Private _lp1start As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean

  Private _closestLineDefIdx As Integer = NOT_FOUND
  Private _closestPoint As Vec2
End Class
