Public Interface IMode
  Event ModeChanged(sender As Object, e As ModeChangedEventArgs)
  Event HelpTextChanged(sender As Object, e As EventArgs)
  Event BlockSizeChanged(sender As Object, e As EventArgs)
  Event Refresh(sender As Object, e As EventArgs)

  ReadOnly Property Name() As String
  ReadOnly Property HelpText() As String
  Property BlockSize() As Single
  Sub OnProcess()
  Sub OnRender(g As Graphics, cam As Camera2D)
  Sub OnMouseMove(e As MouseEventArgs)
  Sub OnMouseClick(e As MouseEventArgs)
  Sub OnMouseDoubleClick(e As MouseEventArgs)
  Sub OnMouseWheel(e As MouseEventArgs)
  Sub OnKeyPressed(e As KeyEventArgs)
End Interface
