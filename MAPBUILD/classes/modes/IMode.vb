﻿Public Interface IMode
  Event ModeChanged(sender As Object, e As ModeChangedEventArgs)
  Event ModeStarted(sender As Object, e As ModeChangedEventArgs)
  Event ModeFinished(sender As Object, e As ModeChangedEventArgs)
  Event ModeEvent(sender As Object, eventInfo As Object, eventType As ModeEventType)
  Event HelpTextChanged(sender As Object, e As EventArgs)
  Event GridSizeChanged(sender As Object, e As EventArgs)
  Event Refresh(sender As Object, e As EventArgs)

  ReadOnly Property Name() As String
  ReadOnly Property HelpText() As String
  Property GridSize() As Single
  Property ViewRect() As Rectangle
  Property Map() As Map
  Property Layer() As Layer
  Property Camera() As Camera2D

  Sub OnClearSelection()
  Sub OnRender(g As Graphics)
  Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
  Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
  Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
  Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys)
  Sub OnMouseDown(e As MouseEventArgs)
  Sub OnMouseWheel(e As MouseEventArgs, modifierKeys As Keys)
  Sub OnKeyPressed(e As KeyEventArgs, modifierKeys As Keys)
End Interface
