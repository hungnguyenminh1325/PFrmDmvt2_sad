<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChonMayIn
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
        Me.btnChon = New System.Windows.Forms.Button
        Me.cbChonMayIn = New System.Windows.Forms.ComboBox
        Me.lbChonMayIn = New System.Windows.Forms.Label
        Me.lbmayintruoc = New System.Windows.Forms.Label
        Me.lblCheckAction = New System.Windows.Forms.Label
        Me.BtCheckOnOff = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnChon
        '
        Me.btnChon.Location = New System.Drawing.Point(22, 25)
        Me.btnChon.Name = "btnChon"
        Me.btnChon.Size = New System.Drawing.Size(105, 23)
        Me.btnChon.TabIndex = 1
        Me.btnChon.Text = "Chọn máy in"
        Me.btnChon.UseVisualStyleBackColor = True
        '
        'cbChonMayIn
        '
        Me.cbChonMayIn.FormattingEnabled = True
        Me.cbChonMayIn.Location = New System.Drawing.Point(133, 27)
        Me.cbChonMayIn.Name = "cbChonMayIn"
        Me.cbChonMayIn.Size = New System.Drawing.Size(203, 21)
        Me.cbChonMayIn.TabIndex = 0
        '
        'lbChonMayIn
        '
        Me.lbChonMayIn.AutoSize = True
        Me.lbChonMayIn.Location = New System.Drawing.Point(130, 9)
        Me.lbChonMayIn.Name = "lbChonMayIn"
        Me.lbChonMayIn.Size = New System.Drawing.Size(114, 13)
        Me.lbChonMayIn.TabIndex = 2
        Me.lbChonMayIn.Text = "Chọn máy in thích hợp"
        '
        'lbmayintruoc
        '
        Me.lbmayintruoc.AutoSize = True
        Me.lbmayintruoc.Location = New System.Drawing.Point(19, 51)
        Me.lbmayintruoc.Name = "lbmayintruoc"
        Me.lbmayintruoc.Size = New System.Drawing.Size(65, 13)
        Me.lbmayintruoc.TabIndex = 3
        Me.lbmayintruoc.Text = "May in truoc"
        Me.lbmayintruoc.Visible = False
        '
        'lblCheckAction
        '
        Me.lblCheckAction.AutoSize = True
        Me.lblCheckAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckAction.Location = New System.Drawing.Point(130, 67)
        Me.lblCheckAction.Name = "lblCheckAction"
        Me.lblCheckAction.Size = New System.Drawing.Size(214, 16)
        Me.lblCheckAction.TabIndex = 3
        Me.lblCheckAction.Text = "Thông báo máy in đang tắt hay mở"
        Me.lblCheckAction.Visible = False
        '
        'BtCheckOnOff
        '
        Me.BtCheckOnOff.Location = New System.Drawing.Point(342, 25)
        Me.BtCheckOnOff.Name = "BtCheckOnOff"
        Me.BtCheckOnOff.Size = New System.Drawing.Size(100, 23)
        Me.BtCheckOnOff.TabIndex = 1
        Me.BtCheckOnOff.Text = "Kiểm tra (mở/tắt)"
        Me.BtCheckOnOff.UseVisualStyleBackColor = True
        '
        'FrmChonMayIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 92)
        Me.Controls.Add(Me.lblCheckAction)
        Me.Controls.Add(Me.lbmayintruoc)
        Me.Controls.Add(Me.lbChonMayIn)
        Me.Controls.Add(Me.cbChonMayIn)
        Me.Controls.Add(Me.BtCheckOnOff)
        Me.Controls.Add(Me.btnChon)
        Me.Name = "FrmChonMayIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chon may in"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChon As System.Windows.Forms.Button
    Friend WithEvents cbChonMayIn As System.Windows.Forms.ComboBox
    Friend WithEvents lbChonMayIn As System.Windows.Forms.Label
    Friend WithEvents lbmayintruoc As System.Windows.Forms.Label
    Friend WithEvents lblCheckAction As System.Windows.Forms.Label
    Friend WithEvents BtCheckOnOff As System.Windows.Forms.Button
End Class
