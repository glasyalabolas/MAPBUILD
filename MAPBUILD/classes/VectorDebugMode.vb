Public Class VectorDebugMode
  Inherits ModeBase

  Public Sub New(displayW As Long, displayH As Long)
    _w = displayW : _h = displayH
    _center = New Vec2(_w / 2, _h / 2)
  End Sub

  Public Overrides Sub OnProcess()
    If (GetAsyncKeyState(Keys.Up)) Then
      Debug.Print("Up pressed")
    End If

    _angle = Wrap(_angle + 0.1!, 0.0!, 359.0!)
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
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
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs)
    Dim mP = New Vec2(e.X, e.Y)

    _lineSeg = New LineSeg(_center, mP)
    _paramLine = New ParamLine(_center).PointTo(mP)
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs)
    Debug.Print("Key pressed: " & e.KeyValue)
  End Sub

  Private _w As Long, _h As Long
  Private _center As New Vec2()
  Private _lineSeg As New LineSeg()
  Private _paramLine As New ParamLine(New Vec2(0, 0), New Vec2(1, 0))
  Private _angle As Single = 0.0
End Class
