<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btn_Launch = New System.Windows.Forms.Button()
        Me.Text_Display_Gui = New System.Windows.Forms.Label()
        Me.btn_credits = New System.Windows.Forms.Button()
        Me.btn_changelog = New System.Windows.Forms.Button()
        Me.lbl_creator_credits = New System.Windows.Forms.Label()
        Me.changelog_text = New System.Windows.Forms.Label()
        Me.changelog_bbox = New System.Windows.Forms.PictureBox()
        CType(Me.changelog_bbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Launch
        '
        Me.btn_Launch.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.btn_Launch.Enabled = False
        Me.btn_Launch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_Launch.ForeColor = System.Drawing.SystemColors.InfoText
        Me.btn_Launch.Location = New System.Drawing.Point(642, 381)
        Me.btn_Launch.Name = "btn_Launch"
        Me.btn_Launch.Size = New System.Drawing.Size(146, 57)
        Me.btn_Launch.TabIndex = 0
        Me.btn_Launch.Text = "Launch"
        Me.btn_Launch.UseVisualStyleBackColor = False
        '
        'Text_Display_Gui
        '
        Me.Text_Display_Gui.AutoSize = True
        Me.Text_Display_Gui.Location = New System.Drawing.Point(12, 9)
        Me.Text_Display_Gui.Name = "Text_Display_Gui"
        Me.Text_Display_Gui.Size = New System.Drawing.Size(193, 13)
        Me.Text_Display_Gui.TabIndex = 1
        Me.Text_Display_Gui.Text = "Attempting to check for Network Status"
        '
        'btn_credits
        '
        Me.btn_credits.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_credits.Location = New System.Drawing.Point(660, 12)
        Me.btn_credits.Name = "btn_credits"
        Me.btn_credits.Size = New System.Drawing.Size(128, 32)
        Me.btn_credits.TabIndex = 2
        Me.btn_credits.Text = "Credits/Mods"
        Me.btn_credits.UseVisualStyleBackColor = True
        '
        'btn_changelog
        '
        Me.btn_changelog.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_changelog.Location = New System.Drawing.Point(660, 50)
        Me.btn_changelog.Name = "btn_changelog"
        Me.btn_changelog.Size = New System.Drawing.Size(128, 32)
        Me.btn_changelog.TabIndex = 3
        Me.btn_changelog.Text = "Change Log"
        Me.btn_changelog.UseVisualStyleBackColor = True
        '
        'lbl_creator_credits
        '
        Me.lbl_creator_credits.AutoSize = True
        Me.lbl_creator_credits.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lbl_creator_credits.Location = New System.Drawing.Point(12, 390)
        Me.lbl_creator_credits.Name = "lbl_creator_credits"
        Me.lbl_creator_credits.Size = New System.Drawing.Size(329, 13)
        Me.lbl_creator_credits.TabIndex = 4
        Me.lbl_creator_credits.Text = "Modpack Compiled by: Kate 'BurgundyPetal' H. and Avvy 'ItAvvy' D."
        '
        'changelog_text
        '
        Me.changelog_text.AutoSize = True
        Me.changelog_text.Location = New System.Drawing.Point(340, 9)
        Me.changelog_text.Name = "changelog_text"
        Me.changelog_text.Size = New System.Drawing.Size(39, 13)
        Me.changelog_text.TabIndex = 8
        Me.changelog_text.Text = "Label1"
        Me.changelog_text.Visible = False
        '
        'changelog_bbox
        '
        Me.changelog_bbox.Location = New System.Drawing.Point(340, 9)
        Me.changelog_bbox.Name = "changelog_bbox"
        Me.changelog_bbox.Size = New System.Drawing.Size(296, 429)
        Me.changelog_bbox.TabIndex = 9
        Me.changelog_bbox.TabStop = False
        Me.changelog_bbox.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.BackgroundImage = Global.IHUpdater.My.Resources.Resources.Launcher_Background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.changelog_text)
        Me.Controls.Add(Me.btn_changelog)
        Me.Controls.Add(Me.btn_Launch)
        Me.Controls.Add(Me.lbl_creator_credits)
        Me.Controls.Add(Me.btn_credits)
        Me.Controls.Add(Me.Text_Display_Gui)
        Me.Controls.Add(Me.changelog_bbox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "IHUpdater V.0.5.0"
        CType(Me.changelog_bbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Launch As Button
    Friend WithEvents Text_Display_Gui As Label
    Friend WithEvents btn_credits As Button
    Friend WithEvents btn_changelog As Button
    Friend WithEvents lbl_creator_credits As Label
    Friend WithEvents changelog_text As Label
    Friend WithEvents changelog_bbox As PictureBox
End Class
