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
      If (_mode.BlockSize / Camera.Zoom >= 10.0) Then
        RenderBlocksizeGrid(e.Graphics, Color.DarkSlateGray)
      End If

      RenderView(e.Graphics)

      _mode?.OnRender(e.Graphics, _cam)
    End If
  End Sub

  Protected Overrides Sub OnSizeChanged(e As EventArgs)
    MyBase.OnSizeChanged(e)

    _cam.ViewPort = New Vec2(Width, Height)

    Refresh()
  End Sub

  Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
    MyBase.OnMouseMove(e)

    _mode?.OnMouseMove(e)

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

    _mode?.OnMouseClick(e)
  End Sub

  Protected Overrides Sub OnMouseDoubleClick(e As MouseEventArgs)
    MyBase.OnMouseDoubleClick(e)

    _mode?.OnMouseDoubleClick(e)
  End Sub

  Private Sub _mode_ModeChanged(sender As Object, e As ModeChangedEventArgs) Handles _mode.ModeChanged
    Mode = e.Mode
  End Sub

  Private Sub RenderBlocksizeGrid(g As Graphics, c As Color)
    Dim tl = _cam.TopLeft()
    Dim br = _cam.BottomRight()
    Dim inv = Camera.Transform.Inversed()
    Dim prj = Camera.Projection()

    Dim startP = New Vec2(tl.x \ _mode.BlockSize, tl.y \ _mode.BlockSize) * _mode.BlockSize
    Dim p = New Vec2(startP.x, startP.y)
    Dim pn = VGAColors.DarkGrayPen

    Do While (p.y <= br.y)
      Do While (p.x <= br.x)
        Dim p1 = prj * inv * p

        g.DrawLine(pn, p1.x - 2, p1.y, p1.x + 2, p1.y)
        g.DrawLine(pn, p1.x, p1.y - 2, p1.x, p1.y + 2)

        p.x += _mode.BlockSize
      Loop

      p.y += _mode.BlockSize
      p.x = startP.x
    Loop
  End Sub

  Private Sub PreProcess()
    _visibleLines.Clear()

    Dim tl = _cam.TopLeft()
    Dim br = _cam.BottomRight()

    _map.DisableEvents()

    For l As Integer = 0 To _map.Layers - 1
      _map.SelectLayer(l)

      For i As Integer = 0 To _map.LineDefs - 1
        With _map.LineDef(i)
          Dim p0 = _map.Vertex(.p0)
          Dim p1 = _map.Vertex(.p1)

          If (Maths.LiangBarsky(
            tl.x, tl.y, br.x, br.y, p0.x, p0.y, p1.x, p1.y)) Then

            _visibleLines.Add(_map.LineDef(i))
          End If
        End With
      Next
    Next

    _map.EnableEvents()
  End Sub

  Private Sub RenderView(g As Graphics)
    If (_map IsNot Nothing) Then
      PreProcess()

      Dim inv = _cam.Transform().Inversed()

      For i As Integer = 0 To _visibleLines.Count - 1
        Dim p0 = _map.Vertex(_visibleLines(i).p0)
        Dim p1 = _map.Vertex(_visibleLines(i).p1)

        Dim pp0 = _cam.Projection * inv * p0
        Dim pp1 = _cam.Projection * inv * p1

        g.DrawLine(Pens.White, pp0, pp1)
      Next
    End If
  End Sub

  Private WithEvents _mode As IMode

  Private _map As Map
  Private _cam As New Camera2D()
  Private _blockSize As Single
  Private _rdragging As Boolean
  Private _rdelta As Vec2
  Private _rstart As Vec2
  Private _mp As New Vec2()
  Private _visibleLines As New List(Of LineDef)
End Class
