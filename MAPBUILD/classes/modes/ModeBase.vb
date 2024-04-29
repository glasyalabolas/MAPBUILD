''' <summary>
''' Base class for editing modes.
''' </summary>
Public MustInherit Class ModeBase
  Implements IMode

  <Runtime.InteropServices.DllImport("user32.dll")>
  Protected Shared Function GetAsyncKeyState(aKey As Keys) As Short
  End Function

  Public Event ModeChanged(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeChanged

  Public Overridable Sub OnProcess() Implements IMode.OnProcess
  End Sub
  Public Overridable Sub OnRender(g As Graphics, cam As Camera2D) Implements IMode.OnRender
  End Sub
  Public Overridable Sub OnMouseMove(e As MouseEventArgs) Implements IMode.OnMouseMove
  End Sub
  Public Overridable Sub OnMouseClick(e As MouseEventArgs) Implements IMode.OnMouseClick
  End Sub
  Public Overridable Sub OnMouseDoubleClick(e As MouseEventArgs) Implements IMode.OnMouseDoubleClick
  End Sub
  Public Overridable Sub OnKeyPress(e As KeyEventArgs) Implements IMode.OnKeyPressed
  End Sub
  Public Overridable Sub OnMouseWheel(e As MouseEventArgs) Implements IMode.OnMouseWheel
  End Sub

  Protected Sub OnModeChanged(sender As Object, e As ModeChangedEventArgs)
    RaiseEvent ModeChanged(sender, e)
  End Sub
End Class
