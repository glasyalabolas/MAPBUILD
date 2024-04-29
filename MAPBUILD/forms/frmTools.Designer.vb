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
    pnlButtons.Dock = DockStyle.Top
    pnlButtons.Location = New Point(0, 26)
    pnlButtons.Name = "pnlButtons"
    pnlButtons.Size = New Size(395, 201)
    pnlButtons.TabIndex = 2
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
    ResumeLayout(False)
  End Sub
  Friend WithEvents lblPos As Label
  Friend WithEvents pnlButtons As Panel
End Class
