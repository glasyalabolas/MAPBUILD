<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLineMode
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
    Button1 = New Button()
    TextBox1 = New TextBox()
    SuspendLayout()
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(12, 12)
    Button1.Name = "Button1"
    Button1.Size = New Size(155, 42)
    Button1.TabIndex = 0
    Button1.Text = "Button1"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' TextBox1
    ' 
    TextBox1.BorderStyle = BorderStyle.None
    TextBox1.Location = New Point(173, 12)
    TextBox1.Name = "TextBox1"
    TextBox1.Size = New Size(150, 26)
    TextBox1.TabIndex = 1
    ' 
    ' frmLineMode
    ' 
    AutoScaleDimensions = New SizeF(12F, 26F)
    AutoScaleMode = AutoScaleMode.Font
    BackColor = Color.Red
    ClientSize = New Size(401, 468)
    ControlBox = False
    Controls.Add(TextBox1)
    Controls.Add(Button1)
    Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    FormBorderStyle = FormBorderStyle.None
    Margin = New Padding(4, 3, 4, 3)
    MaximizeBox = False
    MinimizeBox = False
    Name = "frmLineMode"
    ShowIcon = False
    ShowInTaskbar = False
    Text = "frmVectorMode"
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Friend WithEvents Button1 As Button
  Friend WithEvents TextBox1 As TextBox
End Class
