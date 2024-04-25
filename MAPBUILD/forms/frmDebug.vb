Imports System.ComponentModel

Public Class frmDebug
  Public Shared Sub Main(args() As String)
    Application.EnableVisualStyles()
    Application.SetHighDpiMode(HighDpiMode.SystemAware)
    Application.Run(New frmDebug)
  End Sub

  Private Async Sub frmDebug_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    _mode = New VectorDebugMode(picDisplay.Width, picDisplay.Height)

    _running = True

    Do While (_running)
      _mode?.OnProcess()
      OnRender()

      Await Task.Delay(1)
    Loop
  End Sub

  Private Sub frmDebug_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
    _running = False
  End Sub

  Private Sub OnRender()
    picDisplay.Refresh()
  End Sub
  Private Sub frmDebug_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
    _mode?.OnKeyPressed(e)
  End Sub

  Private Sub picDisplay_Paint(sender As Object, e As PaintEventArgs) Handles picDisplay.Paint
    _mode?.OnRender(e.Graphics)
  End Sub

  Private Sub picDisplay_MouseMove(sender As Object, e As MouseEventArgs) Handles picDisplay.MouseMove
    _mode?.OnMouseMove(e)
  End Sub

  Private Sub picDisplay_MouseClick(sender As Object, e As MouseEventArgs) Handles picDisplay.MouseClick
    _mode?.OnMouseClick(e)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    _mode = New VectorDebugMode(picDisplay.Width, picDisplay.Height)
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    _mode = New PolyDebugMode()
  End Sub

  Private _mode As IDebugMode
  Private _running As Boolean
End Class
