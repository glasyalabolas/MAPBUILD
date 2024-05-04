Public Class frmTools
  Private Sub frmTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    BackColor = VGAColors.Blue
    ForeColor = VGAColors.Cyan

    lblPos.Text = ""

    For Each c As Control In pnlButtons.Controls
      If (TypeOf c Is TextBox) Then
        c.ForeColor = VGAColors.Cyan
        c.BackColor = VGAColors.Black
      End If
    Next

    _owner = Owner

    AddHandler _owner.mvView.MapMouseMove, AddressOf MapView_MouseMove
  End Sub

  Private Sub lblPos_MouseMove(sender As Object, e As MouseEventArgs) Handles lblPos.MouseMove
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

  Private Sub lblPos_MouseUp(sender As Object, e As MouseEventArgs) Handles lblPos.MouseUp
    _dragging = False
  End Sub

  Private Sub MapView_MouseMove(sender As Object, p As Vec2)
    lblPos.Text = p
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim f = DirectCast(Owner, frmMain)

    f.Mode = New LineMode()
  End Sub

  Private _owner As frmMain
  Private _dragging As Boolean
  Private _sx As Integer, _sy As Integer
End Class