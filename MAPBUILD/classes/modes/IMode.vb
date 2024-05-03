Public Interface IMode
  Event ModeChanged(sender As Object, e As ModeChangedEventArgs)
  Event HelpTextChanged(sender As Object, e As EventArgs)
  Event BlockSizeChanged(sender As Object, e As EventArgs)
  Event Refresh(sender As Object, e As EventArgs)

  ReadOnly Property Name() As String
  ReadOnly Property HelpText() As String
  Property BlockSize() As Single
  Property ViewRect() As Rectangle
  Property Map() As Map
  Property Camera() As Camera2D

  Sub OnProcess()
  Sub OnRender(g As Graphics)
  Sub OnMouseMove(e As MouseEventArgs)
  Sub OnMouseClick(e As MouseEventArgs)
  Sub OnMouseDoubleClick(e As MouseEventArgs)
  Sub OnMouseUp(e As MouseEventArgs)
  Sub OnMouseDown(e As MouseEventArgs)
  Sub OnMouseWheel(e As MouseEventArgs)
  Sub OnKeyPressed(e As KeyEventArgs)
End Interface
