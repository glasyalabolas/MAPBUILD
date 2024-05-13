Public Class frmLineMode
  Private Sub frmVectorMode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    MinimizeBox = False
    MaximizeBox = False

    BackColor = VGAColors.Blue
    ForeColor = VGAColors.Cyan
    Font = New Font("Consolas", 11)

    For Each c As Control In Controls
      If (TypeOf c Is TextBox) Then
        c.ForeColor = VGAColors.Cyan
        c.BackColor = VGAColors.Black
      End If
    Next
  End Sub
End Class