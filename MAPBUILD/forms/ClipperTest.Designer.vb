<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClipperTest
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
    GroupBox1 = New GroupBox()
    RadioButton4 = New RadioButton()
    rbDifference = New RadioButton()
    rbUnion = New RadioButton()
    rbIntersect = New RadioButton()
    PictureBox1 = New PictureBox()
    GroupBox2 = New GroupBox()
    Label1 = New Label()
    rbNonZero = New RadioButton()
    rbEvenOdd = New RadioButton()
    nudCount = New NumericUpDown()
    GroupBox1.SuspendLayout()
    CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
    GroupBox2.SuspendLayout()
    CType(nudCount, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' GroupBox1
    ' 
    GroupBox1.Controls.Add(RadioButton4)
    GroupBox1.Controls.Add(rbDifference)
    GroupBox1.Controls.Add(rbUnion)
    GroupBox1.Controls.Add(rbIntersect)
    GroupBox1.Location = New Point(12, 12)
    GroupBox1.Name = "GroupBox1"
    GroupBox1.Size = New Size(300, 185)
    GroupBox1.TabIndex = 0
    GroupBox1.TabStop = False
    GroupBox1.Text = "Boolean Op"
    ' 
    ' RadioButton4
    ' 
    RadioButton4.AutoSize = True
    RadioButton4.Location = New Point(6, 135)
    RadioButton4.Name = "RadioButton4"
    RadioButton4.Size = New Size(73, 29)
    RadioButton4.TabIndex = 3
    RadioButton4.TabStop = True
    RadioButton4.Text = "XOR"
    RadioButton4.UseVisualStyleBackColor = True
    ' 
    ' rbDifference
    ' 
    rbDifference.AutoSize = True
    rbDifference.Location = New Point(6, 100)
    rbDifference.Name = "rbDifference"
    rbDifference.Size = New Size(117, 29)
    rbDifference.TabIndex = 2
    rbDifference.TabStop = True
    rbDifference.Text = "Difference"
    rbDifference.UseVisualStyleBackColor = True
    ' 
    ' rbUnion
    ' 
    rbUnion.AutoSize = True
    rbUnion.Location = New Point(6, 65)
    rbUnion.Name = "rbUnion"
    rbUnion.Size = New Size(84, 29)
    rbUnion.TabIndex = 1
    rbUnion.TabStop = True
    rbUnion.Text = "Union"
    rbUnion.UseVisualStyleBackColor = True
    ' 
    ' rbIntersect
    ' 
    rbIntersect.AutoSize = True
    rbIntersect.Checked = True
    rbIntersect.Location = New Point(6, 30)
    rbIntersect.Name = "rbIntersect"
    rbIntersect.Size = New Size(104, 29)
    rbIntersect.TabIndex = 0
    rbIntersect.TabStop = True
    rbIntersect.Text = "Intersect"
    rbIntersect.UseVisualStyleBackColor = True
    ' 
    ' PictureBox1
    ' 
    PictureBox1.BackColor = SystemColors.ControlLight
    PictureBox1.Location = New Point(318, 12)
    PictureBox1.Name = "PictureBox1"
    PictureBox1.Size = New Size(680, 611)
    PictureBox1.TabIndex = 2
    PictureBox1.TabStop = False
    ' 
    ' GroupBox2
    ' 
    GroupBox2.Controls.Add(Label1)
    GroupBox2.Controls.Add(rbNonZero)
    GroupBox2.Controls.Add(rbEvenOdd)
    GroupBox2.Controls.Add(nudCount)
    GroupBox2.Location = New Point(12, 203)
    GroupBox2.Name = "GroupBox2"
    GroupBox2.Size = New Size(300, 204)
    GroupBox2.TabIndex = 4
    GroupBox2.TabStop = False
    GroupBox2.Text = "Options"
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Location = New Point(6, 114)
    Label1.Name = "Label1"
    Label1.Size = New Size(110, 25)
    Label1.TabIndex = 7
    Label1.Text = "Vertex count"
    ' 
    ' rbNonZero
    ' 
    rbNonZero.AutoSize = True
    rbNonZero.Checked = True
    rbNonZero.Location = New Point(6, 65)
    rbNonZero.Name = "rbNonZero"
    rbNonZero.Size = New Size(107, 29)
    rbNonZero.TabIndex = 6
    rbNonZero.TabStop = True
    rbNonZero.Text = "NonZero"
    rbNonZero.UseVisualStyleBackColor = True
    ' 
    ' rbEvenOdd
    ' 
    rbEvenOdd.AutoSize = True
    rbEvenOdd.Location = New Point(6, 30)
    rbEvenOdd.Name = "rbEvenOdd"
    rbEvenOdd.Size = New Size(110, 29)
    rbEvenOdd.TabIndex = 5
    rbEvenOdd.Text = "EvenOdd"
    rbEvenOdd.UseVisualStyleBackColor = True
    ' 
    ' nudCount
    ' 
    nudCount.Location = New Point(6, 142)
    nudCount.Name = "nudCount"
    nudCount.Size = New Size(90, 31)
    nudCount.TabIndex = 4
    nudCount.Value = New Decimal(New Integer() {50, 0, 0, 0})
    ' 
    ' ClipperTest
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(1010, 635)
    Controls.Add(GroupBox2)
    Controls.Add(PictureBox1)
    Controls.Add(GroupBox1)
    Name = "ClipperTest"
    Text = "ClipperTest"
    GroupBox1.ResumeLayout(False)
    GroupBox1.PerformLayout()
    CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
    GroupBox2.ResumeLayout(False)
    GroupBox2.PerformLayout()
    CType(nudCount, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents rbIntersect As RadioButton
  Friend WithEvents RadioButton4 As RadioButton
  Friend WithEvents rbDifference As RadioButton
  Friend WithEvents rbUnion As RadioButton
  Friend WithEvents PictureBox1 As PictureBox
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents Label1 As Label
  Friend WithEvents rbNonZero As RadioButton
  Friend WithEvents rbEvenOdd As RadioButton
  Friend WithEvents nudCount As NumericUpDown
End Class
