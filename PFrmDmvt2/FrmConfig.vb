Imports System.Data.SqlClient

Imports Microsoft.VisualBasic.CompilerServices
Imports hg3.hg3
Imports System.Data.SQLite
Imports System.Runtime.CompilerServices
Imports System.IO
Imports PPhotography.PPhotography
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Text

Public Class FrmConfig
    Dim sConn As SQLiteConnection
    Dim aConn As SqlConnection
    Dim oOption As Collection
    Dim oVar As Collection
    Dim values_scale As String = ""
    Private read_data As String
    Private Shared ReadOnly ScaleNumberRegex As New Regex("[-+]?[0-9]*[\.,]?[0-9]+", RegexOptions.Compiled)
    Private Const CONFIG_FILE As String = "config.json"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal sysConn As SQLiteConnection, ByVal appConn As SqlConnection, ByVal oOptions As Collection, ByVal oVars As Collection)
        InitializeComponent()
        sConn = sysConn
        aConn = appConn
        oOption = oOptions
        oVar = oVars
    End Sub

    Private Sub FrmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Me.LoadInfomation()
    End Sub

    Private Sub LoadInfomation()
        Try
            Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames
            Dim port As String
            For Each port In ports
                cbCOM.Items.Add(port)
            Next port

            SelectComPort(sqlite.GetValue(sConn, "Options", "val", "name = 'Scale_portcom'"))
            Write_BaudRate(GetOptionValue("Scale_baudrate", "9600"))
            Write_Parity(GetOptionValue("Scale_parity", "None"))
            Write_DataBits(GetOptionValue("Scale_databits", "8"))
            Write_StopBits(GetOptionValue("Scale_stopbits", "One"))
            Write_ReadMode(GetOptionValue("Scale_readmode", "ReadExisting"))
            txtRemoveLetter.Text = GetOptionValue("Scale_replace", "")
            nWeigh.Value = ParseDecimal(GetOptionValue("Scale_weigh", "1"), 1D)
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetOptionValue(ByVal optionName As String, ByVal defaultValue As String) As String
        Dim value As String = sqlite.GetValue(sConn, "Options", "val", "name = '" & optionName.Replace("'", "''") & "'")
        If value Is Nothing OrElse value.Trim = "" Then
            Return defaultValue
        End If
        Return value.Trim
    End Function

    Private Sub ClearConsole()
        txtGiaTri.Clear()
    End Sub

    Private Sub AppendConsole(ByVal text As String)
        If txtGiaTri.TextLength > 0 Then
            txtGiaTri.AppendText(Environment.NewLine)
        End If
        txtGiaTri.AppendText(DateTime.Now.ToString("HH:mm:ss") & "  " & text)
        txtGiaTri.SelectionStart = txtGiaTri.TextLength
        txtGiaTri.ScrollToCaret()
        Application.DoEvents()
    End Sub

    Private Function ConfigFilePath() As String
        Return Path.Combine(Application.StartupPath, CONFIG_FILE)
    End Function

    Private Sub LoadScaleConfig()
        Write_BaudRate("9600")
        Write_Parity("None")
        Write_DataBits("8")
        Write_StopBits("One")
        Write_ReadMode("ReadExisting")
        txtRemoveLetter.Text = ""
        nWeigh.Value = 1D

        If Not File.Exists(ConfigFilePath()) Then Return

        Dim json As String = File.ReadAllText(ConfigFilePath(), Encoding.UTF8)
        SelectComPort(ReadJsonValue(json, "port_name", ""))
        Write_BaudRate(ReadJsonValue(json, "baud_rate", "9600"))
        Write_Parity(ReadJsonValue(json, "parity", "None"))
        Write_DataBits(ReadJsonValue(json, "data_bits", "8"))
        Write_StopBits(ReadJsonValue(json, "stop_bits", "One"))
        Write_ReadMode(ReadJsonValue(json, "read_mode", "ReadExisting"))
        txtRemoveLetter.Text = ReadJsonValue(json, "remove_text", "")
        nWeigh.Value = ParseDecimal(ReadJsonValue(json, "multiplier", "1"), 1D)
    End Sub

    Private Function ReadJsonValue(ByVal json As String, ByVal key As String, ByVal defaultValue As String) As String
        Dim pattern As String = """" & Regex.Escape(key) & """\s*:\s*(""(?'text'[^""]*)""|(?'number'[-+]?[0-9]*[\.,]?[0-9]+))"
        Dim match As Match = Regex.Match(json, pattern, RegexOptions.IgnoreCase)
        If Not match.Success Then Return defaultValue
        If match.Groups("text").Success Then Return match.Groups("text").Value
        If match.Groups("number").Success Then Return match.Groups("number").Value
        Return defaultValue
    End Function

    Private Sub SaveScaleConfig()
        Dim json As New StringBuilder()
        json.AppendLine("{")
        json.AppendLine("  ""port_name"": """ & EscapeJson(cbCOM.Text.Trim) & """,")
        json.AppendLine("  ""baud_rate"": " & Read_BaudRate().ToString(CultureInfo.InvariantCulture) & ",")
        json.AppendLine("  ""data_bits"": " & Read_DataBits().ToString(CultureInfo.InvariantCulture) & ",")
        json.AppendLine("  ""parity"": """ & Read_Parity().ToString() & """,")
        json.AppendLine("  ""stop_bits"": """ & Read_StopBits().ToString() & """,")
        json.AppendLine("  ""read_mode"": """ & Read_ReadMode() & """,")
        json.AppendLine("  ""remove_text"": """ & EscapeJson(txtRemoveLetter.Text.Trim) & """,")
        json.AppendLine("  ""multiplier"": " & nWeigh.Value.ToString(CultureInfo.InvariantCulture))
        json.AppendLine("}")
        File.WriteAllText(ConfigFilePath(), json.ToString(), Encoding.UTF8)
    End Sub

    Private Function EscapeJson(ByVal value As String) As String
        If value Is Nothing Then Return ""
        Return value.Replace("\", "\\").Replace("""", "\""")
    End Function

    Private Sub SelectComPort(ByVal portName As String)
        If portName Is Nothing OrElse portName.Trim = "" Then Return

        For i As Integer = 0 To cbCOM.Items.Count - 1
            If String.Compare(cbCOM.Items(i).ToString(), portName.Trim, True) = 0 Then
                cbCOM.SelectedIndex = i
                Return
            End If
        Next
    End Sub

    Private Function Read_BaudRate() As Integer
        If (rb300.Checked) Then
            Return 300
        End If
        If (rb600.Checked) Then
            Return 600
        End If
        If (rb1200.Checked) Then
            Return 1200
        End If
        If (rb2400.Checked) Then
            Return 2400
        End If
        If (rb4800.Checked) Then
            Return 4800
        End If
        If (rb9600.Checked) Then
            Return 9600
        End If
        If (rb144K.Checked) Then
            Return 14400
        End If
        If (rb192K.Checked) Then
            Return 19200
        End If
        If (rb384K.Checked) Then
            Return 38400
        End If
        If (rb576K.Checked) Then
            Return 57600
        End If
        If (rb1152K.Checked) Then
            Return 115200
        End If
        Return 9600
    End Function

    Private Sub Write_BaudRate(ByVal _baudrate As String)
        Select Case _baudrate.Trim
            Case "300"
                rb300.Checked = True
            Case "600"
                rb600.Checked = True
            Case "1200"
                rb1200.Checked = True
            Case "2400"
                rb2400.Checked = True
            Case "4800"
                rb4800.Checked = True
            Case "9600"
                rb9600.Checked = True
            Case "14400"
                rb144K.Checked = True
            Case "19200"
                rb192K.Checked = True
            Case "38400"
                rb384K.Checked = True
            Case "57600"
                rb576K.Checked = True
            Case "115200"
                rb1152K.Checked = True
            Case Else
                rb9600.Checked = True
        End Select
    End Sub

    Private Function Read_Parity() As System.IO.Ports.Parity
        If (rbEven.Checked) Then
            Return System.IO.Ports.Parity.Even
        End If
        If (rbOdd.Checked) Then
            Return System.IO.Ports.Parity.Odd
        End If
        If (rbNone.Checked) Then
            Return System.IO.Ports.Parity.None
        End If
        If (rbMark.Checked) Then
            Return System.IO.Ports.Parity.Mark
        End If
        If (rbSpace.Checked) Then
            Return System.IO.Ports.Parity.Space
        End If
        Return System.IO.Ports.Parity.None
    End Function

    Private Sub Write_Parity(ByVal _parity As String)
        Select Case _parity.Trim.ToUpper()
            Case "EVEN"
                rbEven.Checked = True
            Case "ODD"
                rbOdd.Checked = True
            Case "NONE"
                rbNone.Checked = True
            Case "MARK"
                rbMark.Checked = True
            Case "SPACE"
                rbSpace.Checked = True
            Case Else
                rbNone.Checked = True
        End Select
    End Sub

    Private Function Read_DataBits() As Integer
        If (rb5.Checked) Then
            Return 5
        End If
        If (rb6.Checked) Then
            Return 6
        End If
        If (rb7.Checked) Then
            Return 7
        End If
        If (rb8.Checked) Then
            Return 8
        End If
        Return 8
    End Function

    Private Sub Write_DataBits(ByVal _databits As String)
        Select Case _databits.Trim.ToUpper()
            Case "5"
                rb5.Checked = True
            Case "6"
                rb6.Checked = True
            Case "7"
                rb7.Checked = True
            Case "8"
                rb8.Checked = True
            Case Else
                rb8.Checked = True
        End Select
    End Sub

    Private Function Read_StopBits() As System.IO.Ports.StopBits
        If (rb1.Checked) Then
            Return System.IO.Ports.StopBits.One
        End If
        If (rb15.Checked) Then
            Return System.IO.Ports.StopBits.OnePointFive
        End If
        If (rb2.Checked) Then
            Return System.IO.Ports.StopBits.Two
        End If
        Return System.IO.Ports.StopBits.One
    End Function

    Private Sub Write_StopBits(ByVal _stopbits As String)
        Select Case _stopbits.Trim.ToUpper()
            Case "ONE"
                rb1.Checked = True
            Case "ONEPOINTFIVE"
                rb15.Checked = True
            Case "TWO"
                rb2.Checked = True
            Case Else
                rb1.Checked = True
        End Select
    End Sub

    Private Function Read_ReadMode() As String
        If (rbReadExisting.Checked) Then
            Return "ReadExisting"
        Else
            Return "ReadLine"
        End If
    End Function

    Private Sub Write_ReadMode(ByVal _readmode As String)
        Select Case _readmode.Trim.ToUpper()
            Case "READLINE"
                rbReadLine.Checked = True
            Case "READEXISTING"
                rbReadExisting.Checked = True
            Case Else
                rbReadLine.Checked = True
        End Select
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            Select Case btnConnect.Text.ToUpper()
                Case "KẾT NỐI"
                    Try
                        If cbCOM.Text.Trim = "" Then
                            msg.Alert("Hãy chọn cổng COM của cân")
                            Return
                        End If

                        btnConnect.Enabled = False
                        btnConnect.Text = "ĐANG DÒ..."
                        Application.DoEvents()

                        Dim sample As String = ""
                        If Not AutoDetectScale(cbCOM.Text.Trim, sample) Then
                            btnConnect.Text = "KẾT NỐI"
                            msg.Alert("Không nhận được dữ liệu cân trên cổng " & cbCOM.Text.Trim)
                            Return
                        End If

                        SaveSqliteConfig()
                        OpenSelectedSerialPort()
                        read_data = sample
                        DoUpdate()
                        btnConnect.Text = "NGẮT KẾT NỐI"
                    Catch ex As Exception
                        btnConnect.Text = "KẾT NỐI"
                        If cbCOM.Items.Count > 0 Then
                            msg.Alert(ex.ToString)
                        Else
                            msg.Alert("Máy tính chưa nhận kết nối cân")
                        End If
                        Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames
                        Dim port As String
                        cbCOM.Items.Clear()
                        For Each port In ports
                            cbCOM.Items.Add(port)
                        Next port
                    Finally
                        btnConnect.Enabled = True
                    End Try
                Case "NGẮT KẾT NỐI"
                    If SerialPort1.IsOpen Then
                        SerialPort1.Close()
                        btnConnect.Text = "KẾT NỐI"
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Function AutoDetectScale(ByVal portName As String, ByRef sample As String) As Boolean
        Dim baudRates As Integer() = New Integer() {Read_BaudRate(), 9600, 4800, 2400, 1200, 19200, 115200}
        Dim parities As System.IO.Ports.Parity() = New System.IO.Ports.Parity() {Read_Parity(), System.IO.Ports.Parity.None, System.IO.Ports.Parity.Even, System.IO.Ports.Parity.Odd}
        Dim dataBitsList As Integer() = New Integer() {Read_DataBits(), 8, 7}
        Dim stopBitsList As System.IO.Ports.StopBits() = New System.IO.Ports.StopBits() {Read_StopBits(), System.IO.Ports.StopBits.One, System.IO.Ports.StopBits.Two}

        For Each baud As Integer In baudRates
            For Each parity As System.IO.Ports.Parity In parities
                For Each dataBits As Integer In dataBitsList
                    For Each stopBits As System.IO.Ports.StopBits In stopBitsList
                        If TryReadScale(portName, baud, parity, dataBits, stopBits, sample) Then
                            Write_BaudRate(baud.ToString())
                            Write_Parity(parity.ToString())
                            Write_DataBits(dataBits.ToString())
                            Write_StopBits(stopBits.ToString())
                            Write_ReadMode("ReadExisting")
                            Return True
                        End If
                    Next
                Next
            Next
        Next

        Return False
    End Function

    Private Function TryReadScale(ByVal portName As String, ByVal baudRate As Integer, ByVal parity As System.IO.Ports.Parity, ByVal dataBits As Integer, ByVal stopBits As System.IO.Ports.StopBits, ByRef sample As String) As Boolean
        Try
            Using port As New System.IO.Ports.SerialPort(portName, baudRate, parity, dataBits, stopBits)
                port.Handshake = IO.Ports.Handshake.None
                port.RtsEnable = True
                port.ReadTimeout = 500
                port.Open()

                For i As Integer = 1 To 3
                    System.Threading.Thread.Sleep(150)
                    Dim data As String = port.ReadExisting()
                    If data IsNot Nothing AndAlso data.Trim <> "" Then
                        sample = data
                        If ScaleNumberRegex.IsMatch(data) Then Return True
                    End If
                Next
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return False
    End Function

    Private Sub OpenSelectedSerialPort()
        If SerialPort1.IsOpen() Then
            SerialPort1.Close()
        End If

        SerialPort1.PortName = cbCOM.Text.Trim
        SerialPort1.BaudRate = Read_BaudRate()
        SerialPort1.Parity = Read_Parity()
        SerialPort1.DataBits = Read_DataBits()
        SerialPort1.StopBits = Read_StopBits()
        SerialPort1.Handshake = IO.Ports.Handshake.None
        SerialPort1.RtsEnable = True
        SerialPort1.ReadTimeout = 500
        SerialPort1.Open()
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        If SerialPort1.IsOpen Then
            Try
                If rbReadLine.Checked Then
                    values_scale = SerialPort1.ReadLine
                Else
                    values_scale = SerialPort1.ReadExisting
                End If
                read_data = values_scale
                values_scale = ""
                Me.BeginInvoke(New EventHandler(AddressOf DoUpdate))
            Catch ex As Exception
                read_data = "0"
            End Try
        End If
    End Sub

    Public Sub DoUpdate()
        Me.txtGiaTri.Text = read_data
        Try
            Dim cutvalue As String = read_data.Replace(" ", "").Trim
            Dim replace As String() = txtRemoveLetter.Text.Trim.Split(" ")

            For i As Integer = 0 To replace.Length - 1
                If replace(i).Trim <> "" Then
                    cutvalue = Strings.Replace(cutvalue, replace(i), "")
                End If
            Next

            If cutvalue = "" Then
                Return
            End If

            Dim value As Decimal = ExtractScaleValue(cutvalue)
            Dim displayValue As String = (value * nWeigh.Value).ToString()
            txtGiaTri2.Text = displayValue

        Catch ex As Exception
            msg.Alert(ex.ToString)
        End Try
    End Sub

    Private Function ExtractScaleValue(ByVal rawValue As String) As Decimal
        If rawValue Is Nothing Then Return 0D

        Dim match As Match = ScaleNumberRegex.Match(rawValue)
        If Not match.Success Then Return 0D

        Return ParseDecimal(match.Value, 0D)
    End Function

    Private Function ParseDecimal(ByVal value As String, ByVal defaultValue As Decimal) As Decimal
        If value Is Nothing Then Return defaultValue

        Dim normalizedValue As String = value.Trim.Replace(",", ".")
        Dim result As Decimal
        If Decimal.TryParse(normalizedValue, NumberStyles.Any, CultureInfo.InvariantCulture, result) Then
            Return result
        End If

        If Decimal.TryParse(value.Trim, result) Then
            Return result
        End If

        Return defaultValue
    End Function

    Private Sub btnReadLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadLine.Click
        'Dim myBytes As String = ""
        'Do While (SerialPort1.BytesToRead > 0)
        '    myBytes = SerialPort1.ReadByte()
        '    txtGiaTri.AppendText(myBytes)
        'Loop
        Try
            values_scale = SerialPort1.ReadLine
            msg.Alert(values_scale)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReadExisting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadExisting.Click
        Try
            values_scale = SerialPort1.ReadExisting
            msg.Alert(values_scale)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        SaveSqliteConfig()

        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        Catch ex As Exception
        End Try
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SaveSqliteConfig()
        sqlite.SQLExecute(sConn, "DELETE FROM Options WHERE name IN ('Scale_yn', 'Scale_portcom', 'Scale_baudrate', 'Scale_parity', 'Scale_stopbits', 'Scale_databits', 'Scale_replace', 'Scale_weigh', 'Scale_readmode')")

        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_yn','C','Kết nối cân','E','1','0','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_portcom','C','Cổng COM kết nối','E','" + cbCOM.Text.Trim.Replace("'", "''") + "','COM1','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_baudrate','C','Baudrate kết nối','E','" + Read_BaudRate().ToString() + "','9600','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_parity','C','Parity kết nối','E','" + Read_Parity().ToString() + "','None','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_stopbits','C','Stopbits kết nối','E','" + Read_StopBits().ToString() + "','One','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_databits','C','Databits kết nối','E','" + Read_DataBits().ToString() + "','8','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_readmode','C','Chế độ đọc dữ liệu','E','" + Read_ReadMode() + "','ReadExisting','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_replace','C','Các chuỗi loại bỏ','E','" + txtRemoveLetter.Text.Trim.Replace("'", "''") + "','','','16/06/2015','16/06/2015',0,0)")
        sqlite.SQLExecute(sConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','Scale_weigh','C','Hệ số nhân','E','" + nWeigh.Value.ToString(CultureInfo.InvariantCulture) + "','1','','16/06/2015','16/06/2015',0,0)")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub FrmConfig_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
