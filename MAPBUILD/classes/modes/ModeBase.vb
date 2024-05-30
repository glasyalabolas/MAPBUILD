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

  '' Max drawing size for vertices
  Protected Const MAX_VERTEX_SIZE As Single = 10.0

  Protected Const UNSELECT_SINGLE_KEY As Keys = Keys.Shift
  Protected Const ADD_TO_SELECTION_KEY = Keys.Shift
  Protected Const REMOVE_FROM_SELECTION_KEY = Keys.Control

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

  Protected ReadOnly Property Selected(index As Integer) As MAP_ID
    Get
      Return (_selected(index))
    End Get
  End Property

  Protected ReadOnly Property SelectedCount() As Integer
    Get
      Return (_selected.Count)
    End Get
  End Property

  Protected Property HighlightedId() As MAP_ID
    Get
      Return (_highlightedId)
    End Get

    Set(value As MAP_ID)
      _highlightedId = value
    End Set
  End Property

  Protected ReadOnly Property MousePos() As Vec2
    Get
      Return (_mousePos)
    End Get
  End Property

  Protected Sub ClearSelection()
    _selected.Clear()
  End Sub

  Protected Sub AddToSelection(id As MAP_ID)
    _selected.Add(id)
  End Sub

  Protected Function IsSelected(id As MAP_ID) As Boolean
    For i As Integer = 0 To _selected.Count - 1
      If (_selected(i) = id) Then
        Return (True)
      End If
    Next

    Return (False)
  End Function

  Protected Sub RemoveSelected(id As MAP_ID)
    For i As Integer = 0 To _selected.Count - 1
      If (_selected(i) = id) Then
        _selected.RemoveAt(i)
        Return
      End If
    Next
  End Sub

  Protected Sub SetName(value As String)
    _name = value
  End Sub

  Protected Sub SetHelpText(value As String)
    _helpText = value

    OnHelpTextChanged()
  End Sub

  Public Overridable Sub OnClearSelection() Implements IMode.OnClearSelection
  End Sub

  Protected Overridable Sub OnSelect(e As Rect, removeFromSelection As Boolean)
  End Sub

  Public Overridable Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseMove
    _mousePos = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _dragging AndAlso Not Selecting) Then
      _highlightedId = FindNearestId()
    End If

    'Debug.Print("Sector references: " & Layer.CountSectorReferences(_mousePos))

    If (e.Button And MouseButtons.Left) Then
      If (_dragging AndAlso Not Selecting) Then
        _delta = SnapToGrid(_mousePos) - _lstart
        _lstart = SnapToGrid(_mousePos)

        If (SelectedCount > 0) Then
          '' Drag selection
          OnDragSelection(_selected, _delta)

          If (_highlightedId <> NOT_FOUND AndAlso Not IsSelected(_highlightedId)) Then
            '' Drag the closest vertex too even if it wasn't selected
            OnDrag(_highlightedId, _delta)
          End If
        Else
          '' Drag individual vertex
          OnDrag(_highlightedId, _delta)
        End If
      Else
        If (SelectedCount > 0 OrElse _highlightedId <> NOT_FOUND) Then
          '' Start dragging selection
          _dragging = True
          _lstart = SnapToGrid(_mousePos)
        End If
      End If

      If (_selecting) Then
        _ep = Camera.ViewToWorld(New Vec2(e.X, e.Y))
        _selectionRect = New Rect(_sp.Clone(), _ep.Clone())
      ElseIf (_highlightedId = NOT_FOUND) Then
        _selecting = True
        _sp = Camera.ViewToWorld(New Vec2(e.X, e.Y))
      End If
    End If
  End Sub

  Public Overridable Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseUp
    If (e.Button And MouseButtons.Left) Then
      If (_selecting) Then
        _selecting = False

        If (_selectionRect IsNot Nothing) Then
          Dim selectionClear As Boolean = Not CBool(modifierKeys And ADD_TO_SELECTION_KEY)
          Dim removeFromSelection As Boolean = modifierKeys And REMOVE_FROM_SELECTION_KEY

          If (selectionClear AndAlso Not removeFromSelection) Then
            ClearSelection()
          End If

          OnSelect(_selectionRect, removeFromSelection)
        End If

        _selectionRect = Nothing
      End If

      If (_dragging) Then
        _dragging = False
        _highlightedId = NOT_FOUND

        SetHelpText("")
      Else
        If (_highlightedId <> NOT_FOUND) Then
          If (modifierKeys And UNSELECT_SINGLE_KEY) Then
            RemoveSelected(_highlightedId)
          Else
            AddToSelection(_highlightedId)
          End If

          OnRefresh()
        End If
      End If
    End If
  End Sub

  Protected Overridable Sub OnDrag(id As MAP_ID, delta As Vec2)
  End Sub

  Protected Overridable Sub OnDragSelection(selected As List(Of MAP_ID), delta As Vec2)
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

  Protected Overridable Function FindNearestId() As MAP_ID
    Return (NOT_FOUND)
  End Function

  Public Overridable Sub OnRender(g As Graphics) Implements IMode.OnRender
    If (GridSize / Camera.Zoom >= 20.0) Then
      RenderGrid(g, VGAColors.DarkGray)
    End If

    If (_selectionRect IsNot Nothing) Then
      Dim p = New Pen(VGAColors.White, 1)
      p.DashPattern = {3, 2, 3, 2}
      Dim sz = (_selectionRect.BottomRight - _selectionRect.TopLeft) / Camera.Zoom
      Dim p0 = Camera.Projection() * Camera.Transform().Inversed() * _selectionRect.TopLeft

      g.DrawRectangle(p, New Rectangle(p0.x, p0.y, sz.x, sz.y))
    End If
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
    Dim pn = New Pen(VGAColors.DarkGray)

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

  Protected Sub RenderVertices(g As Graphics, c As Color)
    Dim T = Camera.Projection() * Camera.Transform().Inversed()
    Dim z As Single = 1.0 / Camera.Zoom

    For i As Integer = 0 To Layer.Vertices - 1
      Dim p = T * Layer.Vertex(i)

      If (InsideView(p)) Then
        RenderVertex(g, p, Math.Min(MAX_VERTEX_SIZE, MAX_VERTEX_SIZE * z), c)
      End If
    Next
  End Sub

  Protected Sub RenderLines(g As Graphics, c As Color)
    PreProcess()

    Dim T = Camera.Projection() * Camera.Transform().Inversed()
    Dim Ns As Single = 10.0 / Camera.Zoom '' Normal size

    For lay As Integer = 0 To _visibleLines.Count - 1
      For ldef As Integer = 0 To _visibleLines(lay).Count - 1
        Dim p = New Pen(c)

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
  End Sub

  Protected Sub RenderThings(g As Graphics, c As Color)
    Dim T = Camera.Projection * Camera.Transform.Inversed()

    For i As Integer = 0 To Layer.Things - 1
      Dim center = T * Layer.Thing(i).Pos
      RenderThing(g, Layer.Thing(i), center, c)
    Next
  End Sub

  Protected Sub RenderThing(g As Graphics, t As Thing, center As Vec2, c As Color)
    Dim s As Single = t.Size / Camera.Zoom
    Dim br = New SolidBrush(c)

    g.FillEllipse(br, New Rectangle(center.x - s * 0.5, center.y - s * 0.5, s, s))
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

  Private _name As String
  Private _helpText As String
  Private _gridSize As Single
  Private _visibleLines As New List(Of List(Of MAP_ID))

  Private _sp As New Vec2, _ep As New Vec2
  Private _selectionRect As Rect

  Private _selecting As Boolean
  Private _selected As New List(Of MAP_ID)

  Private _delta As Vec2
  Private _lstart As Vec2
  Private _mousePos As New Vec2()
  Private _dragging As Boolean
  Private _highlightedId As MAP_ID = NOT_FOUND
End Class
