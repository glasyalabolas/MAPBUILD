Public Interface IMode
  Event ModeChanged(sender As Object, e As ModeChangedEventArgs)
  ReadOnly Property Name() As String
  Property BlockSize() As Single
  Sub OnProcess()
  Sub OnRender(g As Graphics, cam As Camera2D)
  Sub OnMouseMove(e As MouseEventArgs)
  Sub OnMouseClick(e As MouseEventArgs)
  Sub OnMouseDoubleClick(e As MouseEventArgs)
  Sub OnMouseWheel(e As MouseEventArgs)
  Sub OnKeyPressed(e As KeyEventArgs)
End Interface
