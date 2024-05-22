<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPanel
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
    SuspendLayout()
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(12, 12)
    Button1.Name = "Button1"
    Button1.Size = New Size(139, 63)
    Button1.TabIndex = 0
    Button1.Text = "Form in a panel"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' frmPanel
    ' 
    AutoScaleDimensions = New SizeF(12F, 26F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(960, 468)
    Controls.Add(Button1)
    Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    FormBorderStyle = FormBorderStyle.None
    Margin = New Padding(4, 3, 4, 3)
    Name = "frmPanel"
    Text = "frmPanel"
    ResumeLayout(False)
  End Sub

  Friend WithEvents Button1 As Button
End Class
