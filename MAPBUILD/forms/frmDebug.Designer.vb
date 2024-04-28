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
    MenuStrip1 = New MenuStrip()
    FileToolStripMenuItem = New ToolStripMenuItem()
    OpenToolStripMenuItem = New ToolStripMenuItem()
    OpenToolStripMenuItem1 = New ToolStripMenuItem()
    SaveToolStripMenuItem = New ToolStripMenuItem()
    SaveAsToolStripMenuItem = New ToolStripMenuItem()
    PropertiesToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator2 = New ToolStripSeparator()
    ExitToolStripMenuItem = New ToolStripMenuItem()
    EditToolStripMenuItem = New ToolStripMenuItem()
    UndoToolStripMenuItem = New ToolStripMenuItem()
    RedoToolStripMenuItem = New ToolStripMenuItem()
    ToolStripSeparator1 = New ToolStripSeparator()
    CutToolStripMenuItem = New ToolStripMenuItem()
    CopyToolStripMenuItem = New ToolStripMenuItem()
    PasteToolStripMenuItem = New ToolStripMenuItem()
    TestToolStripMenuItem = New ToolStripMenuItem()
    LinesAndVectorsToolStripMenuItem = New ToolStripMenuItem()
    PolygonsToolStripMenuItem = New ToolStripMenuItem()
    StatusStrip1 = New StatusStrip()
    ToolStripStatusLabel1 = New ToolStripStatusLabel()
    MapView1 = New MapView()
    MenuStrip1.SuspendLayout()
    StatusStrip1.SuspendLayout()
    SuspendLayout()
    ' 
    ' MenuStrip1
    ' 
    MenuStrip1.ImageScalingSize = New Size(24, 24)
    MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem, TestToolStripMenuItem})
    MenuStrip1.Location = New Point(0, 0)
    MenuStrip1.Name = "MenuStrip1"
    MenuStrip1.Size = New Size(1134, 33)
    MenuStrip1.TabIndex = 2
    MenuStrip1.Text = "MenuStrip1"
    ' 
    ' FileToolStripMenuItem
    ' 
    FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OpenToolStripMenuItem, OpenToolStripMenuItem1, SaveToolStripMenuItem, SaveAsToolStripMenuItem, PropertiesToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
    FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    FileToolStripMenuItem.Size = New Size(54, 29)
    FileToolStripMenuItem.Text = "File"
    ' 
    ' OpenToolStripMenuItem
    ' 
    OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
    OpenToolStripMenuItem.Size = New Size(206, 34)
    OpenToolStripMenuItem.Text = "New"
    ' 
    ' OpenToolStripMenuItem1
    ' 
    OpenToolStripMenuItem1.Name = "OpenToolStripMenuItem1"
    OpenToolStripMenuItem1.Size = New Size(206, 34)
    OpenToolStripMenuItem1.Text = "Open..."
    ' 
    ' SaveToolStripMenuItem
    ' 
    SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
    SaveToolStripMenuItem.Size = New Size(206, 34)
    SaveToolStripMenuItem.Text = "Save"
    ' 
    ' SaveAsToolStripMenuItem
    ' 
    SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
    SaveAsToolStripMenuItem.Size = New Size(206, 34)
    SaveAsToolStripMenuItem.Text = "Save as..."
    ' 
    ' PropertiesToolStripMenuItem
    ' 
    PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
    PropertiesToolStripMenuItem.Size = New Size(206, 34)
    PropertiesToolStripMenuItem.Text = "Properties..."
    ' 
    ' ToolStripSeparator2
    ' 
    ToolStripSeparator2.Name = "ToolStripSeparator2"
    ToolStripSeparator2.Size = New Size(203, 6)
    ' 
    ' ExitToolStripMenuItem
    ' 
    ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    ExitToolStripMenuItem.Size = New Size(206, 34)
    ExitToolStripMenuItem.Text = "Exit"
    ' 
    ' EditToolStripMenuItem
    ' 
    EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UndoToolStripMenuItem, RedoToolStripMenuItem, ToolStripSeparator1, CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem})
    EditToolStripMenuItem.Name = "EditToolStripMenuItem"
    EditToolStripMenuItem.Size = New Size(58, 29)
    EditToolStripMenuItem.Text = "Edit"
    ' 
    ' UndoToolStripMenuItem
    ' 
    UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
    UndoToolStripMenuItem.Size = New Size(158, 34)
    UndoToolStripMenuItem.Text = "Undo"
    ' 
    ' RedoToolStripMenuItem
    ' 
    RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
    RedoToolStripMenuItem.Size = New Size(158, 34)
    RedoToolStripMenuItem.Text = "Redo"
    ' 
    ' ToolStripSeparator1
    ' 
    ToolStripSeparator1.Name = "ToolStripSeparator1"
    ToolStripSeparator1.Size = New Size(155, 6)
    ' 
    ' CutToolStripMenuItem
    ' 
    CutToolStripMenuItem.Name = "CutToolStripMenuItem"
    CutToolStripMenuItem.Size = New Size(158, 34)
    CutToolStripMenuItem.Text = "Cut"
    ' 
    ' CopyToolStripMenuItem
    ' 
    CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
    CopyToolStripMenuItem.Size = New Size(158, 34)
    CopyToolStripMenuItem.Text = "Copy"
    ' 
    ' PasteToolStripMenuItem
    ' 
    PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
    PasteToolStripMenuItem.Size = New Size(158, 34)
    PasteToolStripMenuItem.Text = "Paste"
    ' 
    ' TestToolStripMenuItem
    ' 
    TestToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LinesAndVectorsToolStripMenuItem, PolygonsToolStripMenuItem})
    TestToolStripMenuItem.Name = "TestToolStripMenuItem"
    TestToolStripMenuItem.Size = New Size(58, 29)
    TestToolStripMenuItem.Text = "Test"
    ' 
    ' LinesAndVectorsToolStripMenuItem
    ' 
    LinesAndVectorsToolStripMenuItem.Name = "LinesAndVectorsToolStripMenuItem"
    LinesAndVectorsToolStripMenuItem.Size = New Size(250, 34)
    LinesAndVectorsToolStripMenuItem.Text = "Lines and vectors"
    ' 
    ' PolygonsToolStripMenuItem
    ' 
    PolygonsToolStripMenuItem.Name = "PolygonsToolStripMenuItem"
    PolygonsToolStripMenuItem.Size = New Size(250, 34)
    PolygonsToolStripMenuItem.Text = "Polygons"
    ' 
    ' StatusStrip1
    ' 
    StatusStrip1.ImageScalingSize = New Size(24, 24)
    StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel1})
    StatusStrip1.Location = New Point(0, 660)
    StatusStrip1.Name = "StatusStrip1"
    StatusStrip1.Size = New Size(1134, 32)
    StatusStrip1.TabIndex = 3
    StatusStrip1.Text = "StatusStrip1"
    ' 
    ' ToolStripStatusLabel1
    ' 
    ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
    ToolStripStatusLabel1.Size = New Size(1119, 25)
    ToolStripStatusLabel1.Spring = True
    ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
    ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' MapView1
    ' 
    MapView1.BackColor = Color.Black
    MapView1.BlockSize = 0F
    MapView1.Location = New Point(0, 33)
    MapView1.Map = Nothing
    MapView1.Mode = Nothing
    MapView1.Name = "MapView1"
    MapView1.Size = New Size(800, 600)
    MapView1.TabIndex = 4
    ' 
    ' frmDebug
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(1134, 692)
    Controls.Add(MapView1)
    Controls.Add(StatusStrip1)
    Controls.Add(MenuStrip1)
    KeyPreview = True
    MainMenuStrip = MenuStrip1
    Name = "frmDebug"
    Text = "Debug"
    MenuStrip1.ResumeLayout(False)
    MenuStrip1.PerformLayout()
    StatusStrip1.ResumeLayout(False)
    StatusStrip1.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub
  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents LinesAndVectorsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents PolygonsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents OpenToolStripMenuItem1 As ToolStripMenuItem
  Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents PropertiesToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
  Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
  Friend WithEvents StatusStrip1 As StatusStrip
  Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
  Friend WithEvents MapView1 As MapView
End Class
