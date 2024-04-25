
Public MustInherit Class ModeBase
  Implements IDebugMode

  <Runtime.InteropServices.DllImport("user32.dll")>
  Protected Shared Function GetAsyncKeyState(aKey As Keys) As Short
  End Function

  Public Overridable Sub OnProcess() Implements IDebugMode.OnProcess
  End Sub
  Public Overridable Sub OnRender(g As Graphics) Implements IDebugMode.OnRender
  End Sub
  Public Overridable Sub OnMouseMove(e As MouseEventArgs) Implements IDebugMode.OnMouseMove
  End Sub
  Public Overridable Sub OnMouseClick(e As MouseEventArgs) Implements IDebugMode.OnMouseClick
  End Sub
  Public Overridable Sub OnKeyPress(e As KeyEventArgs) Implements IDebugMode.OnKeyPressed
  End Sub

  '' Can be refactored to its own shared class
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
End Class
