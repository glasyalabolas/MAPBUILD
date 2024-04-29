Option Infer On

Public Class VGAColor
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

  Public Shared Index() As Color = {Black, Blue, Green, Cyan, Red,
    Magenta, Brown, LightGray, DarkGray, LightBlue, LightGreen, LightCyan,
    LightRed, LightMagenta, Yellow, White}
End Class
