<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btn_Launch = New System.Windows.Forms.Button()
        Me.Text_Display_Gui = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Launch
        '
        Me.btn_Launch.Enabled = False
        Me.btn_Launch.Location = New System.Drawing.Point(328, 381)
        Me.btn_Launch.Name = "btn_Launch"
        Me.btn_Launch.Size = New System.Drawing.Size(146, 57)
        Me.btn_Launch.TabIndex = 0
        Me.btn_Launch.Text = "Launch"
        Me.btn_Launch.UseVisualStyleBackColor = True
        '
        'Text_Display_Gui
        '
        Me.Text_Display_Gui.AutoSize = True
        Me.Text_Display_Gui.Location = New System.Drawing.Point(12, 9)
        Me.Text_Display_Gui.Name = "Text_Display_Gui"
        Me.Text_Display_Gui.Size = New System.Drawing.Size(208, 13)
        Me.Text_Display_Gui.TabIndex = 1
        Me.Text_Display_Gui.Text = "Compiling File List for Version Pairity Check"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Text_Display_Gui)
        Me.Controls.Add(Me.btn_Launch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "IHUpdater V.0.0.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Launch As Button
    Friend WithEvents Text_Display_Gui As Label
End Class
