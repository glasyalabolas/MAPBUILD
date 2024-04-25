<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDebug
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Button1 = New Button()
    picDisplay = New PictureBox()
    MenuStrip1 = New MenuStrip()
    FileToolStripMenuItem = New ToolStripMenuItem()
    OpenToolStripMenuItem = New ToolStripMenuItem()
    EditToolStripMenuItem = New ToolStripMenuItem()
    CutToolStripMenuItem = New ToolStripMenuItem()
    CopyToolStripMenuItem = New ToolStripMenuItem()
    PasteToolStripMenuItem = New ToolStripMenuItem()
    Button2 = New Button()
    CType(picDisplay, ComponentModel.ISupportInitialize).BeginInit()
    MenuStrip1.SuspendLayout()
    SuspendLayout()
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(12, 54)
    Button1.Name = "Button1"
    Button1.Size = New Size(212, 34)
    Button1.TabIndex = 0
    Button1.Text = "Test Lines"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' picDisplay
    ' 
    picDisplay.BackColor = Color.Black
    picDisplay.Location = New Point(230, 40)
    picDisplay.Name = "picDisplay"
    picDisplay.Size = New Size(800, 600)
    picDisplay.TabIndex = 1
    picDisplay.TabStop = False
    ' 
    ' MenuStrip1
    ' 
    MenuStrip1.ImageScalingSize = New Size(24, 24)
    MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem})
    MenuStrip1.Location = New Point(0, 0)
    MenuStrip1.Name = "MenuStrip1"
    MenuStrip1.Size = New Size(1042, 33)
    MenuStrip1.TabIndex = 2
    MenuStrip1.Text = "MenuStrip1"
    ' 
    ' FileToolStripMenuItem
    ' 
    FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OpenToolStripMenuItem})
    FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    FileToolStripMenuItem.Size = New Size(54, 29)
    FileToolStripMenuItem.Text = "File"
    ' 
    ' OpenToolStripMenuItem
    ' 
    OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
    OpenToolStripMenuItem.Size = New Size(158, 34)
    OpenToolStripMenuItem.Text = "Open"
    ' 
    ' EditToolStripMenuItem
    ' 
    EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem})
    EditToolStripMenuItem.Name = "EditToolStripMenuItem"
    EditToolStripMenuItem.Size = New Size(58, 29)
    EditToolStripMenuItem.Text = "Edit"
    ' 
    ' CutToolStripMenuItem
    ' 
    CutToolStripMenuItem.Name = "CutToolStripMenuItem"
    CutToolStripMenuItem.Size = New Size(156, 34)
    CutToolStripMenuItem.Text = "Cut"
    ' 
    ' CopyToolStripMenuItem
    ' 
    CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
    CopyToolStripMenuItem.Size = New Size(156, 34)
    CopyToolStripMenuItem.Text = "Copy"
    ' 
    ' PasteToolStripMenuItem
    ' 
    PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
    PasteToolStripMenuItem.Size = New Size(156, 34)
    PasteToolStripMenuItem.Text = "Paste"
    ' 
    ' Button2
    ' 
    Button2.Location = New Point(12, 94)
    Button2.Name = "Button2"
    Button2.Size = New Size(212, 34)
    Button2.TabIndex = 3
    Button2.Text = "Test polygons"
    Button2.UseVisualStyleBackColor = True
    ' 
    ' frmDebug
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(1042, 648)
    Controls.Add(Button2)
    Controls.Add(picDisplay)
    Controls.Add(Button1)
    Controls.Add(MenuStrip1)
    KeyPreview = True
    MainMenuStrip = MenuStrip1
    Name = "frmDebug"
    Text = "Debug"
    CType(picDisplay, ComponentModel.ISupportInitialize).EndInit()
    MenuStrip1.ResumeLayout(False)
    MenuStrip1.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Friend WithEvents Button1 As Button
  Friend WithEvents picDisplay As PictureBox
  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents Button2 As Button
End Class
