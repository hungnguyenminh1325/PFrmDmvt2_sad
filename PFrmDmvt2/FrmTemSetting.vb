Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports hg3.hg3
Imports System.Drawing
Imports System.Data.SQLite
Imports System.Runtime.CompilerServices
Imports System.IO
Imports PPhotography.PPhotography
Public Class FrmTemSetting
    Dim cActionItem As String = ""
    Dim oOptions As Collection
    Dim oVar As Collection
    Private sysConn As New SQLiteConnection
    Private appConn As New SQLiteConnection
    Private sField As String
    Private sHeader As String
    Dim dsMaster As New DataSet
    Dim dsDetail As New DataSet
    Dim colBind As New Collection
    Dim oLabelID As String
    Dim tab2 As TabPage
    Dim oStatus As String = "Load"
    Public Sub New(ByVal sysCnn As SQLiteConnection, ByVal appCnn As SQLiteConnection, ByVal pOption As Collection, ByVal pVar As Collection, ByVal pAction As String, Optional ByVal pLabel As String = "")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.sysConn = sysCnn
        Me.appConn = appCnn
        Me.oOptions = pOption
        Me.oVar = pVar
        Me.cActionItem = pAction
        Me.oLabelID = pLabel
        'Me.frmMain1 = frmMain2
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmTemSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.RefreshControl(Me.pnLeft.Controls.GetEnumerator)
        Me.LoadTem()
        Me.SetValue()
        Me.StatusControl()
    End Sub
    Private Sub StatusControl()
        If Me.cActionItem.ToLower = "edit" Then
            txtTemLabel.Enabled = False
            Me.ShowHide(True)
        Else
            Me.ShowHide(False)
        End If
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
                        If (Not box1.Multiline) Then
                            AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
                        End If
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "N", False) = 0) Then
                        Dim box1 As txtNumeric = CType(control1, txtNumeric)
                        box1 = CType(control1, txtNumeric)
                        box1.Format = Me.oOptions.Item(box1.Format.ToString)
                        box1.Text = 0
                        box1.Value = 0
                        AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
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
    Private Sub ShowHide(ByVal flag As Boolean)
        If flag Then
            If Not Me.tabPrimary.TabPages.Contains(tabDetail) Then
                Me.tabPrimary.TabPages.Add(tabDetail)
            End If
        Else
            Me.tabPrimary.TabPages.Remove(tabDetail)
        End If
    End Sub
    Private Sub SetValue()
        Dim cmMaster As String = "SELECT * FROM Temlabel"
        Dim cmDetail As String = "SELECT * FROM Temdetail"
        If Me.cActionItem.ToLower = "edit" Then
            cmMaster = String.Format("{0} WHERE LabelID = '{1}'", cmMaster, oLabelID)
            cmDetail = String.Format("{0} WHERE LabelID = '{1}'", cmDetail, oLabelID)
        Else
            cmMaster = String.Format("{0} WHERE 1=0", cmMaster)
            cmDetail = String.Format("{0} WHERE 1=0", cmDetail)
        End If
        Dim set1 As New DataSet
        sqlite.SQLRetrieve(Me.appConn, cmMaster, "Master", dsMaster)
        sqlite.SQLRetrieve(Me.appConn, cmDetail, "Detail", set1)

        If dsMaster.Tables("Master").Rows.Count = 0 Then
            Dim drr As DataRow = dsMaster.Tables("Master").NewRow
            drr("labelID") = ""
            drr("height") = 0
            drr("width") = 0
            drr("top0") = 0
            drr("left0") = 0
            drr("hItem") = 0
            drr("wItem") = 0
            drr("numRows") = 0
            drr("numCells") = 0
            dsMaster.Tables("Master").Rows.Add(drr)
        End If
        txtTemLabel.DataBindings.Add("Text", dsMaster.Tables("Master"), "labelID")
        txtTop0.DataBindings.Add("Value", dsMaster.Tables("Master"), "top0")
        txtLeft0.DataBindings.Add("Value", dsMaster.Tables("Master"), "left0")
        txtWidth.DataBindings.Add("Value", dsMaster.Tables("Master"), "width")
        txtHeight.DataBindings.Add("Value", dsMaster.Tables("Master"), "height")
        txtHItem.DataBindings.Add("Value", dsMaster.Tables("Master"), "hItem")
        txtwItem.DataBindings.Add("Value", dsMaster.Tables("Master"), "wItem")
        txtNumCells.DataBindings.Add("Value", dsMaster.Tables("Master"), "numCells")
        txtNumRows.DataBindings.Add("Value", dsMaster.Tables("Master"), "numRows")

        For Each dr As DataRow In set1.Tables("Detail").Rows
            If Convert.ToBoolean(dr("checked")) = False Then
                Continue For
            End If
            Dim field As String = dr("SubID")
            Dim i As Integer = 1
            Dim j As Integer = fox.GetWordCount(sField, ","c)
            Dim titlefield As String = ""
            While (i <= j)
                If fox.GetWordNum(sField, i, ","c).ToLower.Trim = field.Trim.ToLower Then
                    titlefield = fox.GetWordNum(sHeader, i, ","c)
                    'cblField.SetSelected(i, True)
                    cblField.SetItemChecked(i - 1, True)
                    Exit While
                End If
                i = i + 1
            End While
            Dim dt As New DataTable(field)
            For Each dc As DataColumn In dr.Table.Columns
                dt.Columns.Add(dc.ColumnName)
            Next
            Dim drr As DataRow = dt.NewRow()
            For Each dc As DataColumn In dr.Table.Columns
                drr(dc.ColumnName) = dr(dc.ColumnName)
            Next
            dt.Rows.Add(drr)
            dsDetail.Tables().Add(dt)

            Dim tab As TabPage = tabProperty.TabPages(field)
            If Information.IsDBNull(tab) Or tab Is Nothing Then
                Dim tabC As New TabPage()
                tabC.Name = field
                tabC.Text = titlefield
                Dim ctrlC As New ctrProperty(Me.oOptions)
                ctrlC.DataBind(dsDetail.Tables(field))
                Me.BindingContext(dsDetail.Tables(field)).EndCurrentEdit()
                tabC.Controls.Add(ctrlC)
                tabProperty.TabPages.Add(tabC)
            End If
        Next
        Me.oStatus = "Loaded"
    End Sub
    Private Sub LoadTem()
        Dim row1 As DataRow = CType(sqlite.GetRow(sysConn, "Report", "UPPER(Code) = 'TEMSETTING'"), DataRow)
        Me.sField = Strings.Trim(StringType.FromObject(row1.Item("Fields")))
        Me.sHeader = Strings.Trim(StringType.FromObject(row1.Item("Headers")))
        Dim numNum As Integer = Convert.ToInt16(fox.GetWordCount(sField, ","))
        Dim num As Integer = 1
        Do While (num <= numNum)
            cblField.Items.Add(fox.GetWordNum(sHeader, num, ","c))
            num = num + 1
        Loop
    End Sub
    Private Sub cblField_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cblField.ItemCheck
        If Me.oStatus.ToLower = "loaded" Then
            Dim i As Integer = cblField.SelectedIndex()
            Dim titlefield As String = cblField.SelectedItem.ToString()
            Dim field As String = fox.GetWordNum(sField, i + 1, ","c)
            If Not cblField.GetItemChecked(i) Then
                Dim tab As TabPage = tabProperty.TabPages(field)
                If Information.IsDBNull(tab) Or tab Is Nothing Then
                    Dim tabC As New TabPage()
                    tabC.Name = field
                    tabC.Text = titlefield
                    If Not dsDetail.Tables.Contains(field) Then
                        Dim drRow As DataRow
                        sqlite.SQLRetrieve(Me.appConn, "SELECT * FROM Temdetail WHERE 1=0", field, dsDetail)
                        drRow = dsDetail.Tables(field).NewRow
                        drRow("SubID") = field
                        drRow("LabelID") = dsMaster.Tables("Master").Rows(0)("LabelID").ToString()
                        drRow("top0") = 1
                        drRow("left0") = 1
                        drRow("size") = 7
                        drRow("angle") = 0
                        drRow("enable") = True
                        drRow("X") = 3
                        drRow("Y") = 3
                        drRow("checked") = True
                        dsDetail.Tables(field).Rows.Add(drRow)
                    Else
                        dsDetail.Tables(field).Rows(0)("checked") = True
                    End If
                    Dim ctrlC As New ctrProperty(Me.oOptions)
                    ctrlC.DataBind(dsDetail.Tables(field))
                    Me.BindingContext(dsDetail).EndCurrentEdit()
                    tabC.Controls.Add(ctrlC)
                    tabProperty.TabPages.Add(tabC)
                End If
            Else
                Try
                    tabProperty.TabPages.RemoveByKey(field)
                    dsDetail.Tables(field).Rows(0)("checked") = False
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.BindingContext(dsMaster).EndCurrentEdit()
        Me.BindingContext(dsDetail).EndCurrentEdit()
        If dsMaster.Tables(0).Rows(0).Item("labelID").ToString.Trim.Length <> 0 Then
            If Me.cActionItem.ToLower = "edit" Then
                sqlite.SQLDelete(Me.appConn, "Temdetail", String.Format("LabelID = '{0}'", Me.oLabelID))
                sqlite.SQLUpdate(Me.appConn, "Temlabel", dsMaster.Tables(0).Rows(0), String.Format("LabelID = '{0}'", Me.oLabelID))
            Else
                sqlite.SQLInsert(Me.appConn, "Temlabel", dsMaster.Tables(0).Rows(0))
            End If
            For Each dr As DataTable In dsDetail.Tables
                sqlite.SQLInsert(Me.appConn, "Temdetail", dr.Rows(0))
            Next
            'frmMain1.LoadTems()
            Me.Close()
            Me.Dispose()
        Else
            sttLabel.Text = "Tên mẫu tem không được để trống"
            sttLabel.ForeColor = Color.Red
            Me.ShowHide(False)
            txtTemLabel.Focus()
        End If
    End Sub

    Private Sub txtTemLabel_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTemLabel.Validated
        Dim temlabel As String = txtTemLabel.Text.Trim
        Dim labelid As String = ""
        Try
            If temlabel <> "" Then
                If Not Information.IsDBNull(sqlite.GetValue(Me.appConn, "temlabel", "labelID", "labelID ='" + temlabel + "'")) And Not sqlite.GetValue(Me.appConn, "temlabel", "labelID", "labelID ='" + temlabel + "'") Is Nothing Then
                    sttLabel.Text = "Tên mẫu tem đã tồn tại"
                    sttLabel.ForeColor = Color.Red
                    txtTemLabel.Focus()
                    Me.ShowHide(False)
                    Return
                Else
                    sttLabel.Text = "Hãy nhập các tham số của khổ tem và thiết lập các thông tin cần in"
                    sttLabel.ForeColor = Color.Black
                    Me.ShowHide(True)
                End If
            Else
                sttLabel.Text = "Tên mẫu tem không được để trống"
                sttLabel.ForeColor = Color.Red
                Me.ShowHide(False)
                txtTemLabel.Focus()
                Return
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class