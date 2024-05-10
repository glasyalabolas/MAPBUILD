''' <summary>
''' Base class for editing modes.
''' </summary>
Public MustInherit Class ModeBase
  Implements IMode

  '<Runtime.InteropServices.DllImport("user32.dll")>
  'Protected Shared Function GetKeyState(aKey As Keys) As Short
  'End Function

  '' To indicate an entity was not found
  Protected Const NOT_FOUND As Integer = -1

  '' Nearest vertex minimum distance, in map units
  Protected Const VERTEX_NEAR_DISTANCE As Single = 75.0

  '' Nearest linedef minimum distance, in map units
  Protected Const LINEDEF_NEAR_DISTANCE As Single = 100.0

  Public Event ModeChanged(sender As Object, m As ModeChangedEventArgs) Implements IMode.ModeChanged
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
  Public Property Layer() As Layer Implements IMode.Layer
  Public Property Camera() As Camera2D Implements IMode.Camera

  Protected Sub SetName(value As String)
    _name = value
  End Sub

  Protected Sub SetHelpText(value As String)
    _helpText = value

    OnHelpTextChanged()
  End Sub

  Public Overridable Sub OnProcess() Implements IMode.OnProcess
  End Sub
  Public Overridable Sub OnRender(g As Graphics) Implements IMode.OnRender
  End Sub
  Public Overridable Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys) Implements IMode.OnMouseMove
  End Sub
  Public Overridable Sub OnMouseUp(e As MouseEventArgs) Implements IMode.OnMouseUp
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
    'e.Mode.Map = Map
    e.Mode.Layer = Layer

    RaiseEvent ModeChanged(sender, e)
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
  Public Function FindClosestVertexId(v As Vec2) As Integer
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
  Protected Function FindClosestLineDefId(v As Vec2) As Integer
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
End Class
