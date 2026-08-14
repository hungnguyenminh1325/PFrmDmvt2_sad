Imports System.Data.SqlClient

Public Class ForBackgroundRun
    Public appConn As SqlConnection
    Public thueConn As SqlConnection

    Public Sub New(ByVal appConnection As SqlConnection, ByVal thueConnection As SqlConnection)
        appConn = appConnection
        thueConn = thueConnection
    End Sub
End Class
