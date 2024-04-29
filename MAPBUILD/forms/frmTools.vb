Public Class frmTools
  Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
    If (e.Button And MouseButtons.Left) Then
      If (_dragging) Then
        Location = New Point(Location.X + (e.X - _sx), Location.Y + (e.Y - _sy))
      Else
        _dragging = True
        _sx = e.X
        _sy = e.Y
      End If
    End If
  End Sub

  Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
    _dragging = False
  End Sub

  Private Sub frmTools_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
    For i = 0 To 15
      e.Graphics.FillRectangle(New SolidBrush(VGAColor.Index(i)),
        New Rectangle(i * 8, 12, 8, 8))
    Next
  End Sub

  Private _dragging As Boolean
  Private _sx As Integer, _sy As Integer
End Class