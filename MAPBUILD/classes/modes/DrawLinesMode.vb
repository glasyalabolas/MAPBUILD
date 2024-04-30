﻿Public Class DrawLinesMode
  Inherits ModeBase

  Public Sub New(m As Map, c As Camera2D)
    SetName("Line mode")
    SetHelpText("Double click to start a line")

    _map = m
    _cam = c
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs)
    If (_drawing) Then
      _ep = SnapToGrid(_cam.ViewToWorld(New Vec2(e.X, e.Y)))
    End If
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
    If (Not _drawing) Then
      _lineDefs.Clear()

      _sp = SnapToGrid(_cam.ViewToWorld(New Vec2(e.X, e.Y)))
      _startVertex = New Vec2(_sp)
      _drawing = True
    End If
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs)
    If (_drawing) Then
      If (e.Button And MouseButtons.Left) Then
        Dim ls = New LineSeg(_sp, _ep)

        '' Ignore zero length segments
        If (ls.LengthSq > 0) Then
          _map.AddVertex(_sp.Clone())
          _map.AddVertex(_ep.Clone())

          Dim ld = New LineDef(_map.Vertices - 2, _map.Vertices - 1)

          _map.AddLineDef(ld)
          _lineDefs.Add(ld)

          '' Close poly if end point = start point
          If (_ep.IsEqual(_startVertex)) Then
            _drawing = False
          Else
            '' New segment
            _ep = _sp
            _sp = SnapToGrid(_cam.ViewToWorld(New Vec2(e.X, e.Y)))
          End If
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs)
    If (e.KeyCode = Keys.Escape) Then
      If (_drawing) Then
        _drawing = False
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics, cam As Camera2D)
    If (_drawing) Then
      Dim inv = _cam.Transform.Inversed()
      Dim proj = _cam.Projection()

      Dim p0 = proj * inv * _sp
      Dim p1 = proj * inv * _ep

      g.DrawLine(VGAColors.LightBluePen, p0, p1)
    End If
  End Sub

  Private _map As Map
  Private _cam As Camera2D
  Private _lineDefs As New List(Of LineDef)
  Private _sp As Vec2, _ep As Vec2, _startVertex As Vec2
  Private _drawing As Boolean
End Class