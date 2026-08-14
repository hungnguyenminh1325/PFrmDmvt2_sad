<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTemSetting
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
        Me.pnBottom = New System.Windows.Forms.Panel
        Me.barStatus = New System.Windows.Forms.StatusStrip
        Me.sttLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.pnTop = New System.Windows.Forms.Panel
        Me.tabDetail = New System.Windows.Forms.TabPage
        Me.pn2Left = New System.Windows.Forms.Panel
        Me.cblField = New System.Windows.Forms.CheckedListBox
        Me.pn2Top = New System.Windows.Forms.Panel
        Me.pn2Primary = New System.Windows.Forms.Panel
        Me.tabProperty = New System.Windows.Forms.TabControl
        Me.tabPrimary = New System.Windows.Forms.TabControl
        Me.TabCommon = New System.Windows.Forms.TabPage
        Me.pnRight = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.pnLeft = New System.Windows.Forms.Panel
        Me.txtNumRows = New hg3.hg3.txtNumeric
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtWidth = New hg3.hg3.txtNumeric
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtHeight = New hg3.hg3.txtNumeric
        Me.txtNumCells = New hg3.hg3.txtNumeric
        Me.txtTop0 = New hg3.hg3.txtNumeric
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.txtLeft0 = New hg3.hg3.txtNumeric
        Me.txtwItem = New hg3.hg3.txtNumeric
        Me.txtHItem = New hg3.hg3.txtNumeric
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTemLabel = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnBottom.SuspendLayout()
        Me.barStatus.SuspendLayout()
        Me.pnTop.SuspendLayout()
        Me.tabDetail.SuspendLayout()
        Me.pn2Left.SuspendLayout()
        Me.pn2Primary.SuspendLayout()
        Me.tabPrimary.SuspendLayout()
        Me.TabCommon.SuspendLayout()
        Me.pnLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnBottom
        '
        Me.pnBottom.Controls.Add(Me.barStatus)
        Me.pnBottom.Controls.Add(Me.btnCancel)
        Me.pnBottom.Controls.Add(Me.btnSave)
        Me.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnBottom.Location = New System.Drawing.Point(0, 215)
        Me.pnBottom.Name = "pnBottom"
        Me.pnBottom.Size = New System.Drawing.Size(706, 48)
        Me.pnBottom.TabIndex = 0
        '
        'barStatus
        '
        Me.barStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sttLabel})
        Me.barStatus.Location = New System.Drawing.Point(0, 26)
        Me.barStatus.Name = "barStatus"
        Me.barStatus.Size = New System.Drawing.Size(706, 22)
        Me.barStatus.TabIndex = 2
        Me.barStatus.Text = "StatusStrip1"
        '
        'sttLabel
        '
        Me.sttLabel.Name = "sttLabel"
        Me.sttLabel.Size = New System.Drawing.Size(129, 17)
        Me.sttLabel.Text = "Hãy nhập tên mẫu tem"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(91, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Bỏ"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(10, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnTop
        '
        Me.pnTop.Controls.Add(Me.tabPrimary)
        Me.pnTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnTop.Location = New System.Drawing.Point(0, 0)
        Me.pnTop.Name = "pnTop"
        Me.pnTop.Size = New System.Drawing.Size(706, 215)
        Me.pnTop.TabIndex = 1
        '
        'tabDetail
        '
        Me.tabDetail.Controls.Add(Me.pn2Primary)
        Me.tabDetail.Controls.Add(Me.pn2Top)
        Me.tabDetail.Controls.Add(Me.pn2Left)
        Me.tabDetail.Location = New System.Drawing.Point(4, 22)
        Me.tabDetail.Name = "tabDetail"
        Me.tabDetail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetail.Size = New System.Drawing.Size(698, 189)
        Me.tabDetail.TabIndex = 1
        Me.tabDetail.Text = "Thiết lập"
        Me.tabDetail.UseVisualStyleBackColor = True
        '
        'pn2Left
        '
        Me.pn2Left.Controls.Add(Me.cblField)
        Me.pn2Left.Dock = System.Windows.Forms.DockStyle.Left
        Me.pn2Left.Location = New System.Drawing.Point(3, 3)
        Me.pn2Left.Name = "pn2Left"
        Me.pn2Left.Size = New System.Drawing.Size(200, 183)
        Me.pn2Left.TabIndex = 0
        '
        'cblField
        '
        Me.cblField.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cblField.FormattingEnabled = True
        Me.cblField.Location = New System.Drawing.Point(0, 0)
        Me.cblField.Margin = New System.Windows.Forms.Padding(0)
        Me.cblField.Name = "cblField"
        Me.cblField.Size = New System.Drawing.Size(200, 169)
        Me.cblField.TabIndex = 3
        '
        'pn2Top
        '
        Me.pn2Top.BackColor = System.Drawing.Color.White
        Me.pn2Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pn2Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pn2Top.Location = New System.Drawing.Point(203, 3)
        Me.pn2Top.Name = "pn2Top"
        Me.pn2Top.Size = New System.Drawing.Size(492, 103)
        Me.pn2Top.TabIndex = 1
        '
        'pn2Primary
        '
        Me.pn2Primary.Controls.Add(Me.tabProperty)
        Me.pn2Primary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pn2Primary.Location = New System.Drawing.Point(203, 106)
        Me.pn2Primary.Name = "pn2Primary"
        Me.pn2Primary.Size = New System.Drawing.Size(492, 80)
        Me.pn2Primary.TabIndex = 2
        '
        'tabProperty
        '
        Me.tabProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabProperty.Location = New System.Drawing.Point(0, 0)
        Me.tabProperty.Margin = New System.Windows.Forms.Padding(0)
        Me.tabProperty.Name = "tabProperty"
        Me.tabProperty.Padding = New System.Drawing.Point(0, 0)
        Me.tabProperty.SelectedIndex = 0
        Me.tabProperty.Size = New System.Drawing.Size(492, 80)
        Me.tabProperty.TabIndex = 0
        '
        'tabPrimary
        '
        Me.tabPrimary.Controls.Add(Me.TabCommon)
        Me.tabPrimary.Controls.Add(Me.tabDetail)
        Me.tabPrimary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPrimary.Location = New System.Drawing.Point(0, 0)
        Me.tabPrimary.Name = "tabPrimary"
        Me.tabPrimary.SelectedIndex = 0
        Me.tabPrimary.Size = New System.Drawing.Size(706, 215)
        Me.tabPrimary.TabIndex = 0
        '
        'TabCommon
        '
        Me.TabCommon.Controls.Add(Me.pnRight)
        Me.TabCommon.Controls.Add(Me.pnLeft)
        Me.TabCommon.Location = New System.Drawing.Point(4, 22)
        Me.TabCommon.Name = "TabCommon"
        Me.TabCommon.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCommon.Size = New System.Drawing.Size(698, 189)
        Me.TabCommon.TabIndex = 0
        Me.TabCommon.Text = "Định nghĩa tem"
        Me.TabCommon.UseVisualStyleBackColor = True
        '
        'pnRight
        '
        Me.pnRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnRight.Location = New System.Drawing.Point(336, 3)
        Me.pnRight.Name = "pnRight"
        Me.pnRight.Size = New System.Drawing.Size(359, 183)
        Me.pnRight.TabIndex = 281
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(168, 63)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(158, 81)
        Me.GroupBox3.TabIndex = 301
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(5, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 81)
        Me.GroupBox2.TabIndex = 296
        Me.GroupBox2.TabStop = False
        '
        'pnLeft
        '
        Me.pnLeft.Controls.Add(Me.Label6)
        Me.pnLeft.Controls.Add(Me.Label7)
        Me.pnLeft.Controls.Add(Me.Label4)
        Me.pnLeft.Controls.Add(Me.Label5)
        Me.pnLeft.Controls.Add(Me.Label1)
        Me.pnLeft.Controls.Add(Me.txtHItem)
        Me.pnLeft.Controls.Add(Me.txtwItem)
        Me.pnLeft.Controls.Add(Me.txtLeft0)
        Me.pnLeft.Controls.Add(Me.Label53)
        Me.pnLeft.Controls.Add(Me.Label52)
        Me.pnLeft.Controls.Add(Me.txtTop0)
        Me.pnLeft.Controls.Add(Me.txtTemLabel)
        Me.pnLeft.Controls.Add(Me.txtNumCells)
        Me.pnLeft.Controls.Add(Me.txtHeight)
        Me.pnLeft.Controls.Add(Me.Label2)
        Me.pnLeft.Controls.Add(Me.txtWidth)
        Me.pnLeft.Controls.Add(Me.Label3)
        Me.pnLeft.Controls.Add(Me.txtNumRows)
        Me.pnLeft.Controls.Add(Me.GroupBox1)
        Me.pnLeft.Controls.Add(Me.GroupBox2)
        Me.pnLeft.Controls.Add(Me.GroupBox3)
        Me.pnLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnLeft.Location = New System.Drawing.Point(3, 3)
        Me.pnLeft.Name = "pnLeft"
        Me.pnLeft.Size = New System.Drawing.Size(333, 183)
        Me.pnLeft.TabIndex = 280
        '
        'txtNumRows
        '
        Me.txtNumRows.Format = "m_ip_sl"
        Me.txtNumRows.Location = New System.Drawing.Point(198, 85)
        Me.txtNumRows.MaxLength = 8
        Me.txtNumRows.Name = "txtNumRows"
        Me.txtNumRows.Size = New System.Drawing.Size(42, 20)
        Me.txtNumRows.TabIndex = 5
        Me.txtNumRows.Tag = "FN"
        Me.txtNumRows.Text = "m_ip_sl"
        Me.txtNumRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumRows.Value = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(14, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 284
        Me.Label3.Text = "W"
        '
        'txtWidth
        '
        Me.txtWidth.Format = "m_ip_sl"
        Me.txtWidth.Location = New System.Drawing.Point(36, 111)
        Me.txtWidth.MaxLength = 8
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(42, 20)
        Me.txtWidth.TabIndex = 2
        Me.txtWidth.Tag = "FN"
        Me.txtWidth.Text = "m_ip_sl"
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.Value = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(14, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 282
        Me.Label2.Text = "H"
        '
        'txtHeight
        '
        Me.txtHeight.Format = "m_ip_sl"
        Me.txtHeight.Location = New System.Drawing.Point(36, 85)
        Me.txtHeight.MaxLength = 8
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(42, 20)
        Me.txtHeight.TabIndex = 1
        Me.txtHeight.Tag = "FN"
        Me.txtHeight.Text = "m_ip_sl"
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHeight.Value = 0
        '
        'txtNumCells
        '
        Me.txtNumCells.Format = "m_ip_sl"
        Me.txtNumCells.Location = New System.Drawing.Point(198, 111)
        Me.txtNumCells.MaxLength = 8
        Me.txtNumCells.Name = "txtNumCells"
        Me.txtNumCells.Size = New System.Drawing.Size(42, 20)
        Me.txtNumCells.TabIndex = 6
        Me.txtNumCells.Tag = "FN"
        Me.txtNumCells.Text = "m_ip_sl"
        Me.txtNumCells.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumCells.Value = 0
        '
        'txtTop0
        '
        Me.txtTop0.Format = "m_ip_sl"
        Me.txtTop0.Location = New System.Drawing.Point(106, 85)
        Me.txtTop0.MaxLength = 8
        Me.txtTop0.Name = "txtTop0"
        Me.txtTop0.Size = New System.Drawing.Size(42, 20)
        Me.txtTop0.TabIndex = 3
        Me.txtTop0.Tag = "FN"
        Me.txtTop0.Text = "m_ip_sl"
        Me.txtTop0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTop0.Value = 0
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Red
        Me.Label52.Location = New System.Drawing.Point(86, 114)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(14, 13)
        Me.Label52.TabIndex = 291
        Me.Label52.Text = "L"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Red
        Me.Label53.Location = New System.Drawing.Point(85, 88)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(15, 13)
        Me.Label53.TabIndex = 3
        Me.Label53.Text = "T"
        '
        'txtLeft0
        '
        Me.txtLeft0.Format = "m_ip_sl"
        Me.txtLeft0.Location = New System.Drawing.Point(106, 111)
        Me.txtLeft0.MaxLength = 8
        Me.txtLeft0.Name = "txtLeft0"
        Me.txtLeft0.Size = New System.Drawing.Size(42, 20)
        Me.txtLeft0.TabIndex = 4
        Me.txtLeft0.Tag = "FN"
        Me.txtLeft0.Text = "m_ip_sl"
        Me.txtLeft0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeft0.Value = 0
        '
        'txtwItem
        '
        Me.txtwItem.Format = "m_ip_sl"
        Me.txtwItem.Location = New System.Drawing.Point(271, 111)
        Me.txtwItem.MaxLength = 8
        Me.txtwItem.Name = "txtwItem"
        Me.txtwItem.Size = New System.Drawing.Size(42, 20)
        Me.txtwItem.TabIndex = 8
        Me.txtwItem.Tag = "FN"
        Me.txtwItem.Text = "m_ip_sl"
        Me.txtwItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtwItem.Value = 0
        '
        'txtHItem
        '
        Me.txtHItem.Format = "m_ip_sl"
        Me.txtHItem.Location = New System.Drawing.Point(271, 85)
        Me.txtHItem.MaxLength = 8
        Me.txtHItem.Name = "txtHItem"
        Me.txtHItem.Size = New System.Drawing.Size(42, 20)
        Me.txtHItem.TabIndex = 7
        Me.txtHItem.Tag = "FN"
        Me.txtHItem.Text = "m_ip_sl"
        Me.txtHItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHItem.Value = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(176, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 298
        Me.Label5.Text = "C"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(176, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 297
        Me.Label4.Text = "R"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(248, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 300
        Me.Label7.Text = "P"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(248, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 13)
        Me.Label6.TabIndex = 299
        Me.Label6.Text = "M"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 54)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tem"
        '
        'txtTemLabel
        '
        Me.txtTemLabel.Location = New System.Drawing.Point(48, 22)
        Me.txtTemLabel.Name = "txtTemLabel"
        Me.txtTemLabel.Size = New System.Drawing.Size(265, 20)
        Me.txtTemLabel.TabIndex = 0
        Me.txtTemLabel.Tag = "FC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Tên"
        '
        'FrmTemSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 263)
        Me.Controls.Add(Me.pnTop)
        Me.Controls.Add(Me.pnBottom)
        Me.Name = "FrmTemSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thiết lập mẫu tem"
        Me.pnBottom.ResumeLayout(False)
        Me.pnBottom.PerformLayout()
        Me.barStatus.ResumeLayout(False)
        Me.barStatus.PerformLayout()
        Me.pnTop.ResumeLayout(False)
        Me.tabDetail.ResumeLayout(False)
        Me.pn2Left.ResumeLayout(False)
        Me.pn2Primary.ResumeLayout(False)
        Me.tabPrimary.ResumeLayout(False)
        Me.TabCommon.ResumeLayout(False)
        Me.pnLeft.ResumeLayout(False)
        Me.pnLeft.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnBottom As System.Windows.Forms.Panel
    Friend WithEvents pnTop As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents barStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents sttLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tabPrimary As System.Windows.Forms.TabControl
    Friend WithEvents TabCommon As System.Windows.Forms.TabPage
    Friend WithEvents pnRight As System.Windows.Forms.Panel
    Friend WithEvents pnLeft As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHItem As hg3.hg3.txtNumeric
    Friend WithEvents txtwItem As hg3.hg3.txtNumeric
    Friend WithEvents txtLeft0 As hg3.hg3.txtNumeric
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtTop0 As hg3.hg3.txtNumeric
    Friend WithEvents txtTemLabel As System.Windows.Forms.TextBox
    Friend WithEvents txtNumCells As hg3.hg3.txtNumeric
    Friend WithEvents txtHeight As hg3.hg3.txtNumeric
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As hg3.hg3.txtNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumRows As hg3.hg3.txtNumeric
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tabDetail As System.Windows.Forms.TabPage
    Friend WithEvents pn2Primary As System.Windows.Forms.Panel
    Friend WithEvents tabProperty As System.Windows.Forms.TabControl
    Friend WithEvents pn2Top As System.Windows.Forms.Panel
    Friend WithEvents pn2Left As System.Windows.Forms.Panel
    Friend WithEvents cblField As System.Windows.Forms.CheckedListBox
End Class
