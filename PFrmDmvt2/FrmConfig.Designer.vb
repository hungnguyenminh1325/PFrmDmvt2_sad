<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfig
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfig))
        Me.cbCOM = New System.Windows.Forms.ComboBox
        Me.gbBaudRate = New System.Windows.Forms.GroupBox
        Me.rb1152K = New System.Windows.Forms.RadioButton
        Me.rb300 = New System.Windows.Forms.RadioButton
        Me.rb600 = New System.Windows.Forms.RadioButton
        Me.rb1200 = New System.Windows.Forms.RadioButton
        Me.rb576K = New System.Windows.Forms.RadioButton
        Me.rb2400 = New System.Windows.Forms.RadioButton
        Me.rb384K = New System.Windows.Forms.RadioButton
        Me.rb4800 = New System.Windows.Forms.RadioButton
        Me.rb192K = New System.Windows.Forms.RadioButton
        Me.rb9600 = New System.Windows.Forms.RadioButton
        Me.rb144K = New System.Windows.Forms.RadioButton
        Me.lblComport = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.txtGiaTri = New System.Windows.Forms.TextBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnReadLine = New System.Windows.Forms.Button
        Me.btnReadExisting = New System.Windows.Forms.Button
        Me.gbParity = New System.Windows.Forms.GroupBox
        Me.rbMark = New System.Windows.Forms.RadioButton
        Me.rbEven = New System.Windows.Forms.RadioButton
        Me.rbSpace = New System.Windows.Forms.RadioButton
        Me.rbOdd = New System.Windows.Forms.RadioButton
        Me.rbNone = New System.Windows.Forms.RadioButton
        Me.gbDataBits = New System.Windows.Forms.GroupBox
        Me.rb8 = New System.Windows.Forms.RadioButton
        Me.rb5 = New System.Windows.Forms.RadioButton
        Me.rb7 = New System.Windows.Forms.RadioButton
        Me.rb6 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.rb15 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.gbStopBits = New System.Windows.Forms.GroupBox
        Me.txtRemoveLetter = New System.Windows.Forms.TextBox
        Me.nWeigh = New System.Windows.Forms.NumericUpDown
        Me.lblRemoveLetter = New System.Windows.Forms.Label
        Me.lblWeigh = New System.Windows.Forms.Label
        Me.gbOutputConfig = New System.Windows.Forms.GroupBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbReadLine = New System.Windows.Forms.RadioButton
        Me.rbReadExisting = New System.Windows.Forms.RadioButton
        Me.txtGiaTri2 = New System.Windows.Forms.TextBox
        Me.gbBaudRate.SuspendLayout()
        Me.gbParity.SuspendLayout()
        Me.gbDataBits.SuspendLayout()
        Me.gbStopBits.SuspendLayout()
        CType(Me.nWeigh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOutputConfig.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbCOM
        '
        Me.cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCOM.FormattingEnabled = True
        Me.cbCOM.Location = New System.Drawing.Point(71, 11)
        Me.cbCOM.Name = "cbCOM"
        Me.cbCOM.Size = New System.Drawing.Size(203, 21)
        Me.cbCOM.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cbCOM, "Cổng COM kết nối với cân")
        '
        'gbBaudRate
        '
        Me.gbBaudRate.Controls.Add(Me.rb1152K)
        Me.gbBaudRate.Controls.Add(Me.rb300)
        Me.gbBaudRate.Controls.Add(Me.rb600)
        Me.gbBaudRate.Controls.Add(Me.rb1200)
        Me.gbBaudRate.Controls.Add(Me.rb576K)
        Me.gbBaudRate.Controls.Add(Me.rb2400)
        Me.gbBaudRate.Controls.Add(Me.rb384K)
        Me.gbBaudRate.Controls.Add(Me.rb4800)
        Me.gbBaudRate.Controls.Add(Me.rb192K)
        Me.gbBaudRate.Controls.Add(Me.rb9600)
        Me.gbBaudRate.Controls.Add(Me.rb144K)
        Me.gbBaudRate.Location = New System.Drawing.Point(12, 43)
        Me.gbBaudRate.Name = "gbBaudRate"
        Me.gbBaudRate.Size = New System.Drawing.Size(262, 121)
        Me.gbBaudRate.TabIndex = 1
        Me.gbBaudRate.TabStop = False
        Me.gbBaudRate.Text = "Baud rate:"
        '
        'rb1152K
        '
        Me.rb1152K.AutoSize = True
        Me.rb1152K.Location = New System.Drawing.Point(184, 67)
        Me.rb1152K.Name = "rb1152K"
        Me.rb1152K.Size = New System.Drawing.Size(59, 17)
        Me.rb1152K.TabIndex = 10
        Me.rb1152K.TabStop = True
        Me.rb1152K.Text = "115.2K"
        Me.rb1152K.UseVisualStyleBackColor = True
        '
        'rb300
        '
        Me.rb300.AutoSize = True
        Me.rb300.Location = New System.Drawing.Point(13, 21)
        Me.rb300.Name = "rb300"
        Me.rb300.Size = New System.Drawing.Size(43, 17)
        Me.rb300.TabIndex = 0
        Me.rb300.TabStop = True
        Me.rb300.Text = "300"
        Me.rb300.UseVisualStyleBackColor = True
        '
        'rb600
        '
        Me.rb600.AutoSize = True
        Me.rb600.Location = New System.Drawing.Point(13, 44)
        Me.rb600.Name = "rb600"
        Me.rb600.Size = New System.Drawing.Size(43, 17)
        Me.rb600.TabIndex = 1
        Me.rb600.TabStop = True
        Me.rb600.Text = "600"
        Me.rb600.UseVisualStyleBackColor = True
        '
        'rb1200
        '
        Me.rb1200.AutoSize = True
        Me.rb1200.Location = New System.Drawing.Point(13, 67)
        Me.rb1200.Name = "rb1200"
        Me.rb1200.Size = New System.Drawing.Size(49, 17)
        Me.rb1200.TabIndex = 2
        Me.rb1200.TabStop = True
        Me.rb1200.Text = "1200"
        Me.rb1200.UseVisualStyleBackColor = True
        '
        'rb576K
        '
        Me.rb576K.AutoSize = True
        Me.rb576K.Location = New System.Drawing.Point(184, 44)
        Me.rb576K.Name = "rb576K"
        Me.rb576K.Size = New System.Drawing.Size(53, 17)
        Me.rb576K.TabIndex = 9
        Me.rb576K.TabStop = True
        Me.rb576K.Text = "57.6K"
        Me.rb576K.UseVisualStyleBackColor = True
        '
        'rb2400
        '
        Me.rb2400.AutoSize = True
        Me.rb2400.Location = New System.Drawing.Point(13, 90)
        Me.rb2400.Name = "rb2400"
        Me.rb2400.Size = New System.Drawing.Size(49, 17)
        Me.rb2400.TabIndex = 3
        Me.rb2400.TabStop = True
        Me.rb2400.Text = "2400"
        Me.rb2400.UseVisualStyleBackColor = True
        '
        'rb384K
        '
        Me.rb384K.AutoSize = True
        Me.rb384K.Location = New System.Drawing.Point(184, 21)
        Me.rb384K.Name = "rb384K"
        Me.rb384K.Size = New System.Drawing.Size(53, 17)
        Me.rb384K.TabIndex = 8
        Me.rb384K.TabStop = True
        Me.rb384K.Text = "38.4K"
        Me.rb384K.UseVisualStyleBackColor = True
        '
        'rb4800
        '
        Me.rb4800.AutoSize = True
        Me.rb4800.Location = New System.Drawing.Point(94, 21)
        Me.rb4800.Name = "rb4800"
        Me.rb4800.Size = New System.Drawing.Size(49, 17)
        Me.rb4800.TabIndex = 4
        Me.rb4800.TabStop = True
        Me.rb4800.Text = "4800"
        Me.rb4800.UseVisualStyleBackColor = True
        '
        'rb192K
        '
        Me.rb192K.AutoSize = True
        Me.rb192K.Location = New System.Drawing.Point(94, 90)
        Me.rb192K.Name = "rb192K"
        Me.rb192K.Size = New System.Drawing.Size(53, 17)
        Me.rb192K.TabIndex = 7
        Me.rb192K.TabStop = True
        Me.rb192K.Text = "19.2K"
        Me.rb192K.UseVisualStyleBackColor = True
        '
        'rb9600
        '
        Me.rb9600.AutoSize = True
        Me.rb9600.Location = New System.Drawing.Point(94, 44)
        Me.rb9600.Name = "rb9600"
        Me.rb9600.Size = New System.Drawing.Size(49, 17)
        Me.rb9600.TabIndex = 5
        Me.rb9600.TabStop = True
        Me.rb9600.Text = "9600"
        Me.rb9600.UseVisualStyleBackColor = True
        '
        'rb144K
        '
        Me.rb144K.AutoSize = True
        Me.rb144K.Location = New System.Drawing.Point(94, 67)
        Me.rb144K.Name = "rb144K"
        Me.rb144K.Size = New System.Drawing.Size(53, 17)
        Me.rb144K.TabIndex = 6
        Me.rb144K.TabStop = True
        Me.rb144K.Text = "14.4K"
        Me.rb144K.UseVisualStyleBackColor = True
        '
        'lblComport
        '
        Me.lblComport.AutoSize = True
        Me.lblComport.Location = New System.Drawing.Point(12, 15)
        Me.lblComport.Name = "lblComport"
        Me.lblComport.Size = New System.Drawing.Size(53, 13)
        Me.lblComport.TabIndex = 11
        Me.lblComport.Text = "COM Port"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(461, 407)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "&Bỏ qua"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(380, 407)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "&Nhận"
        Me.ToolTip1.SetToolTip(Me.cmdOk, "Lưu tham số kết nối")
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtGiaTri
        '
        Me.txtGiaTri.BackColor = System.Drawing.Color.DarkBlue
        Me.txtGiaTri.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiaTri.ForeColor = System.Drawing.Color.Yellow
        Me.txtGiaTri.Location = New System.Drawing.Point(280, 50)
        Me.txtGiaTri.Multiline = True
        Me.txtGiaTri.Name = "txtGiaTri"
        Me.txtGiaTri.Size = New System.Drawing.Size(256, 54)
        Me.txtGiaTri.TabIndex = 12
        '
        'btnConnect
        '
        Me.btnConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Location = New System.Drawing.Point(280, 254)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(256, 61)
        Me.btnConnect.TabIndex = 7
        Me.btnConnect.Text = "KẾT NỐI"
        Me.ToolTip1.SetToolTip(Me.btnConnect, "Thử kết nối với cân theo tham số đã chọn")
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.RtsEnable = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'btnReadLine
        '
        Me.btnReadLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReadLine.Location = New System.Drawing.Point(191, 407)
        Me.btnReadLine.Name = "btnReadLine"
        Me.btnReadLine.Size = New System.Drawing.Size(75, 23)
        Me.btnReadLine.TabIndex = 10
        Me.btnReadLine.Text = "&ReadLine"
        Me.ToolTip1.SetToolTip(Me.btnReadLine, "Thử đọc dữ liệu bằng ReadLine")
        Me.btnReadLine.UseVisualStyleBackColor = True
        '
        'btnReadExisting
        '
        Me.btnReadExisting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReadExisting.Location = New System.Drawing.Point(272, 407)
        Me.btnReadExisting.Name = "btnReadExisting"
        Me.btnReadExisting.Size = New System.Drawing.Size(88, 23)
        Me.btnReadExisting.TabIndex = 11
        Me.btnReadExisting.Text = "Read&Existing"
        Me.ToolTip1.SetToolTip(Me.btnReadExisting, "Thử đọc dữ liệu bằng ReadExisting")
        Me.btnReadExisting.UseVisualStyleBackColor = True
        '
        'gbParity
        '
        Me.gbParity.Controls.Add(Me.rbMark)
        Me.gbParity.Controls.Add(Me.rbEven)
        Me.gbParity.Controls.Add(Me.rbSpace)
        Me.gbParity.Controls.Add(Me.rbOdd)
        Me.gbParity.Controls.Add(Me.rbNone)
        Me.gbParity.Location = New System.Drawing.Point(12, 171)
        Me.gbParity.Name = "gbParity"
        Me.gbParity.Size = New System.Drawing.Size(262, 68)
        Me.gbParity.TabIndex = 2
        Me.gbParity.TabStop = False
        Me.gbParity.Text = "Parity:"
        '
        'rbMark
        '
        Me.rbMark.AutoSize = True
        Me.rbMark.Location = New System.Drawing.Point(81, 42)
        Me.rbMark.Name = "rbMark"
        Me.rbMark.Size = New System.Drawing.Size(49, 17)
        Me.rbMark.TabIndex = 3
        Me.rbMark.TabStop = True
        Me.rbMark.Text = "Mark"
        Me.rbMark.UseVisualStyleBackColor = True
        '
        'rbEven
        '
        Me.rbEven.AutoSize = True
        Me.rbEven.Location = New System.Drawing.Point(12, 19)
        Me.rbEven.Name = "rbEven"
        Me.rbEven.Size = New System.Drawing.Size(50, 17)
        Me.rbEven.TabIndex = 0
        Me.rbEven.TabStop = True
        Me.rbEven.Text = "Even"
        Me.rbEven.UseVisualStyleBackColor = True
        '
        'rbSpace
        '
        Me.rbSpace.AutoSize = True
        Me.rbSpace.Location = New System.Drawing.Point(159, 19)
        Me.rbSpace.Name = "rbSpace"
        Me.rbSpace.Size = New System.Drawing.Size(56, 17)
        Me.rbSpace.TabIndex = 4
        Me.rbSpace.TabStop = True
        Me.rbSpace.Text = "Space"
        Me.rbSpace.UseVisualStyleBackColor = True
        '
        'rbOdd
        '
        Me.rbOdd.AutoSize = True
        Me.rbOdd.Location = New System.Drawing.Point(12, 42)
        Me.rbOdd.Name = "rbOdd"
        Me.rbOdd.Size = New System.Drawing.Size(45, 17)
        Me.rbOdd.TabIndex = 1
        Me.rbOdd.TabStop = True
        Me.rbOdd.Text = "Odd"
        Me.rbOdd.UseVisualStyleBackColor = True
        '
        'rbNone
        '
        Me.rbNone.AutoSize = True
        Me.rbNone.Location = New System.Drawing.Point(81, 19)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(51, 17)
        Me.rbNone.TabIndex = 2
        Me.rbNone.TabStop = True
        Me.rbNone.Text = "None"
        Me.rbNone.UseVisualStyleBackColor = True
        '
        'gbDataBits
        '
        Me.gbDataBits.Controls.Add(Me.rb8)
        Me.gbDataBits.Controls.Add(Me.rb5)
        Me.gbDataBits.Controls.Add(Me.rb7)
        Me.gbDataBits.Controls.Add(Me.rb6)
        Me.gbDataBits.Location = New System.Drawing.Point(150, 248)
        Me.gbDataBits.Name = "gbDataBits"
        Me.gbDataBits.Size = New System.Drawing.Size(124, 68)
        Me.gbDataBits.TabIndex = 4
        Me.gbDataBits.TabStop = False
        Me.gbDataBits.Text = "Data bits:"
        '
        'rb8
        '
        Me.rb8.AutoSize = True
        Me.rb8.Location = New System.Drawing.Point(74, 42)
        Me.rb8.Name = "rb8"
        Me.rb8.Size = New System.Drawing.Size(31, 17)
        Me.rb8.TabIndex = 3
        Me.rb8.TabStop = True
        Me.rb8.Text = "8"
        Me.rb8.UseVisualStyleBackColor = True
        '
        'rb5
        '
        Me.rb5.AutoSize = True
        Me.rb5.Location = New System.Drawing.Point(21, 19)
        Me.rb5.Name = "rb5"
        Me.rb5.Size = New System.Drawing.Size(31, 17)
        Me.rb5.TabIndex = 0
        Me.rb5.TabStop = True
        Me.rb5.Text = "5"
        Me.rb5.UseVisualStyleBackColor = True
        '
        'rb7
        '
        Me.rb7.AutoSize = True
        Me.rb7.Location = New System.Drawing.Point(74, 19)
        Me.rb7.Name = "rb7"
        Me.rb7.Size = New System.Drawing.Size(31, 17)
        Me.rb7.TabIndex = 2
        Me.rb7.TabStop = True
        Me.rb7.Text = "7"
        Me.rb7.UseVisualStyleBackColor = True
        '
        'rb6
        '
        Me.rb6.AutoSize = True
        Me.rb6.Location = New System.Drawing.Point(21, 42)
        Me.rb6.Name = "rb6"
        Me.rb6.Size = New System.Drawing.Size(31, 17)
        Me.rb6.TabIndex = 1
        Me.rb6.TabStop = True
        Me.rb6.Text = "6"
        Me.rb6.UseVisualStyleBackColor = True
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(81, 19)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(31, 17)
        Me.rb2.TabIndex = 2
        Me.rb2.TabStop = True
        Me.rb2.Text = "2"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb15
        '
        Me.rb15.AutoSize = True
        Me.rb15.Location = New System.Drawing.Point(12, 42)
        Me.rb15.Name = "rb15"
        Me.rb15.Size = New System.Drawing.Size(40, 17)
        Me.rb15.TabIndex = 1
        Me.rb15.TabStop = True
        Me.rb15.Text = "1.5"
        Me.rb15.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Location = New System.Drawing.Point(12, 19)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(31, 17)
        Me.rb1.TabIndex = 0
        Me.rb1.TabStop = True
        Me.rb1.Text = "1"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'gbStopBits
        '
        Me.gbStopBits.Controls.Add(Me.rb2)
        Me.gbStopBits.Controls.Add(Me.rb1)
        Me.gbStopBits.Controls.Add(Me.rb15)
        Me.gbStopBits.Location = New System.Drawing.Point(12, 248)
        Me.gbStopBits.Name = "gbStopBits"
        Me.gbStopBits.Size = New System.Drawing.Size(132, 68)
        Me.gbStopBits.TabIndex = 3
        Me.gbStopBits.TabStop = False
        Me.gbStopBits.Text = "Stop bits:"
        '
        'txtRemoveLetter
        '
        Me.txtRemoveLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemoveLetter.Location = New System.Drawing.Point(92, 19)
        Me.txtRemoveLetter.Name = "txtRemoveLetter"
        Me.txtRemoveLetter.Size = New System.Drawing.Size(426, 22)
        Me.txtRemoveLetter.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtRemoveLetter, "Các từ và cụm từ cần loại bỏ trong chuỗi kết quả cân đẩy ra. Cách nhau bởi dấu cá" & _
                "ch")
        '
        'nWeigh
        '
        Me.nWeigh.DecimalPlaces = 3
        Me.nWeigh.Location = New System.Drawing.Point(92, 47)
        Me.nWeigh.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nWeigh.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.nWeigh.Name = "nWeigh"
        Me.nWeigh.Size = New System.Drawing.Size(170, 20)
        Me.nWeigh.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.nWeigh, "Nhân kết quả với hệ số để được kết quả cuối cùng")
        '
        'lblRemoveLetter
        '
        Me.lblRemoveLetter.AutoSize = True
        Me.lblRemoveLetter.Location = New System.Drawing.Point(11, 24)
        Me.lblRemoveLetter.Name = "lblRemoveLetter"
        Me.lblRemoveLetter.Size = New System.Drawing.Size(65, 13)
        Me.lblRemoveLetter.TabIndex = 123
        Me.lblRemoveLetter.Text = "Ký tự loại bỏ"
        '
        'lblWeigh
        '
        Me.lblWeigh.AutoSize = True
        Me.lblWeigh.Location = New System.Drawing.Point(11, 51)
        Me.lblWeigh.Name = "lblWeigh"
        Me.lblWeigh.Size = New System.Drawing.Size(62, 13)
        Me.lblWeigh.TabIndex = 124
        Me.lblWeigh.Text = "Hệ số nhân"
        '
        'gbOutputConfig
        '
        Me.gbOutputConfig.Controls.Add(Me.txtRemoveLetter)
        Me.gbOutputConfig.Controls.Add(Me.lblWeigh)
        Me.gbOutputConfig.Controls.Add(Me.nWeigh)
        Me.gbOutputConfig.Controls.Add(Me.lblRemoveLetter)
        Me.gbOutputConfig.Location = New System.Drawing.Point(12, 322)
        Me.gbOutputConfig.Name = "gbOutputConfig"
        Me.gbOutputConfig.Size = New System.Drawing.Size(524, 76)
        Me.gbOutputConfig.TabIndex = 6
        Me.gbOutputConfig.TabStop = False
        Me.gbOutputConfig.Text = "Output configuration"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbReadLine)
        Me.GroupBox1.Controls.Add(Me.rbReadExisting)
        Me.GroupBox1.Location = New System.Drawing.Point(280, 171)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 68)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Read mode:"
        '
        'rbReadLine
        '
        Me.rbReadLine.AutoSize = True
        Me.rbReadLine.Location = New System.Drawing.Point(12, 19)
        Me.rbReadLine.Name = "rbReadLine"
        Me.rbReadLine.Size = New System.Drawing.Size(71, 17)
        Me.rbReadLine.TabIndex = 0
        Me.rbReadLine.TabStop = True
        Me.rbReadLine.Text = "ReadLine"
        Me.rbReadLine.UseVisualStyleBackColor = True
        '
        'rbReadExisting
        '
        Me.rbReadExisting.AutoSize = True
        Me.rbReadExisting.Location = New System.Drawing.Point(100, 19)
        Me.rbReadExisting.Name = "rbReadExisting"
        Me.rbReadExisting.Size = New System.Drawing.Size(87, 17)
        Me.rbReadExisting.TabIndex = 1
        Me.rbReadExisting.TabStop = True
        Me.rbReadExisting.Text = "ReadExisting"
        Me.rbReadExisting.UseVisualStyleBackColor = True
        '
        'txtGiaTri2
        '
        Me.txtGiaTri2.BackColor = System.Drawing.Color.DarkBlue
        Me.txtGiaTri2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiaTri2.ForeColor = System.Drawing.Color.Yellow
        Me.txtGiaTri2.Location = New System.Drawing.Point(280, 110)
        Me.txtGiaTri2.Multiline = True
        Me.txtGiaTri2.Name = "txtGiaTri2"
        Me.txtGiaTri2.Size = New System.Drawing.Size(256, 54)
        Me.txtGiaTri2.TabIndex = 13
        '
        'FrmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 442)
        Me.Controls.Add(Me.txtGiaTri2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbOutputConfig)
        Me.Controls.Add(Me.gbStopBits)
        Me.Controls.Add(Me.gbDataBits)
        Me.Controls.Add(Me.gbParity)
        Me.Controls.Add(Me.btnReadExisting)
        Me.Controls.Add(Me.btnReadLine)
        Me.Controls.Add(Me.lblComport)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtGiaTri)
        Me.Controls.Add(Me.cbCOM)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.gbBaudRate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thiết đặt kết nối cân điện tử"
        Me.gbBaudRate.ResumeLayout(False)
        Me.gbBaudRate.PerformLayout()
        Me.gbParity.ResumeLayout(False)
        Me.gbParity.PerformLayout()
        Me.gbDataBits.ResumeLayout(False)
        Me.gbDataBits.PerformLayout()
        Me.gbStopBits.ResumeLayout(False)
        Me.gbStopBits.PerformLayout()
        CType(Me.nWeigh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOutputConfig.ResumeLayout(False)
        Me.gbOutputConfig.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCOM As System.Windows.Forms.ComboBox
    Friend WithEvents gbBaudRate As System.Windows.Forms.GroupBox
    Friend WithEvents lblComport As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtGiaTri As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnReadLine As System.Windows.Forms.Button
    Friend WithEvents btnReadExisting As System.Windows.Forms.Button
    Friend WithEvents rb1152K As System.Windows.Forms.RadioButton
    Friend WithEvents rb576K As System.Windows.Forms.RadioButton
    Friend WithEvents rb384K As System.Windows.Forms.RadioButton
    Friend WithEvents rb192K As System.Windows.Forms.RadioButton
    Friend WithEvents rb144K As System.Windows.Forms.RadioButton
    Friend WithEvents rb9600 As System.Windows.Forms.RadioButton
    Friend WithEvents rb4800 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2400 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1200 As System.Windows.Forms.RadioButton
    Friend WithEvents rb600 As System.Windows.Forms.RadioButton
    Friend WithEvents rb300 As System.Windows.Forms.RadioButton
    Friend WithEvents gbParity As System.Windows.Forms.GroupBox
    Friend WithEvents rbSpace As System.Windows.Forms.RadioButton
    Friend WithEvents rbMark As System.Windows.Forms.RadioButton
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents rbOdd As System.Windows.Forms.RadioButton
    Friend WithEvents rbEven As System.Windows.Forms.RadioButton
    Friend WithEvents gbDataBits As System.Windows.Forms.GroupBox
    Friend WithEvents rb8 As System.Windows.Forms.RadioButton
    Friend WithEvents rb7 As System.Windows.Forms.RadioButton
    Friend WithEvents rb6 As System.Windows.Forms.RadioButton
    Friend WithEvents rb5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb15 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents gbStopBits As System.Windows.Forms.GroupBox
    Friend WithEvents txtRemoveLetter As System.Windows.Forms.TextBox
    Friend WithEvents nWeigh As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRemoveLetter As System.Windows.Forms.Label
    Friend WithEvents lblWeigh As System.Windows.Forms.Label
    Friend WithEvents gbOutputConfig As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbReadLine As System.Windows.Forms.RadioButton
    Friend WithEvents rbReadExisting As System.Windows.Forms.RadioButton
    Friend WithEvents txtGiaTri2 As System.Windows.Forms.TextBox
End Class
