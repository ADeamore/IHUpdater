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
        Me.tickbox_launcherstay = New System.Windows.Forms.CheckBox()
        Me.btn_worldmap = New System.Windows.Forms.Button()
        Me.dynmap_browser = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.btn_returnfrommap = New System.Windows.Forms.Button()
        Me.tbox_playername = New System.Windows.Forms.TextBox()
        Me.lbl_playername = New System.Windows.Forms.Label()
        Me.btn_set_playername = New System.Windows.Forms.Button()
        Me.btn_launchpos = New System.Windows.Forms.Button()
        Me.lbl_xpos = New System.Windows.Forms.Label()
        Me.tbox_xpos = New System.Windows.Forms.TextBox()
        Me.tbox_zpos = New System.Windows.Forms.TextBox()
        Me.lbl_zpos = New System.Windows.Forms.Label()
        Me.dbox_dimensions = New System.Windows.Forms.ComboBox()
        Me.lbl_dimension = New System.Windows.Forms.Label()
        Me.btn_dimensions = New System.Windows.Forms.Button()
        Me.btn_reload_map = New System.Windows.Forms.Button()
        CType(Me.changelog_bbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dynmap_browser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Launch
        '
        Me.btn_Launch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Launch.AutoSize = True
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
        Me.btn_credits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btn_changelog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.lbl_creator_credits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.changelog_text.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.changelog_bbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.changelog_bbox.Location = New System.Drawing.Point(340, 9)
        Me.changelog_bbox.Name = "changelog_bbox"
        Me.changelog_bbox.Size = New System.Drawing.Size(296, 429)
        Me.changelog_bbox.TabIndex = 9
        Me.changelog_bbox.TabStop = False
        Me.changelog_bbox.Visible = False
        '
        'tickbox_launcherstay
        '
        Me.tickbox_launcherstay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tickbox_launcherstay.AutoSize = True
        Me.tickbox_launcherstay.Location = New System.Drawing.Point(643, 358)
        Me.tickbox_launcherstay.Name = "tickbox_launcherstay"
        Me.tickbox_launcherstay.Size = New System.Drawing.Size(128, 17)
        Me.tickbox_launcherstay.TabIndex = 10
        Me.tickbox_launcherstay.Text = "Keep Launcher Open"
        Me.tickbox_launcherstay.UseVisualStyleBackColor = True
        '
        'btn_worldmap
        '
        Me.btn_worldmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_worldmap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_worldmap.Location = New System.Drawing.Point(660, 88)
        Me.btn_worldmap.Name = "btn_worldmap"
        Me.btn_worldmap.Size = New System.Drawing.Size(128, 32)
        Me.btn_worldmap.TabIndex = 11
        Me.btn_worldmap.Text = "World Map"
        Me.btn_worldmap.UseVisualStyleBackColor = True
        '
        'dynmap_browser
        '
        Me.dynmap_browser.AllowExternalDrop = True
        Me.dynmap_browser.BackColor = System.Drawing.SystemColors.InfoText
        Me.dynmap_browser.CreationProperties = Nothing
        Me.dynmap_browser.DefaultBackgroundColor = System.Drawing.Color.White
        Me.dynmap_browser.Location = New System.Drawing.Point(47, 101)
        Me.dynmap_browser.Name = "dynmap_browser"
        Me.dynmap_browser.Size = New System.Drawing.Size(105, 97)
        Me.dynmap_browser.TabIndex = 12
        Me.dynmap_browser.ZoomFactor = 1.0R
        '
        'btn_returnfrommap
        '
        Me.btn_returnfrommap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_returnfrommap.Enabled = False
        Me.btn_returnfrommap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_returnfrommap.Location = New System.Drawing.Point(660, 406)
        Me.btn_returnfrommap.Name = "btn_returnfrommap"
        Me.btn_returnfrommap.Size = New System.Drawing.Size(128, 32)
        Me.btn_returnfrommap.TabIndex = 13
        Me.btn_returnfrommap.Text = "Return to Launcher"
        Me.btn_returnfrommap.UseVisualStyleBackColor = True
        Me.btn_returnfrommap.Visible = False
        '
        'tbox_playername
        '
        Me.tbox_playername.AcceptsReturn = True
        Me.tbox_playername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_playername.Enabled = False
        Me.tbox_playername.Location = New System.Drawing.Point(5, 246)
        Me.tbox_playername.Name = "tbox_playername"
        Me.tbox_playername.Size = New System.Drawing.Size(128, 20)
        Me.tbox_playername.TabIndex = 14
        Me.tbox_playername.Visible = False
        '
        'lbl_playername
        '
        Me.lbl_playername.AutoSize = True
        Me.lbl_playername.Enabled = False
        Me.lbl_playername.Location = New System.Drawing.Point(6, 233)
        Me.lbl_playername.Name = "lbl_playername"
        Me.lbl_playername.Size = New System.Drawing.Size(81, 13)
        Me.lbl_playername.TabIndex = 16
        Me.lbl_playername.Text = "Player to follow:"
        Me.lbl_playername.Visible = False
        '
        'btn_set_playername
        '
        Me.btn_set_playername.Enabled = False
        Me.btn_set_playername.Location = New System.Drawing.Point(131, 246)
        Me.btn_set_playername.Name = "btn_set_playername"
        Me.btn_set_playername.Size = New System.Drawing.Size(21, 20)
        Me.btn_set_playername.TabIndex = 17
        Me.btn_set_playername.Text = "→"
        Me.btn_set_playername.UseVisualStyleBackColor = True
        Me.btn_set_playername.Visible = False
        '
        'btn_launchpos
        '
        Me.btn_launchpos.Enabled = False
        Me.btn_launchpos.Location = New System.Drawing.Point(131, 283)
        Me.btn_launchpos.Name = "btn_launchpos"
        Me.btn_launchpos.Size = New System.Drawing.Size(21, 20)
        Me.btn_launchpos.TabIndex = 20
        Me.btn_launchpos.Text = "→"
        Me.btn_launchpos.UseVisualStyleBackColor = True
        Me.btn_launchpos.Visible = False
        '
        'lbl_xpos
        '
        Me.lbl_xpos.AutoSize = True
        Me.lbl_xpos.Enabled = False
        Me.lbl_xpos.Location = New System.Drawing.Point(6, 269)
        Me.lbl_xpos.Name = "lbl_xpos"
        Me.lbl_xpos.Size = New System.Drawing.Size(17, 13)
        Me.lbl_xpos.TabIndex = 19
        Me.lbl_xpos.Text = "X:"
        Me.lbl_xpos.Visible = False
        '
        'tbox_xpos
        '
        Me.tbox_xpos.AcceptsReturn = True
        Me.tbox_xpos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_xpos.Enabled = False
        Me.tbox_xpos.Location = New System.Drawing.Point(5, 283)
        Me.tbox_xpos.Name = "tbox_xpos"
        Me.tbox_xpos.Size = New System.Drawing.Size(58, 20)
        Me.tbox_xpos.TabIndex = 18
        Me.tbox_xpos.Text = "0"
        Me.tbox_xpos.Visible = False
        '
        'tbox_zpos
        '
        Me.tbox_zpos.AcceptsReturn = True
        Me.tbox_zpos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_zpos.Enabled = False
        Me.tbox_zpos.Location = New System.Drawing.Point(69, 283)
        Me.tbox_zpos.Name = "tbox_zpos"
        Me.tbox_zpos.Size = New System.Drawing.Size(58, 20)
        Me.tbox_zpos.TabIndex = 19
        Me.tbox_zpos.Text = "0"
        Me.tbox_zpos.Visible = False
        '
        'lbl_zpos
        '
        Me.lbl_zpos.AutoSize = True
        Me.lbl_zpos.Enabled = False
        Me.lbl_zpos.Location = New System.Drawing.Point(70, 269)
        Me.lbl_zpos.Name = "lbl_zpos"
        Me.lbl_zpos.Size = New System.Drawing.Size(17, 13)
        Me.lbl_zpos.TabIndex = 22
        Me.lbl_zpos.Text = "Z:"
        Me.lbl_zpos.Visible = False
        '
        'dbox_dimensions
        '
        Me.dbox_dimensions.AllowDrop = True
        Me.dbox_dimensions.CausesValidation = False
        Me.dbox_dimensions.Enabled = False
        Me.dbox_dimensions.FormattingEnabled = True
        Me.dbox_dimensions.Items.AddRange(New Object() {"Overworld", "Overworld Orbit", "The End", "The Nether", "Create Earth Orbit", "Create Moon", "Create Moon Orbit", "Endor", "Endor Orbit", "Glacio", "Glacio Orbit", "Hot", "Hot Orbit", "Lost Cities", "Mahou Reality Marble", "Mandalore", "Mandalore Orbit", "Mars", "Mars Orbit", "Mercury", "Mercury Orbit", "Moon", "Moon Orbit", "Mustafar", "Mustafar Orbit", "Normal Planet", "Proxima Asteroid Belt", "Proxima Asteroid Belt Orbit", "Proxima B", "Proxima B Orbit", "Proxima C", "Proxima C Orbit", "Proxima D", "Proxima D Orbit", "Tatooine", "Tatooine Orbit", "Venus", "Venus Orbit", "Vicino", "Vicino Orbit"})
        Me.dbox_dimensions.Location = New System.Drawing.Point(5, 318)
        Me.dbox_dimensions.Name = "dbox_dimensions"
        Me.dbox_dimensions.Size = New System.Drawing.Size(121, 21)
        Me.dbox_dimensions.TabIndex = 23
        Me.dbox_dimensions.Text = "Overworld"
        Me.dbox_dimensions.Visible = False
        '
        'lbl_dimension
        '
        Me.lbl_dimension.AutoSize = True
        Me.lbl_dimension.Enabled = False
        Me.lbl_dimension.Location = New System.Drawing.Point(5, 306)
        Me.lbl_dimension.Name = "lbl_dimension"
        Me.lbl_dimension.Size = New System.Drawing.Size(98, 13)
        Me.lbl_dimension.TabIndex = 24
        Me.lbl_dimension.Text = "Choose Dimension:"
        Me.lbl_dimension.Visible = False
        '
        'btn_dimensions
        '
        Me.btn_dimensions.Enabled = False
        Me.btn_dimensions.Location = New System.Drawing.Point(131, 319)
        Me.btn_dimensions.Name = "btn_dimensions"
        Me.btn_dimensions.Size = New System.Drawing.Size(21, 20)
        Me.btn_dimensions.TabIndex = 25
        Me.btn_dimensions.Text = "→"
        Me.btn_dimensions.UseVisualStyleBackColor = True
        Me.btn_dimensions.Visible = False
        '
        'btn_reload_map
        '
        Me.btn_reload_map.Enabled = False
        Me.btn_reload_map.Location = New System.Drawing.Point(5, 345)
        Me.btn_reload_map.Name = "btn_reload_map"
        Me.btn_reload_map.Size = New System.Drawing.Size(58, 20)
        Me.btn_reload_map.TabIndex = 26
        Me.btn_reload_map.Text = "Reload"
        Me.btn_reload_map.UseVisualStyleBackColor = True
        Me.btn_reload_map.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.BackgroundImage = Global.IHUpdater.My.Resources.Resources.Launcher_Background_2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_reload_map)
        Me.Controls.Add(Me.btn_dimensions)
        Me.Controls.Add(Me.lbl_dimension)
        Me.Controls.Add(Me.dbox_dimensions)
        Me.Controls.Add(Me.lbl_zpos)
        Me.Controls.Add(Me.lbl_xpos)
        Me.Controls.Add(Me.tbox_zpos)
        Me.Controls.Add(Me.btn_launchpos)
        Me.Controls.Add(Me.tbox_xpos)
        Me.Controls.Add(Me.btn_set_playername)
        Me.Controls.Add(Me.lbl_playername)
        Me.Controls.Add(Me.tbox_playername)
        Me.Controls.Add(Me.btn_returnfrommap)
        Me.Controls.Add(Me.btn_worldmap)
        Me.Controls.Add(Me.tickbox_launcherstay)
        Me.Controls.Add(Me.changelog_text)
        Me.Controls.Add(Me.btn_changelog)
        Me.Controls.Add(Me.btn_Launch)
        Me.Controls.Add(Me.lbl_creator_credits)
        Me.Controls.Add(Me.btn_credits)
        Me.Controls.Add(Me.Text_Display_Gui)
        Me.Controls.Add(Me.changelog_bbox)
        Me.Controls.Add(Me.dynmap_browser)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(816, 489)
        Me.Name = "Form1"
        Me.Text = "Infinite Horizons Launcher"
        CType(Me.changelog_bbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dynmap_browser, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tickbox_launcherstay As CheckBox
    Friend WithEvents btn_worldmap As Button
    Friend WithEvents dynmap_browser As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents btn_returnfrommap As Button
    Friend WithEvents tbox_playername As TextBox
    Friend WithEvents lbl_playername As Label
    Friend WithEvents btn_set_playername As Button
    Friend WithEvents btn_launchpos As Button
    Friend WithEvents lbl_xpos As Label
    Friend WithEvents tbox_xpos As TextBox
    Friend WithEvents tbox_zpos As TextBox
    Friend WithEvents lbl_zpos As Label
    Friend WithEvents dbox_dimensions As ComboBox
    Friend WithEvents lbl_dimension As Label
    Friend WithEvents btn_dimensions As Button
    Friend WithEvents btn_reload_map As Button
End Class
