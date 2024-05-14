<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSectorMode
  Inherits BaseToolForm

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
    TextBox1 = New TextBox()
    SuspendLayout()
    ' 
    ' TextBox1
    ' 
    TextBox1.Location = New Point(12, 12)
    TextBox1.Name = "TextBox1"
    TextBox1.Size = New Size(100, 25)
    TextBox1.TabIndex = 0
    TextBox1.Text = "Sector"
    ' 
    ' frmSectorMode
    ' 
    AutoScaleDimensions = New SizeF(8F, 18F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(317, 475)
    Controls.Add(TextBox1)
    Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
    FormBorderStyle = FormBorderStyle.None
    Margin = New Padding(3, 4, 3, 4)
    Name = "frmSectorMode"
    Text = "frmSectorMode"
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Friend WithEvents TextBox1 As TextBox
End Class
