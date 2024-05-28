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
    ModeToolStripMenuItem = New ToolStripMenuItem()
    VertexModeToolStripMenuItem = New ToolStripMenuItem()
    LinedefModeToolStripMenuItem = New ToolStripMenuItem()
    SectorModeToolStripMenuItem = New ToolStripMenuItem()
    TestToolStripMenuItem = New ToolStripMenuItem()
    LinesAndVectorsToolStripMenuItem = New ToolStripMenuItem()
    PolygonsToolStripMenuItem = New ToolStripMenuItem()
    mvView = New MapView()
    pnlStatus = New Panel()
    lblHelp = New Label()
    lblLayer = New Label()
    lblGridSize = New Label()
    lblMode = New Label()
    Panel1 = New Panel()
    ThingsModeToolStripMenuItem = New ToolStripMenuItem()
    MenuStrip1.SuspendLayout()
    pnlStatus.SuspendLayout()
    SuspendLayout()
    ' 
    ' MenuStrip1
    ' 
    MenuStrip1.BackColor = SystemColors.Control
    MenuStrip1.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    MenuStrip1.ImageScalingSize = New Size(24, 24)
    MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, EditToolStripMenuItem, ModeToolStripMenuItem, TestToolStripMenuItem})
    MenuStrip1.Location = New Point(0, 0)
    MenuStrip1.Name = "MenuStrip1"
    MenuStrip1.Padding = New Padding(4, 1, 0, 1)
    MenuStrip1.RenderMode = ToolStripRenderMode.System
    MenuStrip1.Size = New Size(794, 24)
    MenuStrip1.TabIndex = 2
    MenuStrip1.Text = "MenuStrip1"
    ' 
    ' FileToolStripMenuItem
    ' 
    FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {OpenToolStripMenuItem, OpenToolStripMenuItem1, SaveToolStripMenuItem, SaveAsToolStripMenuItem, PropertiesToolStripMenuItem, ToolStripSeparator2, ExitToolStripMenuItem})
    FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    FileToolStripMenuItem.Size = New Size(52, 22)
    FileToolStripMenuItem.Text = "File"
    ' 
    ' OpenToolStripMenuItem
    ' 
    OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
    OpenToolStripMenuItem.Size = New Size(180, 22)
    OpenToolStripMenuItem.Text = "New"
    ' 
    ' OpenToolStripMenuItem1
    ' 
    OpenToolStripMenuItem1.Name = "OpenToolStripMenuItem1"
    OpenToolStripMenuItem1.Size = New Size(180, 22)
    OpenToolStripMenuItem1.Text = "Open..."
    ' 
    ' SaveToolStripMenuItem
    ' 
    SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
    SaveToolStripMenuItem.Size = New Size(180, 22)
    SaveToolStripMenuItem.Text = "Save"
    ' 
    ' SaveAsToolStripMenuItem
    ' 
    SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
    SaveAsToolStripMenuItem.Size = New Size(180, 22)
    SaveAsToolStripMenuItem.Text = "Save as..."
    ' 
    ' PropertiesToolStripMenuItem
    ' 
    PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
    PropertiesToolStripMenuItem.Size = New Size(180, 22)
    PropertiesToolStripMenuItem.Text = "Properties..."
    ' 
    ' ToolStripSeparator2
    ' 
    ToolStripSeparator2.Name = "ToolStripSeparator2"
    ToolStripSeparator2.Size = New Size(177, 6)
    ' 
    ' ExitToolStripMenuItem
    ' 
    ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    ExitToolStripMenuItem.Size = New Size(180, 22)
    ExitToolStripMenuItem.Text = "Exit"
    ' 
    ' EditToolStripMenuItem
    ' 
    EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UndoToolStripMenuItem, RedoToolStripMenuItem, ToolStripSeparator1, CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem})
    EditToolStripMenuItem.Name = "EditToolStripMenuItem"
    EditToolStripMenuItem.Size = New Size(52, 22)
    EditToolStripMenuItem.Text = "Edit"
    ' 
    ' UndoToolStripMenuItem
    ' 
    UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
    UndoToolStripMenuItem.Size = New Size(116, 22)
    UndoToolStripMenuItem.Text = "Undo"
    ' 
    ' RedoToolStripMenuItem
    ' 
    RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
    RedoToolStripMenuItem.Size = New Size(116, 22)
    RedoToolStripMenuItem.Text = "Redo"
    ' 
    ' ToolStripSeparator1
    ' 
    ToolStripSeparator1.Name = "ToolStripSeparator1"
    ToolStripSeparator1.Size = New Size(113, 6)
    ' 
    ' CutToolStripMenuItem
    ' 
    CutToolStripMenuItem.Name = "CutToolStripMenuItem"
    CutToolStripMenuItem.Size = New Size(116, 22)
    CutToolStripMenuItem.Text = "Cut"
    ' 
    ' CopyToolStripMenuItem
    ' 
    CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
    CopyToolStripMenuItem.Size = New Size(116, 22)
    CopyToolStripMenuItem.Text = "Copy"
    ' 
    ' PasteToolStripMenuItem
    ' 
    PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
    PasteToolStripMenuItem.Size = New Size(116, 22)
    PasteToolStripMenuItem.Text = "Paste"
    ' 
    ' ModeToolStripMenuItem
    ' 
    ModeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {VertexModeToolStripMenuItem, LinedefModeToolStripMenuItem, SectorModeToolStripMenuItem, ThingsModeToolStripMenuItem})
    ModeToolStripMenuItem.Name = "ModeToolStripMenuItem"
    ModeToolStripMenuItem.Size = New Size(52, 22)
    ModeToolStripMenuItem.Text = "Mode"
    ' 
    ' VertexModeToolStripMenuItem
    ' 
    VertexModeToolStripMenuItem.Name = "VertexModeToolStripMenuItem"
    VertexModeToolStripMenuItem.Size = New Size(180, 22)
    VertexModeToolStripMenuItem.Text = "Vertex mode"
    ' 
    ' LinedefModeToolStripMenuItem
    ' 
    LinedefModeToolStripMenuItem.Name = "LinedefModeToolStripMenuItem"
    LinedefModeToolStripMenuItem.Size = New Size(180, 22)
    LinedefModeToolStripMenuItem.Text = "Linedef mode"
    ' 
    ' SectorModeToolStripMenuItem
    ' 
    SectorModeToolStripMenuItem.Name = "SectorModeToolStripMenuItem"
    SectorModeToolStripMenuItem.Size = New Size(180, 22)
    SectorModeToolStripMenuItem.Text = "Sector mode"
    ' 
    ' TestToolStripMenuItem
    ' 
    TestToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LinesAndVectorsToolStripMenuItem, PolygonsToolStripMenuItem})
    TestToolStripMenuItem.Name = "TestToolStripMenuItem"
    TestToolStripMenuItem.Size = New Size(52, 22)
    TestToolStripMenuItem.Text = "Test"
    TestToolStripMenuItem.Visible = False
    ' 
    ' LinesAndVectorsToolStripMenuItem
    ' 
    LinesAndVectorsToolStripMenuItem.Name = "LinesAndVectorsToolStripMenuItem"
    LinesAndVectorsToolStripMenuItem.Size = New Size(212, 22)
    LinesAndVectorsToolStripMenuItem.Text = "Lines and vectors"
    ' 
    ' PolygonsToolStripMenuItem
    ' 
    PolygonsToolStripMenuItem.Name = "PolygonsToolStripMenuItem"
    PolygonsToolStripMenuItem.Size = New Size(212, 22)
    PolygonsToolStripMenuItem.Text = "Polygons"
    ' 
    ' mvView
    ' 
    mvView.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0))
    mvView.Dock = DockStyle.Fill
    mvView.Location = New Point(0, 24)
    mvView.Map = Nothing
    mvView.Margin = New Padding(1, 1, 1, 1)
    mvView.Mode = Nothing
    mvView.Name = "mvView"
    mvView.Size = New Size(794, 269)
    mvView.TabIndex = 5
    ' 
    ' pnlStatus
    ' 
    pnlStatus.Controls.Add(lblHelp)
    pnlStatus.Controls.Add(lblLayer)
    pnlStatus.Controls.Add(lblGridSize)
    pnlStatus.Controls.Add(lblMode)
    pnlStatus.Controls.Add(Panel1)
    pnlStatus.Dock = DockStyle.Bottom
    pnlStatus.Font = New Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point)
    pnlStatus.Location = New Point(0, 293)
    pnlStatus.Margin = New Padding(2, 2, 2, 2)
    pnlStatus.Name = "pnlStatus"
    pnlStatus.Size = New Size(794, 122)
    pnlStatus.TabIndex = 6
    ' 
    ' lblHelp
    ' 
    lblHelp.Dock = DockStyle.Fill
    lblHelp.Location = New Point(0, 104)
    lblHelp.Margin = New Padding(2, 0, 2, 0)
    lblHelp.Name = "lblHelp"
    lblHelp.Size = New Size(388, 18)
    lblHelp.TabIndex = 4
    lblHelp.Text = "Label1"
    lblHelp.TextAlign = ContentAlignment.MiddleLeft
    ' 
    ' lblLayer
    ' 
    lblLayer.Dock = DockStyle.Right
    lblLayer.Location = New Point(388, 104)
    lblLayer.Margin = New Padding(2, 0, 2, 0)
    lblLayer.Name = "lblLayer"
    lblLayer.Size = New Size(165, 18)
    lblLayer.TabIndex = 3
    lblLayer.Text = "Layer"
    lblLayer.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' lblGridSize
    ' 
    lblGridSize.Dock = DockStyle.Right
    lblGridSize.Location = New Point(553, 104)
    lblGridSize.Margin = New Padding(2, 0, 2, 0)
    lblGridSize.Name = "lblGridSize"
    lblGridSize.Size = New Size(52, 18)
    lblGridSize.TabIndex = 2
    lblGridSize.Text = "BS"
    lblGridSize.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' lblMode
    ' 
    lblMode.Dock = DockStyle.Right
    lblMode.Location = New Point(605, 104)
    lblMode.Margin = New Padding(2, 0, 2, 0)
    lblMode.Name = "lblMode"
    lblMode.Size = New Size(189, 18)
    lblMode.TabIndex = 1
    lblMode.Text = "Mode"
    lblMode.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' Panel1
    ' 
    Panel1.Dock = DockStyle.Top
    Panel1.Location = New Point(0, 0)
    Panel1.Margin = New Padding(2, 2, 2, 2)
    Panel1.Name = "Panel1"
    Panel1.Size = New Size(794, 104)
    Panel1.TabIndex = 5
    ' 
    ' ThingsModeToolStripMenuItem
    ' 
    ThingsModeToolStripMenuItem.Name = "ThingsModeToolStripMenuItem"
    ThingsModeToolStripMenuItem.Size = New Size(180, 22)
    ThingsModeToolStripMenuItem.Text = "Things mode"
    ' 
    ' frmMain
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(794, 415)
    Controls.Add(mvView)
    Controls.Add(pnlStatus)
    Controls.Add(MenuStrip1)
    KeyPreview = True
    MainMenuStrip = MenuStrip1
    Margin = New Padding(2, 2, 2, 2)
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
  Friend WithEvents mvView As MapView
  Friend WithEvents pnlStatus As Panel
  Friend WithEvents Label1 As Label
  Friend WithEvents lblMode As Label
  Friend WithEvents lblHelp As Label
  Friend WithEvents lblLayer As Label
  Friend WithEvents lblGridSize As Label
  Friend WithEvents ModeToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents VertexModeToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents LinedefModeToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SectorModeToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents Panel1 As Panel
  Friend WithEvents ThingsModeToolStripMenuItem As ToolStripMenuItem
End Class
