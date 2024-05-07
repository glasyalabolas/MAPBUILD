<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTools
  Inherits System.Windows.Forms.Form

  'Form reemplaza a Dispose para limpiar la lista de componentes.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Requerido por el Diseñador de Windows Forms
  Private components As System.ComponentModel.IContainer

  'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
  'Se puede modificar usando el Diseñador de Windows Forms.  
  'No lo modifique con el editor de código.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    lblPos = New Label()
    pnlButtons = New Panel()
    Button2 = New Button()
    Button1 = New Button()
    TextBox1 = New TextBox()
    Label1 = New Label()
    Button3 = New Button()
    pnlButtons.SuspendLayout()
    SuspendLayout()
    ' 
    ' lblPos
    ' 
    lblPos.Dock = DockStyle.Top
    lblPos.Location = New Point(0, 0)
    lblPos.Name = "lblPos"
    lblPos.Size = New Size(395, 26)
    lblPos.TabIndex = 1
    lblPos.Text = "Label1"
    lblPos.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' pnlButtons
    ' 
    pnlButtons.Controls.Add(Button3)
    pnlButtons.Controls.Add(Button2)
    pnlButtons.Controls.Add(Button1)
    pnlButtons.Controls.Add(TextBox1)
    pnlButtons.Controls.Add(Label1)
    pnlButtons.Dock = DockStyle.Top
    pnlButtons.Location = New Point(0, 26)
    pnlButtons.Name = "pnlButtons"
    pnlButtons.Size = New Size(395, 201)
    pnlButtons.TabIndex = 2
    ' 
    ' Button2
    ' 
    Button2.Location = New Point(12, 87)
    Button2.Name = "Button2"
    Button2.Size = New Size(163, 48)
    Button2.TabIndex = 6
    Button2.Text = "Vertex mode"
    Button2.UseVisualStyleBackColor = True
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(12, 141)
    Button1.Name = "Button1"
    Button1.Size = New Size(163, 48)
    Button1.TabIndex = 5
    Button1.Text = "Line mode"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' TextBox1
    ' 
    TextBox1.BorderStyle = BorderStyle.None
    TextBox1.Location = New Point(126, 12)
    TextBox1.Name = "TextBox1"
    TextBox1.Size = New Size(101, 26)
    TextBox1.TabIndex = 4
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Location = New Point(12, 15)
    Label1.Name = "Label1"
    Label1.Size = New Size(108, 26)
    Label1.TabIndex = 3
    Label1.Text = "Sector #"
    ' 
    ' Button3
    ' 
    Button3.Location = New Point(181, 87)
    Button3.Name = "Button3"
    Button3.Size = New Size(163, 48)
    Button3.TabIndex = 7
    Button3.Text = "Sector mode"
    Button3.UseVisualStyleBackColor = True
    ' 
    ' frmTools
    ' 
    AutoScaleDimensions = New SizeF(12F, 26F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(395, 275)
    Controls.Add(pnlButtons)
    Controls.Add(lblPos)
    DoubleBuffered = True
    Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    FormBorderStyle = FormBorderStyle.None
    Margin = New Padding(5)
    Name = "frmTools"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.Manual
    pnlButtons.ResumeLayout(False)
    pnlButtons.PerformLayout()
    ResumeLayout(False)
  End Sub
  Friend WithEvents lblPos As Label
  Friend WithEvents pnlButtons As Panel
  Friend WithEvents TextBox1 As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents Button1 As Button
  Friend WithEvents Button2 As Button
  Friend WithEvents Button3 As Button
End Class
