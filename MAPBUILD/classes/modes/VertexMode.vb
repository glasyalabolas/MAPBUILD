Imports MAP_ID = System.Int32

Public Class VertexMode
  Inherits ModeBase

  Public Sub New()
    SetName("Vertex mode")
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseDoubleClick(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      ClearSelection()

      OnModeStarted()

      Dim newModeArgs = New ModeChangedEventArgs() With {
        .Mode = New PolyDrawMode()}

      OnModeChanged(Me, newModeArgs)

      newModeArgs.Mode.OnMouseDoubleClick(e, modifierKeys)
    End If
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

        If (SelectedCount > 0) Then
          '' Drag selection
          For i As Integer = 0 To SelectedCount - 1
            Layer.VertexById(Selected(i)).Pos += _ldelta
          Next

          If (_closestVertexId <> NOT_FOUND AndAlso Not IsSelected(_closestVertexId)) Then
            '' Drag the closest vertex too even if it wasn't selected
            Layer.VertexById(_closestVertexId).Pos += _ldelta
          End If
        Else
          '' Drag individual vertex
          If (_closestVertexId <> NOT_FOUND) Then
            Layer.VertexById(_closestVertexId).Pos += _ldelta
          End If
        End If
      Else
        If (SelectedCount > 0 OrElse _closestVertexId <> NOT_FOUND) Then
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
      Else
        If (_closestVertexId <> NOT_FOUND) Then
          If (modifierKeys And UNSELECT_SINGLE_KEY) Then
            RemoveSelected(_closestVertexId)
          Else
            AddToSelection(_closestVertexId)
          End If

          OnRefresh()
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    RenderLines(g, VGAColors.DarkGray)
    RenderVertices(g, VGAColors.LightCyan)

    If (_closestVertexId <> NOT_FOUND) Then
      Dim T = Camera.Projection() * Camera.Transform().Inversed()
      Dim p = T * Layer.VertexById(_closestVertexId).Pos
      Dim z As Single = 1.0 / Camera.Zoom
      Dim pen = New Pen(VGAColors.White)
      Dim sz As Single = Math.Min(10.0, 10.0 * z)

      g.DrawRectangle(pen, New Rectangle(p.x - sz * 0.5 - 2, p.y - sz * 0.5 - 2, sz + 3, sz + 3))
    End If

    If (SelectedCount > 0) Then
      Dim T = Camera.Projection() * Camera.Transform().Inversed()
      Dim z As Single = 1.0 / Camera.Zoom

      For i As Integer = 0 To SelectedCount - 1
        Dim p = T * Layer.VertexById(Selected(i)).Pos

        If (InsideView(p)) Then
          RenderVertex(g, p, Math.Min(MAX_VERTEX_SIZE, MAX_VERTEX_SIZE * z), VGAColors.LightRed)
        End If
      Next
    End If
  End Sub

  Protected Overrides Sub OnSelect(e As Rect, modifierKeys As Keys)
    Dim selectionClear As Boolean = Not CBool(modifierKeys And ADD_TO_SELECTION_KEY)
    Dim removeFromSelection As Boolean = modifierKeys And REMOVE_FROM_SELECTION_KEY

    If (selectionClear AndAlso Not removeFromSelection) Then
      ClearSelection()
    End If

    For i As Integer = 0 To Layer.Vertices - 1
      If (e.Inside(Layer.Vertex(i))) Then
        Dim selected As Boolean = IsSelected(Layer.Vertex(i).Id)

        If (Not selected) Then
          AddToSelection(Layer.Vertex(i).Id)
        ElseIf (removefromselection) Then
          RemoveSelected(Layer.Vertex(i).Id)
        End If
      End If
    Next
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean
  Private _closestVertexId As MAP_ID = NOT_FOUND
End Class
