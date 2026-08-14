<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrProperty
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cboC = New System.Windows.Forms.CheckBox
        Me.txtL = New hg3.hg3.txtNumeric
        Me.txtT = New hg3.hg3.txtNumeric
        Me.TxtA = New hg3.hg3.txtNumeric
        Me.TxtS = New hg3.hg3.txtNumeric
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtX = New hg3.hg3.txtNumeric
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtY = New hg3.hg3.txtNumeric
        Me.cboR = New System.Windows.Forms.CheckBox
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.lbl = New System.Windows.Forms.Label
        Me.cboB = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'cboC
        '
        Me.cboC.AutoSize = True
        Me.cboC.Location = New System.Drawing.Point(4, 29)
        Me.cboC.Name = "cboC"
        Me.cboC.Size = New System.Drawing.Size(177, 17)
        Me.cboC.TabIndex = 12
        Me.cboC.Text = "Ẩn nễu bằng 0 hoặc bằng trắng"
        Me.cboC.UseVisualStyleBackColor = True
        '
        'txtL
        '
        Me.txtL.Format = "m_ip_sl"
        Me.txtL.Location = New System.Drawing.Point(50, 3)
        Me.txtL.MaxLength = 8
        Me.txtL.Name = "txtL"
        Me.txtL.Size = New System.Drawing.Size(42, 20)
        Me.txtL.TabIndex = 1
        Me.txtL.Tag = "FN"
        Me.txtL.Text = "m_ip_sl"
        Me.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtL.Value = 0
        '
        'txtT
        '
        Me.txtT.Format = "m_ip_sl"
        Me.txtT.Location = New System.Drawing.Point(151, 3)
        Me.txtT.MaxLength = 8
        Me.txtT.Name = "txtT"
        Me.txtT.Size = New System.Drawing.Size(42, 20)
        Me.txtT.TabIndex = 3
        Me.txtT.Tag = "FN"
        Me.txtT.Text = "m_ip_sl"
        Me.txtT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtT.Value = 0
        '
        'TxtA
        '
        Me.TxtA.Format = "m_ip_sl"
        Me.TxtA.Location = New System.Drawing.Point(232, 3)
        Me.TxtA.MaxLength = 8
        Me.TxtA.Name = "TxtA"
        Me.TxtA.Size = New System.Drawing.Size(42, 20)
        Me.TxtA.TabIndex = 5
        Me.TxtA.Tag = "FN"
        Me.TxtA.Text = "m_ip_sl"
        Me.TxtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtA.Value = 0
        '
        'TxtS
        '
        Me.TxtS.Format = "m_ip_sl"
        Me.TxtS.Location = New System.Drawing.Point(327, 3)
        Me.TxtS.MaxLength = 8
        Me.TxtS.Name = "TxtS"
        Me.TxtS.Size = New System.Drawing.Size(42, 20)
        Me.TxtS.TabIndex = 7
        Me.TxtS.Tag = "FN"
        Me.TxtS.Text = "m_ip_sl"
        Me.TxtS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtS.Value = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Căn trái"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Căn trên"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(280, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cỡ chữ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Góc"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(212, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "X"
        '
        'TxtX
        '
        Me.TxtX.Format = "m_ip_sl"
        Me.TxtX.Location = New System.Drawing.Point(232, 29)
        Me.TxtX.MaxLength = 8
        Me.TxtX.Name = "TxtX"
        Me.TxtX.Size = New System.Drawing.Size(42, 20)
        Me.TxtX.TabIndex = 9
        Me.TxtX.Tag = "FN"
        Me.TxtX.Text = "m_ip_sl"
        Me.TxtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtX.Value = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(307, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Y"
        '
        'TxtY
        '
        Me.TxtY.Format = "m_ip_sl"
        Me.TxtY.Location = New System.Drawing.Point(327, 29)
        Me.TxtY.MaxLength = 8
        Me.TxtY.Name = "TxtY"
        Me.TxtY.Size = New System.Drawing.Size(42, 20)
        Me.TxtY.TabIndex = 11
        Me.TxtY.Tag = "FN"
        Me.TxtY.Text = "m_ip_sl"
        Me.TxtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtY.Value = 0
        '
        'cboR
        '
        Me.cboR.AutoSize = True
        Me.cboR.Location = New System.Drawing.Point(4, 46)
        Me.cboR.Name = "cboR"
        Me.cboR.Size = New System.Drawing.Size(100, 17)
        Me.cboR.TabIndex = 13
        Me.cboR.Text = "Lược bớt 3 số 0"
        Me.cboR.UseVisualStyleBackColor = True
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(232, 55)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(137, 20)
        Me.txtValue.TabIndex = 23
        Me.txtValue.Tag = "FC"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(193, 58)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(34, 13)
        Me.lbl.TabIndex = 22
        Me.lbl.Tag = ""
        Me.lbl.Text = "Giá trị"
        '
        'cboB
        '
        Me.cboB.AutoSize = True
        Me.cboB.Location = New System.Drawing.Point(4, 63)
        Me.cboB.Name = "cboB"
        Me.cboB.Size = New System.Drawing.Size(69, 17)
        Me.cboB.TabIndex = 24
        Me.cboB.Text = "Chữ đậm"
        Me.cboB.UseVisualStyleBackColor = True
        '
        'ctrProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.cboB)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.cboR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtY)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtX)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtA)
        Me.Controls.Add(Me.TxtS)
        Me.Controls.Add(Me.txtL)
        Me.Controls.Add(Me.txtT)
        Me.Controls.Add(Me.cboC)
        Me.Name = "ctrProperty"
        Me.Size = New System.Drawing.Size(381, 83)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboC As System.Windows.Forms.CheckBox
    Friend WithEvents txtL As hg3.hg3.txtNumeric
    Friend WithEvents txtT As hg3.hg3.txtNumeric
    Friend WithEvents TxtA As hg3.hg3.txtNumeric
    Friend WithEvents TxtS As hg3.hg3.txtNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtX As hg3.hg3.txtNumeric
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtY As hg3.hg3.txtNumeric
    Friend WithEvents cboR As System.Windows.Forms.CheckBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cboB As System.Windows.Forms.CheckBox

End Class
