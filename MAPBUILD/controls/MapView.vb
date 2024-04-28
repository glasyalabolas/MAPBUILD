Imports System.ComponentModel

Public Class MapView
  <Runtime.InteropServices.DllImport("user32.dll")>
  Protected Shared Function GetAsyncKeyState(aKey As Keys) As Short
  End Function

  Public Event MapMouseMove(sender As Object, p As Vec2)

  Public Sub New()
    'Esta llamada es exigida por el diseñador.
    InitializeComponent()

    'Agregue cualquier inicialización después de la llamada a InitializeComponent().
    SetStyle(ControlStyles.UserPaint, True)
    SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
  End Sub

  Protected Overrides Sub Finalize()
    _running = False

    MyBase.Finalize()
  End Sub

  <Browsable(False)>
  Public Property Map() As Map
    Get
      Return (_map)
    End Get

    Set(value As Map)
      _map = value
    End Set
  End Property

  <Browsable(False)>
  Public Property Mode() As IMode
    Get
      Return (_mode)
    End Get

    Set(value As IMode)
      _mode = value
    End Set
  End Property

  Public ReadOnly Property Camera() As Camera2D
    Get
      Return (_cam)
    End Get
  End Property

  Public Property BlockSize() As Single
    Get
      Return (_blockSize)
    End Get

    Set(value As Single)
      _blockSize = value
    End Set
  End Property

  Private Sub MapView_Load(sender As Object, e As EventArgs) Handles Me.Load
    If (Not DesignMode) Then
      _running = True
      _blockSize = 32.0

      Run()
    End If
  End Sub

  Private Async Sub Run()
    Do While (_running)
      Process()
      Refresh()

      Await Task.Delay(5)
    Loop
  End Sub

  Private Sub Process()
    Dim dx As Single, dy As Single

    If (GetAsyncKeyState(Keys.Up)) Then
      dy = -16
    End If
    If (GetAsyncKeyState(Keys.Down)) Then
      dy = 16
    End If
    If (GetAsyncKeyState(Keys.Left)) Then
      dx = -16
    End If
    If (GetAsyncKeyState(Keys.Right)) Then
      dx = 16
    End If

    If (GetAsyncKeyState(Keys.A)) Then
      _cam.Zoom *= 1.02
    End If

    If (GetAsyncKeyState(Keys.Z)) Then
      _cam.Zoom *= 0.98
    End If

    _cam.Position += New Vec2(dx, dy) * _cam.Zoom

    _mode?.OnProcess()
  End Sub

  Protected Overrides Sub OnPaint(e As PaintEventArgs)
    If (Not DesignMode) Then
      If (BlockSize / Camera.Zoom >= 10.0) Then
        RenderBlocksizeGrid(e.Graphics, Color.DarkSlateGray)
      End If

      _mode?.OnRender(e.Graphics, _cam)
    End If
  End Sub

  Protected Overrides Sub OnSizeChanged(e As EventArgs)
    MyBase.OnSizeChanged(e)

    _cam.ViewPort = New Vec2(Width, Height)
  End Sub

  Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
    MyBase.OnMouseMove(e)

    _mode?.OnMouseMove(e)

    Dim p = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (e.Button And MouseButtons.Right) Then
      If (_rdragging) Then
        _rdelta = _rstart - p
        Camera.Position += _rdelta
      Else
        _rdragging = True
        _rstart = p
      End If
    End If

    RaiseEvent MapMouseMove(Me, p)
  End Sub

  Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
    MyBase.OnMouseUp(e)

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
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    _mode = e.Mode
  End Sub

  Private Sub RenderBlocksizeGrid(g As Graphics, c As Color)
    Dim tl = _cam.TopLeft()
    Dim br = _cam.BottomRight()
    Dim inv = Camera.Transform.Inversed()
    Dim prj = Camera.Projection()

    Dim startP = New Vec2(tl.x \ BlockSize, tl.y \ BlockSize) * BlockSize
    Dim p = New Vec2(startP.x, startP.y)
    Dim pn = New Pen(c)

    Do While (p.y <= br.y)
      Do While (p.x <= br.x)
        Dim p1 = prj * inv * p

        g.DrawLine(pn, p1.x - 2, p1.y, p1.x + 2, p1.y)
        g.DrawLine(pn, p1.x, p1.y - 2, p1.x, p1.y + 2)

        p.x += BlockSize
      Loop

      p.y += BlockSize
      p.x = startP.x
    Loop
  End Sub

  Private WithEvents _mode As IMode

  Private _map As Map
  Private _cam As New Camera2D()
  Private _blockSize As Single

  Private _running As Boolean
  Private _rdragging As Boolean
  Private _rdelta As Vec2
  Private _rstart As Vec2
End Class
