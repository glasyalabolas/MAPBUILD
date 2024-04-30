''' <summary>
''' Base class for editing modes.
''' </summary>
Public MustInherit Class ModeBase
  Implements IMode

  <Runtime.InteropServices.DllImport("user32.dll")>
  Protected Shared Function GetAsyncKeyState(aKey As Keys) As Short
  End Function

  Public Event ModeChanged(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeChanged

  Public ReadOnly Property Name() As String Implements IMode.Name
    Get
      Return (_name)
    End Get
  End Property

  Public Property BlockSize() As Single Implements IMode.BlockSize
    Get
      Return (_blockSize)
    End Get

    Set(value As Single)
      _blockSize = value
    End Set
  End Property

  Protected Sub SetName(n As String)
    _name = n
  End Sub

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

  Private _name As String
  Private _blockSize As Single
End Class
