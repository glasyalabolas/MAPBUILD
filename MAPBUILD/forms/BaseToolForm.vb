Public Class BaseToolForm
  Private Sub BaseToolForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    MinimizeBox = False
    MaximizeBox = False

    BackColor = VGAColors.Blue
    ForeColor = VGAColors.Cyan

    For Each c As Control In Controls
      If (TypeOf c Is TextBox) Then
        c.ForeColor = VGAColors.Cyan
        c.BackColor = VGAColors.Black
      End If
    Next
  End Sub
End Class