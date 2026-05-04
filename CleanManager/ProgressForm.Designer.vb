<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressForm))
        Me.CurrentItemLabel = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProgressDescriptionLabel = New System.Windows.Forms.Label()
        Me.TypeLabel = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CurrentItemLabel
        '
        Me.CurrentItemLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentItemLabel.Location = New System.Drawing.Point(82, 62)
        Me.CurrentItemLabel.Name = "CurrentItemLabel"
        Me.CurrentItemLabel.Size = New System.Drawing.Size(308, 15)
        Me.CurrentItemLabel.TabIndex = 0
        Me.CurrentItemLabel.Text = "%CurrentItem%"
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.Location = New System.Drawing.Point(12, 84)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(295, 21)
        Me.ProgressBar.TabIndex = 1
        '
        'QuitButton
        '
        Me.QuitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.QuitButton.Location = New System.Drawing.Point(317, 83)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 0
        Me.QuitButton.Text = "Cancel"
        Me.QuitButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.cleanmgrx.My.Resources.Resources.ProgressLogo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 41)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'ProgressDescriptionLabel
        '
        Me.ProgressDescriptionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressDescriptionLabel.Location = New System.Drawing.Point(60, 13)
        Me.ProgressDescriptionLabel.Name = "ProgressDescriptionLabel"
        Me.ProgressDescriptionLabel.Size = New System.Drawing.Size(333, 39)
        Me.ProgressDescriptionLabel.TabIndex = 4
        Me.ProgressDescriptionLabel.Text = "Files that are no longer required are deleted from the computer."
        '
        'TypeLabel
        '
        Me.TypeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.Location = New System.Drawing.Point(9, 62)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(51, 13)
        Me.TypeLabel.TabIndex = 5
        Me.TypeLabel.Text = "Cleaning:"
        '
        'ProgressForm
        '
        Me.AcceptButton = Me.QuitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.QuitButton
        Me.ClientSize = New System.Drawing.Size(402, 116)
        Me.ControlBox = False
        Me.Controls.Add(Me.CurrentItemLabel)
        Me.Controls.Add(Me.TypeLabel)
        Me.Controls.Add(Me.ProgressDescriptionLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.ProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProgressForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disk Cleanup X"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CurrentItemLabel As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents QuitButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ProgressDescriptionLabel As Label
    Friend WithEvents TypeLabel As Label
End Class
