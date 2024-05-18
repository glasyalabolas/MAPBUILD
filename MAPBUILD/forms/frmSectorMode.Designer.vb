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
    Label1 = New Label()
    lblSectorId = New Label()
    SuspendLayout()
    ' 
    ' TextBox1
    ' 
    TextBox1.Location = New Point(205, 63)
    TextBox1.Name = "TextBox1"
    TextBox1.Size = New Size(100, 34)
    TextBox1.TabIndex = 0
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Location = New Point(12, 15)
    Label1.Name = "Label1"
    Label1.Size = New Size(116, 27)
    Label1.TabIndex = 1
    Label1.Text = "Sector #"
    ' 
    ' lblSectorId
    ' 
    lblSectorId.AutoSize = True
    lblSectorId.Location = New Point(125, 15)
    lblSectorId.Name = "lblSectorId"
    lblSectorId.Size = New Size(90, 27)
    lblSectorId.TabIndex = 2
    lblSectorId.Text = "Label2"
    ' 
    ' frmSectorMode
    ' 
    AutoScaleDimensions = New SizeF(13F, 27F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(374, 475)
    Controls.Add(lblSectorId)
    Controls.Add(Label1)
    Controls.Add(TextBox1)
    Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
    ForeColor = Color.FromArgb(CByte(0), CByte(170), CByte(170))
    Margin = New Padding(3, 4, 3, 4)
    MaximizeBox = False
    MinimizeBox = False
    Name = "frmSectorMode"
    Text = "frmSectorMode"
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Friend WithEvents TextBox1 As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents lblSectorId As Label
End Class
