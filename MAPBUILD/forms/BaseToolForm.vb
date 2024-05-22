Public Class BaseToolForm
  Protected Overridable Sub OnModeEvent(info As Object, eventType As ModeEventType)
  End Sub

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

  Private Sub Mode_ModeEvent(sender As Object, eventInfo As Object, eventType As ModeEventType) Handles Mode.ModeEvent
    OnModeEvent(eventInfo, eventType)
  End Sub

  Public WithEvents Mode As IMode
End Class