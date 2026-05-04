<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpForm))
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pDescriptionLabel = New System.Windows.Forms.Label()
        Me.ProfileDescriptionLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mDescriptionLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rDescriptionLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.sDescriptionLabel = New System.Windows.Forms.Label()
        Me.ExampleLabel = New System.Windows.Forms.Label()
        Me.Logo = New System.Windows.Forms.PictureBox()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DescriptionLabel.Location = New System.Drawing.Point(55, 13)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(335, 34)
        Me.DescriptionLabel.TabIndex = 6
        Me.DescriptionLabel.Text = "The following start parameters are available:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "-p:[N]"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "-"
        '
        'pDescriptionLabel
        '
        Me.pDescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pDescriptionLabel.AutoSize = True
        Me.pDescriptionLabel.Location = New System.Drawing.Point(163, 73)
        Me.pDescriptionLabel.Name = "pDescriptionLabel"
        Me.pDescriptionLabel.Size = New System.Drawing.Size(121, 13)
        Me.pDescriptionLabel.TabIndex = 9
        Me.pDescriptionLabel.Text = "Select predefined profile"
        '
        'ProfileDescriptionLabel
        '
        Me.ProfileDescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProfileDescriptionLabel.AutoSize = True
        Me.ProfileDescriptionLabel.Location = New System.Drawing.Point(163, 86)
        Me.ProfileDescriptionLabel.Name = "ProfileDescriptionLabel"
        Me.ProfileDescriptionLabel.Size = New System.Drawing.Size(179, 13)
        Me.ProfileDescriptionLabel.TabIndex = 10
        Me.ProfileDescriptionLabel.Text = "[2 - Thorough, 3 - Aggressive, 4 - All]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "-m"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(154, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "-"
        '
        'mDescriptionLabel
        '
        Me.mDescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mDescriptionLabel.AutoSize = True
        Me.mDescriptionLabel.Location = New System.Drawing.Point(163, 47)
        Me.mDescriptionLabel.Name = "mDescriptionLabel"
        Me.mDescriptionLabel.Size = New System.Drawing.Size(71, 13)
        Me.mDescriptionLabel.TabIndex = 13
        Me.mDescriptionLabel.Text = "Minimal mode"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(55, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "-r"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(154, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "-"
        '
        'rDescriptionLabel
        '
        Me.rDescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rDescriptionLabel.AutoSize = True
        Me.rDescriptionLabel.Location = New System.Drawing.Point(163, 112)
        Me.rDescriptionLabel.Name = "rDescriptionLabel"
        Me.rDescriptionLabel.Size = New System.Drawing.Size(93, 13)
        Me.rDescriptionLabel.TabIndex = 18
        Me.rDescriptionLabel.Text = "Reboot after finish"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(55, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "-s"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(154, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "-"
        '
        'sDescriptionLabel
        '
        Me.sDescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sDescriptionLabel.AutoSize = True
        Me.sDescriptionLabel.Location = New System.Drawing.Point(163, 138)
        Me.sDescriptionLabel.Name = "sDescriptionLabel"
        Me.sDescriptionLabel.Size = New System.Drawing.Size(106, 13)
        Me.sDescriptionLabel.TabIndex = 22
        Me.sDescriptionLabel.Text = "Shutdown after finish"
        '
        'ExampleLabel
        '
        Me.ExampleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExampleLabel.AutoSize = True
        Me.ExampleLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.ExampleLabel.Location = New System.Drawing.Point(55, 164)
        Me.ExampleLabel.Name = "ExampleLabel"
        Me.ExampleLabel.Size = New System.Drawing.Size(167, 13)
        Me.ExampleLabel.TabIndex = 23
        Me.ExampleLabel.Text = "Example: cleanmgrx.exe -m -p:2 -s"
        '
        'Logo
        '
        Me.Logo.Image = Global.cleanmgrx.My.Resources.Resources.DriveLogoNA
        Me.Logo.Location = New System.Drawing.Point(9, 7)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(40, 40)
        Me.Logo.TabIndex = 5
        Me.Logo.TabStop = False
        '
        'HelpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 188)
        Me.Controls.Add(Me.ExampleLabel)
        Me.Controls.Add(Me.sDescriptionLabel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rDescriptionLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.mDescriptionLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProfileDescriptionLabel)
        Me.Controls.Add(Me.pDescriptionLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HelpForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disk Cleanup X"
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Logo As PictureBox
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pDescriptionLabel As Label
    Friend WithEvents ProfileDescriptionLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents mDescriptionLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents rDescriptionLabel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents sDescriptionLabel As Label
    Friend WithEvents ExampleLabel As Label
End Class
