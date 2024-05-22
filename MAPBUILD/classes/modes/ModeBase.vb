Option Infer On

Imports MAP_ID = System.Int32

''' <summary>
''' Base class for editing modes.
''' </summary>
Public MustInherit Class ModeBase
  Implements IMode

  '' To indicate an entity was not found
  Protected Const NOT_FOUND As MAP_ID = -1

  '' Nearest vertex minimum distance, in map units
  Protected Const VERTEX_NEAR_DISTANCE As Single = 50.0

  '' Nearest linedef minimum distance, in map units
  Protected Const LINEDEF_NEAR_DISTANCE As Single = 100.0

  Public Event ModeChanged(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeChanged
  Public Event ModeStarted(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeStarted
  Public Event ModeFinished(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeFinished
  Public Event ModeEvent(sender As Object, info As Object, eventType As ModeEventType) Implements IMode.ModeEvent
  Public Event HelpTextChanged(sender As Object, e As EventArgs) Implements IMode.HelpTextChanged
  Public Event GridSizeChanged(sender As Object, e As EventArgs) Implements IMode.GridSizeChanged
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

  Public Property GridSize() As Single Implements IMode.GridSize
    Get
      Return (_gridSize)
    End Get

    Set(value As Single)
      _gridSize = value

      OnGridSizeChanged()
    End Set
  End Property

  Public Property ViewRect() As Rectangle Implements IMode.ViewRect
  Public Property Map() As Map Implements IMode.Map
  Public Property Layer() As Layer Implements IMode.Layer
  Public Property Camera() As Camera2D Implements IMode.Camera

  Protected ReadOnly Property Selecting() As Boolean
    Get
      Return (_selecting)
    End Get
  End Property


  Protected Sub SetName(value As String)
    _name = value
  End Sub

  Protected Sub SetHelpText(value As String)
    _helpText = value

    OnHelpTextChanged()
  End Sub

  'Protected Overridable Sub OnSelectionChanged()
  'End Sub

  Public Overridable Sub OnClearSelection() Implements IMode.OnClearSelection
  End Sub

  Public Overridable Sub OnRender(g As Graphics) Implements IMode.OnRender
    If (GridSize / Camera.Zoom >= 20.0) Then
      RenderGrid(g, VGAColors.DarkGray)
    End If

    RenderView(g)

    If (_selectRect IsNot Nothing) Then
      Dim p = New Pen(VGAColors.White, 1)
      p.DashPattern = {3, 2, 3, 2}
      Dim sz = (_selectRect.BottomRight - _selectRect.TopLeft) / Camera.Zoom
      Dim T = Camera.Projection() * Camera.Transform().Inversed()
      Dim p0 = T * _selectRect.TopLeft

      g.DrawRectangle(p, New Rectangle(p0.x, p0.y, sz.x, sz.y))
    End If
  End Sub

  Public Overridable Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseMove
    If (e.Button And MouseButtons.Left) Then
      If (_selecting) Then
        _ep = Camera.ViewToWorld(New Vec2(e.X, e.Y))
        _selectRect = New Rect(_sp.Clone(), _ep.Clone())
      Else
        _selecting = True
        _sp = Camera.ViewToWorld(New Vec2(e.X, e.Y))
      End If
    End If
  End Sub

  Public Overridable Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseUp
    If (e.Button And MouseButtons.Left) Then
      If (_selecting) Then
        _selecting = False

        If (_selectRect IsNot Nothing) Then
          OnSelect(_selectRect, modifierKeys)
        End If

        _selectRect = Nothing
        End If
      End If
  End Sub

  Protected Overridable Sub OnSelect(e As Rect, modifierKeys As Keys)
  End Sub

  Public Overridable Sub OnMouseDown(e As MouseEventArgs) Implements IMode.OnMouseDown
  End Sub
  Public Overridable Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseClick
  End Sub
  Public Overridable Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseDoubleClick
  End Sub
  Public Overridable Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys) Implements IMode.OnKeyPressed
  End Sub
  Public Overridable Sub OnMouseWheel(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseWheel
  End Sub

  Protected Sub OnModeChanged(sender As Object, e As ModeChangedEventArgs)
    e.Mode.GridSize = GridSize
    e.Mode.ViewRect = ViewRect
    e.Mode.Map = Map
    e.Mode.Layer = Layer

    RaiseEvent ModeChanged(sender, e)
  End Sub

  Protected Sub OnModeStarted()
    RaiseEvent ModeStarted(Me, New ModeChangedEventArgs())
  End Sub

  Protected Sub OnModeFinished()
    RaiseEvent ModeFinished(Me, New ModeChangedEventArgs())
  End Sub

  Protected Sub OnModeEvent(info As Object, eventType As ModeEventType)
    RaiseEvent ModeEvent(Me, info, eventType)
  End Sub
  Protected Sub OnRefresh()
    RaiseEvent Refresh(Me, EventArgs.Empty)
  End Sub

  Private Sub OnHelpTextChanged()
    RaiseEvent HelpTextChanged(Me, EventArgs.Empty)
  End Sub

  Private Sub OnGridSizeChanged()
    RaiseEvent GridSizeChanged(Me, EventArgs.Empty)
  End Sub

  ''' <summary>
  ''' Gets all visible lines on the view for all layers.
  ''' </summary>
  Private Sub PreProcess()
    _visibleLines.Clear()

    For i As Integer = 0 To Map.Layers - 1
      _visibleLines.Add(Map.Layer(i).GetVisibleLines(Camera))
    Next
  End Sub

  ''' <summary>
  ''' Renders the base view for the mode.
  ''' </summary>
  ''' <param name="g">The Graphics context.</param>
  Private Sub RenderView(g As Graphics)
    If (Map IsNot Nothing) Then
      PreProcess()

      Dim T = Camera.Projection() * Camera.Transform().Inversed()
      Dim Ns As Single = 10.0 / Camera.Zoom '' Normal size

      For lay As Integer = 0 To _visibleLines.Count - 1
        For ldef As Integer = 0 To _visibleLines(lay).Count - 1
          Dim p As Pen = VGAColors.WhitePen

          With Map.Layer(lay).LineDef(_visibleLines(lay)(ldef))
            Dim p0 = Map.SelectedLayer.VertexById(.P0)
            Dim p1 = Map.SelectedLayer.VertexById(.P1)

            Dim pp0 = T * p0
            Dim pp1 = T * p1

            g.DrawLine(p, pp0, pp1)

            Dim N = .Normal
            Dim Np = pp0 + (pp1 - pp0) * 0.5

            g.DrawLine(p, Np, Np + N * Ns)
          End With
        Next
      Next
    End If
  End Sub

  ''' <summary>
  ''' Renders the grid.
  ''' </summary>
  ''' <param name="g">The Graphics context.</param>
  ''' <param name="c">The color of the grid.</param>
  Private Sub RenderGrid(g As Graphics, c As Color)
    Dim tl = Camera.TopLeft()
    Dim br = Camera.BottomRight()
    Dim T = Camera.Projection() * Camera.Transform.Inversed()
    Dim startP = New Vec2(tl.x \ GridSize, tl.y \ GridSize) * GridSize
    Dim p = New Vec2(startP.x, startP.y)
    Dim pn = VGAColors.DarkGrayPen

    Do While (p.y <= br.y)
      Do While (p.x <= br.x)
        Dim p1 = T * p

        g.DrawLine(pn, p1.x - 2, p1.y, p1.x + 2, p1.y)
        g.DrawLine(pn, p1.x, p1.y - 2, p1.x, p1.y + 2)

        p.x += GridSize
      Loop

      p.y += GridSize
      p.x = startP.x
    Loop
  End Sub

  ''' <summary>
  ''' Snaps the specified vertex to the block grid.
  ''' </summary>
  ''' <param name="v">The vertex to snap to grid, expressed in world coordinates.</param>
  ''' <returns></returns>
  Protected Function SnapToGrid(v As Vec2) As Vec2
    Dim hbsx As Single = IIf(v.x >= 0, GridSize * 0.5, -GridSize * 0.5)
    Dim hbsy As Single = IIf(v.y >= 0, GridSize * 0.5, -GridSize * 0.5)

    Return (New Vec2((v.x + hbsx) \ GridSize, (v.y + hbsy) \ GridSize) * GridSize)
  End Function

  ''' <summary>
  ''' Returns whether or not the specified vertex is within view bounds.
  ''' </summary>
  ''' <param name="v">The vertex, expressed in view coordinates.</param>
  ''' <returns></returns>
  Protected Function InsideView(v As Vec2) As Boolean
    Return (v.x >= 0 AndAlso v.x <= ViewRect.Width - 1 AndAlso
      v.y >= 0 AndAlso v.y <= ViewRect.Height - 1)
  End Function

  ''' <summary>
  ''' Returns whether v1 is the closest vertex to v2 in the selected layer.
  ''' </summary>
  ''' <param name="v1">The vertex to check.</param>
  ''' <param name="v2">The vertex in the selected layer to check against.</param>
  ''' <returns></returns>
  Public Function IsClosestVertex(v1 As Vec2, v2 As Vec2) As Boolean
    Dim closest = Integer.MaxValue
    Dim closestV As New Vec2

    For i As Integer = 0 To Layer.Vertices - 1
      Dim dist = v2.DistanceToSq(Layer.Vertex(i))

      If (dist < closest) Then
        closest = dist
        closestV = Layer.Vertex(i)
      End If
    Next

    Return (closestV.x = v1.x AndAlso closestV.y = v1.y)
  End Function

  ''' <summary>
  ''' Finds the vertex id in the selected layer closest to the specified vertex.
  ''' </summary>
  ''' <param name="v">The vertex to check against.</param>
  ''' <returns></returns>
  Public Function FindClosestVertexId(v As Vec2) As MAP_ID
    Dim closest As Single = Single.MaxValue
    Dim result As Integer = NOT_FOUND
    Dim minDist As Single = VERTEX_NEAR_DISTANCE * Camera.Zoom

    For i As Integer = 0 To Layer.Vertices - 1
      Dim dist As Single = v.DistanceToSq(Layer.Vertex(i))

      If (dist < closest AndAlso dist <= minDist) Then
        closest = dist
        result = Layer.Vertex(i).Id
      End If
    Next

    Return (result)
  End Function

  ''' <summary>
  ''' Finds the closest linedef id to the specified vertex.
  ''' </summary>
  ''' <param name="v">The vertex to check against.</param>
  ''' <returns></returns>
  Protected Function FindClosestLineDefId(v As Vec2) As MAP_ID
    Dim result As Integer = NOT_FOUND
    Dim closest As Single = Single.MaxValue
    Dim minDist As Single = LINEDEF_NEAR_DISTANCE * Camera.Zoom

    With Layer
      For i As Integer = 0 To .LineDefs - 1
        Dim dist = .LineDef(i).GetClosestPoint(v).DistanceToSq(v)

        If (dist < closest AndAlso dist <= minDist) Then
          closest = dist
          result = .LineDef(i).Id
        End If
      Next
    End With

    Return (result)
  End Function

  Private _name As String
  Private _helpText As String
  Private _gridSize As Single
  Private _visibleLines As New List(Of List(Of MAP_ID))
  Private _selecting As Boolean
  Private _sp As New Vec2, _ep As New Vec2
  Private _selectRect As Rect
End Class
