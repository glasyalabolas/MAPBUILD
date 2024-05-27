Option Infer On

Public Module Rendering
  Public ReadOnly BLACK = RGB(0, 0, 0)

  Public Sub RenderPoint(g As Graphics, p As Vec2, r As Long, c As Color)
    g.FillEllipse(New SolidBrush(c), New Rectangle(
      p.x - r, p.y - r, r * 2, r * 2))
  End Sub

  Public Sub RenderLineSeg(g As Graphics, l As LineSeg, c As Color)
    g.DrawLine(New Pen(c), l.p0, l.p1)
    RenderPoint(g, l.p0, 3, Color.Green)
    RenderPoint(g, l.p1, 3, Color.Red)
  End Sub

  Public Sub RenderParamLine(g As Graphics, l As ParamLine, c As Color)
    g.DrawLine(New Pen(c, 2), l.p0, l.GetPoint(100))
  End Sub

  Public Sub RenderVertex(g As Graphics, v As Vec2, s As Single, c As Color)
    Dim p = New Pen(c)

    g.DrawRectangle(p, New Rectangle(v.x - s * 0.5, v.y - s * 0.5, s - 1, s - 1))
  End Sub

  Public Sub RenderLineDef(g As Graphics, p0 As Vec2, p1 As Vec2, ns As Single, c As Color)
    Dim p = New Pen(c)
    Dim N = (p0 - p1).Normalize().TurnLeft()
    Dim mp = p0 + (p1 - p0) * 0.5

    g.DrawLine(p, p0, p1)
    g.DrawLine(p, mp, mp + N * ns)
  End Sub
End Module
