<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapView
  Inherits System.Windows.Forms.UserControl

  'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
    SuspendLayout()
    ' 
    ' MapView
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    BackColor = Color.Black
    DoubleBuffered = True
    Name = "MapView"
    ResumeLayout(False)
  End Sub

End Class
