<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCap
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblResolutions = New System.Windows.Forms.Label()
        Me.lblDevices = New System.Windows.Forms.Label()
        Me.cbResolutions = New System.Windows.Forms.ComboBox()
        Me.cbDevices = New System.Windows.Forms.ComboBox()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblResolutions)
        Me.pnlHeader.Controls.Add(Me.lblDevices)
        Me.pnlHeader.Controls.Add(Me.cbResolutions)
        Me.pnlHeader.Controls.Add(Me.cbDevices)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(784, 50)
        Me.pnlHeader.TabIndex = 0
        '
        'lblResolutions
        '
        Me.lblResolutions.AutoSize = True
        Me.lblResolutions.Location = New System.Drawing.Point(400, 18)
        Me.lblResolutions.Name = "lblResolutions"
        Me.lblResolutions.Size = New System.Drawing.Size(73, 13)
        Me.lblResolutions.TabIndex = 3
        Me.lblResolutions.Text = "Độ phân giải:"
        '
        'lblDevices
        '
        Me.lblDevices.AutoSize = True
        Me.lblDevices.Location = New System.Drawing.Point(12, 18)
        Me.lblDevices.Name = "lblDevices"
        Me.lblDevices.Size = New System.Drawing.Size(77, 13)
        Me.lblDevices.TabIndex = 2
        Me.lblDevices.Text = "Chọn Camera:"
        '
        'cbResolutions
        '
        Me.cbResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbResolutions.FormattingEnabled = True
        Me.cbResolutions.Location = New System.Drawing.Point(479, 15)
        Me.cbResolutions.Name = "cbResolutions"
        Me.cbResolutions.Size = New System.Drawing.Size(200, 21)
        Me.cbResolutions.TabIndex = 1
        '
        'cbDevices
        '
        Me.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDevices.FormattingEnabled = True
        Me.cbDevices.Location = New System.Drawing.Point(95, 15)
        Me.cbDevices.Name = "cbDevices"
        Me.cbDevices.Size = New System.Drawing.Size(280, 21)
        Me.cbDevices.TabIndex = 0
        '
        'pnlFooter
        '
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Controls.Add(Me.btnCapture)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 502)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(784, 60)
        Me.pnlFooter.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(400, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 30)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Hủy bỏ"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCapture
        '
        Me.btnCapture.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCapture.Location = New System.Drawing.Point(260, 15)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(120, 30)
        Me.btnCapture.TabIndex = 0
        Me.btnCapture.Text = "Chụp ảnh"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'pbPreview
        '
        Me.pbPreview.BackColor = System.Drawing.Color.Black
        Me.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbPreview.Location = New System.Drawing.Point(0, 50)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(784, 452)
        Me.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPreview.TabIndex = 2
        Me.pbPreview.TabStop = False
        '
        'FrmCap
        '
        Me.AcceptButton = Me.btnCapture
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.pbPreview)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "FrmCap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chụp ảnh sản phẩm"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents cbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents cbResolutions As System.Windows.Forms.ComboBox
    Friend WithEvents lblResolutions As System.Windows.Forms.Label
    Friend WithEvents lblDevices As System.Windows.Forms.Label
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox

End Class
