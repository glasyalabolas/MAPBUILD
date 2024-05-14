Imports MAP_ID = System.Int32

Public Class VertexMode
  Inherits ModeBase

  Public Sub New()
    SetName("Vertex mode")
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    _selected.Clear()

    OnModeStarted()

    Dim newModeArgs = New ModeChangedEventArgs() With {
      .Mode = New PolyDrawMode()}

    OnModeChanged(Me, newModeArgs)

    newModeArgs.Mode.OnMouseDoubleClick(e, modifierKeys)
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _ldragging AndAlso Not Selecting) Then
      _closestVertexId = FindClosestVertexId(_mp)
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging AndAlso Not Selecting) Then
        _ldelta = SnapToGrid(_mp) - _lstart
        _lstart = SnapToGrid(_mp)

        If (_selected.Count > 0) Then
          '' Drag selection
          For i As Integer = 0 To _selected.Count - 1
            Layer.VertexById(_selected(i)).Pos += _ldelta
          Next

          If (_closestVertexId <> NOT_FOUND AndAlso Not IsSelected(_closestVertexId)) Then
            '' Drag the closest vertex too even if it wasn't selected
            Layer.VertexById(_closestVertexId).Pos += _ldelta
          End If
        Else
          '' Drag invidivual vertex
          If (_closestVertexId <> NOT_FOUND) Then
            Layer.VertexById(_closestVertexId).Pos += _ldelta
          End If
        End If
      Else
        If (_selected.Count > 0 OrElse _closestVertexId <> NOT_FOUND) Then
          '' Start dragging selection
          _ldragging = True
          _lstart = SnapToGrid(_mp)
        End If
      End If
    End If

    If (_closestVertexId = NOT_FOUND) Then
      MyBase.OnMouseMove(e, modifierKeys)
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseUp(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _closestVertexId = NOT_FOUND

        SetHelpText("")
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()
    Dim z As Single = 1.0 / Camera.Zoom

    For i As Integer = 0 To Layer.Vertices - 1
      Dim p = T * Layer.Vertex(i)

      If (InsideView(p)) Then
        If (IsSelected(Layer.Vertex(i).Id)) Then
          RenderVertex(g, p, Math.Min(10.0, 10.0 * z), VGAColors.Yellow)
        Else
          RenderVertex(g, p, Math.Min(10.0, 10.0 * z), VGAColors.LightRed)
        End If
      End If
    Next
  End Sub

  Protected Overrides Sub OnSelect(e As Rect, modifierKeys As Keys)
    Dim clearSelection As Boolean = Not CBool(modifierKeys And Keys.Shift)
    Dim removeFromSelection As Boolean = modifierKeys And Keys.Control

    If (clearSelection AndAlso Not removeFromSelection) Then
      _selected.Clear()
    End If

    For i As Integer = 0 To Layer.Vertices - 1
      If (e.Inside(Layer.Vertex(i))) Then
        Dim selected As Boolean = IsSelected(Layer.Vertex(i).Id)

        If (Not selected AndAlso Not removeFromSelection) Then
          _selected.Add(Layer.Vertex(i).Id)
        Else
          RemoveSelected(Layer.Vertex(i).Id)
        End If
      End If
    Next
  End Sub

  Private Function IsSelected(id As MAP_ID) As Boolean
    For i As Integer = 0 To _selected.Count - 1
      If (_selected(i) = id) Then
        Return (True)
      End If
    Next

    Return (False)
  End Function

  Private Sub RemoveSelected(id As MAP_ID)
    For i As Integer = 0 To _selected.Count - 1
      If (_selected(i) = id) Then
        _selected.RemoveAt(i)
        Return
      End If
    Next
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean
  Private _closestVertexId As MAP_ID = NOT_FOUND
  Private _selected As New List(Of MAP_ID)
End Class
