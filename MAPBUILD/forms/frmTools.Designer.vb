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
    Panel1 = New Panel()
    SuspendLayout()
    ' 
    ' Panel1
    ' 
    Panel1.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(170))
    Panel1.Dock = DockStyle.Top
    Panel1.Location = New Point(0, 0)
    Panel1.Name = "Panel1"
    Panel1.Size = New Size(353, 12)
    Panel1.TabIndex = 0
    ' 
    ' frmTools
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(353, 270)
    Controls.Add(Panel1)
    DoubleBuffered = True
    FormBorderStyle = FormBorderStyle.None
    Name = "frmTools"
    ShowInTaskbar = False
    StartPosition = FormStartPosition.CenterParent
    ResumeLayout(False)
  End Sub

  Friend WithEvents Panel1 As Panel
End Class
