Imports hg3.hg3
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices
Imports Microsoft.Win32
Imports System.DBNull
Imports System.Drawing.Printing
Imports System.IO
Imports Hgbarcode
Imports PFrmPrint
Imports PFrmPND
Imports PFrmLib
Imports System.Net
Imports QRCoder
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Input
Imports System.IO.Ports
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip

Public Class ctrItem
    '' Danh muc vat tu
    Private sysConn As New SQLiteConnection
    Private appConn As New SqlConnection
    Private oOptions As New Collection
    Private oVar As Collection
    Private _keyitem As String
    Private _keygroup As String
    Private i_Keygroup As String
    Private g_Keyfield As String
    Private i_view As DataTable
    Private g_viewselect As DataTable
    Private g_view As DataTable
    '--------------------------
    Private _exchage As String = "exchange"
    Private i_table As String
    Private i_basetable As String
    Private i_title As String
    Private i_groupfield As String
    Private i_groupnamefield As String
    Private i_keyfield As String
    Private i_field As String
    Private i_fieldOther As String = ""
    Private i_header As String
    Private i_format As String
    Private i_width As String
    Private i_filter As String
    Private i_rptfile As String
    Private i_readony As String
    Public e_view As New DataView
    Private i_flagwidth As Boolean = False
    Private i_ds As DataView

    Private tbsDetail As DataGridTableStyle
    Private tbcDetail As DataGridTextBoxColumn()
    Private i_InvUnitDetail As Voucherlib.VoucherLibObj
    Private i_InvGroupDetail As Voucherlib.VoucherLibObj
    Private i_InvRuleBanDetail As Voucherlib.VoucherLibObj
    Private i_InvRuleMuaDetail As Voucherlib.VoucherLibObj
    Public cAction As String = "Start"
    Private dsTemMaster As New DataSet
    Private dsTemDetail As New DataSet

    Dim height1 As Integer
    Dim width1 As Integer
    Dim pLeft1 As Integer
    Dim pTop1 As Integer
    Dim mRow1 As Integer
    Dim mCell1 As Integer
    Dim nRow1 As Integer
    Dim nCell1 As Integer

    Private pd As New PrintDocument
    Private Preview As New PrintPreviewDialog
    Private dataOnePage As New DataSet
    ''
    Private Frmprint11 As FrmPrint1
    Public NamePrint As String

    Private iHeaderRow As Integer = 4
    Private iFirstRow As Integer = 5
    Private cFirstCol As Char = "A"
    Private iFirstCol As Integer = 1

    Private rptFile As String
    Private title_print As String
    Dim numberEdit As Integer
    Public flagStatus As Boolean = False
    Public flagVtEnter As Boolean = False
    Private flagCheckLoi As Boolean = False
    'Scale
    Private _status As Boolean = False
    Dim values_Scale As String = ""
    Public Shared picImage As PictureBox
    Dim itemDir As String = ""
    Dim itemDir2 As String = ""
    Private UserID As String
    Dim mota1 As String = ""
    Dim mota2 As String = ""
    Dim mota3 As String = ""
    Dim mota4 As String = ""
    Dim mota5 As String = ""
    Dim tenVat As String = ""
    Dim dsNCC As New DataSet
    Dim KieuInBartender As String = ""
    Dim InLuonSL As String = ""
    Dim TronGia5k As String = ""
    Private _Paused As Boolean = False

    Private thueSqlConn As SqlConnection
    Private forBackgroundRun As ForBackgroundRun
    Dim serverThueB As String = ""
    Dim dataThueB As String = ""
    Dim userThueB As String = ""
    Dim passThueB As String = ""
    Public Sub New(ByVal scnn As SQLiteConnection, ByVal acnn As SqlConnection, ByVal ooOption As Collection, ByVal oovar As Collection, ByVal iTable As String, ByVal iBaseTable As String, ByVal iKeyField As String, ByVal iKeyGroup As String, ByVal gKeyfield As String, ByRef iview As DataTable, ByRef gview As DataTable, ByRef ids As DataView, ByVal UserID As String)
        Me.sysConn = scnn
        Me.appConn = acnn
        Me.oOptions = ooOption
        Me.oVar = oovar
        Me.i_table = iTable
        Me.i_basetable = iBaseTable
        Me.i_keyfield = iKeyField
        Me.i_Keygroup = iKeyGroup
        Me.i_view = iview
        Me.g_view = gview
        Me.g_Keyfield = gKeyfield
        Me.i_ds = ids
        Me.UserID = UserID
        Globalvar.AppVariable.InitLogin(UserID, acnn)
        InitializeComponent()
    End Sub
    Private Sub ctrExchange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        itemDir = Me.oVar("itemDir").ToString
        Try
            itemDir2 = Me.oVar("itemDir2").ToString
        Catch ex As Exception
            msg.Alert("Bị lỗi thiếu biến itemDir2. Hãy tắt pm đi bật lại!")
            sqlite.SQLExecute(sysConn, "DELETE FROM Sysvar WHERE name IN ('itemDir2')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Sysvar (name,type,descript,val,defaul,datetime0,datetime2,user_id0,user_id2) VALUES ('itemDir2','C','Đường dẫn chứa ảnh chung để lưu ảnh sản phẩm khi làm nhiều máy',' ',' ','08/12/2015','08/12/2015',0,0)")
        End Try
        If Len(itemDir2.Trim) > 1 Then
            itemDir = itemDir2
        End If
        RefreshControl(Me.Controls.GetEnumerator)
        _setStatus()
        LoadTems()
        LoadNCC()
        AddHandler pd.PrintPage, New PrintPageEventHandler(AddressOf Me.pd_Print)
        'Dim obj1 As New Dirlib.CharLib(Me.txts12, "0, 1, 2")
        Dim text1 As String = "1=1"
        Dim lib1 As New Dirlib.DirLib(Me.txtFk_Nhvt2ID, Me.lblNhvt2Name, Me.sysConn, Me.appConn, "dmnhvt2", "Nhvt2ID", "Nhvt2Name", "Itemgroup", text1, False, Me.cmdCancel, "Nhvt2ID || NHvt2Name")
        Dim lib2 As New Dirlib.DirLib(Me.txtFk_DvtID, Me.lblDvtName, Me.sysConn, Me.appConn, "dmdvt", "dvtid", "dvtName", "Unit", text1, False, Me.cmdCancel, "dvtid || dvtName")
        Dim lib3 As New Dirlib.DirLib(Me.txtFk_qttgID, Me.TblQttgName, Me.sysConn, Me.appConn, "dmqttg", "QttgID", "QttgName", "priceruler", text1, True, Me.cmdCancel, "QttgID || QttgName")
        Dim lib4 As New Dirlib.DirLib(Me.txtFk_qttgID1, Me.TblQttgName1, Me.sysConn, Me.appConn, "dmqttg", "QttgID", "QttgName", "priceruler", text1, True, Me.cmdCancel, "QttgID || QttgName")
        Try
            NamePrint = oOptions.Item("printNameDmvt")
        Catch ex As Exception
            NamePrint = "Microsoft XPS Document Writer"
            sqlite.SQLExecute(sysConn, "DELETE FROM Options WHERE name IN ('printNameDmvt')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','printNameDmvt','C','Tên máy in mặc định trên máy in tem Dmvt','E','Microsoft XPS Document Writer','Microsoft XPS Document Writer','','14/12/2021','14/12/2021',0,0)")
            msg.Alert("Lỗi biến printNameDmvt ở sqlite. Hãy tắt phần mềm đi bật lại")
        End Try
        Try
            mota1 = oOptions.Item("mota1")
            mota2 = oOptions.Item("mota2")
            mota3 = oOptions.Item("mota3")
            mota4 = oOptions.Item("mota4")
            mota5 = oOptions.Item("mota5")
        Catch ex As Exception
            mota1 = "Hãng SX"
            mota2 = "Mô tả đá chủ"
            mota3 = "Mô tả đá còn"
            mota4 = "Mô tả khác"
            mota5 = "Mã GIA"
            sqlite.SQLExecute(sysConn, "DELETE FROM Options WHERE name IN ('mota1','mota2','mota3','mota4','mota5')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','mota1','C','Nhãn mô tả 1 trên dm hàng hóa','E','Hãng SX','Hãng SX','','06/03/2024','06/03/2024',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','mota2','C','Nhãn mô tả 2 trên dm hàng hóa','E','Mô tả đá chủ','Mô tả đá chủ','','06/03/2024','06/03/2024',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','mota3','C','Nhãn mô tả 3 trên dm hàng hóa','E','Ghi chú đá','Mô tả đá còn','','06/03/2024','06/03/2024',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','mota4','C','Nhãn mô tả 4 trên dm hàng hóa','E','Mô tả khác','Mô tả khác','','06/03/2024','06/03/2024',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','mota5','C','Nhãn mô tả 5 trên dm hàng hóa','E','Mã GIA','Mã GIA','','06/03/2024','06/03/2024',0,0)")
            msg.Alert("Lỗi biến mota1, 2, 3, 4, 5 ở sqlite. Hãy tắt phần mềm đi bật lại")
        End Try
        lblS1.Text = mota1
        lblS2.Text = mota2
        lbls3.Text = mota3
        lbls10.Text = mota4
        lbls11.Text = mota5
        Try
            tenVat = oOptions.Item("tenVatDmvt")
        Catch ex As Exception
            tenVat = "1"
            sqlite.SQLExecute(sysConn, "DELETE FROM Options WHERE name IN ('tenVatDmvt')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','tenVatDmvt','C','Lấy tên VAT ghép theo hlg klv tiền công đá:1-ghép 0-không','E','1','1','','21/08/2024','21/08/2024',0,0)")
            msg.Alert("Lỗi biến tenVatDmvt ở sqlite. Hãy tắt phần mềm đi bật lại")
        End Try
        Try
            serverThueB = Me.oVar("serverThueB").ToString
            dataThueB = Me.oVar("dataThueB").ToString
            userThueB = Me.oVar("userThueB").ToString
            passThueB = Me.oVar("passThueB").ToString
        Catch ex As Exception
            sqlite.SQLExecute(sysConn, "DELETE FROM Sysvar WHERE name IN ('serverThueB','dataThueB','userThueB','passThueB')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Sysvar (name,type,descript,val,defaul,datetime0,datetime2,user_id0,user_id2) VALUES ('serverThueB','C','Tên máy chủ CSDL bên thuế để chuyển','ADMIN\SQLEXPRESS','name server B','20/09/2022','20/09/2022',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Sysvar (name,type,descript,val,defaul,datetime0,datetime2,user_id0,user_id2) VALUES ('dataThueB','C','Tên database CSDL bên thuế','Gold_kiemkhoB','data server B','20/09/2022','20/09/2022',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Sysvar (name,type,descript,val,defaul,datetime0,datetime2,user_id0,user_id2) VALUES ('userThueB','C','Tên truy cập CSDL bên thuế','sa','user server B','20/09/2022','20/09/2022',0,0)")
            sqlite.SQLExecute(sysConn, "INSERT INTO Sysvar (name,type,descript,val,defaul,datetime0,datetime2,user_id0,user_id2) VALUES ('passThueB','C','Mật khẩu truy cập CSDL bên thuế','sa','password server B','20/09/2022','20/09/2022',0,0)")
            msg.Alert("Bị lỗi thiếu biến kết nối đến database B serverThueB, dataThueB, userThueB,passThueB. Phần mềm sẽ được khởi động lại!")
            'Application.Restart()
            Me.Dispose()
        End Try
        Try
            KieuInBartender = oOptions.Item("InBartender")
        Catch ex As Exception
            KieuInBartender = "1"
            sqlite.SQLExecute(sysConn, "DELETE FROM Options WHERE name IN ('InBartender')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','InBartender','C','Dùng để in phần mềm bartender: 1-có, 0- không','E','1','0','','14/12/2021','14/12/2021',0,0)")
            msg.Alert("Lỗi biến InBartender ở sqlite. Hãy tắt phần mềm đi bật lại")
        End Try
        Try
            InLuonSL = oOptions.Item("SaveInTemSL")
        Catch ex As Exception
            InLuonSL = "1"
            sqlite.SQLExecute(sysConn, "DELETE FROM Options WHERE name IN ('SaveInTemSL')")
            sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','SaveInTemSL','C','Lúc bấm lưu tem theo số lượng thì có in luôn hay không: 1-có, 0- không','E','1','0','','14/12/2021','14/12/2021',0,0)")
            msg.Alert("Lỗi biến SaveInTemSL ở sqlite. Hãy tắt phần mềm đi bật lại")
        End Try
        'Try
        '    TronGia5k = oOptions.Item("tronGia5")
        'Catch ex As Exception
        '    TronGia5k = "0"
        '    sqlite.SQLExecute(sysConn, "DELETE FROM Options WHERE name IN ('tronGia5')")
        '    sqlite.SQLExecute(sysConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','tronGia5','C','Làm tròn tiền mốc 5k và 10k trong dmvt: 0-không, 1-có','E','0','0','','30/12/2025','30/12/2025',0,0)")
        '    msg.Alert("Lỗi biến tronGia5 ở sqlite. Hãy tắt phần mềm đi bật lại")
        'End Try
        TronGia5k = "1"

        TbrPreview.Visible = False
        'Set values Scale
        If cAction.ToLower = "new" Then
            _status = True
        Else
            _status = False
        End If
        InitialFunction()
    End Sub

    Private Sub InitialFunction()
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5111") = False) Then
            tbrAddItem.Enabled = False
            MớiToolStripMenuItem.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5112") = False) Then
            tbrEditItem.Enabled = False
            SửaToolStripMenuItem.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5113") = False) Then
            TbrDel.Enabled = False
            XóaToolStripMenuItem.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5114") = False) Then
            mnConfigCan.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5115") = False) Then
            cboTems.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5116") = False) Then
            TbrPreview.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5117") = False) Then
            TbrPrint.Enabled = False
            LưuVàInToolStripMenuItem.Enabled = False
            InMãVạchToolStripMenuItem.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5118") = False) Then
            mnNewTem.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu5119") = False) Then
            mnEditTem.Enabled = False
        End If
        If (Globalvar.AppVariable.CheckUserPermission(Globalvar.AppVariable.UserID, "Menu51110") = False) Then
            mnDelTem.Enabled = False
        End If
    End Sub

    Public Sub LoadTems()
        Me.cboTems.Items.Clear()
        dsTemMaster.Tables.Clear()
        Dim cmMaster As String = "SELECT * FROM TemLabel"
        sql.SQLRetrieve(Me.appConn, cmMaster, "Master", dsTemMaster)
        For Each dr As DataRow In dsTemMaster.Tables("Master").Rows
            cboTems.Items.Add(dr("LabelID"))
        Next
        Dim temUse As String = sqlite.GetValue(Me.sysConn, "Options", "val", "name = 'TemIDUsing'").ToString()
        If cboTems.Items.Contains(temUse) Then
            cboTems.SelectedItem = temUse
        Else
            If cboTems.Items.Count > 0 Then
                cboTems.SelectedIndex = 0
                'rboPrint.Visible = True
                'rboPreview.Visible = True
            Else
                cboTems.SelectedText = ""
                'rboPrint.Visible = False
                'rboPreview.Visible = False
            End If
        End If
    End Sub
    Private Sub _setStatus()
        Select Case cAction.ToLower
            Case "start"
                '' GrdExchange.ReadOnly = True
                tbrAddItem.Enabled = True
                tbrAddItem.Text = "&Mới"
                ''tbrDeleteItem.Enabled = True
                tbrEditItem.Enabled = True
                tbrEditItem.Text = "&Sửa"
                tbrCancel.Visible = False
                TbrDel.Enabled = True
                btnBrown.Enabled = False
                btnPick.Enabled = False
                '' TbrPND.Visible = True
                cbChonNCC.Enabled = False
                flagStatus = True
            Case "new"
                ''    GrdExchange.ReadOnly = False
                tbrAddItem.Text = "&Lưu"
                tbrEditItem.Enabled = False
                '' tbrDeleteItem.Enabled = False
                tbrCancel.Visible = True
                btnBrown.Enabled = True
                btnPick.Enabled = True
                ''   TbrPND.Visible = False
                flagStatus = True
            Case "edit"
                ''  GrdExchange.ReadOnly = False
                tbrEditItem.Text = "&Lưu"
                tbrAddItem.Enabled = False
                '' tbrDeleteItem.Enabled = False
                ''  colVtID.TextBox.Enabled = False
                ''  colCode.TextBox.Enabled = False
                btnBrown.Enabled = True
                btnPick.Enabled = True
                tbrCancel.Visible = True
                ''  TbrPND.Visible = False
                flagStatus = True
        End Select
    End Sub

    '' Đếm số hàng trong dmvt
    Private Function checkCountVt() As Integer
        Dim dsC As New DataSet
        sql.SQLRetrieve(appConn, "SELECT COUNT(*) AS c FROM dmvt WHERE vtid NOT IN (SELECT FK_VtID FROM ct70)", "count", dsC)
        Return dsC.Tables("count").Rows(0)("c")
    End Function
    '' Hàm kiểm tra mã vạch đã tồn tại hay chưa 
    Private Function checkCode(ByVal code As String) As Boolean
        Dim strSql As String = "Select * From dmvt Where code = '" + code + "'"
        Dim dsCode As New DataSet
        sql.SQLRetrieve(appConn, strSql, "code", dsCode)

        If dsCode.Tables("code").Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub GenCodeItem(ByVal view As DataRow)
        txtVtID.Text = GetCodeItem(view)
    End Sub
    Private Function GetCodeItem(ByVal view As DataRow) As String
        Dim set1 As New DataSet
        sql.SQLRetrieve(Me.appConn, "Select Getdate() as SDate", "tblSdate", set1)
        Dim SDate As String = Strings.Mid(Strings.Trim(StringType.FromObject(set1.Tables.Item(0).Rows.Item(0).Item("Sdate"))), 1, 10)
        Dim Stt As String = ""
        Dim Ds1 As New DataSet
        Dim Dv1 As New DataView
        Dim text3 As String = ""
        Dim kt1 As String = ""
        'lấy ra 1 ký tự của tên hàng để tạo mã
        Dim Vtname As String = LTrim(txtVtName.Text)
        kt1 = Strings.Left(Vtname, 1)
        If kt1.ToUpper = "Đ" Then
            kt1 = "D"
        ElseIf kt1.ToUpper = "Ô" Then
            kt1 = "O"
        ElseIf kt1.ToUpper = "Ổ" Then
            kt1 = "O"
        End If
        Try
            Dim ds2 As New DataSet
            Dim text4 As String = "SELECT datepart(dd,getdate()) As Ngay,datepart(mm,getdate()) As Thang,right(datepart(yyyy,getdate()),2) As Nam"
            Dim da2 As SqlDataAdapter = New SqlDataAdapter(text4, Me.appConn)
            da2.Fill(ds2, "TblNTN")
            Dim nam As String = ""
            Dim thang As String = ""
            Dim ngay As String = ""
            If ds2.Tables("TblNTN").Rows(0)("nam").ToString.Length = 1 Then
                nam = "0" + ds2.Tables("TblNTN").Rows(0)("nam").ToString
            Else
                nam = ds2.Tables("TblNTN").Rows(0)("nam").ToString
            End If
            If ds2.Tables("TblNTN").Rows(0)("thang").ToString.Length = 1 Then
                thang = "0" + ds2.Tables("TblNTN").Rows(0)("thang").ToString
            Else
                thang = ds2.Tables("TblNTN").Rows(0)("thang").ToString
            End If
            If ds2.Tables("TblNTN").Rows(0)("ngay").ToString.Length = 1 Then
                ngay = "0" + ds2.Tables("TblNTN").Rows(0)("ngay").ToString
            Else
                ngay = ds2.Tables("TblNTN").Rows(0)("ngay").ToString
            End If
            'If kt = "" Then
            '    msg.Alert("Tên hàng không được để trống")
            '    txtVtName.Focus()
            '    Return
            'End If
            Dim kt As String = ""
            kt = kt1 + nam + thang + ngay
            text3 = "select MAX(RIGHT(RTRIM(VtID),3))  AS Stt FROM Dmvt WHERE LEN(RTRIM(VtID)) = 10 AND LEFT(RTRIM(VtID),7) = '" + kt + "'"
            Dim da1 As SqlDataAdapter = New SqlDataAdapter(text3, Me.appConn)
            da1.Fill(Ds1, "TblDmvt")
            Dv1.Table = Ds1.Tables("TblDmvt")
        Catch ex As Exception
            flagCheckLoi = True
            msg.Alert("Có lỗi xảy ra khi tăng ký tự của mã hàng")
        End Try
        If Dv1.Table.Rows.Count = 0 Or Information.IsDBNull(RuntimeHelpers.GetObjectValue(Dv1.Item(0).Item("stt"))) Then
            Stt = "001"
        Else
            Dim nStt As Integer = 0
            Try
                nStt = IntegerType.FromObject(Dv1.Item(0).Item("stt")) + 1
            Catch ex As Exception
                nStt = 1
            End Try
            If nStt < 10 Then
                Stt = "00" & StringType.FromObject(nStt).Trim
            Else
                If nStt < 100 Then
                    Stt = "0" & StringType.FromObject(nStt).Trim
                Else
                    If nStt < 1000 Then
                        Stt = StringType.FromObject(nStt).Trim
                    Else
                        flagCheckLoi = True
                        msg.Alert("Có nhiều hơn 999 mã trong ngày của nhóm hàng '" & Strings.Mid(view("FK_Nhvt2ID").ToString.Trim, 3, 1) & "'!.", 3)
                    End If
                End If
            End If
        End If
        Dim strVtID As String = ""
        strVtID = kt1.ToUpper & Strings.Mid(SDate, 9, 2) & Strings.Mid(SDate, 4, 2) & Strings.Mid(SDate, 1, 2) & Stt
        Return strVtID
    End Function
    Private Sub Genbarcode(ByVal view As DataRow)
        If view("code").ToString.Trim = "" Then
            'view("code") = cCode
            txtCode.Text = Getbarcode(view)
        End If
    End Sub

    Private Function Getbarcode(ByVal view As DataRow) As String
        Dim set2 As New DataSet
        Dim Dv2 As New DataView
        Dim text2 As String = "EXEC fs_HG_GEN_CODE_ITEM"
        Dim cCode As String = ""
        Try
            Do While (cCode = "") Or (Strings.Left(cCode, 3) <> "***")
                set2 = New DataSet
                Dv2 = New DataView
                sql.SQLRetrieve(Me.appConn, text2, "Tmp", set2)
                Dv2.Table = set2.Tables("Tmp")
                cCode = StringType.FromObject(Dv2.Item(0).Item("Code"))
                If Replace(cCode, "AA", "") <> cCode Or Replace(cCode, "DD", "") <> cCode Or Replace(cCode, "EE", "") <> cCode Or Replace(cCode, "OO", "") <> cCode Then
                    cCode = ""
                End If
                If Replace(cCode, "AS", "") <> cCode Or Replace(cCode, "AJ", "") <> cCode Or Replace(cCode, "AR", "") <> cCode Or Replace(cCode, "AX", "") <> cCode Or Replace(cCode, "AF", "") <> cCode Then
                    cCode = ""
                End If
                If Replace(cCode, "ES", "") <> cCode Or Replace(cCode, "EJ", "") <> cCode Or Replace(cCode, "ER", "") <> cCode Or Replace(cCode, "EX", "") <> cCode Or Replace(cCode, "EF", "") <> cCode Then
                    cCode = ""
                End If
                If Replace(cCode, "IS", "") <> cCode Or Replace(cCode, "IJ", "") <> cCode Or Replace(cCode, "IR", "") <> cCode Or Replace(cCode, "IX", "") <> cCode Or Replace(cCode, "IF", "") <> cCode Then
                    cCode = ""
                End If
                If Replace(cCode, "OS", "") <> cCode Or Replace(cCode, "OJ", "") <> cCode Or Replace(cCode, "OR", "") <> cCode Or Replace(cCode, "OX", "") <> cCode Or Replace(cCode, "OF", "") <> cCode Then
                    cCode = ""
                End If
                If Replace(cCode, "US", "") <> cCode Or Replace(cCode, "UJ", "") <> cCode Or Replace(cCode, "UR", "") <> cCode Or Replace(cCode, "UX", "") <> cCode Or Replace(cCode, "UF", "") <> cCode Then
                    cCode = ""
                End If
                If Replace(cCode, "W", "") <> cCode Then
                    cCode = ""
                End If
                If cCode <> "" Then
                    Exit Do
                End If
            Loop
        Catch
        End Try
        Return cCode
    End Function

    ''Private Sub tbrDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrDeleteItem.Click
    ''    If cAction.ToLower = "start" And e_view.Table.Rows.Count > 0 Then
    ''        If msg.Question("Bạn có chắc chắn muốn xóa không?") Then
    ''            For Each dr As DataRow In e_view.Table.Rows
    ''                Try
    ''                    sql.SQLDelete(Me.appConn, i_basetable, "VtID='" + dr("VtID").ToString.Trim + "'")
    ''                Catch
    ''                    msg.Alert("Đã có phát sinh không xóa được")
    ''                    Return
    ''                End Try
    ''                Dim dirImage As String = ""
    ''                dirImage = dr("ImagePath").ToString
    ''                If File.Exists(dirImage) Then
    ''                    File.Delete(dirImage)
    ''                End If
    ''            Next
    ''            Dim i As Integer = e_view.Table.Rows.Count - 1
    ''            While i >= 0
    ''                For Each dr1 As DataRow In i_ds.Table.Rows
    ''                    If dr1("VtID").ToString.ToLower = e_view.Table.Rows(i)("VtID").ToString.ToLower Then
    ''                        i_ds.Table.Rows.Remove(dr1)
    ''                        Exit For
    ''                    End If
    ''                Next
    ''                i = i - 1
    ''            End While
    ''        End If
    ''    End If
    ''End Sub
    Private Sub TbrBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbrPreview.Click
        If Me.cAction.ToLower = "start" Then
            If i_view.Rows.Count = 0 Then
                msg.Alert("Hãy chọn những mặt hàng cần in tem")
                Return
            End If
            If dataOnePage.Tables.Count = 0 Then
                dataOnePage = New DataSet
                Dim dt As New DataTable("BARCODE")
                For Each dc As DataColumn In i_view.Columns
                    dt.Columns.Add(dc.ColumnName, dc.DataType)
                Next
                dataOnePage.Tables.Add(dt)
            End If
            dataOnePage.Tables(0).Rows.Clear()
            Dim dr As DataRow = dataOnePage.Tables(0).NewRow
            If i_view.Rows.Count > 0 Then
                Dim dre_view As DataRow = i_view.Rows(0) ''e_view.Table.Rows(GrdExchange.CurrentRowIndex)
                For Each dc As DataColumn In dataOnePage.Tables(0).Columns
                    dr(dc.ColumnName) = dre_view(dc.ColumnName)
                Next
                dataOnePage.Tables(0).Rows.Add(dr)
                pd.PrinterSettings.PrinterName = NamePrint
                Preview.Document = pd
                Preview.Text = "HiVi Gold Barcode Printer 2.1"
                Preview.UseAntiAlias = True
                Preview.WindowState = FormWindowState.Maximized
                Preview.ShowDialog()
                Preview.PrintPreviewControl.Enabled = False
                Return
            End If
        Else
            msg.Alert("Chưa lưu không xem được !")
        End If
    End Sub
    Private Sub DrawIt(ByVal G As Graphics, ByVal data As DataSet, ByVal height1 As Integer, ByVal width1 As Integer, ByVal pLeft1 As Integer, ByVal pTop1 As Integer, ByVal mRow1 As Integer, ByVal mCell1 As Integer, ByVal nRow1 As Integer, ByVal nCell1 As Integer)
        'Dim labelID As String = cboTems.SelectedItem.ToString()
        Dim height As Integer = height1
        Dim width As Integer = width1
        Dim pLeft As Integer = pLeft1
        Dim pTop As Integer = pTop1
        Dim mRow As Integer = mRow1
        Dim mCell As Integer = mCell1
        Dim nRow As Integer = nRow1
        Dim nCell As Integer = nCell1
        Dim iRow As Integer = 0
        Dim iTem As Integer = 0
        Dim SpaceL As Integer = 0
        Dim SpaceT As Integer = 0
        Dim imageType As String = oOptions("imageType")
        Dim barcodeType As String = oOptions("barcodeType")
        Dim moneyType As String = oOptions("moneyType")
        Dim numberType As String = oOptions("numberType")
        Dim freeType As String = oOptions("freeType")
        Dim HgBarcode1 As New Hgbarcode.HgBarcode
        Dim txtNumber As New txtNumeric()
        While iRow < nRow
            SpaceL = 0
            SpaceT = SpaceT + pTop
            Dim iCell As Integer = 0
            While iCell < nCell
                SpaceL = SpaceL + pLeft
                Dim drItem As DataRow = data.Tables(0).Rows(iTem)
                For Each drTem As DataRow In dsTemDetail.Tables(0).Rows
                    Dim key As String = drTem("SubID")
                    Dim left0 As Integer = drTem("left0")
                    Dim top0 As Integer = drTem("top0")
                    Dim angle As Integer = drTem("angle")
                    Dim size As Integer = drTem("size")
                    Dim x1 As Integer = drTem("X")
                    Dim y1 As Integer = drTem("Y")
                    Dim enable As Boolean = Convert.ToBoolean(drTem("enable"))
                    Dim enable2 As Boolean = Convert.ToBoolean(drTem("enable2"))
                    Dim enable3 As Boolean = Convert.ToBoolean(drTem("enable3"))
                    Dim font As String = "tahoma"
                    Dim style As FontStyle = FontStyle.Regular
                    If enable3 Then
                        style = FontStyle.Bold
                    End If
                    Dim x As Integer = SpaceL + left0
                    Dim y As Integer = SpaceT + top0

                    If enable Then
                        If freeType.ToUpper.Replace(key.ToUpper, "#") <> freeType.ToUpper Then
                            If IsNumeric(drTem("value")) Then
                                Try
                                    If Convert.ToDecimal(drTem("value").ToString) = 0 Then
                                        Continue For
                                    End If
                                Catch ex As Exception
                                    Continue For
                                End Try
                            Else
                                If drTem("value").ToString = "" Then
                                    Continue For
                                End If
                            End If
                        Else
                            If IsNumeric(drItem(key)) Then
                                Try
                                    'Trường hợp k bắt được là do mã vạch là 1E4 thì isnumeric là true
                                    If Convert.ToDecimal(drItem(key).ToString) = 0 Then
                                        Continue For
                                    End If
                                Catch ex As Exception
                                    Continue For
                                End Try
                            Else
                                If key.ToUpper <> "CODE2" Then
                                    If drItem(key) = "" Then
                                        Continue For
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If angle <> 0 AndAlso angle <> 180 AndAlso angle <> 360 Then
                        x = SpaceT + top0
                        y = -(SpaceL + left0)
                    End If
                    G.RotateTransform(angle)
                    If imageType.ToUpper.Replace(key.ToUpper, "#") <> imageType.ToUpper Then 'key.ToUpper.Replace(imageType.ToUpper, "") <> key.ToUpper Then
                        If File.Exists(drItem(key).ToString) Then
                            G.DrawImage(Image.FromFile(drItem(key).ToString), x, y, x1, y1)
                        End If
                    ElseIf key.ToUpper = "CODE2" Then
                        G.DrawString(String.Format("{0}", drItem("code").ToString), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                    ElseIf barcodeType.ToUpper.Replace(key.ToUpper, "#") <> barcodeType.ToUpper Then
                        'x1,y1 chính là giá trị x, y chỉnh trong phần tem, khung ngon là 74,74
                        'dùng enable2 để đảo giữa 2 mã vạch (lược bớt 3 số 0) 
                        If enable2 Then
                            G.DrawImage(GetQrcode(drItem(key).ToString()), x, y, x1, y1)
                        Else
                            HgBarcode1.DrawBarcode(G, drItem(key).ToString(), size, x, y)
                        End If
                    ElseIf moneyType.ToUpper.Replace(key.ToUpper, "#") <> moneyType.ToUpper Then
                        txtNumber.Value = Convert.ToDecimal(drItem(key).ToString.Trim)
                        ''  msg.Alert(txtNumber.Value)
                        Dim tien As Decimal = 0
                        If enable2 Then 'Me.oOptions("format_gia").ToString = "1" Then
                            tien = txtNumber.Value / 1000
                        Else
                            tien = txtNumber.Value
                        End If
                        'HgBarcode1.DrawString(G, Strings.Format(tien, Me.oOptions("m_ip_tien")), size, x, y)
                        G.DrawString(Strings.Format(tien, Me.oOptions("m_ip_tien")), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                    ElseIf numberType.ToUpper.Replace(key.ToUpper, "#") <> numberType.ToUpper Then
                        txtNumber.Value = Convert.ToDecimal(drItem(key).ToString.Trim)
                        Dim so As Decimal = 0
                        If enable2 Then
                            so = txtNumber.Value / 1000
                        Else
                            so = txtNumber.Value
                        End If
                        'HgBarcode1.DrawString(G, txtNumber.Value, size, x, y)
                        G.DrawString(so, New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                    ElseIf freeType.ToUpper.Replace(key.ToUpper, "#") <> freeType.ToUpper Then
                        If key.ToUpper.Replace(imageType.ToUpper, "") <> key.ToUpper Then
                            If File.Exists(drTem("value").ToString) Then
                                G.DrawImage(Image.FromFile(drTem("value").ToString), x, y, x1, y1)
                            End If
                        Else
                            If key.ToUpper = "VALUE20" Then
                                txtNumber.Value = Convert.ToDecimal(drItem("Tong_tlg").ToString.Trim)
                                G.DrawString(getKLgam(txtNumber.Value), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                            ElseIf key.ToUpper = "VALUE21" Then
                                txtNumber.Value = Convert.ToDecimal(drItem("Tlg_au").ToString.Trim)
                                G.DrawString(getKLgam(txtNumber.Value), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                            ElseIf key.ToUpper = "VALUE22" Then
                                txtNumber.Value = Convert.ToDecimal(drItem("Tlg_da").ToString.Trim)
                                G.DrawString(getKLgam(txtNumber.Value), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                            Else
                                G.DrawString(drTem("value"), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                            End If
                        End If
                    ElseIf key.ToUpper = "TONG_TLG" Then
                        'HgBarcode1.DrawString(G, Me.txtTong_tlg.Text, size, x, y)
                        G.DrawString(Me.txtTong_tlg.Text, New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                    Else
                        'HgBarcode1.DrawString(G, drItem(key), size, x, y)
                        G.DrawString(drItem(key), New System.Drawing.Font(font, size, style), System.Drawing.Brushes.Black, x, y)
                    End If
                    G.RotateTransform(-angle)
                Next
                iTem = iTem + 1
                iCell = iCell + 1
                If iTem = data.Tables(0).Rows.Count Then
                    Return
                End If
                SpaceL = SpaceL + width
            End While
            iRow = iRow + 1
            SpaceT = SpaceT + height
        End While
    End Sub
    Private Sub pd_Print(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Select Case Me.oOptions("tem_unit").ToString().ToLower()
            Case "mm"
                e.Graphics.PageUnit = GraphicsUnit.Millimeter
            Case "inch"
                e.Graphics.PageUnit = GraphicsUnit.Inch
            Case "pixel"
                e.Graphics.PageUnit = GraphicsUnit.Pixel
        End Select
        DrawIt(e.Graphics, dataOnePage, height1, width1, pLeft1, pTop1, mRow1, mCell1, nRow1, nCell1)
    End Sub

    Private Function GetQrcode(ByVal StrData As String) As Image
        Try
            Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
            Dim qrCodeData As QRCoder.QRCodeData = qrGenerator.CreateQrCode(StrData, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As QRCode = New QRCode(qrCodeData)
            Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20)
            Return qrCodeImage
            'qrCodeImage.Save("qrcode.png")
            'Me.PictureBox1.Image = qrCodeImage

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Nothing
        End Try
    End Function
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnNewTem.Click
        Dim frmTem As New FrmBarcode(Me.sysConn, Me.appConn, Me.oOptions, Me.oVar, "new", Me, cboTems.Text)
        frmTem.ShowDialog()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEditTem.Click
        If cboTems.Items.Count > 0 Then
            Dim useTem As String = cboTems.SelectedItem.ToString
            Dim frmTem As New FrmBarcode(Me.sysConn, Me.appConn, Me.oOptions, Me.oVar, "edit", Me, useTem)
            frmTem.ShowDialog()
        Else
            msg.Alert("Bạn chưa thiết lập Mẫu in")
        End If
    End Sub

    Private Sub cboTems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTems.SelectedIndexChanged
        If cboTems.Items.Count > 0 Then
            If cboTems.SelectedItem.ToString <> "" Then
                dsTemDetail.Tables.Clear()
                For Each dr As DataRow In dsTemMaster.Tables(0).Rows
                    If dr("labelID").ToString.ToLower = cboTems.SelectedItem.ToString.ToLower Then
                        height1 = Convert.ToInt16(dr("height"))
                        width1 = Convert.ToInt16(dr("width"))
                        pLeft1 = Convert.ToInt16(dr("left0"))
                        pTop1 = Convert.ToInt16(dr("top0"))
                        mRow1 = Convert.ToInt16(dr("hItem"))
                        mCell1 = Convert.ToInt16(dr("wItem"))
                        nRow1 = Convert.ToInt16(dr("numRows"))
                        nCell1 = Convert.ToInt16(dr("numCells"))
                    End If
                Next
                sqlite.SQLExecute(Me.sysConn, "UPDATE Options SET Val = '" + cboTems.SelectedItem.ToString + "' WHERE name = 'temUse' ")
                sql.SQLRetrieve(Me.appConn, "SELECT * FROM Temdetail WHERE LabelID = N'" + cboTems.SelectedItem.ToString + "'", "Temdetail", dsTemDetail)
            End If
        End If
    End Sub
    Public Function getTemMaster() As DataRow
        For Each dr As DataRow In dsTemMaster.Tables(0).Rows
            If dr("labelID").ToString.ToLower = cboTems.SelectedItem.ToString.ToLower Then
                Return dr
            End If
        Next
        Return Nothing
    End Function
    Public Function getTemDetail() As DataSet
        Return dsTemDetail
    End Function

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnDelTem.Click
        If cboTems.Items.Count > 0 Then
            Dim useTem As String = cboTems.SelectedItem.ToString
            If useTem <> "" Then
                If Convert.ToInt16(msg.Question("Bạn có chắc chắn muốn xóa mẫu Tem: '" + useTem + "'")) = 1 Then
                    sql.SQLDelete(Me.appConn, "Temdetail", "LabelID = N'" + useTem + "'")
                    sql.SQLDelete(Me.appConn, "Temlabel", "LabelID = N'" + useTem + "'")
                    Me.LoadTems()
                End If
            End If
        Else
            msg.Alert("Bạn chưa thiết lập Mẫu in")
        End If
    End Sub

    Private Sub TbrPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbrPrint.Click
        printItem()
    End Sub
    Private Sub printItem()
        If Me.cAction.ToLower = "start" Then
            If KieuInBartender = "1" Then
                'xuất excel và in bartender
                'Dim FilePathSave As String
                'FilePathSave = StringType.FromObject(oVar.Item("reportDir")).Replace("report\", "export\") & "export2exceldmvt.xls"
                'ExportGridToExcel2(i_view, "Xuất dmvt để in tem", FilePathSave)
                'In bằng bartender
                If i_view.Rows.Count = 0 Then
                    msg.Alert("Hãy chọn những mặt hàng cần in tem")
                    Return
                End If
                inBartender(i_view)
            Else
                'in tem bằng phần mềm cũ vẫn dùng
                If i_view.Rows.Count = 0 Then
                    msg.Alert("Hãy chọn những mặt hàng cần in tem")
                    Return
                End If
                If dataOnePage.Tables.Count = 0 Then
                    dataOnePage = New DataSet
                    Dim dt As New DataTable("BARCODE")
                    For Each dc As DataColumn In i_view.Columns
                        dt.Columns.Add(dc.ColumnName, dc.DataType)
                    Next
                    dataOnePage.Tables.Add(dt)
                End If
                dataOnePage.Tables(0).Rows.Clear()
                Dim dr As DataRow = dataOnePage.Tables(0).NewRow
                For Each dc As DataColumn In dataOnePage.Tables(0).Columns
                    dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                Next
                dataOnePage.Tables(0).Rows.Add(dr)
                pd.PrinterSettings.PrinterName = NamePrint
                pd.Print()
                dataOnePage.Tables(0).Rows.Clear()
            End If
        Else
            msg.Alert("Chưa lưu không in được !")
        End If
    End Sub
    'Private Sub printItem()
    '    If Me.cAction.ToLower = "start" Then
    '        If i_view.Rows.Count = 0 Then
    '            msg.Alert("Hãy chọn những mặt hàng cần in tem")
    '            Return
    '        End If
    '        If dataOnePage.Tables.Count = 0 Then
    '            dataOnePage = New DataSet
    '            Dim dt As New DataTable("BARCODE")
    '            For Each dc As DataColumn In i_view.Columns
    '                dt.Columns.Add(dc.ColumnName, dc.DataType)
    '            Next
    '            dataOnePage.Tables.Add(dt)
    '        End If
    '        dataOnePage.Tables(0).Rows.Clear()
    '        Dim dr As DataRow = dataOnePage.Tables(0).NewRow
    '        For Each dc As DataColumn In dataOnePage.Tables(0).Columns
    '            dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
    '        Next
    '        dataOnePage.Tables(0).Rows.Add(dr)
    '        pd.PrinterSettings.PrinterName = NamePrint
    '        pd.Print()
    '        dataOnePage.Tables(0).Rows.Clear()
    '    Else
    '        msg.Alert("Chưa lưu không in được !")
    '    End If
    'End Sub
    Private Sub tbrCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrCancel.Click
        cancel()
        'msg.Alert(String.Format("time real: {0}", GetNetworkTime()))
    End Sub
    Private Sub cancel()
        Me.cAction = "start"
        setEnableControl(Me.Controls.GetEnumerator)
        Me.tbrAddItem.Image = ImageList1.Images.Item(1)
        _setStatus()
        i_view.Rows.Clear()
        closeScale()
        InitialFunction()
    End Sub
    'Hàm In hóa đơn
    Private Sub PrintAction()
        Try
            Dim row1 As DataRow = CType(sqlite.GetRow(sysConn, "Dir", "UPPER(Code) = 'STOCK'"), DataRow)
            Me.title_print = Strings.Trim(StringType.FromObject(row1.Item("title")))
            Me.rptFile = StringType.FromObject(oVar.Item("reportDir")) & Strings.Trim(StringType.FromObject(row1.Item("repfile")))
            MessageBox.Show(rptFile)
        Catch
        End Try

        If System.IO.File.Exists(Me.rptFile) Then
            If Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Frmprint11.pCRpt.FileName)) Then
                If Frmprint11.pCRpt.FileName.Trim = "" Then
                    Frmprint11.pCRpt.Load(rptFile)
                End If
            End If
        Else
            msg.Alert("Không thấy tệp mẫu in tại: " & rptFile, 3)
            Return

            'Frmprint11.CreateParametervalue("Title", "C", Me.title)
            'Frmprint11.CreateParametervalue("Ngay_ct", "C", Me.txtNgay_ct.Value)
            'Frmprint11.CreateParametervalue("So_ct", "C", Me.txtSo_ct.Text)
            'Frmprint11.CreateParametervalue("FK_DoitacID", "C", Me.txtFK_DoitacID.Text)
            'Frmprint11.CreateParametervalue("DoitacName", "C", Me.lblDoitacName.Text)
            'Frmprint11.CreateParametervalue("FK_BpkdID", "C", Me.txtFK_BpkdID.Text)
            'Frmprint11.CreateParametervalue("BpkdName", "C", Me.lblBpkdName.Text)
            'Frmprint11.CreateParametervalue("FK_KhoID", "C", Me.txtFK_KhoID.Text)
            'Frmprint11.CreateParametervalue("KhoName", "C", Me.lblKhoName.Text)
            'Frmprint11.CreateParametervalue("Dien_giai", "C", Me.txtDien_giai.Text)
            Frmprint11.pview1 = i_ds
            Frmprint11.printName = NamePrint
            Frmprint11.ShowDialog()
        End If
    End Sub

    Private Sub XóaDòngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbrDelRow.Click

        ''If e_view.Table.Rows.Count > 0 Then
        ''    If msg.Question("Bạn có thực sự muốn xóa dòng này không ?") Then
        ''        Me.e_view.Table.Rows.RemoveAt(GrdExchange.CurrentRowIndex)
        ''        If Me.e_view.Table.Rows.Count = 0 Then
        ''            cOldIndexRow = 0
        ''        Else
        ''            cOldIndexRow = GrdExchange.CurrentRowIndex
        ''        End If
        ''    End If
        ''Else
        ''    msg.Alert("Không có dữ liệu để xóa")
        ''End If
    End Sub

    Private Sub MớiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MớiToolStripMenuItem.Click
        If cAction.ToLower = "start" Then
            statusNew()
        End If
    End Sub

    Private Sub XóaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaToolStripMenuItem.Click
        deleteItemSelected()
    End Sub

    Private Sub LưuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LưuToolStripMenuItem.Click
        If cAction.ToLower = "new" Then
            saveAddItem()
        ElseIf cAction.ToLower = "edit" Then
            saveEditItem()
        End If
        InitialFunction()
    End Sub

    Private Sub SetValue()
        Select Case cAction.ToLower
            Case "new"
                'If i_view.Rows.Count > 0 Then
                '    i_view.Clear()
                'End If
                If i_view.Rows.Count = 0 Then
                    Dim dr As DataRow = i_view.NewRow
                    For Each dc As DataColumn In dr.Table.Columns
                        If dc.DataType.ToString = "System.String" Then
                            dr(dc.ColumnName) = ""
                        ElseIf dc.DataType.ToString = "System.Boolean" Then
                            dr(dc.ColumnName) = True
                        ElseIf dc.DataType.ToString = "System.DateTime" Then
                            dr(dc.ColumnName) = DateTime.Now
                        Else
                            dr(dc.ColumnName) = 0
                        End If
                    Next
                    i_view.Rows.Add(dr)
                End If
                i_view.Rows(0)(i_keyfield) = ""
                '' Set giá trị của nhóm
                If txtFk_Nhvt2ID.Text.Length = 0 Then
                    If g_view.Rows.Count > 0 Then
                        i_view.Rows(0)(i_Keygroup) = g_view.Rows(0)(g_Keyfield)
                        i_view.Rows(0)("Nhvt2Name") = g_view.Rows(0)("Nhvt2Name")
                    End If
                End If
                i_view.Rows(0)("Status") = 1
                i_view.Rows(0)("Status2") = 0
                i_view.Rows(0)("User_id0") = oVar("CurrUserID")
                i_view.Rows(0)("User_id2") = oVar("CurrUserID")
                i_view.Rows(0)("Datetime0") = DateTime.Now
                i_view.Rows(0)("Datetime2") = DateTime.Now
                i_view.Rows(0)("FK_DvkdID") = oVar("DvkdID")
                i_view.Rows(0)("Fk_qttgID") = Me.txtFk_qttgID.Text.Trim
                i_view.Rows(0)("Code") = ""
                i_view.Rows(0)("VtID") = ""
                i_view.Rows(0)("SlLow") = 1
                txtVtID.Text = ""
                Me.txtImagePath.Text = ""
                txtCode.Text = ""
                txtSlLow.Value = 1
                chktien_yn.Checked = False
                tbrAddItem.Text = "Lưu"
                tbrEditItem.Enabled = False
                tbrCancel.Visible = True
                TbrDel.Enabled = False
                btnBrown.Enabled = True
                btnPick.Enabled = True
                chkStatus2.Checked = False
                cbChonNCC.Enabled = True
                'If cbChonNCC.Items.Count > 0 Then
                '    If cbChonNCC.Text <> "" Then
                '        Dim dtRowID As DataRow() = dsNCC.Tables("NCC").Select("DoitacID = '" & cbChonNCC.Text & "'")
                '        txtS1.Text = dtRowID(0)("DoitacName")
                '        txtS2.Text = dtRowID(0)("DoitacAdd")
                '        txtS3.Text = dtRowID(0)("tccs")
                '        TxtS10.Text = dtRowID(0)("maKyHieu")
                '        txts12.Text = dtRowID(0)("maTem")
                '        If dtRowID(0)("maTem").ToString.Length > 0 Then
                '            cboTems.SelectedItem = dtRowID(0)("maTem")
                '        End If
                '    End If
                'End If
                txtVtName.SelectAll()
                txtVtName.Focus()
                Me.BindingContext(i_view).EndCurrentEdit()
            Case "start"
                tbrAddItem.Enabled = True
                tbrEditItem.Enabled = True

                tbrAddItem.Text = "Mới"
                tbrEditItem.Text = "Sửa"
                tbrCancel.Visible = False
                TbrDel.Enabled = True
                btnBrown.Enabled = False
                btnPick.Enabled = False
                cbChonNCC.Enabled = False
            Case "edit"
                txtVtName.SelectAll()
                txtVtName.Focus()
                tbrAddItem.Enabled = False
                tbrEditItem.Text = "Lưu"
                tbrCancel.Visible = True
                TbrDel.Enabled = False
                btnBrown.Enabled = True
                btnPick.Enabled = True
                cbChonNCC.Enabled = True
        End Select
        'txtTlg_da.Enabled = False
        'txtTlg_da.TabStop = False
    End Sub
    Private Sub setEnableControl(ByVal IE As IEnumerator)
        Dim control1 As Control
        Dim enumerator1 As IEnumerator
        Try
            enumerator1 = IE
            Do While enumerator1.MoveNext
                control1 = CType(enumerator1.Current, Control)
                If (StringType.StrCmp(Strings.Left(StringType.FromObject(control1.Tag), 1), "F", False) = 0) Then
                    Dim obj1 As Object = Strings.Right(control1.Name, (control1.Name.Length - 3))
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "C", False) = 0) Then
                        Dim box1 As TextBox = CType(control1, TextBox)
                        box1 = CType(control1, TextBox)
                        box1.Enabled = True
                        If cAction.ToLower = "edit" And Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = i_keyfield.ToLower Then
                            box1.Enabled = False
                        End If
                        If cAction.ToLower = "start" Then
                            box1.Enabled = False
                        End If
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "N", False) = 0) Then
                        Dim box1 As TextBox = CType(control1, TextBox)
                        box1 = CType(control1, TextBox)
                        box1.Enabled = True

                        If cAction.ToLower = "edit" And Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = i_keyfield.ToLower Then
                            box1.Enabled = False
                        End If
                        If cAction.ToLower = "start" Then
                            box1.Enabled = False
                        End If
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "R", False) = 0) Then
                        Dim box1 As RadioButton = CType(control1, RadioButton)
                        box1 = CType(control1, RadioButton)
                        box1.Enabled = True
                        If cAction.ToLower = "start" Then
                            box1.Enabled = False
                        End If
                    End If

                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "B", False) = 0) Then
                        Dim box1 As CheckBox = CType(control1, CheckBox)
                        box1 = CType(control1, CheckBox)
                        box1.Enabled = True
                        If cAction.ToLower = "start" Then
                            box1.Enabled = False
                        End If
                    End If
                End If
            Loop
        Finally
            If TypeOf enumerator1 Is IDisposable Then
                CType(enumerator1, IDisposable).Dispose()
            End If
        End Try
    End Sub
    Private Sub RefreshControl(ByVal IE As IEnumerator)
        Dim control1 As Control
        Dim enumerator1 As IEnumerator
        Try
            enumerator1 = IE
            Do While enumerator1.MoveNext
                control1 = CType(enumerator1.Current, Control)
                If (StringType.StrCmp(Strings.Left(StringType.FromObject(control1.Tag), 1), "F", False) = 0) Then
                    Dim obj1 As Object = Strings.Right(control1.Name, (control1.Name.Length - 3))
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "C", False) = 0) Then
                        Dim box1 As TextBox = CType(control1, TextBox)
                        box1 = CType(control1, TextBox)
                        box1.Text = ""
                        box1.Enabled = False
                        box1.DataBindings.Add("Text", i_view, Strings.Mid(box1.Name, 4, box1.Name.Length))
                        If (Not box1.Multiline) Then
                            AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
                        End If
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "R", False) = 0) Then
                        Dim box1 As RadioButton = CType(control1, RadioButton)
                        box1 = CType(control1, RadioButton)
                        box1.Enabled = False
                        box1.DataBindings.Add("Checked", i_view, Strings.Mid(box1.Name, 4, box1.Name.Length))
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "B", False) = 0) Then
                        Dim box1 As CheckBox = CType(control1, CheckBox)
                        box1 = CType(control1, CheckBox)
                        box1.Enabled = False
                        box1.DataBindings.Add("Checked", i_view, Strings.Mid(box1.Name, 4, box1.Name.Length))
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "L", False) = 0) Then
                        Dim box1 As Label = CType(control1, Label)
                        box1 = CType(control1, Label)
                        box1.Text = ""
                        box1.Enabled = False
                        box1.DataBindings.Add("Text", i_view, Strings.Mid(box1.Name, 4, box1.Name.Length))
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "N", False) = 0) Then
                        Dim box1 As txtNumeric = CType(control1, txtNumeric)
                        box1 = CType(control1, txtNumeric)
                        Dim fm As String = box1.Format
                        box1.Enabled = False
                        box1.Format = Me.oOptions.Item(box1.Format.ToString)
                        box1.Text = "0"
                        box1.DataBindings.Add("Value", i_view, Strings.Mid(box1.Name, 4, box1.Name.Length))
                        AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
                        If fm.ToLower.Trim = "m_ip_tien" Or fm.ToLower.Trim = "m_ip_gia" Then
                            AddHandler box1.Validating, AddressOf txtValidating
                        End If
                    Else
                        Try
                            Dim box2 As TextBox = CType(control1, TextBox)
                            If (Strings.InStr(Strings.LCase(control1.GetType.ToString), "text", CompareMethod.Binary) <> 0) _
                            And (Strings.InStr(Strings.LCase(control1.GetType.ToString), "txt", CompareMethod.Binary) <> 0) _
                            Then
                                AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
                            End If
                            If (Strings.InStr(Strings.LCase(control1.GetType.ToString), "text", CompareMethod.Binary) = 0) And (Not box2.Multiline) Then
                                AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
                            End If
                        Catch
                        End Try
                    End If
                End If
            Loop
            Me.BindingContext(i_view).EndCurrentEdit()
        Finally
            If TypeOf enumerator1 Is IDisposable Then
                CType(enumerator1, IDisposable).Dispose()
            End If
        End Try
    End Sub
    Public Shared Sub txtKeyPressEnter(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If (e.KeyChar = ChrW(13)) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Public Sub txtValidating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim txtNum As txtNumeric = CType(sender, txtNumeric)
        If txtNum.Value <> i_view.Rows(0)(Strings.Right(txtNum.Name, txtNum.Name.Length - 3)) Then
            txtNum.Value = txtNum.Value * Convert.ToDecimal(Me.oOptions("unit_money_input"))
        End If
    End Sub


    Private Sub tbrAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrAddItem.Click
        Select Case cAction.ToLower
            Case "start"
                statusNew()
            Case "new"
                saveAddItem()
        End Select
    End Sub
    Private Sub statusNew()
        Me.cAction = "new"
        Me.tbrAddItem.Image = ImageList1.Images.Item(0)
        setEnableControl(Me.Controls.GetEnumerator)
        Me.SetValue()
        'Select Case TbrConnect.Text.ToUpper
        '    Case "NGẮT KẾT NỐI"
        '        ''đóng kết nối, sau đó thì mở lại lúc thêm mới
        '        If SerialPort1.IsOpen Then
        '            SerialPort1.Close()
        '        End If
        '        Me.ConnectScale()
        '        Me.TbrConnect.Text = "Ngắt kết nối"
        'End Select
        'FreeMemory.FreeMemory.FlushMemory()
    End Sub
    Private Sub saveAddItem()
        If _check() Then
            Return
        End If
        closeScale()
        If tenVat = "1" Then
            GhepTenVAT()
        End If
        'Dim i As String = Me.txtImagePath.Text
        If i_view.Rows(0)("VtID").ToString.Trim = "" Then
            Me.GenCodeItem(i_view.Rows(0))
        End If
        If flagCheckLoi Then
            Return
        End If
        If i_view.Rows(0)("code").ToString.Trim = "" Then
            Me.Genbarcode(i_view.Rows(0))
            Me.tbrAddItem.Image = ImageList1.Images.Item(1)
        Else
            If checkCode(i_view.Rows(0)("code").ToString.Trim) Then
                msg.Alert("Trùng mã vạch")
                Return
            End If
        End If
        If File.Exists(txtImagePath.Text) Then
            Dim path As String = ""
            Dim f As New FileInfo(txtImagePath.Text)
            If Strings.Replace(f.FullName, f.Name, "").ToLower = Me.itemDir.ToLower Then
                'msg.Alert("kname:" + Strings.Left(f.Name, f.Name.IndexOf(".")) + " - " + txtVtID.Text)
                If Strings.Left(f.Name, f.Name.IndexOf(".")) = txtVtID.Text Then
                    path = txtImagePath.Text
                Else
                    path = Me.itemDir + txtVtID.Text + ".jpg"
                    If File.Exists(path) Then
                        File.Delete(path)
                    End If
                    f.CopyTo(path)
                End If
            Else
                path = Me.itemDir + txtVtID.Text + ".jpg"
                If File.Exists(path) Then
                    File.Delete(path)
                End If
                f.CopyTo(path)
            End If
            txtImagePath.Text = path
        End If
        Me.BindingContext(i_view).EndCurrentEdit()
        'i_view.Rows(0)("recitem") = txtVtID.Text
        'If sql.SQLInsert(Me.appConn, i_basetable, i_view.Rows(0)) = 1 Then
        '    Dim dr As DataRow = i_ds.Table.NewRow
        '    For Each dc As DataColumn In i_ds.Table.Columns
        '        dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
        '    Next
        '    i_ds.Table.Rows.Add(dr)
        'End If
        '' viết thêm nếu số lượng tem lớn hơn 1 thì tự tạo thêm mã hàng mới và in tem luôn
        If txtSlLow.Value > 1 Then
            'nếu lớn hơn 1 thì phải in tem mã trên đã, đang thiếu
            Dim i_ds2 As DataSet = New DataSet
            Dim i_view2 As DataTable = New DataTable
            sql.SQLRetrieve(Me.appConn, ("SELECT * FROM vdmvt WHERE 1=0 ORDER BY datetime2 DESC "), "cStruct", i_ds2)

            i_view2 = i_ds2.Tables("cStruct")
            'thêm tiếp mã tự sinh khác
            i_view.Rows(0)("recitem") = txtVtID.Text
            If sql.SQLInsert(Me.appConn, i_basetable, i_view.Rows(0)) = 1 Then
                Dim dr As DataRow = i_ds.Table.NewRow
                Dim dr2 As DataRow = i_view2.NewRow
                For Each dc As DataColumn In i_ds.Table.Columns
                    dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                    dr2(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                Next
                i_ds.Table.Rows.Add(dr)
                i_view2.Rows.Add(dr2)
            End If
            For i As Integer = 2 To txtSlLow.Value
                Dim strVtID As String = ""
                Dim strbarcode As String = ""
                strVtID = Me.GetCodeItem(i_view.Rows(0))
                strbarcode = Me.Getbarcode(i_view.Rows(0))
                txtVtID.Text = strVtID
                txtCode.Text = strbarcode
                'msg.Alert(txtVtID.Text & " và mã code:" & txtCode.Text)
                i_view.Rows(0)("VtID") = strVtID
                i_view.Rows(0)("code") = strbarcode
                i_view.Rows(0)("recitem") = strVtID
                If sql.SQLInsert(Me.appConn, i_basetable, i_view.Rows(0)) = 1 Then
                    Dim dr As DataRow = i_ds.Table.NewRow
                    Dim dr2 As DataRow = i_view2.NewRow
                    For Each dc As DataColumn In i_ds.Table.Columns
                        dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                        dr2(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                    Next
                    i_ds.Table.Rows.Add(dr)
                    i_view2.Rows.Add(dr2)
                End If
            Next
            If InLuonSL = "1" Then
                If KieuInBartender = "1" Then
                    'lưu xong mã thì xuất excel và in ra bartender luôn
                    'Dim FilePathSave As String
                    'FilePathSave = StringType.FromObject(oVar.Item("reportDir")).Replace("report\", "export\") & "export2exceldmvt.xls"
                    'ExportGridToExcel2(i_view2, "Xuất dmvt để in tem", FilePathSave)
                    inBartenderSLnhieu(i_view2)
                Else
                    'lưu xong mã thì in tem
                    Intem(i_view2)
                End If
            End If
        Else
            i_view.Rows(0)("recitem") = txtVtID.Text
            If sql.SQLInsert(Me.appConn, i_basetable, i_view.Rows(0)) = 1 Then
                Dim dr As DataRow = i_ds.Table.NewRow
                For Each dc As DataColumn In i_ds.Table.Columns
                    dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                Next
                i_ds.Table.Rows.Add(dr)
            End If
        End If
        i_ds.Sort = "datetime2 DESC"
        Me.cAction = "start"
        Me.setEnableControl(Me.Controls.GetEnumerator)
        Me.SetValue()
        Me.Focus()
    End Sub
    Private Function ImageToStream(ByVal fileName As String) As Byte()
        Dim stream As New MemoryStream()
tryagain:
        Try
            Dim image As New Bitmap(fileName)
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            GoTo tryagain
        End Try
        Return stream.ToArray()
    End Function
    Function _check() As Boolean
        Dim num1 As Decimal = Decimal.Zero
        Dim num2 As Decimal = Decimal.Zero
        Dim num3 As Decimal = Decimal.Zero

        num1 = DoubleType.FromObject(Me.txtTong_tlg.Value)
        num2 = DoubleType.FromObject(Me.txtTlg_da.Value)
        num3 = DoubleType.FromObject(Me.txtTlg_au.Value)
        If num1 = num2 + num3 Then
        Else
            flagCheckLoi = True
            txtTong_tlg.Focus()
            txtTong_tlg.SelectAll()
            msg.Alert("Tổng trọng lượng đang không bằng trọng lượng đá và vàng. Mời xem lại")
            Return True
        End If
        If txtTong_tlg.Value < 0 Then
            flagCheckLoi = True
            txtTong_tlg.Focus()
            txtTong_tlg.SelectAll()
            msg.Alert("Tổng trọng lượng đang bị âm. Mời xem lại")
            Return True
        End If
        If txtTlg_da.Value < 0 Then
            flagCheckLoi = True
            txtTlg_da.Focus()
            txtTlg_da.SelectAll()
            msg.Alert("Trọng lượng đá đang bị âm. Mời xem lại")
            Return True
        End If
        If txtTlg_au.Value < 0 Then
            flagCheckLoi = True
            txtTlg_au.Focus()
            txtTlg_au.SelectAll()
            msg.Alert("Trọng lượng vàng đang bị âm. Mời xem lại")
            Return True
        End If
        'ktra không cho thêm mới tem vào nhóm mẹ
        Dim dsdmvt As New DataSet
        Dim strString As String = "SELECT Nhvt2ID FROM dmnhvt2 WHERE Nhvt2ID LIKE '" & txtFk_Nhvt2ID.Text & "%'"
        sql.SQLRetrieve(Me.appConn, strString, "TEST", dsdmvt)
        If dsdmvt.Tables(0).Rows.Count > 1 Then
            msg.Alert("Không thể thêm mới tem vào nhóm mẹ!")
            txtFk_Nhvt2ID.Focus()
            Return True
        End If

        Dim control1 As Control
        Dim enumerator1 As IEnumerator
        'Try
        enumerator1 = Me.Controls.GetEnumerator
        Do While enumerator1.MoveNext
            control1 = CType(enumerator1.Current, Control)
            If (StringType.StrCmp(Strings.Left(StringType.FromObject(control1.Tag), 4), "FCNB", False) = 0) Then
                Dim box1 As TextBox = CType(control1, TextBox)
                box1 = CType(control1, TextBox)
                If box1.Text = "" Then
                    msg.Alert("Trường dữ liệu không được để trống!")
                    box1.Focus()
                    Return True
                End If
                If Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = i_keyfield.ToLower And cAction.ToLower = "new" Then
                    Dim dsTest As New DataSet
                    Dim cmText As String = "SELECT * FROM " & i_table & " WHERE " & i_keyfield & "='" & box1.Text & "'"
                    sql.SQLRetrieve(Me.appConn, cmText, "TEST", dsTest)
                    If dsTest.Tables(0).Rows.Count > 0 Then
                        msg.Alert("Mã đã có hoặc trùng nhau!")
                        box1.Focus()
                        Return True
                    End If
                End If
            End If
        Loop
        flagCheckLoi = False
        Return False
    End Function

    Private Sub tbrEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrEditItem.Click
        If Me.oOptions.Item("m_Edit_dmvt") = 2 Then
            Dim dstmp As New DataSet
            If Me.txtVtID.Text.Trim <> Me.txtCode.Text.Trim Then
                Dim txt1 As String = "Select * from ct70 where Fk_VtID = '" & txtVtID.Text & "'"
                sql.SQLRetrieve(Me.appConn, txt1, "tmptxt1", dstmp)
                If dstmp.Tables(0).Rows.Count > 0 Then
                    msg.Alert("Mã hàng nãy đã có phát sinh, không sửa được!", 1)
                    Return
                End If
            End If
        End If
        Select Case cAction.ToLower
            Case "start"
                statusEdit()
            Case "edit"
                saveEditItem()
        End Select
    End Sub
    Private Sub statusEdit()
        If i_view.Rows.Count > 0 Then
            Me.cAction = "edit"
            Me.tbrAddItem.Image = ImageList1.Images.Item(0)
            setEnableControl(Me.Controls.GetEnumerator)
            Me.SetValue()
            txtCode.Enabled = False
        End If
    End Sub
    Private Sub saveEditItem()
        If _check() Then
            Return
        End If
        If tenVat = "1" Then
            GhepTenVAT()
        End If
        If File.Exists(txtImagePath.Text) Then
            Dim path As String = ""
            Dim f As New FileInfo(txtImagePath.Text)
            If Strings.Replace(f.FullName, f.Name, "").ToLower = Me.itemDir.ToLower Then
                'msg.Alert("kname:" + Strings.Left(f.Name, f.Name.IndexOf(".")) + " - " + txtVtID.Text)
                If Strings.Left(f.Name, f.Name.IndexOf(".")) = txtVtID.Text Then
                    path = txtImagePath.Text
                Else
                    path = Me.itemDir + txtVtID.Text + ".jpg"
                    If File.Exists(path) Then
                        File.Delete(path)
                    End If
                    f.CopyTo(path)
                End If
                'path = Strings.Replace(dr("imagepath"), f.Name, txtVtID.Text) + ".jpg"
                'Dim path2 As String = ""
                'path2 = Strings.Replace(dr("imagepath"), f.Name, txtVtID.Text) + "_2.jpg"
                'Dim f2 As New FileInfo(path2)
                'If File.Exists(path) Then
                '    f.CopyTo(path2)
                '    File.Delete(path)
                '    f2.CopyTo(path)
                '    File.Delete(path2)
                'Else : f.CopyTo(path)
                'End If
            Else
                path = Me.itemDir + txtVtID.Text + ".jpg"
                If File.Exists(path) Then
                    File.Delete(path)
                End If
                f.CopyTo(path)
            End If
            txtImagePath.Text = path
        End If
        Me.BindingContext(i_view).EndCurrentEdit()
        'msg.Alert("2:" + i_view.Rows(0)("Imagepath"))
        If sql.SQLUpdate(Me.appConn, i_basetable, i_view.Rows(0), i_keyfield + "='" + i_view.Rows(0)(i_keyfield) + "'") = 1 Then
            Dim rowHt As DataRow = i_view.Select(i_keyfield + " = '" + i_view.Rows(0)(i_keyfield).ToString.ToLower + "'").CopyToDataTable.Rows(0)
            For Each drr As DataRow In i_ds.Table.Rows
                If drr(i_keyfield).ToString.ToLower = i_view.Rows(0)(i_keyfield).ToString.ToLower Then
                    i_ds.Table.Rows.Remove(drr)
                    Exit For
                End If
            Next
            Dim dr As DataRow = i_ds.Table.NewRow
            For Each dc As DataColumn In i_ds.Table.Columns
                dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
            Next
            i_ds.Table.Rows.Add(dr)
            Me.tbrAddItem.Image = ImageList1.Images.Item(1)
            'Chỉ áp dụng cho các mã hàng khác mã vạch
            ''thêm thì thành công thì sửa trong phiếu nhập kho ct74, ct70 và cdvt nếu k có hóa đơn bán HDA
            If txtVtID.Text <> txtCode.Text Then
                Dim HDAban As String = Nothing
                HDAban = sql.GetValue(appConn, "ct70", "stt_rec", "FK_CtID='HDA' AND FK_VtID = '" + txtVtID.Text + "'")
                'nếu k có trong hóa đơn bán là Null thì update 3 bảng ct74, ct70 và cdvt
                If String.IsNullOrEmpty(HDAban) Then
                    sql.SQLExecute(appConn, String.Format("Update ct74 set Tong_tlg={0}, Tlg_au={1}, Tlg_da={2}, Hlg_au={3}, datetime2=getdate() where FK_VtID='{4}'", txtTong_tlg.Value, txtTlg_au.Value, txtTlg_da.Value, txtHlg_au.Value, txtVtID.Text))
                    sql.SQLExecute(appConn, String.Format("Update cdvt set Tong_tlg={0}, Tlg_au={1}, Tlg_da={2}, Hlg_au={3}, datetime2=getdate() where FK_VtID='{4}'", txtTong_tlg.Value, txtTlg_au.Value, txtTlg_da.Value, txtHlg_au.Value, txtVtID.Text))
                    sql.SQLExecute(appConn, String.Format("Update ct70 set Tong_tlg={0}, Tlg_au={1}, Tlg_da={2}, Hlg_au={3}, datetime2=getdate() where FK_VtID='{4}' AND FK_CtID ='PND'", txtTong_tlg.Value, txtTlg_au.Value, txtTlg_da.Value, txtHlg_au.Value, txtVtID.Text))
                End If
            End If
        Else
            msg.Alert("Cập nhật không thành công !")
            Return
        End If
        i_ds.Sort = " datetime2 DESC"
        Me.cAction = "start"
        Me.setEnableControl(Me.Controls.GetEnumerator)
        Me.SetValue()
        Me.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txtFk_Nhvt2ID.Text.Trim = "" Then
            Me.Button1.Enabled = False
            Return
        Else
            Dim ds As New DataSet
            Dim dv As New DataView
            sql.SQLRetrieve(appConn, "Select Fk_QttgID, Fk_QttgID1 From dmnhvt2 where Nhvt2ID = '" & Me.txtFk_Nhvt2ID.Text.Trim & "'", "dmnhvt2", ds)
            dv.Table = ds.Tables("dmnhvt2")
            If Me.txtFk_qttgID.Text.Trim = "" Or Me.txtFk_qttgID.Text.Trim <> dv.Table.Rows(0).Item("Fk_QttgID") Then
                Me.txtFk_qttgID.Text = dv.Table.Rows(0).Item("Fk_QttgID")
                Me.txtFk_qttgID1.Text = dv.Table.Rows(0).Item("Fk_QttgID1")
            ElseIf Me.txtFk_qttgID1.Text.Trim = "" Or Me.txtFk_qttgID1.Text.Trim <> dv.Table.Rows(0).Item("Fk_QttgID1") Then
                Me.txtFk_qttgID1.Text = dv.Table.Rows(0).Item("Fk_QttgID1")
                Me.txtFk_qttgID.Text = dv.Table.Rows(0).Item("Fk_QttgID")
            Else
            End If
            dv.Table.Clear()
            ds.Tables.Clear()
        End If
    End Sub

    Private Sub txtFk_Nhvt2ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFk_Nhvt2ID.TextChanged
        If Me.txtFk_Nhvt2ID.Text.Trim = "" Then
            Return
        Else
            Me.Button1.Enabled = True
        End If
    End Sub

    Function ConnectScale() As Boolean
        'Dim flag As Boolean = False
        'Try
        '    SerialPort1.PortName = Me.oOptions.Item("Scale_portcom").ToString()
        '    SerialPort1.BaudRate = Convert.ToInt32(Me.oOptions.Item("Scale_baudrate"))
        '    SerialPort1.Parity = Read_Parity(Me.oOptions.Item("Scale_parity").ToString())
        '    SerialPort1.DataBits = Convert.ToInt32(Me.oOptions.Item("Scale_databits"))
        '    SerialPort1.StopBits = Read_StopBits(Me.oOptions.Item("Scale_stopbits"))
        '    SerialPort1.Handshake = IO.Ports.Handshake.None
        '    If SerialPort1.IsOpen() Then
        '        SerialPort1.Close()
        '    End If
        '    SerialPort1.Open()
        '    flag = True
        'Catch ex As Exception
        '    flag = False
        '    MessageBox.Show(ex.ToString())
        'End Try
        'Return flag
    End Function

    Private Function Read_Parity(ByVal _parity As String) As System.IO.Ports.Parity
        Select Case _parity.Trim.ToUpper
            Case "EVEN"
                Return System.IO.Ports.Parity.Even
            Case "ODD"
                Return System.IO.Ports.Parity.Odd
            Case "NONE"
                Return System.IO.Ports.Parity.None
            Case "MARK"
                Return System.IO.Ports.Parity.Mark
            Case "SPACE"
                Return System.IO.Ports.Parity.Space
            Case Else
                Return System.IO.Ports.Parity.None
        End Select
    End Function

    Private Function Read_StopBits(ByVal _stopbits As String) As System.IO.Ports.StopBits
        Select Case _stopbits.Trim.ToUpper
            Case "ONE"
                Return System.IO.Ports.StopBits.One
            Case "ONEPOINTFIVE"
                Return System.IO.Ports.StopBits.OnePointFive
            Case "TWO"
                Return System.IO.Ports.StopBits.Two
            Case Else
                Return System.IO.Ports.StopBits.One
        End Select
    End Function

    Private Sub BtConfigScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmConfig1 As New FrmConfig(sysConn, appConn, oOptions, oVar)
        frmConfig1.ShowDialog()
    End Sub

    Private Sub txtTlg_da_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTlg_da.Validated
        'Me.calC()
        Dim num1 As Decimal = Decimal.Zero
        Dim num2 As Decimal = Decimal.Zero

        num1 = DoubleType.FromObject(Me.txtTong_tlg.Value)
        num2 = DoubleType.FromObject(Me.txtTlg_da.Value)
        If num2 > num1 Then
            msg.Alert("Trọng lượng đá đang lớn hơn tổng trọng lượng !")
            Me.txtTlg_da.Value = Me.txtTong_tlg.Value - Me.txtTlg_au.Value
        Else
            Me.txtTlg_au.Value = num1 - num2
        End If
    End Sub
    Private Sub calC()
        Dim num1 As Decimal = Decimal.Zero
        Dim num2 As Decimal = Decimal.Zero
        num1 = DoubleType.FromObject(Me.txtTong_tlg.Value)
        num2 = DoubleType.FromObject(Me.txtTlg_da.Value)
        If num2 > num1 Then
            'msg.Alert("Trọng lượng đá đang lớn hơn tổng trọng lượng !")
            'Me.txtTlg_da.Value = Me.txtTong_tlg.Value - Me.txtTlg_au.Value
        Else
            Me.txtTlg_au.Value = num1 - num2
        End If
        'If txts12.Text = "1" Then
        '    Me.txtTlg_da.Value = num1 - num2
        'ElseIf txts12.Text = "2" Then
        '    Me.txtTlg_au.Value = num1 - Me.txtTlg_da.Value
        'Else
        '    Me.txtTlg_au.Value = num1
        '    Me.txtTlg_da.Value = 0
        'End If
    End Sub

    Private ReadData As String
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'If Me.txtVtID.Text.Trim = "" Then
        '    If Me.oOptions.Item("Scale_yn") = 1 Then
        '        If SerialPort1.IsOpen Then
        '            Try
        '                If Me.oOptions.Item("Scale_readmode").ToString.ToUpper = "READLINE" Then
        '                    values_Scale = SerialPort1.ReadLine
        '                Else
        '                    values_Scale = SerialPort1.ReadExisting
        '                End If
        '                ReadData = values_Scale
        '                values_Scale = ""
        '                Me.BeginInvoke(New EventHandler(AddressOf DoUpdate))
        '            Catch ex As Exception
        '                ReadData = "0"
        '            End Try
        '        End If
        '    End If
        'End If
    End Sub

    Public Sub DoUpdate()
        'Try
        '    If _Paused Then
        '        Return
        '    End If
        '    Scale.Text = ReadData
        '    Dim cutvalue As String = ReadData.Replace(" ", "").Trim
        '    Dim replace As String() = Me.oOptions.Item("Scale_replace").ToString.Trim.Split(" ")

        '    For i As Integer = 0 To replace.Length - 1
        '        cutvalue = Strings.Replace(cutvalue, replace(i), "")
        '    Next

        '    If cutvalue = "" Then
        '        Return
        '    End If

        '    Dim value As Decimal = 0
        '    Try
        '        value = Convert.ToDecimal(cutvalue.Trim)
        '    Catch ex As Exception
        '        Scale.Text = cutvalue
        '        value = 0
        '    End Try
        '    Dim tong As Decimal = 0
        '    tong = Math.Round(value * Convert.ToDecimal(Me.oOptions.Item("Scale_weigh")), 4)
        '    If Me.txtTong_tlg.Value <> tong Then
        '        txtTong_tlg.Value = tong
        '        txtTlg_au.Value = tong - txtTlg_da.Value
        '    End If
        'Catch ex2 As Exception
        '    msg.Alert(ex2.ToString)
        'End Try
    End Sub

    Private Sub TbrDelTem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbrDel.Click
        deleteItemSelected()
    End Sub
    Private Sub deleteItemSelected()
        If cAction.ToLower = "start" And txtVtID.Text <> "" Then
            If msg.Question("Bạn có thực sự muốn xóa không ?") = 1 Then
                Try
                    If sql.SQLDelete(appConn, i_basetable, i_keyfield + " =" + "'" + i_view.Rows(0)(i_keyfield).ToString + "'") Then
                        If i_view.Columns.Contains("ImagePath") Then
                            If Not Information.IsDBNull(i_view.Rows(0)("ImagePath")) Then
                                Dim dirImage As String = i_view.Rows(0)("ImagePath")
                                If File.Exists(dirImage) Then
                                    File.Delete(dirImage)
                                End If
                            End If
                        End If

                        Dim id As String = i_view.Rows(0)(i_keyfield).ToString.ToLower
                        i_view.Rows.Clear()
                        For Each drr As DataRow In i_ds.Table.Rows
                            If drr(i_keyfield).ToString.ToLower = id Then
                                i_ds.Table.Rows.Remove(drr)
                                Exit For
                            End If
                        Next
                    End If
                Catch ex As Exception
                    msg.Alert("Có phát sinh không xóa được")
                End Try
            End If
        End If

    End Sub
    Public Sub closeScale()
        'Try
        '	If SerialPort1.IsOpen Then
        '		SerialPort1.Close()
        '	End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub btnPick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPick.Click
        txtImagePath.Text = ""
        If Me.txtVtID.Text.Trim = "" Then
            Me.GenCodeItem(i_view.Rows(0))
        End If
        If flagCheckLoi Then
            msg.Alert("Sinh mã vạch bị quá 999 mã")
            Return
        End If
        Dim pathName As String = txtVtID.Text
        pathName = String.Format("{0}{1}.jpg", Me.itemDir, pathName)
        Dim camera As New FrmCap(pathName)
        camera.ShowDialog(Me.FindForm())
        If File.Exists(pathName) Then
            txtImagePath.Text = pathName
        End If
    End Sub

    Private Sub btnBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown.Click
        Dim f As New OpenFileDialog
        Dim fileToRead As String = ""
        'f.InitialDirectory = oVars.Item("reportDir").Replace("report\", "export\import\")
        f.Filter = "Standard Image files (*.jpg)|*.jpg|Standard Image files (*.png)|*.png" '"All files (*.*)|*.*|Standard Excel files (*.xls)|*.xls"
        If f.ShowDialog() = DialogResult.OK Then
            'phần này đang bị lỗi, k hiểu sao nó k vào phần nút ok này
            'msg.Alert(f.FileName)
            fileToRead = f.FileName
        End If
        fileToRead = f.FileName
        txtImagePath.Text = fileToRead
    End Sub

    Private Sub SửaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửaToolStripMenuItem.Click
        If cAction.ToLower = "start" Then
            statusEdit()
        End If
    End Sub

    Private Sub LưuVàInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LưuVàInToolStripMenuItem.Click
        If cAction.ToLower = "new" Then
            '' viết thêm nếu số lượng tem lớn hơn 1 thì tự tạo thêm mã hàng mới và in tem luôn
            If txtSlLow.Value > 1 Then
                saveAddItem()
            Else
                saveAddItem()
                If flagCheckLoi Then
                    Return
                Else
                    printItem()
                End If
            End If
        ElseIf cAction.ToLower = "edit" Then
            saveEditItem()
            If flagCheckLoi Then
                Return
            Else
                printItem()
            End If
        End If
        InitialFunction()
    End Sub

    Private Sub BỏQuaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BỏQuaToolStripMenuItem.Click
        cancel()
    End Sub

    Private Sub InMãVạchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InMãVạchToolStripMenuItem.Click
        printItem()
    End Sub
    Public Function getActionState() As String
        Return cAction
    End Function

    Private Sub mnConfigCan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnConfigCan.Click
        Dim frmConfig1 As New FrmConfig(sysConn, appConn, oOptions, oVar)
        frmConfig1.ShowDialog()
    End Sub

    Private Sub txtGia_ban_nt11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGia_ban_nt11.TextChanged
        Try
            If cAction.ToLower = "new" Or cAction.ToLower = "edit" Then
                If Not oOptions.Item("rating_money") Is Nothing AndAlso txtGia_ban_nt11.Value > 0 Then
                    Dim giaTron As Decimal = Math.Round((txtGia_ban_nt11.Value * Decimal.Parse(oOptions.Item("rating_money"))) / 1000, 0) * 1000
                    Me.txtGia_ban11.Value = giaTron
                End If
            End If
        Catch ex As Exception
            txtGia_ban11.Value = 0
        End Try
    End Sub

    Private Sub calC2()
        If txtGia_au0.Value > 0 AndAlso txtTlg_au.Value > 0 Then
            Dim num1 As Decimal = Decimal.Zero
            Dim num2 As Decimal = Decimal.Zero
            Dim num3 As Decimal = Decimal.Zero
            Dim num4 As Decimal = Decimal.Zero

            num1 = Me.txtTlg_au.Value
            num2 = Me.txtGia_au0.Value
            num3 = Me.TxtTien_cong0.Value
            num4 = Me.txtTien_da0.Value
            Me.txtGia_mua.Value = num1 * num2 + num3 + num4
        End If
    End Sub

    Private Sub calC3()
        If txtGia_au.Value > 0 AndAlso txtTlg_au.Value > 0 Then
            Dim num1 As Decimal = Decimal.Zero
            Dim num2 As Decimal = Decimal.Zero
            Dim num3 As Decimal = Decimal.Zero
            Dim num4 As Decimal = Decimal.Zero

            num1 = Me.txtTlg_au.Value
            num2 = Me.txtGia_au.Value
            num3 = Me.TxtTien_cong.Value
            num4 = Me.txtTien_da.Value
            Dim giaTron As Decimal = Math.Round(Math.Round((num1 * num2 + num3 + num4), 0) / 1000, 0) * 1000
            Me.txtGia_ban11.Value = getTronTien5k(giaTron)
        End If
    End Sub

    Private Sub txtTlg_au_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTlg_au.TextChanged
        If cAction.ToLower = "new" Or cAction.ToLower = "edit" Then
            Me.calC2()
            Me.calC3()
            If txtGia_cong.Value > 0 Then
                calC_CongBan()
            End If
            If txtGia_cong0.Value > 0 Then
                calC_CongGoc()
            End If
        End If
    End Sub

    Private Sub txtTien_da0_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTien_da0.Validated, txtGia_cong0.Validated
        Me.calC2()
    End Sub

    Private Sub txtGia_au0_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGia_au0.Validated
        Me.calC2()
    End Sub

    Private Sub txtGia_au_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGia_au.Validated
        Me.calC3()
    End Sub

    Private Sub TxtTien_cong_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTien_cong.Validated
        Me.calC3()
    End Sub

    Private Sub txtTien_da_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTien_da.Validated
        Me.calC3()
    End Sub

    Private Sub TxtTien_cong0_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTien_cong0.Validated, txtGia_cong.Validated
        Me.calC2()
    End Sub

    Private Sub txtTong_tlg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTong_tlg.TextChanged
        Me.calC()
    End Sub


    Private Sub txtTlg_au_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTlg_au.Validated
        Dim num1 As Decimal = Decimal.Zero
        Dim num2 As Decimal = Decimal.Zero

        num1 = DoubleType.FromObject(Me.txtTong_tlg.Value)
        num2 = DoubleType.FromObject(Me.txtTlg_au.Value)
        If num2 > num1 Then
            msg.Alert("Trọng lượng vàng đang lớn hơn tổng trọng lượng !")
            Me.txtTlg_au.Value = Me.txtTong_tlg.Value - Me.txtTlg_da.Value
        Else
            Me.txtTlg_da.Value = num1 - num2
        End If
        'If txts12.Text = "0" Then
        '    Me.txtTong_tlg.Value = Me.txtTlg_au.Value
        '    Me.txtTlg_da.Value = 0
        'End If
    End Sub
    'Public Shared Function GetNetworkTime0() As DateTime
    '    Const ntpServer As String = "pool.ntp.org"
    '    Dim ntpData = New Byte(47) {}
    '    ntpData(0) = &H1B
    '    'LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)
    '    Dim addresses = Dns.GetHostEntry(ntpServer).AddressList
    '    Dim ipEndPoint = New IPEndPoint(addresses(0), 123)
    '    Dim socket = New Net.Sockets.Socket(Sockets.AddressFamily.InterNetwork, Sockets.SocketType.Dgram, Sockets.ProtocolType.Udp)

    '    socket.Connect(ipEndPoint)
    '    socket.Send(ntpData)
    '    socket.Receive(ntpData)
    '    socket.Close()

    '    Dim intPart As ULong = CULng(ntpData(40)) << 24 Or CULng(ntpData(41)) << 16 Or CULng(ntpData(42)) << 8 Or CULng(ntpData(43))
    '    Dim fractPart As ULong = CULng(ntpData(44)) << 24 Or CULng(ntpData(45)) << 16 Or CULng(ntpData(46)) << 8 Or CULng(ntpData(47))

    '    Dim milliseconds = (intPart * 1000) + ((fractPart * 1000) / &H100000000L)
    '    Dim networkDateTime = (New DateTime(1900, 1, 1)).AddMilliseconds(CLng(milliseconds))

    '    Return networkDateTime
    'End Function
    'msg.Alert(String.Format("time real: {0}", GetNetworkTime()))
    Public Shared Function GetNetworkTime() As DateTime 'lấy giờ thực tế trên mạng
        'default Windows time server
        Const ntpServer As String = "time.windows.com"

        ' NTP message size - 16 bytes of the digest (RFC 2030)
        Dim ntpData = New Byte(47) {}

        'Setting the Leap Indicator, Version Number and Mode values
        ntpData(0) = &H1B
        'LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)
        Dim addresses = Dns.GetHostEntry(ntpServer).AddressList

        'The UDP port number assigned to NTP is 123
        Dim ipEndPoint = New IPEndPoint(addresses(0), 123)
        'NTP uses UDP
        Dim socket = New Net.Sockets.Socket(Sockets.AddressFamily.InterNetwork, Sockets.SocketType.Dgram, Sockets.ProtocolType.Udp)

        socket.Connect(ipEndPoint)
        'Stops code hang if NTP is blocked
        socket.ReceiveTimeout = 3000

        socket.Send(ntpData)
        socket.Receive(ntpData)
        socket.Close()

        'Offset to get to the "Transmit Timestamp" field (time at which the reply 
        'departed the server for the client, in 64-bit timestamp format."
        Const serverReplyTime As Byte = 40

        'Get the seconds part
        Dim intPart As ULong = BitConverter.ToUInt32(ntpData, serverReplyTime)

        'Get the seconds fraction
        Dim fractPart As ULong = BitConverter.ToUInt32(ntpData, serverReplyTime + 4)

        'Convert From big-endian to little-endian
        intPart = SwapEndianness(intPart)
        fractPart = SwapEndianness(fractPart)

        Dim milliseconds = (intPart * 1000) + ((fractPart * 1000) / &H100000000L)

        '**UTC** time
        Dim networkDateTime = (New DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(CLng(milliseconds))

        Return networkDateTime.ToLocalTime()
    End Function

    ' stackoverflow.com/a/3294698/162671
    Private Shared Function SwapEndianness(ByVal x As ULong) As UInteger
        Return CUInt(((x And &HFF) << 24) + ((x And &HFF00) << 8) + ((x And &HFF0000) >> 8) + ((x And &HFF000000UI) >> 24))
    End Function

    Private Sub txtTong_tlg_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTong_tlg.KeyDown
        If e.KeyData = Keys.Enter Then

        End If
    End Sub

    Private Sub mnChoicePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnChoicePrint.Click
        Dim mayin As New FrmChonMayIn(Me, oOptions, sysConn, NamePrint, "1")
        mayin.ShowDialog()
    End Sub
    Private Sub Intem(ByVal i_view As DataTable)
        If dataOnePage.Tables.Count = 0 Then
            dataOnePage = New DataSet
            Dim dt As New DataTable("BARCODE")
            For Each dc As DataColumn In i_view.Columns
                dt.Columns.Add(dc.ColumnName, dc.DataType)
            Next
            dataOnePage.Tables.Add(dt)
        End If
        dataOnePage.Tables(0).Rows.Clear()

        Dim i As Integer = 0
        For Each row As DataRow In i_view.Rows
            Dim dr As DataRow = dataOnePage.Tables(0).NewRow
            For Each dc As DataColumn In dataOnePage.Tables(0).Columns
                dr(dc.ColumnName) = i_view(i)(dc.ColumnName)
            Next
            dataOnePage.Tables(0).Rows.Add(dr)
            'For Each dc As DataColumn In dataOnePage.Tables(0).Columns
            '    dr(dc.ColumnName) = i_view(i)(dc.ColumnName)
            'Next
            i = i + 1
        Next
        'nCell1
        Dim k As Integer = dataOnePage.Tables(0).Rows.Count
        Dim dem As Int32 = 0
        Dim data As New DataTable
        For Each dc As DataColumn In dataOnePage.Tables(0).Columns
            data.Columns.Add(dc.ColumnName, dc.DataType)
        Next

        For j As Int32 = 0 To k - 1
            dem = dem + 1
            If dem = nCell1 Then
                pd.PrinterSettings.PrinterName = NamePrint
                pd.Print()
                Dim count2 As Int32 = nCell1 - 1
                For count As Int32 = 0 To nCell1 - 1
                    If dataOnePage.Tables(0).Rows.Count > count2 Then
                        dataOnePage.Tables(0).Rows(count2).Delete()
                    End If
                    count2 = count2 - 1
                Next
                dem = 0
            End If

        Next
        If dataOnePage.Tables(0).Rows.Count = 1 AndAlso dataOnePage.Tables(0).Rows.Count = 1 Then
            pd.PrinterSettings.PrinterName = NamePrint
            pd.Print()
            Dim count2 As Int32 = nCell1 - 1
            For count As Int32 = 0 To nCell1 - 1
                If dataOnePage.Tables(0).Rows.Count > count2 Then
                    dataOnePage.Tables(0).Rows(count2).Delete()
                End If
                count2 = count2 - 1
            Next
            dem = 0
        End If

        If dataOnePage.Tables(0).Rows.Count < k AndAlso dataOnePage.Tables(0).Rows.Count > 0 Then
            pd.PrinterSettings.PrinterName = NamePrint
            pd.Print()
            Dim count2 As Int32 = nCell1 - 1
            For count As Int32 = 0 To nCell1 - 1
                If dataOnePage.Tables(0).Rows.Count > count2 Then
                    dataOnePage.Tables(0).Rows(count2).Delete()
                End If
                count2 = count2 - 1
            Next
            dem = 0
        End If

        dataOnePage.Tables(0).Rows.Clear()
    End Sub
    Private Sub GhepTenVAT()
        Dim hlg As String = ""
        If txtMa_td2.Text.Length > 0 Then
            hlg = String.Format("HLV:{0};", txtMa_td2.Text)
        End If
        Dim tlg_au As Decimal = 0
        Dim tlg_au_gam As Decimal = 0
        Dim KLVStr As String = ""
        Dim KLVgStr As String = ""
        If txtTlg_au.Value > 0 Then
            tlg_au = txtTlg_au.Value
            If tlg_au.ToString.Length > 4 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "KLV: {0:#,##0.000} chỉ", tlg_au)
            ElseIf tlg_au.ToString.Length > 3 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "KLV: {0:#,##0.00} chỉ", tlg_au)
            ElseIf tlg_au.ToString.Length > 2 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "KLV: {0:#,##0.0} chỉ", tlg_au)
            Else
                KLVStr = String.Format(New CultureInfo("vi-VN"), "KLV: {0:#,##0} chỉ", tlg_au)
            End If
            tlg_au_gam = tlg_au * 3.75
            If tlg_au_gam.ToString.Length > 3 Then
                KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.00} g);", tlg_au_gam)
            ElseIf tlg_au_gam.ToString.Length > 2 Then
                KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.0} g);", tlg_au_gam)
            Else
                KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0} g);", tlg_au_gam)
            End If
            'KLVStr = String.Format(New CultureInfo("vi-VN"), "KLV: {0:#,##0.000} chỉ({1:#,##0.00} g);", tlg_au, tlg_au_gam)
            KLVStr = KLVStr & KLVgStr
        End If
        Dim tlg_da As Decimal = 0
        Dim tlg_da_gam As Decimal = 0
        Dim KLDStr As String = ""
        Dim KLDgStr As String = ""
        If txtTlg_da.Value > 0 Then
            tlg_da = txtTlg_da.Value
            If tlg_da.ToString.Length > 4 Then
                KLDStr = String.Format(New CultureInfo("vi-VN"), "KLĐ: {0:#,##0.000} chỉ", tlg_da)
            ElseIf tlg_da.ToString.Length > 3 Then
                KLDStr = String.Format(New CultureInfo("vi-VN"), "KLĐ: {0:#,##0.00} chỉ", tlg_da)
            ElseIf tlg_da.ToString.Length > 2 Then
                KLDStr = String.Format(New CultureInfo("vi-VN"), "KLĐ: {0:#,##0.0} chỉ", tlg_da)
            Else
                KLDStr = String.Format(New CultureInfo("vi-VN"), "KLĐ: {0:#,##0} chỉ", tlg_da)
            End If
            tlg_da_gam = tlg_da * 3.75
            If tlg_da_gam.ToString.Length > 3 Then
                KLDgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.00} g);", tlg_da_gam)
            ElseIf tlg_da_gam.ToString.Length > 2 Then
                KLDgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.0} g);", tlg_da_gam)
            Else
                KLDgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0} g);", tlg_da_gam)
            End If
            'KLDStr = String.Format(New CultureInfo("vi-VN"), "KLD: {0:#,##0.000} chỉ({1:#,##0.00} g);", tlg_da, tlg_da_gam)
            KLDStr = KLDStr & KLDgStr
        End If
        'tiền công
        Dim Tien_cong As Decimal = 0
        Dim Tien_congStr As String = ""
        If TxtTien_cong.Value > 0 Then
            Tien_cong = TxtTien_cong.Value
            Tien_congStr = String.Format(New CultureInfo("vi-VN"), "Tiền công: {0:#,##0} vnđ;", Tien_cong)
        End If
        Dim Tien_da As Decimal = 0
        Dim Tien_daStr As String = ""
        If txtTien_da.Value > 0 Then
            Tien_da = txtTien_da.Value
            Tien_daStr = String.Format(New CultureInfo("vi-VN"), "Tiền đá: {0:#,##0} vnđ", Tien_da)
            'Tien_daStr = String.Format("Tiền đá: {0};", txtTien_da.Text.ToString)
        End If

        txtVtName2.Text = txtVtName.Text & " " & hlg & KLVStr & KLDStr & Tien_congStr & Tien_daStr & "."
    End Sub
    Private Function getKLgam(ByVal tlg As Decimal) As String
        Dim tlg_au As Decimal = 0
        Dim tlg_au_gam As Decimal = 0
        Dim KLVStr As String = ""
        Dim KLVgStr As String = ""
        If tlg > 0 Then
            tlg_au = tlg
            If tlg_au.ToString.Length > 5 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "{0:#,##0.0000} chỉ", tlg_au)
            ElseIf tlg_au.ToString.Length > 4 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "{0:#,##0.000} chỉ", tlg_au)
            ElseIf tlg_au.ToString.Length > 3 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "{0:#,##0.00} chỉ", tlg_au)
            ElseIf tlg_au.ToString.Length > 2 Then
                KLVStr = String.Format(New CultureInfo("vi-VN"), "{0:#,##0.0} chỉ", tlg_au)
            Else
                KLVStr = String.Format(New CultureInfo("vi-VN"), "{0:#,##0} chỉ", tlg_au)
            End If
            tlg_au_gam = tlg_au * 3.75
            If tlg_au_gam.ToString.Length > 3 Then
                KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.00} gam)", tlg_au_gam)
            ElseIf tlg_au_gam.ToString.Length > 2 Then
                KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.0} gam)", tlg_au_gam)
            Else
                KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0} gam)", tlg_au_gam)
            End If
            'KLVStr = String.Format(New CultureInfo("vi-VN"), "KLV: {0:#,##0.000} chỉ({1:#,##0.00} g);", tlg_au, tlg_au_gam)
            KLVStr = KLVStr & KLVgStr
        End If
        Return KLVStr
    End Function
    Private Function getKLgamSo(ByVal tlg As Decimal) As Decimal
        Dim tlg_au_gam As Decimal = 0
        Dim KLVgStr As String = ""
        If tlg > 0 Then
            tlg_au_gam = tlg * 3.75
            KLVgStr = Strings.Format(tlg_au_gam, Me.oOptions("m_ip_tlg"))
            'If tlg_au_gam.ToString.Length > 3 Then
            '    KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.00} gam)", tlg_au_gam)
            'ElseIf tlg_au_gam.ToString.Length > 2 Then
            '    KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0.0} gam)", tlg_au_gam)
            'Else
            '    KLVgStr = String.Format(New CultureInfo("vi-VN"), "({0:#,##0} gam)", tlg_au_gam)
            'End If
            tlg_au_gam = Convert.ToDecimal(KLVgStr)
        End If
        Return tlg_au_gam
    End Function

    Private Sub TsmInExcel_Click(sender As Object, e As EventArgs) Handles TsmInExcel.Click
        exportExcel()
    End Sub
    Private Sub exportExcel()
        If txtSlLow.Value > 1 Then
            If _check() Then
                Return
            End If
            closeScale()
            If tenVat = "1" Then
                GhepTenVAT()
            End If
            'Dim i As String = Me.txtImagePath.Text
            If i_view.Rows(0)("VtID").ToString.Trim = "" Then
                Me.GenCodeItem(i_view.Rows(0))
            End If
            If flagCheckLoi Then
                Return
            End If
            If i_view.Rows(0)("code").ToString.Trim = "" Then
                Me.Genbarcode(i_view.Rows(0))
                Me.tbrAddItem.Image = ImageList1.Images.Item(1)
            Else
                If checkCode(i_view.Rows(0)("code").ToString.Trim) Then
                    msg.Alert("Trùng mã vạch")
                    Return
                End If
            End If
            If File.Exists(txtImagePath.Text) Then
                Dim path As String = ""
                Dim f As New FileInfo(txtImagePath.Text)
                If Strings.Replace(f.FullName, f.Name, "").ToLower = Me.itemDir.ToLower Then
                    'msg.Alert("kname:" + Strings.Left(f.Name, f.Name.IndexOf(".")) + " - " + txtVtID.Text)
                    If Strings.Left(f.Name, f.Name.IndexOf(".")) = txtVtID.Text Then
                        path = txtImagePath.Text
                    Else
                        path = Me.itemDir + txtVtID.Text + ".jpg"
                        If File.Exists(path) Then
                            File.Delete(path)
                        End If
                        f.CopyTo(path)
                    End If
                Else
                    path = Me.itemDir + txtVtID.Text + ".jpg"
                    If File.Exists(path) Then
                        File.Delete(path)
                    End If
                    f.CopyTo(path)
                End If
                txtImagePath.Text = path
            End If
            Me.BindingContext(i_view).EndCurrentEdit()
            'nếu lớn hơn 1 thì phải in tem mã trên đã, đang thiếu
            Dim i_ds2 As DataSet = New DataSet
            Dim i_view2 As DataTable = New DataTable
            sql.SQLRetrieve(Me.appConn, ("SELECT * FROM vdmvt WHERE 1=0 ORDER BY datetime2 DESC "), "cStruct", i_ds2)

            i_view2 = i_ds2.Tables("cStruct")
            'thêm tiếp mã tự sinh khác
            i_view.Rows(0)("recitem") = txtVtID.Text
            If sql.SQLInsert(Me.appConn, i_basetable, i_view.Rows(0)) = 1 Then
                Dim dr As DataRow = i_ds.Table.NewRow
                Dim dr2 As DataRow = i_view2.NewRow
                For Each dc As DataColumn In i_ds.Table.Columns
                    dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                    dr2(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                Next
                i_ds.Table.Rows.Add(dr)
                i_view2.Rows.Add(dr2)
            End If
            For i As Integer = 2 To txtSlLow.Value
                Dim strVtID As String = ""
                Dim strbarcode As String = ""
                strVtID = Me.GetCodeItem(i_view.Rows(0))
                strbarcode = Me.Getbarcode(i_view.Rows(0))
                txtVtID.Text = strVtID
                txtCode.Text = strbarcode
                'msg.Alert(txtVtID.Text & " và mã code:" & txtCode.Text)
                i_view.Rows(0)("VtID") = strVtID
                i_view.Rows(0)("code") = strbarcode
                i_view.Rows(0)("recitem") = strVtID
                If sql.SQLInsert(Me.appConn, i_basetable, i_view.Rows(0)) = 1 Then
                    Dim dr As DataRow = i_ds.Table.NewRow
                    Dim dr2 As DataRow = i_view2.NewRow
                    For Each dc As DataColumn In i_ds.Table.Columns
                        dr(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                        dr2(dc.ColumnName) = i_view.Rows(0)(dc.ColumnName)
                    Next
                    i_ds.Table.Rows.Add(dr)
                    i_view2.Rows.Add(dr2)
                End If
            Next

            'lưu xong mã thì xuất excel
            Dim FilePathSave As String

            FilePathSave = StringType.FromObject(oVar.Item("reportDir")).Replace("report\", "export\") & "export2exceldmvt.xls"

            ExportGridToExcel2(i_view2, "Xuất dmvt để in tem", FilePathSave)
            'lưu xong mã thì in tem
            'Intem(i_view2)

            i_ds.Sort = "datetime2 DESC"
            Me.cAction = "start"
            Me.setEnableControl(Me.Controls.GetEnumerator)
            Me.SetValue()
            Me.Focus()
        Else
            msg.Alert("Số lượng tem phải nhiều mới sử dụng F9")
        End If
    End Sub
    Private Sub ExportGridToExcel2(ByVal dv As DataTable, ByVal cTitle As String, ByVal FilePath2Save As String)
        'Vừa xuất ra excel rồi chạy luôn in tem trên bartender .btw
        Dim appExcel As Excel.Application = New Excel.Application
        If appExcel Is Nothing Then
            msg.Alert("ERROR: EXCEL couldn't be started!", 1)
            Environment.ExitCode = 0
            Exit Sub
        End If

        For Each dr As DataRow In dv.Rows
            dr("gc_td1") = getKLgam(dr("Tong_tlg"))
            dr("gc_td2") = getKLgam(dr("Tlg_au"))
            dr("gc_td3") = getKLgam(dr("Tlg_da"))
            dr("sl_td1") = getKLgamSo(dr("Tong_tlg"))
            dr("sl_td2") = getKLgamSo(dr("Tlg_au"))
            dr("sl_td3") = getKLgamSo(dr("Tlg_da"))
        Next

        appExcel.Visible = False
        Dim workbook As Excel.Workbook = appExcel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet)
        Dim worksheet As Excel.Worksheet = workbook.Worksheets.Item(1)
        If worksheet Is Nothing Then
            msg.Alert("ERROR: worksheet == null", 1)
        End If

        'Setting
        worksheet.Cells.Font.Name = "Times New Roman"
        worksheet.Cells.Font.Size = 11

        ''Title
        'worksheet.Range("A2:E2").Select()
        'worksheet.Range("A2:E2").MergeCells = True
        'worksheet.Range("A2:E2").Merge()
        'Dim range0 As Object
        'range0 = worksheet.Cells(2, 1) 'worksheet.Range("A2")
        'range0.Value2 = Strings.UCase(cTitle).Trim
        'range0.Font.Size = 16
        'range0.Font.Bold = True

        'Header
        Dim rowIndex As Int16 = 0 'để 5 mà nó lại in từ dòng 7 nên giảm xuống 3 là ok
        Dim colIndex As Int16 = 0
        For Each dc As DataColumn In dv.Columns
            colIndex = colIndex + 1
            Dim range1 As Object
            range1 = worksheet.Cells(1, colIndex) 'worksheet.Range(Convert.ToChar(Convert.ToInt16(cFirstCol) + num1 - 1) & Convert.ToString(iHeaderRow), Missing.Value)
            range1.Value2 = dc.ColumnName
            range1.Font.Bold = True
            range1.Font.Color = RGB(0, 0, 0)
            range1.Interior.Color = RGB(70, 255, 163)
        Next
        For Each dr As DataRow In dv.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc As DataColumn In dv.Columns
                colIndex = colIndex + 1
                Dim range1 As Object
                range1 = worksheet.Cells(rowIndex + 1, colIndex)
                If dc.ColumnName.ToLower = "gia_ban11" Then
                    Dim tien As Decimal
                    tien = Convert.ToDecimal(dr(dc.ColumnName))
                    range1.Value2 = LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien")))
                ElseIf dc.ColumnName.ToLower = "tien_cong" Then
                    Dim tien As Decimal
                    tien = Convert.ToDecimal(dr(dc.ColumnName))
                    range1.Value2 = LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien")))
                ElseIf dc.ColumnName.ToLower = "tien_da" Then
                    Dim tien As Decimal
                    tien = Convert.ToDecimal(dr(dc.ColumnName))
                    range1.Value2 = LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien")))
                ElseIf dc.ColumnName.ToLower = "tong_tlg" Then
                    Dim so As Decimal = Convert.ToDecimal(dr(dc.ColumnName).ToString.Trim)
                    range1.NumberFormat = Me.oOptions("m_ip_tlg")
                    range1.Value2 = so 'Strings.Format(so, Me.oOptions("m_ip_tlg"))
                ElseIf dc.ColumnName.ToLower = "tlg_au" Then
                    Dim so As Decimal = Convert.ToDecimal(dr(dc.ColumnName).ToString.Trim)
                    range1.NumberFormat = Me.oOptions("m_ip_tlg")
                    range1.Value2 = so 'Strings.Format(so, Me.oOptions("m_ip_tlg"))
                ElseIf dc.ColumnName.ToLower = "tlg_da" Then
                    Dim so As Decimal = Convert.ToDecimal(dr(dc.ColumnName).ToString.Trim)
                    range1.NumberFormat = Me.oOptions("m_ip_tlg")
                    range1.Value2 = so 'Strings.Format(so, Me.oOptions("m_ip_tlg"))
                ElseIf dc.ColumnName.ToLower = "sl_td1" Then
                    range1.NumberFormat = Me.oOptions("m_ip_tlg")
                    range1.Value2 = dr(dc.ColumnName)
                ElseIf dc.ColumnName.ToLower = "sl_td2" Then
                    range1.NumberFormat = Me.oOptions("m_ip_tlg")
                    range1.Value2 = dr(dc.ColumnName)
                ElseIf dc.ColumnName.ToLower = "sl_td3" Then
                    range1.NumberFormat = Me.oOptions("m_ip_tlg")
                    range1.Value2 = dr(dc.ColumnName)
                ElseIf dc.DataType Is System.Type.GetType("System.DateTime") Then
                    If dc.ColumnName.ToLower = "datetime0" Or dc.ColumnName.ToLower = "datetime2" Then
                        range1.NumberFormat = "dd/MM/yyyy hh:mm:ss"
                    Else
                        range1.NumberFormat = "dd/MM/yyyy"
                    End If
                    range1.Value2 = dr(dc.ColumnName)
                Else
                    range1.NumberFormat = "@"
                    range1.Value2 = dr(dc.ColumnName)
                End If
            Next
        Next

        worksheet.Columns.AutoFit()
        Try
            If System.IO.File.Exists(FilePath2Save) Then
                System.IO.File.Delete(FilePath2Save)
            End If
            workbook.SaveAs(FilePath2Save)
            workbook.Close()
            'appExcel = Nothing
            appExcel.Quit()
            'msg.Alert("Xuất file excel thành công")
            'xuất excel xong in
            inBartenderExcel()
        Catch Outer As COMException
            Console.WriteLine("User closed Excel manually, so we don't have to do that")
        End Try
    End Sub

    Private Sub LoadNCC()
        Me.cbChonNCC.Items.Clear()
        dsNCC.Tables.Clear()

        Dim stSelectSql As String = "SELECT DoitacID,DoitacName,DoitacAdd,DoitacTel,maTem,tccs,maKyHieu FROM dmdoitac WHERE Ncc_yn = 1"
        sql.SQLRetrieve(Me.appConn, stSelectSql, "NCC", dsNCC)
        cbChonNCC.ValueMember = "DoitacID"
        cbChonNCC.DisplayMember = "DoitacID"
        cbChonNCC.DataSource = dsNCC.Tables("NCC")
        'For Each dr As DataRow In dsNCC.Tables("NCC").Rows
        '    cbChonNCC.Items.Add(dr("DoitacName"))
        'Next
        cbChonNCC.SelectedText = ""
        'If cbChonNCC.Items.Count > 0 Then
        '    cbChonNCC.SelectedIndex = 0
        '    'rboPrint.Visible = True
        '    'rboPreview.Visible = True
        'Else
        '    cbChonNCC.SelectedText = ""
        '    'rboPrint.Visible = False
        '    'rboPreview.Visible = False
        'End If
    End Sub

    Private Sub cbChonNCC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbChonNCC.SelectedIndexChanged
        If cbChonNCC.Items.Count > 0 Then
            If cbChonNCC.SelectedItem.ToString <> "" Then
                Dim dtRowID As DataRow() = dsNCC.Tables("NCC").Select("DoitacID = '" & cbChonNCC.SelectedValue & "'")
                txtS1.Text = dtRowID(0)("DoitacName")
                txtS2.Text = dtRowID(0)("DoitacAdd")
                txtS3.Text = dtRowID(0)("tccs")
                TxtS10.Text = dtRowID(0)("maKyHieu")
                txts12.Text = dtRowID(0)("maTem")
                If dtRowID(0)("maTem").ToString.Length > 0 Then
                    cboTems.SelectedItem = dtRowID(0)("maTem")
                End If
            End If
        End If
    End Sub
    Dim btApp As BarTender.Application
    Dim btFormat As BarTender.Format
    Dim btMsgs As BarTender.Messages
    Private Sub inBartender(ByVal dv As DataTable)
        'Sử dụng để in ra bartender 1 tem
        'Tên mẫu btw cần lấy
        Dim NameFileBatender As String = ""
        NameFileBatender = cboTems.SelectedItem.ToString()

        btApp = New BarTender.Application()
        Dim filepath As String = Application.StartupPath & "\export\" & NameFileBatender & ".btw"
        If System.IO.File.Exists(filepath) Then
            Try
                'btFormat = btApp.Formats.Open("D:\00ngoai\2019\pm kho_thao\3cm 1cm.btw")
                'Vtid,Vtname,Ma_td2,Gc_td1,Gc_td2,Gc_td3,Tien_cong,Tien_da
                'Code_qr=Code_text(chính là code hiện tại),S1,S2,S3,S10,tong_tlg,tlg_au,tlg_da,gia_ban11
                btFormat = btApp.Formats.Open(filepath)
                'msg.Alert(LTrim(Strings.Format(Convert.ToDecimal(dv.Rows(0)("Tien_cong")), Me.oOptions("m_ip_tien"))))
                btFormat.SetNamedSubStringValue("Code_qr", dv.Rows(0)("Code"))
                btFormat.SetNamedSubStringValue("Code_text", dv.Rows(0)("Code"))
                btFormat.SetNamedSubStringValue("Vtid", dv.Rows(0)("VtID"))
                btFormat.SetNamedSubStringValue("Vtname", dv.Rows(0)("VtName"))
                btFormat.SetNamedSubStringValue("Ma_td2", dv.Rows(0)("Ma_td2"))
                btFormat.SetNamedSubStringValue("gc_td1", getKLgam(dv.Rows(0)("Tong_tlg")))
                btFormat.SetNamedSubStringValue("gc_td2", getKLgam(dv.Rows(0)("Tlg_au")))
                btFormat.SetNamedSubStringValue("gc_td3", getKLgam(dv.Rows(0)("Tlg_da")))
                btFormat.SetNamedSubStringValue("sl_td1", getKLgamSo(dv.Rows(0)("Tong_tlg")))
                btFormat.SetNamedSubStringValue("sl_td2", getKLgamSo(dv.Rows(0)("Tlg_au")))
                btFormat.SetNamedSubStringValue("sl_td3", getKLgamSo(dv.Rows(0)("Tlg_da")))
                Dim so As Decimal
                so = Convert.ToDecimal(dv.Rows(0)("Tlg_au").ToString.Trim)
                btFormat.SetNamedSubStringValue("tlg_au", so)
                so = Convert.ToDecimal(dv.Rows(0)("Tlg_da").ToString.Trim)
                btFormat.SetNamedSubStringValue("tlg_da", so)
                so = Convert.ToDecimal(dv.Rows(0)("Tong_tlg").ToString.Trim)
                btFormat.SetNamedSubStringValue("Tong_tlg", so)
                Dim tien As Decimal
                tien = Convert.ToDecimal(dv.Rows(0)("Gia_ban11"))
                btFormat.SetNamedSubStringValue("gia_ban11", LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien"))))
                tien = Convert.ToDecimal(dv.Rows(0)("Tien_da"))
                btFormat.SetNamedSubStringValue("Tien_da", LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien"))))
                tien = Convert.ToDecimal(dv.Rows(0)("Tien_cong"))
                btFormat.SetNamedSubStringValue("Tien_cong", LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien"))))
                btFormat.SetNamedSubStringValue("s1", dv.Rows(0)("S1"))
                btFormat.SetNamedSubStringValue("s2", dv.Rows(0)("S2"))
                btFormat.SetNamedSubStringValue("s3", dv.Rows(0)("S3"))
                btFormat.SetNamedSubStringValue("s10", dv.Rows(0)("S10"))
                btFormat.SetNamedSubStringValue("s11", dv.Rows(0)("S11"))
                If dv.Rows(0)("dienGiaiNh").ToString.Length > 0 Then
                    btFormat.SetNamedSubStringValue("dienGiaiNh", dv.Rows(0)("dienGiaiNh"))
                Else
                    Dim NhomDg As String = sql.GetValue(appConn, "dmnhvt2", "DienGiai", "Nhvt2ID ='" & dv.Rows(0)("FK_Nhvt2ID") & "'")
                    btFormat.SetNamedSubStringValue("dienGiaiNh", NhomDg)
                End If

                'Số bản copy của 1 con tem
                btFormat.IdenticalCopiesOfLabel = 1
                'số lượng tem cần in
                btFormat.NumberSerializedLabels = 1
                'hàm in
                btFormat.UseDatabase = True
                btFormat.UseInputDataFile = False
                btFormat.Print("Job1", True, -1, btMsgs)
                'btFormat.PrintOut(False, False)
            Catch ex As Exception
                msg.Alert(ex.Message)
            Finally
                btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            End Try
        Else
            msg.Alert("Chưa có file " & NameFileBatender & ".btw  để thực hiện in ." & vbCrLf & "Đường dẫn đến file " & filepath)
        End If
    End Sub
    Private Sub inBartenderSLnhieu(ByVal dv As DataTable)
        'Sử dụng để in ra bartender 1 tem
        'Tên mẫu btw cần lấy
        Dim NameFileBatender As String = ""
        NameFileBatender = cboTems.SelectedItem.ToString()

        btApp = New BarTender.Application()
        Dim filepath As String = Application.StartupPath & "\export\" & NameFileBatender & ".btw"
        If System.IO.File.Exists(filepath) Then
            Try
                'btFormat = btApp.Formats.Open("D:\00ngoai\2019\pm kho_thao\3cm 1cm.btw")
                'Vtid,Vtname,Ma_td2,Gc_td1,Gc_td2,Gc_td3,Tien_cong,Tien_da
                'Code_qr=Code_text(chính là code hiện tại),S1,S2,S3,S10,tong_tlg,tlg_au,tlg_da,gia_ban11
                btFormat = btApp.Formats.Open(filepath, False, "")
                For Each drTemIn As DataRow In dv.Rows
                    'msg.Alert(LTrim(Strings.Format(Convert.ToDecimal(dv.Rows(0)("Tien_cong")), Me.oOptions("m_ip_tien"))))
                    btFormat.SetNamedSubStringValue("Code_qr", drTemIn("Code"))
                    btFormat.SetNamedSubStringValue("Code_text", drTemIn("Code"))
                    btFormat.SetNamedSubStringValue("Vtid", drTemIn("VtID"))
                    btFormat.SetNamedSubStringValue("Vtname", drTemIn("VtName"))
                    btFormat.SetNamedSubStringValue("Ma_td2", drTemIn("Ma_td2"))
                    btFormat.SetNamedSubStringValue("gc_td1", getKLgam(drTemIn("Tong_tlg")))
                    btFormat.SetNamedSubStringValue("gc_td2", getKLgam(drTemIn("Tlg_au")))
                    btFormat.SetNamedSubStringValue("gc_td3", getKLgam(drTemIn("Tlg_da")))
                    btFormat.SetNamedSubStringValue("sl_td1", getKLgamSo(drTemIn("Tong_tlg")))
                    btFormat.SetNamedSubStringValue("sl_td2", getKLgamSo(drTemIn("Tlg_au")))
                    btFormat.SetNamedSubStringValue("sl_td3", getKLgamSo(drTemIn("Tlg_da")))
                    Dim so As Decimal
                    so = Convert.ToDecimal(drTemIn("Tlg_au").ToString.Trim)
                    btFormat.SetNamedSubStringValue("tlg_au", so)
                    so = Convert.ToDecimal(drTemIn("Tlg_da").ToString.Trim)
                    btFormat.SetNamedSubStringValue("tlg_da", so)
                    so = Convert.ToDecimal(drTemIn("Tong_tlg").ToString.Trim)
                    btFormat.SetNamedSubStringValue("Tong_tlg", so)
                    Dim tien As Decimal
                    tien = Convert.ToDecimal(drTemIn("Gia_ban11"))
                    btFormat.SetNamedSubStringValue("gia_ban11", LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien"))))
                    tien = Convert.ToDecimal(drTemIn("Tien_da"))
                    btFormat.SetNamedSubStringValue("Tien_da", LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien"))))
                    tien = Convert.ToDecimal(drTemIn("Tien_cong"))
                    btFormat.SetNamedSubStringValue("Tien_cong", LTrim(Strings.Format(tien, Me.oOptions("m_ip_tien"))))
                    btFormat.SetNamedSubStringValue("s1", drTemIn("S1"))
                    btFormat.SetNamedSubStringValue("s2", drTemIn("S2"))
                    btFormat.SetNamedSubStringValue("s3", drTemIn("S3"))
                    btFormat.SetNamedSubStringValue("s10", drTemIn("S10"))
                    btFormat.SetNamedSubStringValue("s11", drTemIn("S11"))
                    If drTemIn("dienGiaiNh").ToString.Length > 0 Then
                        btFormat.SetNamedSubStringValue("dienGiaiNh", drTemIn("dienGiaiNh"))
                    Else
                        Dim NhomDg As String = sql.GetValue(appConn, "dmnhvt2", "DienGiai", "Nhvt2ID ='" & drTemIn("FK_Nhvt2ID") & "'")
                        btFormat.SetNamedSubStringValue("dienGiaiNh", NhomDg)
                    End If

                    'Số bản copy của 1 con tem
                    btFormat.IdenticalCopiesOfLabel = 1
                    'số lượng tem cần in
                    btFormat.NumberSerializedLabels = 1
                    'hàm in
                    btFormat.UseDatabase = True
                    btFormat.UseInputDataFile = False
                    btFormat.Print("Job1", True, -1, btMsgs)
                    'btFormat.PrintOut(False, False)
                Next
            Catch ex As Exception
                msg.Alert(ex.Message)
            Finally
                btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            End Try
        Else
            msg.Alert("Chưa có file " & NameFileBatender & ".btw  để thực hiện in ." & vbCrLf & "Đường dẫn đến file " & filepath)
        End If
    End Sub
    Private Sub inBartenderExcel()
        'Tên mẫu btw cần lấy
        Dim NameFileBatender As String = ""
        NameFileBatender = cboTems.SelectedItem.ToString()

        btApp = New BarTender.Application()
        Dim filepath As String = Application.StartupPath & "\export\" & NameFileBatender & ".btw"
        If System.IO.File.Exists(filepath) Then
            Try
                'btFormat = btApp.Formats.Open("D:\00ngoai\2019\pm kho_thao\3cm 1cm.btw")
                'Code, vtid, vtname, gia_ban11, ma_td2, s1, tong_tlg, tlg_au, tlg_da, tien_da, tien_cong
                btFormat = btApp.Formats.Open(filepath)
                'btFormat.SetNamedSubStringValue("code", txtCode.Text)

                'Số bản copy của 1 con tem
                btFormat.IdenticalCopiesOfLabel = 1
                'số lượng tem cần in
                btFormat.NumberSerializedLabels = 1
                'hàm in
                'btFormat.UseDatabase = True
                'btFormat.UseInputDataFile = True
                btFormat.Print("Job1", True, -1, btMsgs)
            Catch ex As Exception
                msg.Alert(ex.Message)
            Finally
                btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
            End Try
        Else
            msg.Alert("Chưa có file " & NameFileBatender & ".btw  để thực hiện in ." & vbCrLf & "Đường dẫn đến file " & filepath)
        End If
    End Sub

    Private Sub txtS1_TextChanged(sender As Object, e As EventArgs) Handles txtS1.TextChanged
        If Me.cAction.ToLower = "start" Then
            If cbChonNCC.Items.Count > 0 Then
                If cbChonNCC.Text <> "" Then
                    'Dim dtRowID As DataRow() = dsNCC.Tables("NCC").Select("DoitacName = N'" & txtS1.Text & "'")
                    'If dtRowID(0)("maTem").ToString.Length > 0 Then
                    '    cboTems.Text = dtRowID(0)("maTem")
                    'End If
                    cboTems.Text = txts12.Text
                End If
            End If
        End If
    End Sub

    Private Sub txtGia_cong_TextChanged(sender As Object, e As EventArgs) Handles txtGia_cong.TextChanged
        If cAction.ToLower = "new" Or cAction.ToLower = "edit" Then
            calC_CongBan()
        End If
    End Sub

    Private Sub txtGia_cong0_TextChanged(sender As Object, e As EventArgs) Handles txtGia_cong0.TextChanged
        If cAction.ToLower = "new" Or cAction.ToLower = "edit" Then
            calC_CongGoc()
        End If
    End Sub

    Private Sub calC_CongGoc()
        TxtTien_cong0.Value = Math.Round(Math.Round(txtGia_cong0.Value * txtTlg_au.Value, 0) / 1000, 0) * 1000
    End Sub
    Private Sub calC_CongBan()
        'làm tròn về 5000, 65k, 66k, 69k = 65k, còn 61k 64k =60k
        Dim strCong_ban As String = Math.Round(Math.Round(txtGia_cong.Value * txtTlg_au.Value, 0) / 1000, 0)
        Dim ktra As Int16 = Int16.Parse(Strings.Right(strCong_ban, 1))
        Dim soTron As String
        If ktra < 5 Then
            soTron = "0"
        Else
            soTron = "5"
        End If
        strCong_ban = Strings.Left(strCong_ban, strCong_ban.Length - 1) & soTron
        Dim cong_ban As Decimal = Decimal.Parse(strCong_ban)
        TxtTien_cong.Value = cong_ban * 1000
    End Sub

    Private Sub TbrPause_Click(sender As Object, e As EventArgs) Handles TbrPause.Click
        Select Case TbrPause.Text.ToUpper
            Case "TẠM DỪNG"
                _Paused = True
                Me.TbrPause.Text = "Hủy dừng"
            Case "HỦY DỪNG"
                _Paused = False
                Me.TbrPause.Text = "Tạm dừng"
        End Select
    End Sub
#Region "Nhập từ cân điện tử"
    Private _comPort As New SerialPort


    Dim DoDaiTrongLuong As Integer = -1
    Dim HeSoCan As Integer = -1
    Dim BaudRate As Integer = -1
    Dim DataBits As Integer = -1
    Dim PortName As String = ""
    Dim KyTuTrongLuongTinh As String = "S"
    Dim KyTuTrongLuongDong As String = "U"


    Private Sub TbrConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbrConnect.Click
        'Select Case TbrConnect.Text.ToUpper
        '    Case "KẾT NỐI"
        '        If SerialPort1.IsOpen Then
        '            SerialPort1.Close()
        '        End If
        '        Me.ConnectScale()
        '        Me.TbrConnect.Text = "Ngắt kết nối"
        '    Case "NGẮT KẾT NỐI"
        '        If SerialPort1.IsOpen Then
        '            SerialPort1.Close()
        '        End If
        '        Me.TbrConnect.Text = "Kết nối"
        'End Select
        Select Case TbrConnect.Text.ToUpper
            Case "KẾT NỐI"
                Bat_CanDienTu()
            Case "NGẮT KẾT NỐI"
                tmrCanDienTu_T1.Stop()
                tmrCanDienTu_T1.Enabled = False
                _comPort.Close()
                Me.TbrConnect.Text = "Kết nối"
                Scale.Text = "Cân đã tắt"
        End Select
    End Sub

    Private Sub Bat_CanDienTu()
        Scale.Text = ""

        Try
            PortName = Me.oOptions.Item("Scale_portcom").ToString()
            BaudRate = Convert.ToInt32(Me.oOptions.Item("Scale_baudrate"))
            DataBits = Convert.ToInt32(Me.oOptions.Item("Scale_databits"))
            If PortName <> "" Then
                'SerialPort1.StopBits = Read_StopBits(Me.oOptions.Item("Scale_stopbits"))
                'SerialPort1.Handshake = IO.Ports.Handshake.None
                _comPort.BaudRate = BaudRate
                _comPort.DataBits = DataBits
                _comPort.StopBits = Read_StopBits(Me.oOptions.Item("Scale_stopbits"))
                _comPort.Parity = Read_Parity(Me.oOptions.Item("Scale_parity").ToString())
                _comPort.PortName = PortName
                _comPort.Open()
                tmrCanDienTu_T1.Enabled = True
                tmrCanDienTu_T1.Start()
                Scale.Text = "Cân đã được kết nối."

                'txtDataBits.Text = String.Format("{0};{1};{2};{3};{4};{5};{6}", PortName, BaudRate, DataBits, DoDaiTrongLuong, HeSoCan, KyTuTrongLuongDong, KyTuTrongLuongTinh)


                Me.TbrConnect.Text = "Ngắt kết nối"
            End If
        Catch ex As Exception
            Scale.Text = String.Format("Kết nối cân bị lỗi. ({0})", ex.Message)
            If _comPort.IsOpen Then
                _comPort.Close()
                tmrCanDienTu_T1.Stop()
                tmrCanDienTu_T1.Enabled = False
            End If
        End Try
    End Sub

    Dim _okDaKetNoiCan As Boolean = True
    Dim _okDaKetNoiCan_DemLanSai As Integer = 0
    Dim _DemThoiGianKhoa As Integer = 0

    Dim DuocThemTuDong As Boolean = True
    Dim GiaTriVuaThem As Decimal = 0
    Dim SoLanCanDaTinh As Integer = 0

    Private Sub tmrCanDienTu_T1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCanDienTu_T1.Tick
        'tmrCanDienTu_T1.Stop()
        'tmrCanDienTu_T1.Enabled = False

        If _Paused Then
            Return
        End If
        Dim XauTrangThai As String = ""
        Try
            Dim HeSoNhan As Decimal = HeSoCan

            Dim GT As String = _comPort.ReadExisting().ToUpper
            Dim GTCu As String = GT

            'If _DemThoiGianKhoa > 0 Then
            '    _DemThoiGianKhoa = _DemThoiGianKhoa - 1
            '    Exit Sub
            'End If

            GT = GT.Replace("ENTER.", " ")
            If GT.IndexOf(".") < 0 Then
                Exit Sub
            End If
            If GT.IndexOf("MO ") >= 0 Then
                HeSoNhan = 1
            End If

            Dim XauSo As String = "-0123456789. "
            Dim i, j As Integer
            Dim HT As String = ""
            Dim dem As Integer = 0
            Dim okDuocPhep As Boolean = False
            Dim BoQua As Boolean = False

            For j = GT.Length - 1 To 0 Step -1
                Dim KyTu As String = GT.Substring(j, 1)
                If XauSo.IndexOf(KyTu) < 0 Then
                    GT = GT.Replace(KyTu, " ")
                End If
            Next
            GT = GT.Trim()
            While GT.IndexOf("  ") >= 0
                GT = GT.Replace("  ", " ")
            End While
            While GT.IndexOf("00.") >= 0
                GT = GT.Replace("00.", "0.")
            End While
            Dim arr As Array = GT.Split(" ")

            For i = arr.Length - 1 To 0 Step -1
                Dim strSo As String = arr(i)

                If strSo.IndexOf(".") >= 0 And IsNumeric(strSo) And strSo.Length >= DoDaiTrongLuong Then
                    Dim SoLay As Decimal = strSo
                    If SoLay >= 0 Then
                        HT = strSo
                        XauTrangThai = HT
                        Exit For
                    End If
                End If
            Next

            'Dim GiaTri As Decimal = HT
            'GiaTri = GiaTri * HeSoNhan
            'txtTrongLuongCan.Text = GiaTri.ToString("#,##0.######")
            Dim cutvalue As String = HT.Replace(" ", "").Trim
            Dim replace As String() = Me.oOptions.Item("Scale_replace").ToString.Trim.Split(" ")

            For l As Integer = 0 To replace.Length - 1
                cutvalue = Strings.Replace(cutvalue, replace(l), "")
            Next

            If cutvalue = "" Then
                Return
            End If

            Dim GiaTri As Decimal = 0
            Try
                GiaTri = Convert.ToDecimal(cutvalue.Trim)
            Catch ex As Exception
                Scale.Text = cutvalue
                GiaTri = 0
            End Try
            Dim tong As Decimal = 0
            tong = Math.Round(GiaTri * Convert.ToDecimal(Me.oOptions.Item("Scale_weigh")), 4)
            If Me.txtTong_tlg.Value <> tong Then
                txtTong_tlg.Value = tong
                txtTlg_au.Value = tong - txtTlg_da.Value
            End If

            _okDaKetNoiCan = True
            _okDaKetNoiCan_DemLanSai = 0

            If _okDaKetNoiCan_DemLanSai > 5 Then
                _okDaKetNoiCan = False
            Else
                _okDaKetNoiCan_DemLanSai = _okDaKetNoiCan_DemLanSai + 1
            End If

            Scale.Text = XauTrangThai
        Catch ex As Exception
            Scale.Text = String.Format("Kết nối cân bị lỗi. ({0})", ex.Message)
            _okDaKetNoiCan = False
        End Try

        'If _okDaKetNoiCan Then
        '    XauTrangThai = String.Format("1:{0}", XauTrangThai)
        'Else
        '    XauTrangThai = String.Format("2:{0}", XauTrangThai)
        'End If

        'Scale.Text = XauTrangThai

        'tmrCanDienTu_T1.Enabled = True
        'tmrCanDienTu_T1.Start()
    End Sub

    Private Sub mnCopyData2_Click(sender As Object, e As EventArgs) Handles mnCopyData2.Click
        DongBoData2()
    End Sub
    Private Sub DongBoData2()
        If serverThueB.Length = 0 Then
            msg.Alert("Lỗi không kết nối được đến database 2 (dataThueB) bên thuế. Hãy kiểm tra lại kết nối và bật lại")
            Return
        End If
        Try
            thueSqlConn = New SqlConnection("data source = " + serverThueB + ";database = " + dataThueB + "; uid= " + userThueB + ";Password= " + passThueB + "")
            ForBackgroundRun = New ForBackgroundRun(Me.appConn, Me.thueSqlConn)
            'lblResult.Text = ""
        Catch ex As Exception
            'AutoSync.Stop()
            'AutoSync.Enabled = False
            msg.Alert("Lỗi không kết nối được đến database 2 (dataThueB) bên thuế. Hãy kiểm tra lại kết nối và bật lại")
            Return
            'Application.Restart()
        End Try
        ''đủ điều kiện thì bắt đầu chuyển dữ liệu sang bên dữ liệu thuế
        'kiểm tra xem phiếu có chưa
        'chuyển dmvt sang (vì mã nhập kho hàng mới chưa có
        'chuyển phiếu nhập kho sang data 2
        Dim textSync As String
        Dim dsSync1 As DataSet
        dsSync1 = New DataSet
        Dim countDmvt As Integer = 0
        Dim countDmnhvt As Integer = 0
        'Chuyển dmstt
        textSync = "SELECT * FROM dmstt"
        sql.SQLRetrieve(forBackgroundRun.appConn, textSync, "sync_dmstt", dsSync1)
        If dsSync1.Tables("sync_dmstt").Rows.Count > 0 Then
            If forBackgroundRun.thueConn.State = ConnectionState.Closed Then
                forBackgroundRun.thueConn.Open()
            End If

            For Each dr As DataRow In dsSync1.Tables("sync_dmstt").Rows
                sql.SQLDelete(forBackgroundRun.thueConn, "dmstt", "1=1")
                Dim kq As Int32 = sql.SQLInsert(forBackgroundRun.thueConn, "dmstt", dr)
            Next
        End If
        'Chuyển dm nhóm vt dmnhvt2 sang
        textSync = "SELECT * FROM dmnhvt2"
        sql.SQLRetrieve(forBackgroundRun.appConn, textSync, "sync_dmnhvt", dsSync1)
        If dsSync1.Tables("sync_dmnhvt").Rows.Count > 0 Then
            If forBackgroundRun.thueConn.State = ConnectionState.Closed Then
                forBackgroundRun.thueConn.Open()
            End If

            For Each dr As DataRow In dsSync1.Tables("sync_dmnhvt").Rows
                dr.Item("datetime2") = Date.Now
                sql.SQLDelete(forBackgroundRun.thueConn, "dmnhvt2", "Nhvt2ID = '" + dr.Item("Nhvt2ID") + "'")
                Dim kq As Int32 = sql.SQLInsert(forBackgroundRun.thueConn, "dmnhvt2", dr)
                If kq > 0 Then
                    countDmnhvt = countDmnhvt + 1
                    'sql.SQLDelete(forBackgroundRun.appConn, "SyncFail", "ID = '" + dr2.Item("doitacID") + "'")
                End If
            Next
        End If
        'Chuyển dmvt sang
        textSync = "SELECT * FROM dmvt"
        sql.SQLRetrieve(forBackgroundRun.appConn, textSync, "sync_dmvt", dsSync1)
        If dsSync1.Tables("sync_dmvt").Rows.Count > 0 Then
            If forBackgroundRun.thueConn.State = ConnectionState.Closed Then
                forBackgroundRun.thueConn.Open()
            End If

            For Each dr As DataRow In dsSync1.Tables("sync_dmvt").Rows
                dr.Item("datetime2") = Date.Now
                'sql.SQLDelete(forBackgroundRun.thueConn, "dmvt", "VtID = '" + dr.Item("VtID") + "'")
                Dim VtName As String = Nothing
                VtName = sql.GetValue(forBackgroundRun.thueConn, "dmvt", "VtID", "VtID = '" + dr.Item("VtID") + "'")
                If String.IsNullOrEmpty(VtName) Then
                    Dim kq As Int32 = sql.SQLInsert(forBackgroundRun.thueConn, "dmvt", dr)
                    If kq > 0 Then
                        countDmvt = countDmvt + 1
                        'sql.SQLDelete(forBackgroundRun.appConn, "SyncFail", "ID = '" + dr2.Item("doitacID") + "'")
                    End If
                End If
            Next
        End If

        msg.Alert("Thêm thành công tổng số mã hàng: " & countDmvt.ToString)
    End Sub

    Private Sub chktien_yn_CheckedChanged(sender As Object, e As EventArgs) Handles chktien_yn.CheckedChanged
        If chktien_yn.Checked Then
            Dim num1 As Decimal = Decimal.Zero
            Dim num2 As Decimal = Decimal.Zero
            Dim num3 As Decimal = Decimal.Zero
            Dim num4 As Decimal = Decimal.Zero

            num1 = Me.txtTong_tlg.Value
            num2 = Me.txtGia_au.Value
            num3 = Me.TxtTien_cong.Value
            num4 = Me.txtTien_da.Value
            Dim giaTron As Decimal = Math.Round(Math.Round((num1 * num2 + num3 + num4), 0) / 1000, 0) * 1000
            Me.txtGia_ban11.Value = getTronTien5k(giaTron)
            num2 = Me.txtGia_au0.Value
            num3 = Me.TxtTien_cong0.Value
            num4 = Me.txtTien_da0.Value
            giaTron = Math.Round(Math.Round((num1 * num2 + num3 + num4), 0) / 1000, 0) * 1000
            txtGia_mua.Value = giaTron
        Else
            calC2()
            calC3()
        End If
    End Sub
#End Region
    Private Function getTronTien5k(ByVal tien As Decimal) As Decimal
        If TronGia5k = "0" Then
            Return tien
        End If
        Dim TienBanVND As Decimal = 0
        Dim tlg_au_gam As Decimal = 0
        'làm tròn về 5000, 65k, 66k, 69k = 70k, còn 61k 64k =65k
        Dim strTien_ban As String = Math.Round(tien / 1000, 0)
        If strTien_ban.Length > 0 Then
            Dim ktra As Int16 = Int16.Parse(Strings.Right(strTien_ban, 1))
            Dim soTron As String
            If ktra = 5 Then
                Return tien
            ElseIf ktra = 0 Then
                Return tien
            ElseIf ktra > 5 Then
                TienBanVND = Math.Round(tien / 10000, 0) * 10000
                Return TienBanVND
            Else
                soTron = "5"
            End If
            strTien_ban = Strings.Left(strTien_ban, strTien_ban.Length - 1) & soTron
            Dim cong_ban As Decimal = Decimal.Parse(strTien_ban)
            TienBanVND = cong_ban * 1000
        Else
            Return tien
        End If

        Return TienBanVND
    End Function
End Class
