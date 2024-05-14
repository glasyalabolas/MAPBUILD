Option Infer On

Public Class mdiTools
  Private Declare Auto Function SetWindowLong Lib "User32.Dll" (hWnd As IntPtr, nIndex As Integer, dwNewLong As Integer) As Integer
  Private Declare Auto Function GetWindowLong Lib "User32.Dll" (hWnd As IntPtr, nIndex As Integer) As Integer
  Private Const GWL_EXSTYLE = (-20)
  Private Const WS_EX_CLIENTEDGE = &H200

  Public Property Mode() As IMode
    Get
      Return (_mode)
    End Get

    Set(value As IMode)
      _mode = value
    End Set
  End Property

  Private Sub mdiTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    RemoveMDIClientBorder()

    BackColor = VGAColors.Blue
    ForeColor = VGAColors.Cyan

    GetClientMDIControl().BackColor = VGAColors.Blue

    lblPos.Text = ""

    _owner = Owner
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

  Private Sub RemoveMDIClientBorder()
    SuspendLayout()

    '' Remove border from MDIClient control
    Dim mdiClient = GetClientMDIControl()

    Dim windowLong As Integer = GetWindowLong(mdiClient.Handle, GWL_EXSTYLE) And (Not WS_EX_CLIENTEDGE)
    SetWindowLong(mdiClient.Handle, GWL_EXSTYLE, windowLong)
    mdiClient.Width += 1

    ResumeLayout()
  End Sub

  Public Sub ShowChild(f As Form)
    f.MdiParent = Me
    f.Show()
    f.Location = New Point(0, 0)

    Dim containerSize = GetClientMDIControl().Size

    f.Size = New Size(containerSize.Width, containerSize.Height)

    f.BringToFront()
  End Sub

  Private Function GetClientMDIControl() As MdiClient
    For Each c As Control In Controls
      If (TypeOf (c) Is MdiClient) Then
        Return (c)
      End If
    Next

    Return (Nothing)
  End Function

  Private Sub MapView_MapMouseMove(sender As Object, p As Vec2) Handles MapView.MapMouseMove
    lblPos.Text = p
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    _owner.Mode = New VertexMode()
    ShowChild(frmVertexMode)
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    _owner.Mode = New LineMode()
    ShowChild(frmLineMode)
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    _owner.Mode = New SectorMode()
    ShowChild(frmSectorMode)
  End Sub

  Public WithEvents MapView As MapView

  Private WithEvents _mode As IMode
  Private _owner As frmMain
  Private _dragging As Boolean
  Private _sx As Integer, _sy As Integer
End Class