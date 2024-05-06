Public Class LineMode
  Inherits ModeBase

  Public Sub New()
    SetName("Line mode")
  End Sub

  Public Overrides Sub OnMouseClick(e As MouseEventArgs, modifierKeys As Keys)
    If (e.Button And MouseButtons.Left) Then
      If (modifierKeys And Keys.Control) Then
        If (_closestPoint IsNot Nothing) Then
          Debug.Print("Split vertex")

          Dim ld = Layer.LineDefById(_closestLineDefId)
          Dim nv = SnapToGrid(_closestPoint)
          Dim nvId = Layer.AddVertex(nv)

          Dim nldId = Layer.AddLineDef(New LineDef(nvId, ld.p1))
          ld.p1 = nvId
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    If (Not _ldragging) Then
      _closestLineDefId = FindClosestLineDefId(_mp)
      _closestPoint = Nothing

      If (_closestLineDefId <> NOT_FOUND) Then
        _closestPoint = Layer.LineDefById(_closestLineDefId).GetClosestPoint(_mp)
      End If
    End If

    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldelta = SnapToGrid(_mp) - _lstart

        If (_closestPoint IsNot Nothing) Then
          Dim ld = Layer.LineDefById(_closestLineDefId)

          With Layer
            Dim p0 = .VertexById(ld.p0)
            Dim p1 = .VertexById(ld.p1)

            .VertexById(ld.p0).Pos = SnapToGrid(_lp0start + _ldelta)
            .VertexById(ld.p1).Pos = SnapToGrid(_lp1start + _ldelta)
          End With
        End If
      Else
        If (_closestLineDefId <> NOT_FOUND) Then
          _ldragging = True
          _lstart = SnapToGrid(_closestPoint)
          _lp0start = Layer.VertexById(Layer.LineDefById(_closestLineDefId).p0)
          _lp1start = Layer.VertexById(Layer.LineDefById(_closestLineDefId).p1)
        End If
      End If
    End If
  End Sub

  Public Overrides Sub OnMouseUp(e As MouseEventArgs)
    If (e.Button And MouseButtons.Left) Then
      If (_ldragging) Then
        _ldragging = False
        _closestLineDefId = NOT_FOUND
        SetHelpText("")
      End If
    End If
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    Dim inv = Camera.Transform().Inversed()
    Dim proj = Camera.Projection()

    If (_closestLineDefId <> NOT_FOUND) Then
      Dim ld = Layer.LineDefById(_closestLineDefId)

      With Layer
        Dim p0 = proj * inv * .VertexById(ld.p0)
        Dim p1 = proj * inv * .VertexById(ld.p1)

        RenderLineDef(g, p0, p1, Color.Yellow)
      End With

      If (_closestPoint IsNot Nothing AndAlso Not _ldragging) Then
        Dim p = proj * inv * _closestPoint

        RenderVertex(g, p, VGAColors.LightRed)
      End If
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs)
    If (e.KeyCode = Keys.Delete) Then
      If (_closestLineDefId <> NOT_FOUND) Then
        Layer.DeleteLineDef(_closestLineDefId)

        _closestLineDefId = NOT_FOUND

        OnRefresh()
      End If
    End If
  End Sub

  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _lp0start As Vec2
  Private _lp1start As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean

  Private _closestLineDefId As Integer = NOT_FOUND
  Private _closestPoint As Vec2
End Class
