Option Infer On

Public Class frmSectorMode
  Protected Overrides Sub OnModeEvent(info As Object, eventType As ModeEventType)
    Select Case eventType
      Case ModeEventType.EVENT_SECTOR_HIGHLIGHTED
        ShowSectorInfo(info)
    End Select
  End Sub

  Private Sub ShowSectorInfo(s As Sector)
    lblSectorId.Text = s.Id
    txtTopHeight.Text = s.TopHeight
    txtBottomHeight.Text = s.BottomHeight
  End Sub
End Class