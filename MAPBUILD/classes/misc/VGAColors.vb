Option Infer On

Public Class VGAColors
  Public Shared ReadOnly Black As Color = Color.FromArgb(255, 0, 0, 0)
  Public Shared ReadOnly Blue As Color = Color.FromArgb(255, 0, 0, 170)
  Public Shared ReadOnly Green As Color = Color.FromArgb(255, 0, 170, 0)
  Public Shared ReadOnly Cyan As Color = Color.FromArgb(255, 0, 170, 170)
  Public Shared ReadOnly Red As Color = Color.FromArgb(255, 170, 0, 0)
  Public Shared ReadOnly Magenta As Color = Color.FromArgb(255, 170, 0, 170)
  Public Shared ReadOnly Brown As Color = Color.FromArgb(255, 170, 85, 0)
  Public Shared ReadOnly LightGray As Color = Color.FromArgb(255, 170, 170, 170)
  Public Shared ReadOnly DarkGray As Color = Color.FromArgb(255, 85, 85, 85)
  Public Shared ReadOnly LightBlue As Color = Color.FromArgb(255, 85, 85, 255)
  Public Shared ReadOnly LightGreen As Color = Color.FromArgb(255, 85, 255, 85)
  Public Shared ReadOnly LightCyan As Color = Color.FromArgb(255, 85, 255, 255)
  Public Shared ReadOnly LightRed As Color = Color.FromArgb(255, 255, 85, 85)
  Public Shared ReadOnly LightMagenta As Color = Color.FromArgb(255, 255, 85, 255)
  Public Shared ReadOnly Yellow As Color = Color.FromArgb(255, 255, 255, 85)
  Public Shared ReadOnly White As Color = Color.FromArgb(255, 255, 255, 255)

  Public Shared ReadOnly Index() As Color = {Black, Blue, Green, Cyan, Red,
    Magenta, Brown, LightGray, DarkGray, LightBlue, LightGreen, LightCyan,
    LightRed, LightMagenta, Yellow, White}

  Public Shared ReadOnly BlackPen As Pen = New Pen(Black)
  Public Shared ReadOnly BluePen As Pen = New Pen(Blue)
  Public Shared ReadOnly GreenPen As Pen = New Pen(Green)
  Public Shared ReadOnly CyanPen As Pen = New Pen(Cyan)
  Public Shared ReadOnly RedPen As Pen = New Pen(Red)
  Public Shared ReadOnly MagentaPen As Pen = New Pen(Magenta)
  Public Shared ReadOnly BrownPen As Pen = New Pen(Brown)
  Public Shared ReadOnly LightGrayPen As Pen = New Pen(LightGray)
  Public Shared ReadOnly DarkGrayPen As Pen = New Pen(DarkGray)
  Public Shared ReadOnly LightBluePen As Pen = New Pen(LightBlue)
  Public Shared ReadOnly LightGreenPen As Pen = New Pen(LightGreen)
  Public Shared ReadOnly LightCyanPen As Pen = New Pen(LightCyan)
  Public Shared ReadOnly LightRedPen As Pen = New Pen(LightRed)
  Public Shared ReadOnly LightMagentaPen As Pen = New Pen(LightMagenta)
  Public Shared ReadOnly YellowPen As Pen = New Pen(Yellow)
  Public Shared ReadOnly WhitePen As Pen = New Pen(White)
End Class
