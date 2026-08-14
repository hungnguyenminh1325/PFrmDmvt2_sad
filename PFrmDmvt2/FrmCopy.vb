Public Class FrmCopy
    Dim _Option As Collection
    Dim _ctr As ctrItem
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal oOptions As Collection, ByVal ctr As ctrItem)
        ' This call is required by the Windows Form Designer.
        _Option = oOptions
        _ctr = ctr
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub FrmCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        txtCopy.Format = Me._Option(txtCopy.Format)
        txtCopy.Value = 0
        txtCopy.Focus()
        txtCopy.SelectAll()
    End Sub
    ''Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    ''    _ctr.copyAction(txtCopy.Text)
    ''    Me.Dispose()
    ''    Me.Close()
    ''End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class
