Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.DBNull
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports hg3.hg3
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Imports PFrmPND
Public Class FrmGroup
    Dim oOptions As Collection
    Dim oVar As Collection
    Dim sysConn As SQLiteConnection
    Dim appConn As SqlConnection
    Dim g_Table As String
    Dim g_Title As String
    'Dim cBaseTable As String
    Dim g_keyfield As String
    Dim g_groupfield As String
    Dim g_groupnamefield As String
    Dim g_dt As DataTable
    Dim cAction As String
    Dim g_ds1 As DataSet
    Dim g_node As TreeNode
    Private thueSqlConn As SqlConnection
    Private forBackgroundRun As ForBackgroundRun

    Public Sub New(ByVal scnn As SQLiteConnection, ByVal acnn As SqlConnection, ByVal oOoption As Collection, ByVal oovar As Collection, ByVal table As String, ByVal title As String, ByVal keyfield As String, ByVal groupfield As String, ByVal groupnamefield As String, ByVal ds As DataTable, ByVal action As String, ByRef g_ds As DataSet, ByRef node As TreeNode)
        ' This call is required by the Windows Form Designer.

        sysConn = scnn
        appConn = acnn
        oOptions = oOoption
        oVar = oovar
        g_Table = table
        g_Title = title
        g_keyfield = keyfield
        g_groupnamefield = groupnamefield
        g_dt = ds
        cAction = action
        g_groupfield = groupfield
        g_ds1 = g_ds
        g_node = node
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub FrmGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetValue()
        ''Dim i As Integer = 9
        ''i = i / 0
        '' msg.Alert(j.ToString)
        Me.RefreshControl(Me.Controls.GetEnumerator)
        Dim obj1 As New Dirlib.CharLib(Me.txtStatus, "0, 1")
        Dim text1 As String = "1=1"
        Dim lib1 As New Dirlib.DirLib(Me.txtNhvt2ID_me, Me.lblNhvt2ID_me_name, Me.sysConn, Me.appConn, "dmnhvt2", "Nhvt2ID", "Nhvt2Name", "Itemgroup", text1, True, Me.cmdCancel, "Nhvt2ID || NHvt2Name")
        Dim lib2 As New Dirlib.DirLib(Me.txtFK_QttgID, Me.lblQttgName, Me.sysConn, Me.appConn, "Dmqttg", "QttgID", "QttgName", "PriceRuler", text1, True, Me.cmdCancel, "QttgID + QttgName")
        Dim lib3 As New Dirlib.DirLib(Me.txtFk_qttgID1, Me.lblQttgName1, Me.sysConn, Me.appConn, "Dmqttg", "QttgID", "QttgName", "PriceRuler", text1, True, Me.cmdCancel, "QttgID + QttgName")
        Dim lib4 As New Dirlib.DirLib(Me.txtFk_qttgID2, Me.lblQttgName2, Me.sysConn, Me.appConn, "Dmqttg", "QttgID", "QttgName", "PriceRuler", text1, True, Me.cmdCancel, "QttgID + QttgName")
    End Sub
    Private Sub SetValue()
        Me.Text = g_Title
        If cAction.ToLower = "new" Then
            g_dt.Rows(0)(g_groupfield) = g_dt.Rows(0)(g_keyfield)
            g_dt.Rows(0)("Status") = 1
            g_dt.Rows(0)("User_id0") = oVar("CurrUserID")
            g_dt.Rows(0)("User_id2") = oVar("CurrUserID")
            g_dt.Rows(0)("Datetime0") = DateTime.Now
            g_dt.Rows(0)("Datetime2") = DateTime.Now
            g_dt.Rows(0)("FK_DvkdID") = oVar("DvkdID")
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
                        box1.DataBindings.Add("Text", g_dt, Strings.Mid(box1.Name, 4, box1.Name.Length))
                        If (Not box1.Multiline) Then
                            AddHandler control1.KeyPress, New KeyPressEventHandler(AddressOf txtKeyPressEnter)
                        End If
                        If Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = g_groupfield.ToLower Then
                            box1.Enabled = False
                        End If
                        If cAction.ToLower = "new" And Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = g_keyfield.ToLower Then
                            box1.Text = ""
                            g_dt.Rows(0)(g_keyfield) = ""
                        End If
                        If cAction.ToLower = "edit" And Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = g_keyfield.ToLower Then
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
                        box1.DataBindings.Add("Checked", g_dt, Strings.Mid(box1.Name, 4, box1.Name.Length))
                    End If
                    If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "N", False) = 0) Then
                        Dim box1 As txtNumeric = CType(control1, txtNumeric)
                        box1 = CType(control1, txtNumeric)
                        box1.Format = Me.oOptions.Item(box1.Format.ToString)
                        box1.DataBindings.Add("Value", g_dt, Strings.Mid(box1.Name, 4, box1.Name.Length))
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
            Me.BindingContext(g_dt).EndCurrentEdit()
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
    Private Sub BindingData(ByVal IE As IEnumerator)
        Dim control1 As Control
        Dim enumerator1 As IEnumerator
        'Try
        enumerator1 = IE
        Do While enumerator1.MoveNext
            control1 = CType(enumerator1.Current, Control)
            If (StringType.StrCmp(Strings.Left(StringType.FromObject(control1.Tag), 1), "F", False) = 0) Then
                Dim obj1 As Object = Strings.Right(control1.Name, (control1.Name.Length - 3))
                If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "C", False) = 0) Then
                    Dim box1 As TextBox = CType(control1, TextBox)
                    box1 = CType(control1, TextBox)
                End If
                If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "N", False) = 0) Then
                    Dim box1 As txtNumeric = CType(control1, txtNumeric)
                    box1 = CType(control1, txtNumeric)
                End If
                If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "R", False) = 0) Then
                    Dim box1 As RadioButton = CType(control1, RadioButton)
                    box1 = CType(control1, RadioButton)
                End If
            End If
        Loop

        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If _check() Then
            Return
        End If
        Me.BindingContext(g_dt).EndCurrentEdit()
        If cAction.ToLower = "new" Then
            g_dt.Rows(0)(g_keyfield) = g_dt.Rows(0)(g_groupfield) + g_dt.Rows(0)(g_keyfield)
            If Not Information.IsDBNull(g_dt.Rows(0)("imagepath")) Then
                If File.Exists(g_dt.Rows(0)("imagepath")) Then
                    Dim path As String = ""
                    Dim f As New FileInfo(g_dt.Rows(0)("imagepath"))
                    If Strings.Replace(f.FullName, f.Name, "").ToLower <> Me.oVar("groupDir").ToString.ToLower Then
                        path = Me.oVar("groupDir").ToString.ToLower + g_dt.Rows(0)(g_keyfield).ToString + ".jpg"
                        If File.Exists(path) Then
                            File.Delete(path)
                        End If
                        f.CopyTo(path)
                    Else
                        path = Strings.Replace(g_dt.Rows(0)("imagepath"), f.Name, g_dt.Rows(0)(g_keyfield).ToString) + ".jpg"
                        Dim path2 As String = ""
                        path2 = Strings.Replace(g_dt.Rows(0)("imagepath"), f.Name, g_dt.Rows(0)(g_keyfield).ToString) + "_2.jpg"
                        Dim f2 As New FileInfo(path2)
                        If File.Exists(path) Then
                            f.CopyTo(path2)
                            File.Delete(path)
                            f2.CopyTo(path)
                            File.Delete(path2)
                        Else : f.CopyTo(path)
                        End If
                    End If
                    g_dt.Rows(0)("imagepath") = path
                End If
            End If
            ''
            g_dt.Rows(0)("Nhvt2ID") = g_dt.Rows(0)("Nhvt2ID").ToString.Trim
            sql.SQLInsert(Me.appConn, g_Table, g_dt.Rows(0))
        Else
            For Each drr As DataRow In g_ds1.Tables(0).Rows
                If drr(g_keyfield).ToString.ToLower = g_dt.Rows(0)(g_keyfield).ToString.ToLower Then
                    g_ds1.Tables(0).Rows.Remove(drr)
                    Exit For
                End If
            Next
            'If Not Information.IsDBNull(g_dt.Rows(0)("imagepath")) Then
            '    If File.Exists(g_dt.Rows(0)("imagepath")) Then
            '        Dim path As String = ""
            '        Dim f As New FileInfo(g_dt.Rows(0)("imagepath"))
            '        If Strings.Replace(f.FullName, f.Name, "").ToLower <> Me.oVar("groupDir").ToString.ToLower Then
            '            path = Me.oVar("groupDir").ToString.ToLower + g_dt.Rows(0)(g_keyfield).ToString + ".jpg"
            '            If File.Exists(path) Then
            '                File.Delete(path)
            '            End If
            '            f.CopyTo(path)
            '        Else
            '            path = Strings.Replace(g_dt.Rows(0)("imagepath"), f.Name, g_dt.Rows(0)(g_keyfield).ToString) + ".jpg"
            '            Dim path2 As String = ""
            '            path2 = Strings.Replace(g_dt.Rows(0)("imagepath"), f.Name, g_dt.Rows(0)(g_keyfield).ToString) + "_2.jpg"
            '            Dim f2 As New FileInfo(path2)
            '            If File.Exists(path) Then
            '                f.CopyTo(path2)
            '                File.Delete(path)
            '                f2.CopyTo(path)
            '                File.Delete(path2)
            '            Else : f.CopyTo(path)
            '            End If
            '           End If
            '        g_dt.Rows(0)("imagepath") = path
            '    End If
            'End If
            g_dt.Rows(0)("Nhvt2ID") = g_dt.Rows(0)("Nhvt2ID").ToString.Trim
            sql.SQLUpdate(Me.appConn, g_Table, g_dt.Rows(0), g_keyfield + "='" + g_dt.Rows(0)(g_keyfield) + "'")
        End If

        Dim dr As DataRow = g_ds1.Tables(0).NewRow
        For Each dc As DataColumn In g_dt.Columns
            dr(dc.ColumnName) = g_dt.Rows(0)(dc.ColumnName)
        Next
        g_ds1.Tables(0).Rows.Add(dr)
        If cAction.ToLower = "new" Then
            Dim tn As New TreeNode
            tn.Text = g_dt.Rows(0)(g_groupnamefield).ToString()
            tn.Tag = g_dt.Rows(0)(g_keyfield).ToString()
            g_node.Nodes.Add(tn)
        Else
            g_node.Text = g_dt.Rows(0)(g_groupnamefield).ToString()
        End If
        Me.Dispose()
        Me.Close()
    End Sub
    Function _check() As Boolean
        Dim control1 As Control
        Dim enumerator1 As IEnumerator
        'Try
        enumerator1 = Me.Controls.GetEnumerator
        Do While enumerator1.MoveNext
            control1 = CType(enumerator1.Current, Control)
            If (StringType.StrCmp(Strings.Left(StringType.FromObject(control1.Tag), 4), "FCNB", False) = 0) Then
                'Dim obj1 As Object = Strings.Right(control1.Name, (control1.Name.Length - 3))
                'If (StringType.StrCmp(Strings.Mid(StringType.FromObject(control1.Tag), 2, 1), "NB", False) = 0) Then
                Dim box1 As TextBox = CType(control1, TextBox)
                box1 = CType(control1, TextBox)
                If box1.Text = "" Then
                    msg.Alert("Trường dữ liệu không được để trống!")
                    box1.Focus()
                    Return True
                End If
                'msg.Alert(Strings.Right(box1.Name, box1.Name.Length - 3).ToLower)
                If Strings.Right(box1.Name, box1.Name.Length - 3).ToLower = g_keyfield.ToLower And cAction.ToLower = "new" Then
                    Dim dsTest As New DataSet
                    ''  Dim cmText As String = "SELECT * FROM " & g_Table & " WHERE " & g_keyfield & "='" & box1.Text & "'"
                    Dim cmText As String = "SELECT * FROM " & g_Table & " WHERE " & g_keyfield & "='" & txtNhvt2ID_me.Text + box1.Text & "'"
                    sql.SQLRetrieve(Me.appConn, cmText, "TEST", dsTest)
                    If dsTest.Tables(0).Rows.Count > 0 Then
                        msg.Alert("Mã đã có hoặc trùng nhau!")
                        box1.Focus()
                        Return True
                    End If
                End If
            End If
            'End If
        Loop
        Return False
    End Function

    Private Sub lblStatusNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStatusNote.Click

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ''Me.Dispose()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImagePath.TextChanged
        If File.Exists(txtImagePath.Text) And (Strings.UCase(Strings.Right(txtImagePath.Text, 4)) = ".JPG" Or Strings.UCase(Strings.Right(txtImagePath.Text, 4)) = ".PNG") Then
            Try
                Dim fs As New FileStream(RuntimeHelpers.GetObjectValue(txtImagePath.Text), FileMode.Open)
                Dim img(fs.Length) As Byte
                fs.Read(img, 0, fs.Length)
                fs.Flush()
                Dim ms As New MemoryStream(img)
                PictureBox1.Image = Image.FromStream(ms)
                ms.Close()
                fs.Close()
            Catch
                PictureBox1.Image = Nothing
            End Try
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim f As New OpenFileDialog
            f.Filter = "All files (*.*)|*.*|Standard Image files (*.png)|*.png"
            f.ShowDialog()
            Me.txtImagePath.Text = f.FileName.Trim
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtImagePath.Text = ""
        Dim pathName As String = ""
        If txtNhvt2ID.Text <> "" Then
            pathName = txtNhvt2ID_me.Text + txtNhvt2ID.Text
        Else
            pathName = pathName = Strings.Right(DateTime.Now.Year.ToString, 2) + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute
        End If
        pathName = String.Format("{0}{1}.jpg", Me.oVar("groupDir"), pathName)
        Dim camera As New FrmCap(pathName)
        camera.ShowDialog()
        If File.Exists(pathName) Then
            txtImagePath.Text = pathName
        End If
    End Sub

    Private Sub btnBrown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrown.Click
        Try
            Dim f As New OpenFileDialog
            f.Filter = "All files (*.*)|*.*|Standard Image files (*.png)|*.png"
            f.ShowDialog()
            Me.txtImagePath.Text = f.FileName.Trim
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPick.Click
        txtImagePath.Text = ""
        Dim pathName As String = ""
        If txtNhvt2ID.Text <> "" Then
            pathName = txtNhvt2ID_me.Text + txtNhvt2ID.Text
        Else
            pathName = pathName = Strings.Right(DateTime.Now.Year.ToString, 2) + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute
        End If
        pathName = String.Format("{0}{1}.jpg", Me.oVar("groupDir"), pathName)
        Dim camera As New FrmCap(pathName)
        camera.ShowDialog()
        If File.Exists(pathName) Then
            txtImagePath.Text = pathName
        End If
    End Sub
End Class