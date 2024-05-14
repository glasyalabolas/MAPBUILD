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
    Button3 = New Button()
    Button2 = New Button()
    Button1 = New Button()
    Panel1.SuspendLayout()
    SuspendLayout()
    ' 
    ' lblPos
    ' 
    lblPos.Dock = DockStyle.Top
    lblPos.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    lblPos.Location = New Point(0, 0)
    lblPos.Margin = New Padding(2, 0, 2, 0)
    lblPos.Name = "lblPos"
    lblPos.Size = New Size(341, 19)
    lblPos.TabIndex = 3
    lblPos.Text = "lblPos"
    lblPos.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' Panel1
    ' 
    Panel1.Controls.Add(Button3)
    Panel1.Controls.Add(Button2)
    Panel1.Controls.Add(Button1)
    Panel1.Dock = DockStyle.Top
    Panel1.Location = New Point(0, 19)
    Panel1.Margin = New Padding(2)
    Panel1.Name = "Panel1"
    Panel1.Size = New Size(341, 59)
    Panel1.TabIndex = 5
    ' 
    ' Button3
    ' 
    Button3.Location = New Point(188, 2)
    Button3.Margin = New Padding(2)
    Button3.Name = "Button3"
    Button3.Size = New Size(89, 32)
    Button3.TabIndex = 2
    Button3.Text = "Sector"
    Button3.UseVisualStyleBackColor = True
    ' 
    ' Button2
    ' 
    Button2.Location = New Point(95, 2)
    Button2.Margin = New Padding(2)
    Button2.Name = "Button2"
    Button2.Size = New Size(89, 32)
    Button2.TabIndex = 1
    Button2.Text = "Line"
    Button2.UseVisualStyleBackColor = True
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(2, 2)
    Button1.Margin = New Padding(2)
    Button1.Name = "Button1"
    Button1.Size = New Size(89, 32)
    Button1.TabIndex = 0
    Button1.Text = "Vertex"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' mdiTools
    ' 
    AutoScaleDimensions = New SizeF(8F, 18F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(341, 324)
    Controls.Add(Panel1)
    Controls.Add(lblPos)
    DoubleBuffered = True
    Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
    FormBorderStyle = FormBorderStyle.None
    IsMdiContainer = True
    Margin = New Padding(2)
    Name = "mdiTools"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.Manual
    Text = "mdiTools"
    Panel1.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

  Friend WithEvents lblPos As Label
  Friend WithEvents Panel1 As Panel
  Friend WithEvents Button1 As Button
  Friend WithEvents Button3 As Button
  Friend WithEvents Button2 As Button
End Class
