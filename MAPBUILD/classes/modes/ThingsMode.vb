Option Infer On

Imports MAP_ID = System.Int32

Public Class ThingsMode
  Inherits ModeBase

  Public Sub New()
    SetName("Things mode")
  End Sub

  Protected Overrides Function FindId() As Integer
    Debug.Print("ThingsMode::FindId")
    Return MyBase.FindId()
  End Function

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseDoubleClick(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      Dim p = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))

      Dim t = New Thing(p) With {.Size = 32.0}

      Layer.AddThing(t)
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseUp(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _hoverThingId = NOT_FOUND

        SetHelpText("")
      Else
        If (_hoverThingId <> NOT_FOUND) Then
          If (modifierKeys And UNSELECT_SINGLE_KEY) Then
            RemoveSelected(_hoverThingId)
          Else
            AddToSelection(_hoverThingId)
          End If

          OnRefresh()
        End If
      End If
    End If
  End Sub
  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    Dim p = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    _mp = SnapToGrid(p)

    If (Not _ldragging AndAlso Not Selecting) Then
      _hoverThingId = FindClosestThingId(p)
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging AndAlso Not Selecting) Then
        _ldelta = SnapToGrid(_mp) - _lstart
        _lstart = SnapToGrid(_mp)

        If (SelectedCount > 0) Then
          '' Drag selection
          For i As Integer = 0 To SelectedCount - 1
            Layer.ThingById(Selected(i)).Pos += _ldelta
          Next

          If (_hoverThingId <> NOT_FOUND AndAlso Not IsSelected(_hoverThingId)) Then
            '' Drag the closest thing too even if it wasn't selected
            Layer.ThingById(_hoverThingId).Pos += _ldelta
          End If
        Else
          '' Drag individual thing
          If (_hoverThingId <> NOT_FOUND) Then
            Layer.ThingById(_hoverThingId).Pos += _ldelta
          End If
        End If
      Else
        If (SelectedCount > 0 OrElse _hoverThingId <> NOT_FOUND) Then
          '' Start dragging selection
          _ldragging = True
          _lstart = SnapToGrid(_mp)
        End If
      End If
    End If

    If (_hoverThingId = NOT_FOUND) Then
      MyBase.OnMouseMove(e, modifierKeys)
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    RenderLines(g, VGAColors.DarkGray)
    RenderVertices(g, VGAColors.DarkGray)
    RenderThings(g, VGAColors.Green)

    If (SelectedCount > 0) Then
      Dim T = Camera.Projection() * Camera.Transform().Inversed()

      For i As Integer = 0 To SelectedCount - 1
        Dim th = Layer.ThingById(Selected(i))

        RenderThing(g, th, T * th.Pos, VGAColors.LightRed)
      Next
    End If

    If (_hoverThingId <> NOT_FOUND) Then
      Dim t = Layer.ThingById(_hoverThingId)
      Dim center = Camera.Projection * Camera.Transform().Inversed() * t.Pos

      RenderThing(g, t, center, VGAColors.Yellow)
    End If
  End Sub

  Protected Overrides Sub OnSelect(e As Rect, modifierKeys As Keys)
    Dim selectionClear As Boolean = Not CBool(modifierKeys And ADD_TO_SELECTION_KEY)
    Dim removeFromSelection As Boolean = modifierKeys And REMOVE_FROM_SELECTION_KEY

    If (selectionClear AndAlso Not removeFromSelection) Then
      ClearSelection()
    End If

    For i As Integer = 0 To Layer.Things - 1
      If (e.Inside(Layer.Thing(i).Pos)) Then
        Dim selected As Boolean = IsSelected(Layer.Thing(i).Id)

        If (Not selected) Then
          AddToSelection(Layer.Thing(i).Id)
        ElseIf (removeFromSelection) Then
          RemoveSelected(Layer.Thing(i).Id)
        End If
      End If
    Next
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean
  Private _hoverThingId As MAP_ID = NOT_FOUND
End Class
