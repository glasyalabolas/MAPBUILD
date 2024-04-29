Public Class VectorDebugMode
  Inherits ModeBase

  Public Sub New(displayW As Long, displayH As Long)
    _w = displayW : _h = displayH
    _center = New Vec2(_w / 2, _h / 2)
  End Sub

  Public Overrides Sub OnProcess()
    If (GetAsyncKeyState(Keys.Up)) Then
      _ymin -= 1
    End If
    If (GetAsyncKeyState(Keys.Down)) Then
      _ymin += 1
    End If
    If (GetAsyncKeyState(Keys.Left)) Then
      _xmin -= 1
    End If
    If (GetAsyncKeyState(Keys.Right)) Then
      _xmin += 1
    End If

    _xmax = _xmin + 300
    _ymax = _ymin + 200

    _angle = Wrap(_angle + 0.1!, 0.0!, 359.0!)
  End Sub

  Public Overrides Sub OnRender(g As Graphics, cam As Camera2D)
    RenderLineSeg(g, _lineSeg, Color.Red)
    RenderParamLine(g, _paramLine, Color.Yellow)
    RenderPoint(g, _center, 5, Color.Red)
    RenderPoint(g, _lineSeg.Interpolate(0.5), 4, Color.Blue)
    RenderPoint(g, _paramLine.GetPoint(20), 4, Color.Blue)
    RenderParamLine(g, New ParamLine(
      _paramLine.Interpolate(0.5, 150),
      _paramLine.dir.TurnedLeft()),
      Color.Magenta)

    Dim rl = New ParamLine(_center, New Vec2(0, -1))
    rl.dir.Rotate(Rad(_angle))

    RenderParamLine(g, rl, Color.Green)

    Dim ls = New LineSeg(New Vec2(100, 100), New Vec2(200, 50))
    ls.LookAt(_mp)

    RenderLineSeg(g, ls, Color.Yellow)

    Dim closestPointLine = New LineSeg(
      New Vec2(400, 100), New Vec2(500, 150))

    RenderLineSeg(g, closestPointLine, Color.Green)

    Dim cp = closestPointLine.GetClosestPoint(_mp)

    RenderPoint(g, cp, 3, Color.AliceBlue)

    Dim intersectLine = New LineSeg(New Vec2(100, 200), New Vec2(300, 250))

    RenderLineSeg(g, intersectLine, Color.LightBlue)

    Dim result As New Vec2()

    If (intersectLine.Intersect(_lineSeg, result)) Then
      RenderPoint(g, result, 3, Color.AliceBlue)
    End If

    Dim rc As Color = Color.Blue

    With intersectLine
      If (Maths.LiangBarsky(
        _xmin, _ymin, _xmax, _ymax,
        .p0.x, .p0.y, .p1.x, .p1.y)) Then

        rc = Color.Yellow
      End If
    End With

    g.DrawRectangle(New Pen(rc), _xmin, _ymin, 300, 200)
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs)
    _mp = New Vec2(e.X, e.Y)

    _lineSeg = New LineSeg(_center, _mp)
    _paramLine = New ParamLine(_center).PointTo(_mp)
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs)
    If (e.KeyCode = Keys.Space) Then
      OnModeChanged(Me, New ModeChangedEventArgs() With {
        .Mode = New PolyDebugMode()})
    End If
  End Sub

  Private _w As Long, _h As Long
  Private _center As New Vec2()
  Private _lineSeg As New LineSeg()
  Private _paramLine As New ParamLine(New Vec2(0, 0), New Vec2(1, 0))
  Private _angle As Single = 0.0
  Private _mp As New Vec2()
  Private _xmin As Single = 100, _ymin As Single = 100
  Private _xmax As Single = _xmin + 300, _ymax As Single = _ymin + 200
End Class
