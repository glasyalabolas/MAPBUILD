Public Class PolyDrawMode2
  Inherits ModeBase

  Public Sub New()
    SetName("Poly draw mode")
    SetHelpText("Double click to start a line")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    If (_drawing) Then
      _cp = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))
    End If
  End Sub

  Public Overrides Sub OnMouseDoubleClick(e As MouseEventArgs, modifierKeys As Keys)
    If (Not _drawing) Then
      _vertices.Clear()
      _vertices.Add(SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y))))

      _drawing = True
    End If
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
    If (_drawing) Then
      If (e.Button And MouseButtons.Left) Then
        Dim nv = SnapToGrid(Camera.ViewToWorld(New Vec2(e.X, e.Y)))
        Dim nearest As Integer = FindClosestVertex(nv)

        If (nearest = 0) Then
          '' Close polygon
          CreateSector(True)

          _drawing = False
        Else
          If (nearest = NOT_FOUND) Then
            _vertices.Add(nv)
          End If
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (e.KeyCode = Keys.Escape) Then
      If (_drawing) Then
        _drawing = False

        OnRefresh()
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    If (_drawing) Then
      Dim T = Camera.Projection() * Camera.Transform.Inversed()

      For i As Integer = 0 To _vertices.Count - 2
        Dim lp0 = T * _vertices(i)
        Dim lp1 = T * _vertices(i + 1)

        g.DrawLine(VGAColors.LightBluePen, lp0, lp1)
      Next

      Dim p0 = T * _vertices(_vertices.Count - 1)
      Dim p1 = T * _cp

      g.DrawLine(VGAColors.LightBluePen, p0, p1)
    End If
  End Sub

  Private Sub CreateSector(closed As Boolean)
    Dim vertIds As New List(Of Integer)

    For i As Integer = 0 To _vertices.Count - 1
      vertIds.Add(Layer.AddVertex(_vertices(i)))
    Next

    Dim lineDefIds As New List(Of Integer)

    For i As Integer = 0 To vertIds.Count - 1
      lineDefIds.Add(Layer.AddLineDef(
        New LineDef(vertIds(i), vertIds(Wrap(i + 1, 0, vertIds.Count)))))
    Next

    If (closed) Then
      Dim s = New Sector()
      Layer.AddSector(s)

      For i As Integer = 0 To lineDefIds.Count - 1
        s.AddLineDef(lineDefIds(i))
      Next
    End If
  End Sub

  Private Function FindClosestVertex(v As Vec2) As Integer
    Dim closest As Single = Single.MaxValue
    Dim result As Integer = NOT_FOUND
    Dim minDist As Single = VERTEX_NEAR_DISTANCE * Camera.Zoom

    For i As Integer = 0 To _vertices.Count - 1
      Dim dist As Single = v.DistanceToSq(_vertices(i))

      If (dist < closest AndAlso dist <= minDist) Then
        closest = dist
        result = i
      End If
    Next

    Return (result)
  End Function

  Private _cp As Vec2
  Private _drawing As Boolean
  Private _vertices As New List(Of Vec2)
End Class
