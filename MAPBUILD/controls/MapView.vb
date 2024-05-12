Imports System.ComponentModel

Public Class MapView
  <Runtime.InteropServices.DllImport("user32.dll")>
  Protected Shared Function GetAsyncKeyState(aKey As Keys) As Short
  End Function

  Public Event MapMouseMove(sender As Object, p As Vec2)
  Public Event BlockSizeChanged(sender As Object, e As EventArgs)
  Public Event ModeChanged(sender As Object, e As EventArgs)

  Public Sub New()
    'Esta llamada es exigida por el diseñador.
    InitializeComponent()

    'Agregue cualquier inicialización después de la llamada a InitializeComponent().
    SetStyle(ControlStyles.UserPaint, True)
    SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
  End Sub

  <Browsable(False)>
  Public Property Map() As Map
    Get
      Return (_map)
    End Get

    Set(value As Map)
      _map = value

      Refresh()
    End Set
  End Property

  <Browsable(False)>
  Public Property Mode() As IMode
    Get
      Return (_mode)
    End Get

    Set(value As IMode)
      _mode = value

      If (_mode IsNot Nothing) Then
        _mode.ViewRect = New Rectangle(0, 0, Width, Height)
        _mode.Map = Map
        _mode.Camera = _cam
      End If

      Refresh()

      RaiseEvent ModeChanged(Me, EventArgs.Empty)
    End Set
  End Property

  Public ReadOnly Property Camera() As Camera2D
    Get
      Return (_cam)
    End Get
  End Property

  Private Sub MapView_Load(sender As Object, e As EventArgs) Handles Me.Load
    BackColor = VGAColors.Black
  End Sub

  Protected Overrides Sub OnPaint(e As PaintEventArgs)
    If (Not DesignMode) Then
      If (_mode IsNot Nothing) Then
        _mode.OnRender(e.Graphics)
      End If
    End If
  End Sub

  Protected Overrides Sub OnSizeChanged(e As EventArgs)
    MyBase.OnSizeChanged(e)

    _cam.ViewPort = New Vec2(Width, Height)

    If (_mode IsNot Nothing) Then
      _mode.ViewRect = New Rectangle(0, 0, Width, Height)
    End If

    Refresh()
  End Sub

  Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
    MyBase.OnMouseMove(e)

    _mode?.OnMouseMove(e, Control.ModifierKeys)

    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (e.Button And MouseButtons.Right) Then
      If (_rdragging) Then
        _rdelta = _rstart - _mp
        Camera.Position += _rdelta
      Else
        _rdragging = True
        _rstart = _mp
      End If
    End If

    RaiseEvent MapMouseMove(Me, _mp)

    Refresh()
  End Sub

  Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
    MyBase.OnMouseUp(e)

    _mode?.OnMouseUp(e)

    If (e.Button And MouseButtons.Right) Then
      _rdragging = False
    End If
  End Sub

  Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
    MyBase.OnMouseWheel(e)

    If (e.Delta > 0) Then
      _cam.Zoom *= 0.85
    Else
      _cam.Zoom *= 1.15
    End If

    Refresh()
  End Sub

  Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
    MyBase.OnMouseClick(e)

    _mode?.OnMouseClick(e, Control.ModifierKeys)
  End Sub

  Protected Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
    MyBase.OnMouseDoubleClick(e)

    _mode?.OnMouseDoubleClick(e, Control.ModifierKeys)
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    Mode = e.Mode
  End Sub

  Private Sub _mode_Refresh(sender As Object, e As EventArgs) Handles _mode.Refresh
    Refresh()
  End Sub

  Private WithEvents _mode As IMode

  Private _map As Map
  Private _cam As New Camera2D()
  Private _blockSize As Single
  Private _rdragging As Boolean
  Private _rdelta As Vec2
  Private _rstart As Vec2
  Private _mp As New Vec2()
  Private _visibleLines As New List(Of List(Of Integer))
End Class
