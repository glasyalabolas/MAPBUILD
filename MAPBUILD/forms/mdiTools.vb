Public Class mdiTools
  Private Declare Auto Function SetWindowLong Lib "User32.Dll" (hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
  Private Declare Auto Function GetWindowLong Lib "User32.Dll" (hWnd As IntPtr, nIndex As Integer) As Integer
  Private Const GWL_EXSTYLE = (-20)
  Private Const WS_EX_CLIENTEDGE = &H200

  Private Sub mdiTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    RemoveMDIClientBorder()

    BackColor = VGAColors.Blue
    ForeColor = VGAColors.Cyan

    lblPos.Text = ""

    'For Each c As Control In pnlButtons.Controls
    '  If (TypeOf c Is TextBox) Then
    '    c.ForeColor = VGAColors.Cyan
    '    c.BackColor = VGAColors.Black
    '  End If
    'Next

    _owner = Owner

    'AddHandler _owner.mvView.MapMouseMove, AddressOf MapView_MouseMove
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

  'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
  '  ShowChild(frmLineMode)
  'End Sub

  Private Sub RemoveMDIClientBorder()
    SuspendLayout()

    '' Set background color and remove border from MDIClient control
    For Each c As Control In Controls()
      If TypeOf (c) Is MdiClient Then
        Dim windowLong As Integer = GetWindowLong(c.Handle, GWL_EXSTYLE)
        windowLong = windowLong And (Not WS_EX_CLIENTEDGE)
        SetWindowLong(c.Handle, GWL_EXSTYLE, windowLong)
        c.Width += 1
        Exit For
      End If
    Next

    ResumeLayout()
  End Sub

  Public Sub ShowChild(f As Form)
    f.MdiParent = Me
    f.Show()
    f.WindowState = FormWindowState.Maximized
  End Sub

  Private Sub MapView_MapMouseMove(sender As Object, p As Vec2) Handles MapView.MapMouseMove
    lblPos.Text = p
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ShowChild(frmLineMode)
  End Sub

  Public WithEvents MapView As MapView

  Private _owner As frmMain
  Private _dragging As Boolean
  Private _sx As Integer, _sy As Integer
End Class