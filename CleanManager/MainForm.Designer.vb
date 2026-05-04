<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.WindowsList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MarkAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrashDumpsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrashReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PipelineCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShaderCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemporaryFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnmarkAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CacheToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrashDumpsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrashReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PipelineCacheToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShaderCacheToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemporaryFilesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResetToDefaultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PresetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThoroughToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AggressiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinishingActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RebootToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DeepCleanList = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.JunkwareList = New System.Windows.Forms.ListView()
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader41 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader42 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GamesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SavegamesList = New System.Windows.Forms.ListView()
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.UnrealEngineList = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalFreeLabel = New System.Windows.Forms.Label()
        Me.FilesToDeleteLabel = New System.Windows.Forms.Label()
        Me.TotalAmountSavedDescriptionLabel = New System.Windows.Forms.Label()
        Me.TotalAmountSavedValueLabel = New System.Windows.Forms.Label()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.FilesToDeleteValueLabel = New System.Windows.Forms.Label()
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.AdminModePanel = New System.Windows.Forms.Panel()
        Me.AdminModeLabel = New System.Windows.Forms.Label()
        Me.ListContextMenu.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WindowsList
        '
        Me.WindowsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WindowsList.CheckBoxes = True
        Me.WindowsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader18, Me.ColumnHeader25})
        Me.WindowsList.ContextMenuStrip = Me.ListContextMenu
        Me.WindowsList.FullRowSelect = True
        Me.WindowsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.WindowsList.HideSelection = False
        Me.WindowsList.Location = New System.Drawing.Point(0, 0)
        Me.WindowsList.Name = "WindowsList"
        Me.WindowsList.ShowGroups = False
        Me.WindowsList.Size = New System.Drawing.Size(378, 275)
        Me.WindowsList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.WindowsList.TabIndex = 1
        Me.WindowsList.UseCompatibleStateImageBehavior = False
        Me.WindowsList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 287
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 69
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Width = 0
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Width = 0
        '
        'ListContextMenu
        '
        Me.ListContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowFilesToolStripMenuItem, Me.ToolStripSeparator2, Me.MarkAllToolStripMenuItem, Me.UnmarkAllToolStripMenuItem, Me.ToolStripSeparator1, Me.ResetToDefaultsToolStripMenuItem, Me.ToolStripSeparator3, Me.PresetsToolStripMenuItem, Me.FinishingActionToolStripMenuItem})
        Me.ListContextMenu.Name = "ListContextMenu"
        Me.ListContextMenu.Size = New System.Drawing.Size(164, 154)
        '
        'ShowFilesToolStripMenuItem
        '
        Me.ShowFilesToolStripMenuItem.Name = "ShowFilesToolStripMenuItem"
        Me.ShowFilesToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ShowFilesToolStripMenuItem.Text = "Show Files..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(160, 6)
        '
        'MarkAllToolStripMenuItem
        '
        Me.MarkAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CacheToolStripMenuItem, Me.CrashDumpsToolStripMenuItem, Me.CrashReportsToolStripMenuItem, Me.LogsToolStripMenuItem, Me.PipelineCacheToolStripMenuItem, Me.ShaderCacheToolStripMenuItem, Me.TemporaryFilesToolStripMenuItem})
        Me.MarkAllToolStripMenuItem.Name = "MarkAllToolStripMenuItem"
        Me.MarkAllToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.MarkAllToolStripMenuItem.Text = "Mark All"
        '
        'CacheToolStripMenuItem
        '
        Me.CacheToolStripMenuItem.Name = "CacheToolStripMenuItem"
        Me.CacheToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CacheToolStripMenuItem.Text = "Cache"
        '
        'CrashDumpsToolStripMenuItem
        '
        Me.CrashDumpsToolStripMenuItem.Name = "CrashDumpsToolStripMenuItem"
        Me.CrashDumpsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CrashDumpsToolStripMenuItem.Text = "Crash Dumps"
        '
        'CrashReportsToolStripMenuItem
        '
        Me.CrashReportsToolStripMenuItem.Name = "CrashReportsToolStripMenuItem"
        Me.CrashReportsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CrashReportsToolStripMenuItem.Text = "Crash Reports"
        '
        'LogsToolStripMenuItem
        '
        Me.LogsToolStripMenuItem.Name = "LogsToolStripMenuItem"
        Me.LogsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.LogsToolStripMenuItem.Text = "Logs"
        '
        'PipelineCacheToolStripMenuItem
        '
        Me.PipelineCacheToolStripMenuItem.Name = "PipelineCacheToolStripMenuItem"
        Me.PipelineCacheToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PipelineCacheToolStripMenuItem.Text = "Pipeline Cache"
        '
        'ShaderCacheToolStripMenuItem
        '
        Me.ShaderCacheToolStripMenuItem.Name = "ShaderCacheToolStripMenuItem"
        Me.ShaderCacheToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ShaderCacheToolStripMenuItem.Text = "Shader Cache"
        '
        'TemporaryFilesToolStripMenuItem
        '
        Me.TemporaryFilesToolStripMenuItem.Name = "TemporaryFilesToolStripMenuItem"
        Me.TemporaryFilesToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.TemporaryFilesToolStripMenuItem.Text = "Temporary Files"
        '
        'UnmarkAllToolStripMenuItem
        '
        Me.UnmarkAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CacheToolStripMenuItem1, Me.CrashDumpsToolStripMenuItem1, Me.CrashReportsToolStripMenuItem1, Me.LogsToolStripMenuItem1, Me.PipelineCacheToolStripMenuItem1, Me.ShaderCacheToolStripMenuItem1, Me.TemporaryFilesToolStripMenuItem1})
        Me.UnmarkAllToolStripMenuItem.Name = "UnmarkAllToolStripMenuItem"
        Me.UnmarkAllToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.UnmarkAllToolStripMenuItem.Text = "Unmark All"
        '
        'CacheToolStripMenuItem1
        '
        Me.CacheToolStripMenuItem1.Name = "CacheToolStripMenuItem1"
        Me.CacheToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.CacheToolStripMenuItem1.Text = "Cache"
        '
        'CrashDumpsToolStripMenuItem1
        '
        Me.CrashDumpsToolStripMenuItem1.Name = "CrashDumpsToolStripMenuItem1"
        Me.CrashDumpsToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.CrashDumpsToolStripMenuItem1.Text = "Crash Dumps"
        '
        'CrashReportsToolStripMenuItem1
        '
        Me.CrashReportsToolStripMenuItem1.Name = "CrashReportsToolStripMenuItem1"
        Me.CrashReportsToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.CrashReportsToolStripMenuItem1.Text = "Crash Reports"
        '
        'LogsToolStripMenuItem1
        '
        Me.LogsToolStripMenuItem1.Name = "LogsToolStripMenuItem1"
        Me.LogsToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.LogsToolStripMenuItem1.Text = "Logs"
        '
        'PipelineCacheToolStripMenuItem1
        '
        Me.PipelineCacheToolStripMenuItem1.Name = "PipelineCacheToolStripMenuItem1"
        Me.PipelineCacheToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.PipelineCacheToolStripMenuItem1.Text = "Pipeline Cache"
        '
        'ShaderCacheToolStripMenuItem1
        '
        Me.ShaderCacheToolStripMenuItem1.Name = "ShaderCacheToolStripMenuItem1"
        Me.ShaderCacheToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.ShaderCacheToolStripMenuItem1.Text = "Shader Cache"
        '
        'TemporaryFilesToolStripMenuItem1
        '
        Me.TemporaryFilesToolStripMenuItem1.Name = "TemporaryFilesToolStripMenuItem1"
        Me.TemporaryFilesToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.TemporaryFilesToolStripMenuItem1.Text = "Temporary Files"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(160, 6)
        '
        'ResetToDefaultsToolStripMenuItem
        '
        Me.ResetToDefaultsToolStripMenuItem.Name = "ResetToDefaultsToolStripMenuItem"
        Me.ResetToDefaultsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ResetToDefaultsToolStripMenuItem.Text = "Reset To Defaults"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(160, 6)
        '
        'PresetsToolStripMenuItem
        '
        Me.PresetsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultToolStripMenuItem, Me.ThoroughToolStripMenuItem, Me.AggressiveToolStripMenuItem, Me.AllToolStripMenuItem})
        Me.PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem"
        Me.PresetsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.PresetsToolStripMenuItem.Text = "Presets"
        '
        'DefaultToolStripMenuItem
        '
        Me.DefaultToolStripMenuItem.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.DefaultToolStripMenuItem.Name = "DefaultToolStripMenuItem"
        Me.DefaultToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.DefaultToolStripMenuItem.Text = "Default"
        '
        'ThoroughToolStripMenuItem
        '
        Me.ThoroughToolStripMenuItem.ForeColor = System.Drawing.Color.Salmon
        Me.ThoroughToolStripMenuItem.Name = "ThoroughToolStripMenuItem"
        Me.ThoroughToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ThoroughToolStripMenuItem.Text = "Thorough"
        '
        'AggressiveToolStripMenuItem
        '
        Me.AggressiveToolStripMenuItem.ForeColor = System.Drawing.Color.IndianRed
        Me.AggressiveToolStripMenuItem.Name = "AggressiveToolStripMenuItem"
        Me.AggressiveToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.AggressiveToolStripMenuItem.Text = "Aggressive"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.ForeColor = System.Drawing.Color.IndianRed
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'FinishingActionToolStripMenuItem
        '
        Me.FinishingActionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.ToolStripSeparator4, Me.ShutdownToolStripMenuItem, Me.RebootToolStripMenuItem})
        Me.FinishingActionToolStripMenuItem.Name = "FinishingActionToolStripMenuItem"
        Me.FinishingActionToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.FinishingActionToolStripMenuItem.Text = "Finishing Action"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Checked = True
        Me.CloseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(125, 6)
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ShutdownToolStripMenuItem.Text = "Shutdown"
        '
        'RebootToolStripMenuItem
        '
        Me.RebootToolStripMenuItem.Name = "RebootToolStripMenuItem"
        Me.RebootToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RebootToolStripMenuItem.Text = "Reboot"
        '
        'MainTabControl
        '
        Me.MainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTabControl.Controls.Add(Me.TabPage1)
        Me.MainTabControl.Controls.Add(Me.TabPage2)
        Me.MainTabControl.Controls.Add(Me.TabPage6)
        Me.MainTabControl.Controls.Add(Me.TabPage4)
        Me.MainTabControl.Controls.Add(Me.TabPage5)
        Me.MainTabControl.Controls.Add(Me.TabPage3)
        Me.MainTabControl.Location = New System.Drawing.Point(8, 52)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(386, 301)
        Me.MainTabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.WindowsList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(378, 275)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Windows"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DeepCleanList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(378, 275)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Deep Clean"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DeepCleanList
        '
        Me.DeepCleanList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeepCleanList.CheckBoxes = True
        Me.DeepCleanList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader11, Me.ColumnHeader14, Me.ColumnHeader17, Me.ColumnHeader26})
        Me.DeepCleanList.ContextMenuStrip = Me.ListContextMenu
        Me.DeepCleanList.FullRowSelect = True
        Me.DeepCleanList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.DeepCleanList.HideSelection = False
        Me.DeepCleanList.Location = New System.Drawing.Point(0, 0)
        Me.DeepCleanList.Name = "DeepCleanList"
        Me.DeepCleanList.ShowGroups = False
        Me.DeepCleanList.Size = New System.Drawing.Size(378, 275)
        Me.DeepCleanList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.DeepCleanList.TabIndex = 2
        Me.DeepCleanList.UseCompatibleStateImageBehavior = False
        Me.DeepCleanList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 287
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 69
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Width = 0
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Width = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.JunkwareList)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(378, 275)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Junkware"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'JunkwareList
        '
        Me.JunkwareList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JunkwareList.CheckBoxes = True
        Me.JunkwareList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader39, Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader42})
        Me.JunkwareList.ContextMenuStrip = Me.ListContextMenu
        Me.JunkwareList.FullRowSelect = True
        Me.JunkwareList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.JunkwareList.HideSelection = False
        Me.JunkwareList.Location = New System.Drawing.Point(0, 0)
        Me.JunkwareList.Name = "JunkwareList"
        Me.JunkwareList.ShowGroups = False
        Me.JunkwareList.Size = New System.Drawing.Size(378, 275)
        Me.JunkwareList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.JunkwareList.TabIndex = 3
        Me.JunkwareList.UseCompatibleStateImageBehavior = False
        Me.JunkwareList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Width = 287
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader37.Width = 69
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Width = 0
        '
        'ColumnHeader39
        '
        Me.ColumnHeader39.Width = 0
        '
        'ColumnHeader40
        '
        Me.ColumnHeader40.Width = 0
        '
        'ColumnHeader41
        '
        Me.ColumnHeader41.Width = 0
        '
        'ColumnHeader42
        '
        Me.ColumnHeader42.Width = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GamesList)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(378, 275)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Games"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GamesList
        '
        Me.GamesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GamesList.CheckBoxes = True
        Me.GamesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader27})
        Me.GamesList.ContextMenuStrip = Me.ListContextMenu
        Me.GamesList.FullRowSelect = True
        Me.GamesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.GamesList.HideSelection = False
        Me.GamesList.Location = New System.Drawing.Point(0, 0)
        Me.GamesList.Name = "GamesList"
        Me.GamesList.ShowGroups = False
        Me.GamesList.Size = New System.Drawing.Size(378, 275)
        Me.GamesList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.GamesList.TabIndex = 4
        Me.GamesList.UseCompatibleStateImageBehavior = False
        Me.GamesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Width = 287
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader20.Width = 69
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Width = 0
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Width = 0
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Width = 0
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Width = 0
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Width = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SavegamesList)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(378, 275)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Savegames"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'SavegamesList
        '
        Me.SavegamesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SavegamesList.CheckBoxes = True
        Me.SavegamesList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34, Me.ColumnHeader35})
        Me.SavegamesList.ContextMenuStrip = Me.ListContextMenu
        Me.SavegamesList.FullRowSelect = True
        Me.SavegamesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.SavegamesList.HideSelection = False
        Me.SavegamesList.Location = New System.Drawing.Point(0, 0)
        Me.SavegamesList.Name = "SavegamesList"
        Me.SavegamesList.ShowGroups = False
        Me.SavegamesList.Size = New System.Drawing.Size(378, 275)
        Me.SavegamesList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.SavegamesList.TabIndex = 5
        Me.SavegamesList.UseCompatibleStateImageBehavior = False
        Me.SavegamesList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Width = 287
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader30.Width = 69
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Width = 0
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Width = 0
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Width = 0
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Width = 0
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Width = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.UnrealEngineList)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(378, 275)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Unreal Engine"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'UnrealEngineList
        '
        Me.UnrealEngineList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UnrealEngineList.CheckBoxes = True
        Me.UnrealEngineList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader28})
        Me.UnrealEngineList.ContextMenuStrip = Me.ListContextMenu
        Me.UnrealEngineList.FullRowSelect = True
        Me.UnrealEngineList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.UnrealEngineList.HideSelection = False
        Me.UnrealEngineList.Location = New System.Drawing.Point(0, 0)
        Me.UnrealEngineList.Name = "UnrealEngineList"
        Me.UnrealEngineList.ShowGroups = False
        Me.UnrealEngineList.Size = New System.Drawing.Size(378, 275)
        Me.UnrealEngineList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.UnrealEngineList.TabIndex = 6
        Me.UnrealEngineList.UseCompatibleStateImageBehavior = False
        Me.UnrealEngineList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Width = 287
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 69
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Width = 0
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Width = 0
        '
        'TotalFreeLabel
        '
        Me.TotalFreeLabel.Location = New System.Drawing.Point(55, 13)
        Me.TotalFreeLabel.Name = "TotalFreeLabel"
        Me.TotalFreeLabel.Size = New System.Drawing.Size(305, 34)
        Me.TotalFreeLabel.TabIndex = 2
        Me.TotalFreeLabel.Text = "You can use Disk Cleanup X to free up to X of disk space."
        '
        'FilesToDeleteLabel
        '
        Me.FilesToDeleteLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FilesToDeleteLabel.AutoSize = True
        Me.FilesToDeleteLabel.Location = New System.Drawing.Point(8, 358)
        Me.FilesToDeleteLabel.Name = "FilesToDeleteLabel"
        Me.FilesToDeleteLabel.Size = New System.Drawing.Size(75, 13)
        Me.FilesToDeleteLabel.TabIndex = 3
        Me.FilesToDeleteLabel.Text = "Files to delete:"
        '
        'TotalAmountSavedDescriptionLabel
        '
        Me.TotalAmountSavedDescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalAmountSavedDescriptionLabel.AutoSize = True
        Me.TotalAmountSavedDescriptionLabel.Location = New System.Drawing.Point(8, 377)
        Me.TotalAmountSavedDescriptionLabel.Name = "TotalAmountSavedDescriptionLabel"
        Me.TotalAmountSavedDescriptionLabel.Size = New System.Drawing.Size(173, 13)
        Me.TotalAmountSavedDescriptionLabel.TabIndex = 5
        Me.TotalAmountSavedDescriptionLabel.Text = "Total amount of disk space gained:"
        '
        'TotalAmountSavedValueLabel
        '
        Me.TotalAmountSavedValueLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalAmountSavedValueLabel.Location = New System.Drawing.Point(292, 377)
        Me.TotalAmountSavedValueLabel.Name = "TotalAmountSavedValueLabel"
        Me.TotalAmountSavedValueLabel.Size = New System.Drawing.Size(100, 13)
        Me.TotalAmountSavedValueLabel.TabIndex = 6
        Me.TotalAmountSavedValueLabel.Text = "0 Bytes"
        Me.TotalAmountSavedValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Location = New System.Drawing.Point(238, 399)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 8
        Me.StartButton.Text = "OK"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'QuitButton
        '
        Me.QuitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.QuitButton.Location = New System.Drawing.Point(319, 399)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 7
        Me.QuitButton.Text = "Cancel"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'FilesToDeleteValueLabel
        '
        Me.FilesToDeleteValueLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilesToDeleteValueLabel.Location = New System.Drawing.Point(292, 358)
        Me.FilesToDeleteValueLabel.Name = "FilesToDeleteValueLabel"
        Me.FilesToDeleteValueLabel.Size = New System.Drawing.Size(100, 13)
        Me.FilesToDeleteValueLabel.TabIndex = 9
        Me.FilesToDeleteValueLabel.Text = "0"
        Me.FilesToDeleteValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Logo
        '
        Me.Logo.Image = Global.cleanmgrx.My.Resources.Resources.DriveLogoNA
        Me.Logo.Location = New System.Drawing.Point(9, 7)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(40, 40)
        Me.Logo.TabIndex = 4
        Me.Logo.TabStop = False
        '
        'AdminModePanel
        '
        Me.AdminModePanel.BackColor = System.Drawing.Color.Black
        Me.AdminModePanel.Location = New System.Drawing.Point(10, 403)
        Me.AdminModePanel.Name = "AdminModePanel"
        Me.AdminModePanel.Size = New System.Drawing.Size(220, 15)
        Me.AdminModePanel.TabIndex = 11
        Me.AdminModePanel.Visible = False
        '
        'AdminModeLabel
        '
        Me.AdminModeLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdminModeLabel.BackColor = System.Drawing.Color.LightCoral
        Me.AdminModeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdminModeLabel.ForeColor = System.Drawing.Color.IndianRed
        Me.AdminModeLabel.Location = New System.Drawing.Point(11, 404)
        Me.AdminModeLabel.Name = "AdminModeLabel"
        Me.AdminModeLabel.Size = New System.Drawing.Size(218, 13)
        Me.AdminModeLabel.TabIndex = 10
        Me.AdminModeLabel.Text = "ADMINISTRATOR MODE"
        Me.AdminModeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.AdminModeLabel.Visible = False
        '
        'MainForm
        '
        Me.AcceptButton = Me.StartButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.QuitButton
        Me.ClientSize = New System.Drawing.Size(402, 430)
        Me.Controls.Add(Me.AdminModeLabel)
        Me.Controls.Add(Me.FilesToDeleteValueLabel)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.TotalAmountSavedValueLabel)
        Me.Controls.Add(Me.TotalAmountSavedDescriptionLabel)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.FilesToDeleteLabel)
        Me.Controls.Add(Me.TotalFreeLabel)
        Me.Controls.Add(Me.MainTabControl)
        Me.Controls.Add(Me.AdminModePanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(392, 473)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disk Cleanup X"
        Me.ListContextMenu.ResumeLayout(False)
        Me.MainTabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WindowsList As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DeepCleanList As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents TotalFreeLabel As Label
    Friend WithEvents FilesToDeleteLabel As Label
    Friend WithEvents Logo As PictureBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents UnrealEngineList As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents TotalAmountSavedDescriptionLabel As Label
    Friend WithEvents TotalAmountSavedValueLabel As Label
    Friend WithEvents StartButton As Button
    Friend WithEvents QuitButton As Button
    Friend WithEvents ListContextMenu As ContextMenuStrip
    Friend WithEvents MarkAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnmarkAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ResetToDefaultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GamesList As ListView
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents ShowFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents PipelineCacheToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShaderCacheToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TemporaryFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PipelineCacheToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ShaderCacheToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TemporaryFilesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LogsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CacheToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CacheToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CrashDumpsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrashDumpsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CrashReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrashReportsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents FinishingActionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RebootToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents PresetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DefaultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ThoroughToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AggressiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents FilesToDeleteValueLabel As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents SavegamesList As ListView
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents ColumnHeader32 As ColumnHeader
    Friend WithEvents ColumnHeader33 As ColumnHeader
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents ColumnHeader35 As ColumnHeader
    Friend WithEvents AdminModePanel As Panel
    Friend WithEvents AdminModeLabel As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents JunkwareList As ListView
    Friend WithEvents ColumnHeader36 As ColumnHeader
    Friend WithEvents ColumnHeader37 As ColumnHeader
    Friend WithEvents ColumnHeader38 As ColumnHeader
    Friend WithEvents ColumnHeader39 As ColumnHeader
    Friend WithEvents ColumnHeader40 As ColumnHeader
    Friend WithEvents ColumnHeader41 As ColumnHeader
    Friend WithEvents ColumnHeader42 As ColumnHeader
End Class
