<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBarcode
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
        Me.pn2Top = New System.Windows.Forms.Panel
        Me.cblField = New System.Windows.Forms.CheckedListBox
        Me.tabProperty = New System.Windows.Forms.TabControl
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTemLabel = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtHItem = New hg3.hg3.txtNumeric
        Me.txtTop0 = New hg3.hg3.txtNumeric
        Me.txtwItem = New hg3.hg3.txtNumeric
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNumCells = New hg3.hg3.txtNumeric
        Me.txtLeft0 = New hg3.hg3.txtNumeric
        Me.txtNumRows = New hg3.hg3.txtNumeric
        Me.txtWidth = New hg3.hg3.txtNumeric
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtHeight = New hg3.hg3.txtNumeric
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pn2Top
        '
        Me.pn2Top.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pn2Top.BackColor = System.Drawing.Color.White
        Me.pn2Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pn2Top.Location = New System.Drawing.Point(179, 12)
        Me.pn2Top.Name = "pn2Top"
        Me.pn2Top.Size = New System.Drawing.Size(333, 135)
        Me.pn2Top.TabIndex = 296
        '
        'cblField
        '
        Me.cblField.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cblField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cblField.FormattingEnabled = True
        Me.cblField.Location = New System.Drawing.Point(521, 12)
        Me.cblField.Margin = New System.Windows.Forms.Padding(0)
        Me.cblField.Name = "cblField"
        Me.cblField.Size = New System.Drawing.Size(177, 257)
        Me.cblField.TabIndex = 297
        '
        'tabProperty
        '
        Me.tabProperty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabProperty.Location = New System.Drawing.Point(9, 154)
        Me.tabProperty.Margin = New System.Windows.Forms.Padding(0)
        Me.tabProperty.Name = "tabProperty"
        Me.tabProperty.Padding = New System.Drawing.Point(0, 0)
        Me.tabProperty.SelectedIndex = 0
        Me.tabProperty.Size = New System.Drawing.Size(505, 115)
        Me.tabProperty.TabIndex = 298
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(90, 276)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 318
        Me.btnCancel.Text = "&Bỏ qua"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(9, 276)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 317
        Me.btnSave.Text = "&Nhận"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtTemLabel)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtHItem)
        Me.Panel1.Controls.Add(Me.txtTop0)
        Me.Panel1.Controls.Add(Me.txtwItem)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtNumCells)
        Me.Panel1.Controls.Add(Me.txtLeft0)
        Me.Panel1.Controls.Add(Me.txtNumRows)
        Me.Panel1.Controls.Add(Me.txtWidth)
        Me.Panel1.Controls.Add(Me.Label53)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label52)
        Me.Panel1.Controls.Add(Me.txtHeight)
        Me.Panel1.Location = New System.Drawing.Point(9, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(164, 135)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 337
        Me.Label1.Text = "TÊN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(87, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 13)
        Me.Label6.TabIndex = 335
        Me.Label6.Text = "M"
        '
        'txtTemLabel
        '
        Me.txtTemLabel.Location = New System.Drawing.Point(42, 5)
        Me.txtTemLabel.Name = "txtTemLabel"
        Me.txtTemLabel.Size = New System.Drawing.Size(115, 20)
        Me.txtTemLabel.TabIndex = 320
        Me.txtTemLabel.Tag = "FC"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(87, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 336
        Me.Label7.Text = "P"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 333
        Me.Label4.Text = "R"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(9, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 334
        Me.Label5.Text = "C"
        '
        'txtHItem
        '
        Me.txtHItem.Format = "m_ip_sl"
        Me.txtHItem.Location = New System.Drawing.Point(115, 84)
        Me.txtHItem.MaxLength = 8
        Me.txtHItem.Name = "txtHItem"
        Me.txtHItem.Size = New System.Drawing.Size(42, 20)
        Me.txtHItem.TabIndex = 328
        Me.txtHItem.Tag = "FN"
        Me.txtHItem.Text = "m_ip_sl"
        Me.txtHItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHItem.Value = 0
        '
        'txtTop0
        '
        Me.txtTop0.Format = "m_ip_sl"
        Me.txtTop0.Location = New System.Drawing.Point(115, 32)
        Me.txtTop0.MaxLength = 8
        Me.txtTop0.Name = "txtTop0"
        Me.txtTop0.Size = New System.Drawing.Size(42, 20)
        Me.txtTop0.TabIndex = 323
        Me.txtTop0.Tag = "FN"
        Me.txtTop0.Text = "m_ip_sl"
        Me.txtTop0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTop0.Value = 0
        '
        'txtwItem
        '
        Me.txtwItem.Format = "m_ip_sl"
        Me.txtwItem.Location = New System.Drawing.Point(115, 110)
        Me.txtwItem.MaxLength = 8
        Me.txtwItem.Name = "txtwItem"
        Me.txtwItem.Size = New System.Drawing.Size(42, 20)
        Me.txtwItem.TabIndex = 329
        Me.txtwItem.Tag = "FN"
        Me.txtwItem.Text = "m_ip_sl"
        Me.txtwItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtwItem.Value = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 331
        Me.Label3.Text = "W"
        '
        'txtNumCells
        '
        Me.txtNumCells.Format = "m_ip_sl"
        Me.txtNumCells.Location = New System.Drawing.Point(42, 110)
        Me.txtNumCells.MaxLength = 8
        Me.txtNumCells.Name = "txtNumCells"
        Me.txtNumCells.Size = New System.Drawing.Size(42, 20)
        Me.txtNumCells.TabIndex = 327
        Me.txtNumCells.Tag = "FN"
        Me.txtNumCells.Text = "m_ip_sl"
        Me.txtNumCells.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumCells.Value = 0
        '
        'txtLeft0
        '
        Me.txtLeft0.Format = "m_ip_sl"
        Me.txtLeft0.Location = New System.Drawing.Point(115, 58)
        Me.txtLeft0.MaxLength = 8
        Me.txtLeft0.Name = "txtLeft0"
        Me.txtLeft0.Size = New System.Drawing.Size(42, 20)
        Me.txtLeft0.TabIndex = 325
        Me.txtLeft0.Tag = "FN"
        Me.txtLeft0.Text = "m_ip_sl"
        Me.txtLeft0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLeft0.Value = 0
        '
        'txtNumRows
        '
        Me.txtNumRows.Format = "m_ip_sl"
        Me.txtNumRows.Location = New System.Drawing.Point(42, 84)
        Me.txtNumRows.MaxLength = 8
        Me.txtNumRows.Name = "txtNumRows"
        Me.txtNumRows.Size = New System.Drawing.Size(42, 20)
        Me.txtNumRows.TabIndex = 326
        Me.txtNumRows.Tag = "FN"
        Me.txtNumRows.Text = "m_ip_sl"
        Me.txtNumRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNumRows.Value = 0
        '
        'txtWidth
        '
        Me.txtWidth.Format = "m_ip_sl"
        Me.txtWidth.Location = New System.Drawing.Point(42, 58)
        Me.txtWidth.MaxLength = 8
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(42, 20)
        Me.txtWidth.TabIndex = 322
        Me.txtWidth.Tag = "FN"
        Me.txtWidth.Text = "m_ip_sl"
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtWidth.Value = 0
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(86, 35)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(15, 13)
        Me.Label53.TabIndex = 324
        Me.Label53.Text = "T"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 330
        Me.Label2.Text = "H"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(87, 61)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(14, 13)
        Me.Label52.TabIndex = 332
        Me.Label52.Text = "L"
        '
        'txtHeight
        '
        Me.txtHeight.Format = "m_ip_sl"
        Me.txtHeight.Location = New System.Drawing.Point(42, 32)
        Me.txtHeight.MaxLength = 8
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(42, 20)
        Me.txtHeight.TabIndex = 321
        Me.txtHeight.Tag = "FN"
        Me.txtHeight.Text = "m_ip_sl"
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHeight.Value = 0
        '
        'FrmBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(707, 306)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tabProperty)
        Me.Controls.Add(Me.pn2Top)
        Me.Controls.Add(Me.cblField)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thiết lập mẫu tem"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pn2Top As System.Windows.Forms.Panel
    Friend WithEvents cblField As System.Windows.Forms.CheckedListBox
    Friend WithEvents tabProperty As System.Windows.Forms.TabControl
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTemLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHItem As hg3.hg3.txtNumeric
    Friend WithEvents txtTop0 As hg3.hg3.txtNumeric
    Friend WithEvents txtwItem As hg3.hg3.txtNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumCells As hg3.hg3.txtNumeric
    Friend WithEvents txtLeft0 As hg3.hg3.txtNumeric
    Friend WithEvents txtNumRows As hg3.hg3.txtNumeric
    Friend WithEvents txtWidth As hg3.hg3.txtNumeric
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As hg3.hg3.txtNumeric
End Class
