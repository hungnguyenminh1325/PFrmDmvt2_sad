<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGroup))
        Me.lblMa_au_me = New System.Windows.Forms.Label()
        Me.lblNhvt2_bac = New System.Windows.Forms.Label()
        Me.txtNhvt2_bac = New hg3.hg3.txtNumeric()
        Me.lblNhvt2ID_me_name = New System.Windows.Forms.Label()
        Me.txtNhvt2ID_me = New System.Windows.Forms.TextBox()
        Me.lblStatusNote = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtDiengiai = New System.Windows.Forms.TextBox()
        Me.lblDiengiai = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblNhvt2Name = New System.Windows.Forms.Label()
        Me.txtNhvt2Name = New System.Windows.Forms.TextBox()
        Me.txtNhvt2ID = New System.Windows.Forms.TextBox()
        Me.lblNhvt2ID = New System.Windows.Forms.Label()
        Me.lblQttgName = New System.Windows.Forms.Label()
        Me.txtFK_QttgID = New System.Windows.Forms.TextBox()
        Me.lblQttgName1 = New System.Windows.Forms.Label()
        Me.txtFk_qttgID1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnBrown = New System.Windows.Forms.Button()
        Me.btnPick = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFk_qttgID2 = New System.Windows.Forms.TextBox()
        Me.lblQttgName2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMa_au_me
        '
        Me.lblMa_au_me.AutoSize = True
        Me.lblMa_au_me.Location = New System.Drawing.Point(20, 103)
        Me.lblMa_au_me.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMa_au_me.Name = "lblMa_au_me"
        Me.lblMa_au_me.Size = New System.Drawing.Size(149, 20)
        Me.lblMa_au_me.TabIndex = 8
        Me.lblMa_au_me.Text = "Quy tắc tính giá bán"
        '
        'lblNhvt2_bac
        '
        Me.lblNhvt2_bac.Location = New System.Drawing.Point(184, 249)
        Me.lblNhvt2_bac.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNhvt2_bac.Name = "lblNhvt2_bac"
        Me.lblNhvt2_bac.Size = New System.Drawing.Size(150, 26)
        Me.lblNhvt2_bac.TabIndex = 7
        Me.lblNhvt2_bac.Text = "Nhóm bậc"
        '
        'txtNhvt2_bac
        '
        Me.txtNhvt2_bac.Enabled = False
        Me.txtNhvt2_bac.Format = "m_ip_bac_tk"
        Me.txtNhvt2_bac.Location = New System.Drawing.Point(478, 272)
        Me.txtNhvt2_bac.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNhvt2_bac.MaxLength = 12
        Me.txtNhvt2_bac.Name = "txtNhvt2_bac"
        Me.txtNhvt2_bac.Size = New System.Drawing.Size(78, 26)
        Me.txtNhvt2_bac.TabIndex = 8
        Me.txtNhvt2_bac.TabStop = False
        Me.txtNhvt2_bac.Tag = "FN"
        Me.txtNhvt2_bac.Text = "m_ip_bac_tk"
        Me.txtNhvt2_bac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNhvt2_bac.Value = 0R
        '
        'lblNhvt2ID_me_name
        '
        Me.lblNhvt2ID_me_name.Location = New System.Drawing.Point(184, 275)
        Me.lblNhvt2ID_me_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNhvt2ID_me_name.Name = "lblNhvt2ID_me_name"
        Me.lblNhvt2ID_me_name.Size = New System.Drawing.Size(392, 26)
        Me.lblNhvt2ID_me_name.TabIndex = 6
        Me.lblNhvt2ID_me_name.Tag = ""
        Me.lblNhvt2ID_me_name.Text = "Tên nhóm mẹ"
        '
        'txtNhvt2ID_me
        '
        Me.txtNhvt2ID_me.BackColor = System.Drawing.Color.PaleGreen
        Me.txtNhvt2ID_me.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNhvt2ID_me.Location = New System.Drawing.Point(184, 17)
        Me.txtNhvt2ID_me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNhvt2ID_me.Name = "txtNhvt2ID_me"
        Me.txtNhvt2ID_me.Size = New System.Drawing.Size(127, 26)
        Me.txtNhvt2ID_me.TabIndex = 1
        Me.txtNhvt2ID_me.Tag = "FC"
        Me.txtNhvt2ID_me.Text = "NHVT2ID_ME"
        '
        'lblStatusNote
        '
        Me.lblStatusNote.Location = New System.Drawing.Point(273, 217)
        Me.lblStatusNote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatusNote.Name = "lblStatusNote"
        Me.lblStatusNote.Size = New System.Drawing.Size(338, 25)
        Me.lblStatusNote.TabIndex = 17
        Me.lblStatusNote.Text = "1 - Đang sử dụng; 0 - Khóa lại"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(20, 217)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(150, 26)
        Me.lblStatus.TabIndex = 15
        Me.lblStatus.Text = "Trạng thái"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(184, 213)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStatus.MaxLength = 1
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(78, 26)
        Me.txtStatus.TabIndex = 16
        Me.txtStatus.Tag = "FC"
        Me.txtStatus.Text = "Status"
        '
        'txtDiengiai
        '
        Me.txtDiengiai.Location = New System.Drawing.Point(184, 249)
        Me.txtDiengiai.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDiengiai.Multiline = True
        Me.txtDiengiai.Name = "txtDiengiai"
        Me.txtDiengiai.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDiengiai.Size = New System.Drawing.Size(445, 68)
        Me.txtDiengiai.TabIndex = 19
        Me.txtDiengiai.Tag = "FC"
        '
        'lblDiengiai
        '
        Me.lblDiengiai.Location = New System.Drawing.Point(20, 260)
        Me.lblDiengiai.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDiengiai.Name = "lblDiengiai"
        Me.lblDiengiai.Size = New System.Drawing.Size(150, 26)
        Me.lblDiengiai.TabIndex = 18
        Me.lblDiengiai.Text = "Diễn giải"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(146, 386)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(112, 35)
        Me.cmdCancel.TabIndex = 25
        Me.cmdCancel.Text = "&Bỏ qua"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.Location = New System.Drawing.Point(24, 386)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(112, 35)
        Me.cmdOk.TabIndex = 24
        Me.cmdOk.Text = "&Nhận"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'lblNhvt2Name
        '
        Me.lblNhvt2Name.Location = New System.Drawing.Point(20, 62)
        Me.lblNhvt2Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNhvt2Name.Name = "lblNhvt2Name"
        Me.lblNhvt2Name.Size = New System.Drawing.Size(150, 26)
        Me.lblNhvt2Name.TabIndex = 3
        Me.lblNhvt2Name.Text = "Tên nhóm hàng"
        '
        'txtNhvt2Name
        '
        Me.txtNhvt2Name.BackColor = System.Drawing.Color.PaleGreen
        Me.txtNhvt2Name.Location = New System.Drawing.Point(184, 58)
        Me.txtNhvt2Name.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNhvt2Name.Name = "txtNhvt2Name"
        Me.txtNhvt2Name.Size = New System.Drawing.Size(445, 26)
        Me.txtNhvt2Name.TabIndex = 4
        Me.txtNhvt2Name.Tag = "FCNB"
        '
        'txtNhvt2ID
        '
        Me.txtNhvt2ID.BackColor = System.Drawing.Color.PaleGreen
        Me.txtNhvt2ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNhvt2ID.Location = New System.Drawing.Point(322, 17)
        Me.txtNhvt2ID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNhvt2ID.Name = "txtNhvt2ID"
        Me.txtNhvt2ID.Size = New System.Drawing.Size(127, 26)
        Me.txtNhvt2ID.TabIndex = 2
        Me.txtNhvt2ID.Tag = "FCNBDF"
        '
        'lblNhvt2ID
        '
        Me.lblNhvt2ID.Location = New System.Drawing.Point(20, 22)
        Me.lblNhvt2ID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNhvt2ID.Name = "lblNhvt2ID"
        Me.lblNhvt2ID.Size = New System.Drawing.Size(150, 26)
        Me.lblNhvt2ID.TabIndex = 0
        Me.lblNhvt2ID.Text = "Mã nhóm hàng"
        '
        'lblQttgName
        '
        Me.lblQttgName.Location = New System.Drawing.Point(322, 103)
        Me.lblQttgName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQttgName.Name = "lblQttgName"
        Me.lblQttgName.Size = New System.Drawing.Size(302, 26)
        Me.lblQttgName.TabIndex = 10
        Me.lblQttgName.Tag = ""
        Me.lblQttgName.Text = "Tên qttg"
        '
        'txtFK_QttgID
        '
        Me.txtFK_QttgID.BackColor = System.Drawing.SystemColors.Window
        Me.txtFK_QttgID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFK_QttgID.Location = New System.Drawing.Point(184, 98)
        Me.txtFK_QttgID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFK_QttgID.Name = "txtFK_QttgID"
        Me.txtFK_QttgID.Size = New System.Drawing.Size(127, 26)
        Me.txtFK_QttgID.TabIndex = 9
        Me.txtFK_QttgID.Tag = "FC"
        Me.txtFK_QttgID.Text = "QTTGID"
        '
        'lblQttgName1
        '
        Me.lblQttgName1.Location = New System.Drawing.Point(322, 143)
        Me.lblQttgName1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQttgName1.Name = "lblQttgName1"
        Me.lblQttgName1.Size = New System.Drawing.Size(302, 26)
        Me.lblQttgName1.TabIndex = 14
        Me.lblQttgName1.Tag = ""
        Me.lblQttgName1.Text = "Tên qttg"
        '
        'txtFk_qttgID1
        '
        Me.txtFk_qttgID1.BackColor = System.Drawing.SystemColors.Window
        Me.txtFk_qttgID1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFk_qttgID1.Location = New System.Drawing.Point(184, 138)
        Me.txtFk_qttgID1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFk_qttgID1.Name = "txtFk_qttgID1"
        Me.txtFk_qttgID1.Size = New System.Drawing.Size(127, 26)
        Me.txtFk_qttgID1.TabIndex = 13
        Me.txtFk_qttgID1.Tag = "FC"
        Me.txtFk_qttgID1.Text = "QTTGID1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 143)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Quy tắc tính giá mua"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 334)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 26)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Ảnh nhóm hàng"
        '
        'txtImagePath
        '
        Me.txtImagePath.BackColor = System.Drawing.Color.White
        Me.txtImagePath.Location = New System.Drawing.Point(184, 329)
        Me.txtImagePath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(352, 26)
        Me.txtImagePath.TabIndex = 26
        Me.txtImagePath.Tag = "FC"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(640, 17)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(308, 342)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'btnBrown
        '
        Me.btnBrown.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrown.Location = New System.Drawing.Point(543, 328)
        Me.btnBrown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBrown.Name = "btnBrown"
        Me.btnBrown.Size = New System.Drawing.Size(40, 32)
        Me.btnBrown.TabIndex = 21
        Me.btnBrown.Text = "..."
        Me.btnBrown.UseVisualStyleBackColor = True
        '
        'btnPick
        '
        Me.btnPick.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPick.Image = CType(resources.GetObject("btnPick.Image"), System.Drawing.Image)
        Me.btnPick.Location = New System.Drawing.Point(588, 328)
        Me.btnPick.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPick.Name = "btnPick"
        Me.btnPick.Size = New System.Drawing.Size(44, 32)
        Me.btnPick.TabIndex = 22
        Me.btnPick.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 179)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Quy tắc tính giá buôn"
        '
        'txtFk_qttgID2
        '
        Me.txtFk_qttgID2.BackColor = System.Drawing.SystemColors.Window
        Me.txtFk_qttgID2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFk_qttgID2.Location = New System.Drawing.Point(184, 174)
        Me.txtFk_qttgID2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFk_qttgID2.Name = "txtFk_qttgID2"
        Me.txtFk_qttgID2.Size = New System.Drawing.Size(127, 26)
        Me.txtFk_qttgID2.TabIndex = 13
        Me.txtFk_qttgID2.Tag = "FC"
        Me.txtFk_qttgID2.Text = "QTTGID2"
        '
        'lblQttgName2
        '
        Me.lblQttgName2.Location = New System.Drawing.Point(322, 179)
        Me.lblQttgName2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQttgName2.Name = "lblQttgName2"
        Me.lblQttgName2.Size = New System.Drawing.Size(302, 26)
        Me.lblQttgName2.TabIndex = 14
        Me.lblQttgName2.Tag = ""
        Me.lblQttgName2.Text = "Tên qttg"
        '
        'FrmGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(968, 440)
        Me.Controls.Add(Me.btnBrown)
        Me.Controls.Add(Me.btnPick)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtImagePath)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblQttgName2)
        Me.Controls.Add(Me.lblQttgName1)
        Me.Controls.Add(Me.txtFk_qttgID2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFk_qttgID1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDiengiai)
        Me.Controls.Add(Me.lblQttgName)
        Me.Controls.Add(Me.txtFK_QttgID)
        Me.Controls.Add(Me.lblMa_au_me)
        Me.Controls.Add(Me.lblNhvt2_bac)
        Me.Controls.Add(Me.txtNhvt2_bac)
        Me.Controls.Add(Me.lblNhvt2ID_me_name)
        Me.Controls.Add(Me.txtNhvt2ID_me)
        Me.Controls.Add(Me.lblStatusNote)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.lblDiengiai)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblNhvt2Name)
        Me.Controls.Add(Me.txtNhvt2Name)
        Me.Controls.Add(Me.txtNhvt2ID)
        Me.Controls.Add(Me.lblNhvt2ID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMa_au_me As System.Windows.Forms.Label
    Friend WithEvents lblNhvt2_bac As System.Windows.Forms.Label
    Friend WithEvents txtNhvt2_bac As hg3.hg3.txtNumeric
    Friend WithEvents lblNhvt2ID_me_name As System.Windows.Forms.Label
    Friend WithEvents txtNhvt2ID_me As System.Windows.Forms.TextBox
    Friend WithEvents lblStatusNote As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtDiengiai As System.Windows.Forms.TextBox
    Friend WithEvents lblDiengiai As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblNhvt2Name As System.Windows.Forms.Label
    Friend WithEvents txtNhvt2Name As System.Windows.Forms.TextBox
    Friend WithEvents txtNhvt2ID As System.Windows.Forms.TextBox
    Friend WithEvents lblNhvt2ID As System.Windows.Forms.Label
    Friend WithEvents lblQttgName As System.Windows.Forms.Label
    Friend WithEvents txtFK_QttgID As System.Windows.Forms.TextBox
    Friend WithEvents lblQttgName1 As System.Windows.Forms.Label
    Friend WithEvents txtFk_qttgID1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrown As System.Windows.Forms.Button
    Friend WithEvents btnPick As System.Windows.Forms.Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFk_qttgID2 As TextBox
    Friend WithEvents lblQttgName2 As Label
End Class
