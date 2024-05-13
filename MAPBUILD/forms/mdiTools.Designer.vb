<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiTools
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
    Panel1 = New Panel()
    Button1 = New Button()
    Panel1.SuspendLayout()
    SuspendLayout()
    ' 
    ' lblPos
    ' 
    lblPos.Dock = DockStyle.Top
    lblPos.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    lblPos.Location = New Point(0, 0)
    lblPos.Name = "lblPos"
    lblPos.Size = New Size(426, 26)
    lblPos.TabIndex = 3
    lblPos.Text = "lblPos"
    lblPos.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' Panel1
    ' 
    Panel1.Controls.Add(Button1)
    Panel1.Dock = DockStyle.Top
    Panel1.Location = New Point(0, 26)
    Panel1.Name = "Panel1"
    Panel1.Size = New Size(426, 34)
    Panel1.TabIndex = 5
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(57, 6)
    Button1.Name = "Button1"
    Button1.Size = New Size(112, 34)
    Button1.TabIndex = 0
    Button1.Text = "Button1"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' mdiTools
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(426, 450)
    Controls.Add(Panel1)
    Controls.Add(lblPos)
    DoubleBuffered = True
    FormBorderStyle = FormBorderStyle.None
    IsMdiContainer = True
    Name = "mdiTools"
    ShowInTaskbar = False
    Text = "mdiTools"
    Panel1.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

  Friend WithEvents lblPos As Label
  Friend WithEvents Panel1 As Panel
  Friend WithEvents Button1 As Button
End Class
