Option Infer On

Imports MAP_ID = System.Int32

Public Class LineMode
  Inherits ModeBase

  Public Sub New()
    SetName("Linedef mode")
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

  Public Overrides Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseClick(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      If (modifierKeys And Keys.Control) Then
        If (_closestPoint IsNot Nothing) Then
          '' Split linedef at the closest point
          Dim ld = Layer.LineDefById(HighlightedId)
          Dim nv = SnapToGrid(_closestPoint)
          Dim nvId = Layer.AddVertex(nv)

          Dim nldId = Layer.AddLineDef(New LineDef(nvId, ld.P1))

          ld.P1 = nvId
          ld.OnLineDefSplit(nldId)
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _draggedVertices.Clear()

    MyBase.OnMouseMove(e, modifierKeys)
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    RenderThings(g, VGAColors.DarkGray)
    RenderLines(g, VGAColors.Cyan)
    RenderVertices(g, VGAColors.LightGray)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    If (SelectedCount > 0) Then
      For i As Integer = 0 To SelectedCount - 1
        Dim ld = Layer.LineDefById(Selected(i))
        Dim pp0 = T * ld.GetP0.Pos
        Dim pp1 = T * ld.GetP1.Pos

        RenderLineDef(g, pp0, pp1, 10.0 / Camera.Zoom, VGAColors.LightRed)
      Next
    End If

    If (HighlightedId <> NOT_FOUND) Then
      Dim ld = Layer.LineDefById(HighlightedId)
      Dim pp0 = T * ld.GetP0.Pos
      Dim pp1 = T * ld.GetP1.Pos

      RenderLineDef(g, pp0, pp1, 10.0 / Camera.Zoom, VGAColors.Yellow)
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (e.KeyCode = Keys.Delete) Then
      If (HighlightedId <> NOT_FOUND) Then
        Dim ld = Layer.LineDefById(HighlightedId)

        ld.OnLineDefDeleted()

        Layer.DeleteLineDef(HighlightedId)

        HighlightedId = NOT_FOUND

        OnRefresh()
      End If
    End If
  End Sub

  Protected Overrides Function FindNearestId() As MAP_ID
    Dim result As Integer = NOT_FOUND
    Dim closest As Single = Single.MaxValue
    Dim minDist As Single = LINEDEF_NEAR_DISTANCE * Camera.Zoom

    With Layer
      For i As Integer = 0 To .LineDefs - 1
        Dim dist = .LineDef(i).GetClosestPoint(MousePos).DistanceToSq(MousePos)

        If (dist < closest AndAlso dist <= minDist) Then
          closest = dist
          result = .LineDef(i).Id
        End If
      Next
    End With

    Return (result)
  End Function

  Protected Overrides Sub OnSelect(e As Rect, removeFromSelection As Boolean)
    For i As Integer = 0 To Layer.LineDefs - 1
      Dim ld = Layer.LineDef(i)

      Dim p0 = ld.GetP0.Pos
      Dim p1 = ld.GetP1.Pos

      If (e.Inside(p0) AndAlso e.Inside(p1)) Then
        Dim selected As Boolean = IsSelected(ld.Id)

        If (Not selected) Then
          AddToSelection(ld.Id)
        ElseIf (removeFromSelection) Then
          RemoveSelected(ld.Id)
        End If
      End If
    Next
  End Sub

  Protected Overrides Sub OnDrag(id As MAP_ID, delta As Vec2)
    DragLineDef(Layer.LineDefById(id), delta)
  End Sub

  Protected Overrides Sub OnDragSelection(selected As List(Of MAP_ID), delta As Vec2)
    For i As Integer = 0 To selected.Count - 1
      DragLineDef(Layer.LineDefById(selected(i)), delta)
    Next
  End Sub

  Private Sub DragLineDef(ld As LineDef, delta As Vec2)
    Dim p0 = ld.GetP0.Id
    Dim p1 = ld.GetP1.Id

    '' Don't move already moved vertices twice
    If (Not _draggedVertices.Contains(p0)) Then
      ld.GetP0.Pos += delta
      _draggedVertices.Add(p0)
    End If

    If (Not _draggedVertices.Contains(p1)) Then
      ld.GetP1.Pos += delta
      _draggedVertices.Add(p1)
    End If
  End Sub

  Private _closestPoint As Vec2
  Private _draggedVertices As New List(Of MAP_ID)
End Class
