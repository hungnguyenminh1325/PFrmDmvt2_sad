Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Imports hg3.hg3

Namespace Globalvar

    'Lớp chứa các biến dùng chung trong hệ thống
    Public Class AppVariable
        Public Shared UserID As String
        Public Shared UserName As String
        Public Shared khoID As String
        Public Shared AuthorizationGroupID As String
        Public Shared dtPermissionUser As DataTable

        'Khởi tạo các tham số của tài khoản strUserID nếu Login thành công
        Public Shared Function InitLogin(ByVal strUserID As String, ByVal toConnSQL As SqlConnection) As Boolean
            Try
                Dim ds As DataSet = New DataSet()
                Dim dt As DataTable = New DataTable()

                UserID = strUserID
                sql.SQLRetrieve(toConnSQL, "SELECT *, AuthorizationGroupID AS AUTHORID FROM USERINFO WHERE USERID ='" & UserID & "'", "USERINFO", ds)
                dt = ds.Tables("USERINFO").Copy()
                UserName = dt.Rows(0)("USERNAME").ToString()
                khoID = dt.Rows(0)("m_khoid_hdt").ToString()
                AuthorizationGroupID = dt.Rows(0)("AUTHORID").ToString()
                sql.SQLRetrieve(toConnSQL, "SELECT * FROM PERMISSION WHERE USERID ='" & UserID & "'", "PERMISSION", ds)
                dtPermissionUser = ds.Tables("PERMISSION").Copy()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        'Kiểm tra 1 quyền cụ thể của một user
        Public Shared Function CheckUserPermission(ByVal UserID As String, ByVal strAuthorizationID As String) As Boolean
            Dim dr As DataRow()
            dr = dtPermissionUser.Select("UserID = '" & UserID & "' AND AuthorizationID = '" & strAuthorizationID & "'")
            If (dr.Length < 1) Then
                Return False
            Else
                If (dr(0).Item("VAL").ToString() = "1") Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function
    End Class

    Public Class AppFunction
        Public Shared Function Encrypt(ByVal sEncrypt As String, ByVal sKey As String) As String
            Try
                Dim arrKey() As Byte
                Dim arrEncrypt() As Byte = UTF8Encoding.UTF8.GetBytes(sEncrypt)
                Dim obj_Md5_Service As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                arrKey = obj_Md5_Service.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey))
                Dim TdCP As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                TdCP.Key = arrKey
                TdCP.Mode = CipherMode.ECB
                TdCP.Padding = PaddingMode.PKCS7
                Dim cTransform As ICryptoTransform = TdCP.CreateEncryptor()
                Dim arrResult() As Byte = cTransform.TransformFinalBlock(arrEncrypt, 0, arrEncrypt.Length)
                Return Convert.ToBase64String(arrResult, 0, arrResult.Length)
            Catch ex As System.Security.Cryptography.CryptographicException
                Throw (New System.Exception(ex.Message, ex.InnerException))
            End Try
        End Function

        Public Shared Function Decrypt(ByVal sDecrypt As String, ByVal sKey As String) As String
            Try
                Dim arrKey() As Byte
                Dim arrEncrypt() As Byte = Convert.FromBase64String(sDecrypt)
                Dim obj_Md5_Service As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
                arrKey = obj_Md5_Service.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey))
                Dim TdCP As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                TdCP.Key = arrKey
                TdCP.Mode = CipherMode.ECB
                TdCP.Padding = PaddingMode.PKCS7
                Dim cTransform As ICryptoTransform = TdCP.CreateDecryptor()
                Dim arrResult() As Byte = cTransform.TransformFinalBlock(arrEncrypt, 0, arrEncrypt.Length)
                Return UTF8Encoding.UTF8.GetString(arrResult)
            Catch ex As System.Security.Cryptography.CryptographicException
                Throw (New System.Exception(ex.Message, ex.InnerException))
            End Try
        End Function
    End Class
End Namespace
