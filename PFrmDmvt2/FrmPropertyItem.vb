Imports hg3.hg3
Imports Microsoft.VisualBasic.CompilerServices
Public Class ctrProperty
    Dim oOptions As Collection
    Public Sub New(ByVal pOption As Collection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.oOptions = pOption
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub ctrProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshControl(Me.Controls.GetEnumerator)
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
    Public Sub DataBind(ByRef ds As DataTable)
        txtT.DataBindings.Add("Value", ds, "top0")
        txtL.DataBindings.Add("Value", ds, "left0")
        TxtS.DataBindings.Add("Value", ds, "size")
        TxtA.DataBindings.Add("Value", ds, "angle")
        cboC.DataBindings.Add("Checked", ds, "enable")
        cboR.DataBindings.Add("Checked", ds, "enable2")
        TxtY.DataBindings.Add("Value", ds, "Y")
        TxtX.DataBindings.Add("Value", ds, "X")
        txtValue.DataBindings.Add("Text", ds, "value")
        cboB.DataBindings.Add("Checked", ds, "enable3")
    End Sub
End Class
