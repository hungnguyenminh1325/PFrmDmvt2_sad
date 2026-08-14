Option Strict Off
Option Explicit On
Imports System.Management
Imports System.Data.SQLite
Imports hg3.hg3

Public Class FrmChonMayIn
    Dim search As System.Management.ManagementObjectSearcher
    Dim results As System.Management.ManagementObjectCollection
    'Dim args(1) As Object
    Dim printer As System.Management.ManagementObject
    'Dim motherform As ctrHDT
    Dim pr As Printing.PrinterSettings
    Dim poOptions As Collection
    Dim poVar As Collection
    Dim psConn As SQLiteConnection
    Dim typeChoice As String
    Dim pFrmMain As UserControl
    Dim NamePrinter As String
    
    Public Sub New(ByVal FrmMain As UserControl, ByVal oOptions As Collection, ByVal sConn As SQLiteConnection, ByVal NamePrint As String, ByVal type As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'Me.motherform = form1
        pFrmMain = FrmMain
        poOptions = oOptions
        psConn = sConn
        NamePrinter = NamePrint
        Me.typeChoice = type
    End Sub

    Private Sub FrmChonMayIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ten may in truoc
        'Dim pr = New Printing.PrinterSettings
        'lbmayintruoc.Text = pr.PrinterName
        Me.Name = "Chọn máy in tem"
        Try
            search = New System.Management.ManagementObjectSearcher("select * from Win32_Printer")
            results = search.Get
            For Each printer In results
                cbChonMayIn.Items.Add(printer("Name"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        If Me.typeChoice = "1" Then
            lbChonMayIn.Text = "Chọn máy in tem"
        Else
            lbChonMayIn.Text = "Chọn máy in"
        End If
        'Dim namePrint As String = ""
        'Try
        '    namePrint = poOptions.Item("printNameDmvt")
        'Catch ex As Exception
        '    sqlite.SQLExecute(psConn, "DELETE FROM Options WHERE name IN ('printNameDmvt')")
        '    sqlite.SQLExecute(psConn, "INSERT INTO Options (attribute,name,type,descript,descript2,val,defaul,inputmask,datetime0,datetime2,user_id0,user_id2) VALUES ('1','printNameDmvt','C','Tên máy in mặc định trên máy in tem Dmvt','E','Microsoft XPS Document Writer','Microsoft XPS Document Writer','','14/12/2021','14/12/2021',0,0)")
        '    msg.Alert("Lỗi biến printNameDmvt ở sqlite. Hãy tắt phần mềm đi bật lại")
        'End Try
        cbChonMayIn.Text = NamePrinter
        'Me.lbmayintruoc.Text = cbChonMayIn.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChon.Click
        If cbChonMayIn.Text.Length > 0 Then
            'If Me.lbmayintruoc.Text <> cbChonMayIn.Text Then
            Dim sql0 As String = ""
            'If Me.typeChoice = "1" Then
            '    sql0 = String.Format("Update options set val = '{0}' where [name] = 'printerHDA' ", cbChonMayIn.Text)
            'Else
            '    sql0 = String.Format("Update options set val = '{0}' where [name] = 'printerGdbv' ", cbChonMayIn.Text)
            'End If
            sql0 = String.Format("Update options set val = '{0}' where [name] = 'printNameDmvt' ", cbChonMayIn.Text)
            sqlite.SQLExecute(Me.psConn, sql0)
            Dim ctrItem1 As ctrItem = CType(Me.pFrmMain, ctrItem)
            ctrItem1.NamePrint = cbChonMayIn.Text
            'Me.lbmayintruoc.Text = "...... Đã sửa thành công ....."
            'End If
            Me.Close()
        Else
            MsgBox("Chưa chọn mẫu in")
        End If
        'Gio co ham moi chi can lay ten may in, va in theo ten may in
        'Frmprint1.pCRpt.PrintOptions.PrinterName = "Ten may in"
    End Sub

    Private Sub BtCheckOnOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCheckOnOff.Click
        Try
            search = New System.Management.ManagementObjectSearcher("select * from Win32_Printer")
            results = search.Get
            For Each printer In results
                If printer("Name") = cbChonMayIn.Text Then
                    If printer("WorkOffline").ToString().ToLower().Equals("true") Then
                        lblCheckAction.Text = "Đang tắt"
                        lblCheckAction.Visible = True
                        lblCheckAction.ForeColor = Color.Red
                    Else
                        lblCheckAction.Text = "Đang mở"
                        lblCheckAction.Visible = True
                        lblCheckAction.ForeColor = Color.Blue
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
End Class