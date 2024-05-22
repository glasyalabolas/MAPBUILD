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
    txtTopHeight = New TextBox()
    Label1 = New Label()
    lblSectorId = New Label()
    Label2 = New Label()
    Label3 = New Label()
    txtBottomHeight = New TextBox()
    SuspendLayout()
    ' 
    ' txtTopHeight
    ' 
    txtTopHeight.Location = New Point(217, 63)
    txtTopHeight.Name = "txtTopHeight"
    txtTopHeight.Size = New Size(100, 34)
    txtTopHeight.TabIndex = 0
    txtTopHeight.TextAlign = HorizontalAlignment.Right
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
    ' Label2
    ' 
    Label2.AutoSize = True
    Label2.Location = New Point(12, 66)
    Label2.Name = "Label2"
    Label2.Size = New Size(142, 27)
    Label2.TabIndex = 3
    Label2.Text = "Top height"
    ' 
    ' Label3
    ' 
    Label3.AutoSize = True
    Label3.Location = New Point(12, 106)
    Label3.Name = "Label3"
    Label3.Size = New Size(181, 27)
    Label3.TabIndex = 4
    Label3.Text = "Bottom height"
    ' 
    ' txtBottomHeight
    ' 
    txtBottomHeight.Location = New Point(217, 103)
    txtBottomHeight.Name = "txtBottomHeight"
    txtBottomHeight.Size = New Size(100, 34)
    txtBottomHeight.TabIndex = 5
    txtBottomHeight.TextAlign = HorizontalAlignment.Right
    ' 
    ' frmSectorMode
    ' 
    AutoScaleDimensions = New SizeF(13F, 27F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(374, 475)
    Controls.Add(txtBottomHeight)
    Controls.Add(Label3)
    Controls.Add(Label2)
    Controls.Add(lblSectorId)
    Controls.Add(Label1)
    Controls.Add(txtTopHeight)
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

  Friend WithEvents txtTopHeight As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents lblSectorId As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents txtBottomHeight As TextBox
End Class
