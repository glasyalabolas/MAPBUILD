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
    pnlSide = New Panel()
    mvView = New MapView()
    pnlStatus = New Panel()
    lblHelp = New Label()
    lblLayer = New Label()
    lblBlockSize = New Label()
    lblMode = New Label()
    MenuStrip1.SuspendLayout()
    pnlStatus.SuspendLayout()
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
    ' pnlSide
    ' 
    pnlSide.Dock = DockStyle.Right
    pnlSide.Location = New Point(855, 33)
    pnlSide.Name = "pnlSide"
    pnlSide.Size = New Size(279, 626)
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
    mvView.Size = New Size(855, 626)
    mvView.TabIndex = 5
    ' 
    ' pnlStatus
    ' 
    pnlStatus.Controls.Add(lblHelp)
    pnlStatus.Controls.Add(lblLayer)
    pnlStatus.Controls.Add(lblBlockSize)
    pnlStatus.Controls.Add(lblMode)
    pnlStatus.Dock = DockStyle.Bottom
    pnlStatus.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    pnlStatus.Location = New Point(0, 659)
    pnlStatus.Name = "pnlStatus"
    pnlStatus.Size = New Size(1134, 33)
    pnlStatus.TabIndex = 6
    ' 
    ' lblHelp
    ' 
    lblHelp.Dock = DockStyle.Fill
    lblHelp.Location = New Point(0, 0)
    lblHelp.Name = "lblHelp"
    lblHelp.Size = New Size(554, 33)
    lblHelp.TabIndex = 4
    lblHelp.Text = "Label1"
    lblHelp.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' lblLayer
    ' 
    lblLayer.Dock = DockStyle.Right
    lblLayer.Location = New Point(554, 0)
    lblLayer.Name = "lblLayer"
    lblLayer.Size = New Size(236, 33)
    lblLayer.TabIndex = 3
    lblLayer.Text = "Layer"
    lblLayer.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' lblBlockSize
    ' 
    lblBlockSize.Dock = DockStyle.Right
    lblBlockSize.Location = New Point(790, 0)
    lblBlockSize.Name = "lblBlockSize"
    lblBlockSize.Size = New Size(74, 33)
    lblBlockSize.TabIndex = 2
    lblBlockSize.Text = "BS"
    lblBlockSize.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' lblMode
    ' 
    lblMode.Dock = DockStyle.Right
    lblMode.Location = New Point(864, 0)
    lblMode.Name = "lblMode"
    lblMode.Size = New Size(270, 33)
    lblMode.TabIndex = 1
    lblMode.Text = "Mode"
    lblMode.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' frmMain
    ' 
    AutoScaleDimensions = New SizeF(10F, 25F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(1134, 692)
    Controls.Add(mvView)
    Controls.Add(pnlSide)
    Controls.Add(pnlStatus)
    Controls.Add(MenuStrip1)
    KeyPreview = True
    MainMenuStrip = MenuStrip1
    Name = "frmMain"
    Text = "Debug"
    WindowState = FormWindowState.Maximized
    MenuStrip1.ResumeLayout(False)
    MenuStrip1.PerformLayout()
    pnlStatus.ResumeLayout(False)
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
  Friend WithEvents pnlSide As Panel
  Friend WithEvents mvView As MapView
  Friend WithEvents pnlStatus As Panel
  Friend WithEvents Label1 As Label
  Friend WithEvents lblMode As Label
  Friend WithEvents lblHelp As Label
  Friend WithEvents lblLayer As Label
  Friend WithEvents lblBlockSize As Label
End Class
