Imports System.Data.Entity
Imports MySql.Data.MySqlClient

Public Class MyDbContext
    Inherits DbContext
    Public Property Users As DbSet(Of User)
    Public Sub New(nameOrConnectionString As String)
        MyBase.New(nameOrConnectionString)
    End Sub

End Class