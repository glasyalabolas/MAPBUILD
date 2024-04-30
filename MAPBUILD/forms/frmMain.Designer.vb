<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
    ssStatus = New StatusStrip()
    tsslHelp = New ToolStripStatusLabel()
    tsslLayer = New ToolStripStatusLabel()
    tsslBlockSize = New ToolStripStatusLabel()
    tsslMode = New ToolStripStatusLabel()
    pnlSide = New Panel()
    mvView = New MapView()
    MenuStrip1.SuspendLayout()
    ssStatus.SuspendLayout()
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
    ' ssStatus
    ' 
    ssStatus.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    ssStatus.ImageScalingSize = New Size(24, 24)
    ssStatus.Items.AddRange(New ToolStripItem() {tsslHelp, tsslLayer, tsslBlockSize, tsslMode})
    ssStatus.Location = New Point(0, 659)
    ssStatus.Name = "ssStatus"
    ssStatus.RenderMode = ToolStripRenderMode.ManagerRenderMode
    ssStatus.Size = New Size(1134, 33)
    ssStatus.SizingGrip = False
    ssStatus.TabIndex = 3
    ssStatus.Text = "StatusStrip1"
    ' 
    ' tsslHelp
    ' 
    tsslHelp.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    tsslHelp.Name = "tsslHelp"
    tsslHelp.Size = New Size(613, 26)
    tsslHelp.Spring = True
    tsslHelp.Text = "Help"
    tsslHelp.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' tsslLayer
    ' 
    tsslLayer.AutoSize = False
    tsslLayer.Name = "tsslLayer"
    tsslLayer.Size = New Size(220, 26)
    tsslLayer.Text = "Layer"
    ' 
    ' tsslBlockSize
    ' 
    tsslBlockSize.Name = "tsslBlockSize"
    tsslBlockSize.Size = New Size(120, 26)
    tsslBlockSize.Text = "BlockSize"
    ' 
    ' tsslMode
    ' 
    tsslMode.AutoSize = False
    tsslMode.Name = "tsslMode"
    tsslMode.Size = New Size(120, 26)
    tsslMode.Text = "Mode"
    ' 
    ' pnlSide
    ' 
    pnlSide.Dock = DockStyle.Right
    pnlSide.Location = New Point(834, 33)
    pnlSide.Name = "pnlSide"
    pnlSide.Size = New Size(300, 626)
    pnlSide.TabIndex = 4
    ' 
    ' mvView
    ' 
    mvView.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0))
    mvView.Dock = DockStyle.Fill
    mvView.Location = New Point(0, 33)
    mvView.Map = Nothing
    mvView.Mode = Nothing
    mvView.Name = "mvView"
    mvView.Size = New Size(834, 626)
    mvView.TabIndex = 5
    ' 
    ' frmMain
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(1134, 692)
    Controls.Add(mvView)
    Controls.Add(pnlSide)
    Controls.Add(ssStatus)
    Controls.Add(MenuStrip1)
    KeyPreview = True
    MainMenuStrip = MenuStrip1
    Name = "frmMain"
    Text = "Debug"
    WindowState = FormWindowState.Maximized
    MenuStrip1.ResumeLayout(False)
    MenuStrip1.PerformLayout()
    ssStatus.ResumeLayout(False)
    ssStatus.PerformLayout()
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
  Friend WithEvents ssStatus As StatusStrip
  Friend WithEvents tsslHelp As ToolStripStatusLabel
  Friend WithEvents pnlSide As Panel
  Friend WithEvents mvView As MapView
  Friend WithEvents tsslBlockSize As ToolStripStatusLabel
  Friend WithEvents tsslMode As ToolStripStatusLabel
  Friend WithEvents tsslLayer As ToolStripStatusLabel
End Class
