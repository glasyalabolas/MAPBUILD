Option Infer On

Imports MAP_ID = System.Int32

Public Class ThingsMode
  Inherits ModeBase

  Public Sub New()
    SetName("Things mode")
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    MyBase.OnMouseDoubleClick(e, modifierKeys)

    If (e.Button And MouseButtons.Left) Then
      Dim p = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))

      Dim t = New Thing(p) With {.Size = 32.0}

      Layer.AddThing(t)
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

    If (HighlightedId <> NOT_FOUND) Then
      Dim t = Layer.ThingById(HighlightedId)
      Dim center = Camera.Projection * Camera.Transform().Inversed() * t.Pos

      RenderThing(g, t, center, VGAColors.Yellow)
    End If
  End Sub

  Protected Overrides Function FindNearestId() As MAP_ID
    With Layer
      For i As Integer = 0 To .Things - 1
        Dim t = .Thing(i)
        Dim hs As Single = t.Size * 0.5

        If (MousePos.x >= t.Pos.x - hs AndAlso MousePos.y >= t.Pos.y - hs AndAlso
          MousePos.x <= t.Pos.x + hs AndAlso MousePos.y <= t.Pos.y + hs) Then

          Return (t.Id)
        End If
      Next
    End With

    Return (NOT_FOUND)
  End Function

  Protected Overrides Sub OnSelect(e As Rect, removeFromSelection As Boolean)
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

  Protected Overrides Sub OnDrag(id As MAP_ID, delta As Vec2)
    Layer.ThingById(id).Pos += delta
  End Sub

  Protected Overrides Sub OnDragSelection(selected As List(Of MAP_ID), delta As Vec2)
    For i As Integer = 0 To selected.Count - 1
      Layer.ThingById(selected(i)).Pos += delta
    Next
  End Sub
End Class
