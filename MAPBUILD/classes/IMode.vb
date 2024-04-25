Public Interface IMode
  Sub OnProcess()
  Sub OnRender(g As Graphics)
  Sub OnMouseMove(e As MouseEventArgs)
  Sub OnMouseClick(e As MouseEventArgs)
  Sub OnKeyPressed(e As KeyEventArgs)
End Interface
