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

  Public Sub RenderPoly(g As Graphics, p As Poly, c As Color)
    Using nPen As New Pen(c)
      For i As Integer = 0 To p.Count - 1
        Dim v0 = p(i), v1 = p(i + 1)

        g.DrawLine(nPen, v0, v1)
      Next
    End Using
  End Sub

  Public Sub RenderVertex(g As Graphics, v As Vec2, c As Color)
    Dim br = New SolidBrush(c)

    g.FillRectangle(br, New Rectangle(v.x - 3, v.y - 3, 7, 7))
  End Sub
End Module
