''' <summary>
''' Base class for editing modes.
''' </summary>
Public MustInherit Class ModeBase
  Implements IMode

  <Runtime.InteropServices.DllImport("user32.dll")>
  Protected Shared Function GetAsyncKeyState(aKey As Keys) As Short
  End Function

  Public Event ModeChanged(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeChanged
  Public Event HelpTextChanged(sender As Object, e As EventArgs) Implements IMode.HelpTextChanged
  Public Event BlockSizeChanged(sender As Object, e As EventArgs) Implements IMode.BlockSizeChanged
  Public Event Refresh(sender As Object, e As EventArgs) Implements IMode.Refresh

  Public ReadOnly Property Name() As String Implements IMode.Name
    Get
      Return (_name)
    End Get
  End Property

  Public ReadOnly Property HelpText() As String Implements IMode.HelpText
    Get
      Return (_helpText)
    End Get
  End Property

  Public Property BlockSize() As Single Implements IMode.BlockSize
    Get
      Return (_blockSize)
    End Get

    Set(value As Single)
      _blockSize = value

      OnBlockSizeChanged()
    End Set
  End Property

  Protected Sub SetName(value As String)
    _name = value
  End Sub

  Protected Sub SetHelpText(value As String)
    _helpText = value

    OnHelpTextChanged()
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

  Protected Sub OnRefresh()
    RaiseEvent Refresh(Me, EventArgs.Empty)
  End Sub

  Private Sub OnHelpTextChanged()
    RaiseEvent HelpTextChanged(Me, EventArgs.Empty)
  End Sub

  Private Sub OnBlockSizeChanged()
    RaiseEvent BlockSizeChanged(Me, EventArgs.Empty)
  End Sub

  Protected Function SnapToGrid(v As Vec2) As Vec2
    Dim hbsx As Single = IIf(v.x >= 0, BlockSize * 0.5, -BlockSize * 0.5)
    Dim hbsy As Single = IIf(v.y >= 0, BlockSize * 0.5, -BlockSize * 0.5)

    Return (New Vec2((v.x + hbsx) \ BlockSize, (v.y + hbsy) \ BlockSize) * BlockSize)
  End Function

  Private _name As String
  Private _helpText As String
  Private _blockSize As Single
End Class
