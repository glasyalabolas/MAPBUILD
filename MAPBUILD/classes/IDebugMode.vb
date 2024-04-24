Public Interface IDebugMode
  Sub OnProcess()
  Sub OnRender(g As Graphics)
  Sub OnMouseMove(e As MouseEventArgs)
  Sub OnKeyPressed(e As KeyEventArgs)
End Interface
