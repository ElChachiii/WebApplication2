Imports System.Web.Http
Imports System.Web.Mvc
Imports MySql.Data

Namespace Controllers
    Public Class UsersController
        Inherits ApiController

        Private ReadOnly _dbContext As MyDbContext

        Public Sub New()
            _dbContext = New MyDbContext(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        End Sub

        ' GET api/users
        Public Function GetUsers() As IHttpActionResult
            Dim users = _dbContext.Users.ToList()
            Return Ok(users)
        End Function

        ' GET api/users/name
        Public Function GetUser(name As String, password As String) As IHttpActionResult
            Dim user = _dbContext.Users.SingleOrDefault(Function(u) u.Name = name)

            If user Is Nothing Then
                Dim msg = "Usuario es incorrecto"
                Return Ok(msg)
            Else
                If user.Name = name Then

                    If user.Password = password Then

                        Dim msg = "Login correcto!"
                        Return Ok(msg)

                    Else

                        Dim msg = "Contraseña incorrecta"
                        Return Ok(msg)

                    End If

                Else
                    Dim msg = "Nombre incorrecto"
                    Return Ok(msg)
                End If
            End If


        End Function

        ' POST api/users
        Public Function PostUser(user As User) As IHttpActionResult
            If Not ModelState.IsValid Then
                Dim msg = "Usuario incorrecto!"
                Return Ok(msg)

            Else

                _dbContext.Users.Add(user)
                _dbContext.SaveChanges()

                Dim msg = "Usuario creado!"
                Return Ok(msg)

            End If

        End Function

        ' POST /api/password
        Public Function ChangePassword(name As String, password As String) As IHttpActionResult

            Dim msg = "En desarrollo!"
            Return Ok(msg)


        End Function

        ' DELETE api/users/5
        Public Function DeleteUser(id As Integer) As IHttpActionResult
            Dim user = _dbContext.Users.SingleOrDefault(Function(u) u.Id = id)
            If user Is Nothing Then
                Return NotFound()
            End If
            _dbContext.Users.Remove(user)
            _dbContext.SaveChanges()

            Dim msg = "Usuario eliminado!"

            Return Ok(msg)
        End Function

    End Class

End Namespace
