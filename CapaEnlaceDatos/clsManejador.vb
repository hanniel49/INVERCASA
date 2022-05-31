Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient

Public Class clsManejador
    Public conexion As SqlConnection = New SqlConnection("Server=.;DataBase=PruebaINVERCASA;Integrated Security=SSPI")

    Public Sub Conectar()
        If conexion.State = ConnectionState.Closed Then conexion.Open()
    End Sub

    Public Sub Desconectar()
        If conexion.State = ConnectionState.Open Then conexion.Close()
    End Sub

    Public Function Listado(ByVal NombreSP As String, ByVal lst As List(Of clsParametro)) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim da As SqlDataAdapter

        Try
            Conectar()
            da = New SqlDataAdapter(NombreSP, conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            If lst IsNot Nothing Then

                For i As Integer = 0 To lst.Count - 1
                    da.SelectCommand.Parameters.AddWithValue(lst(i).Nombre, lst(i).Valor)
                Next
            End If

            da.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Desconectar()
        Return dt
    End Function

    Public Sub EjecutarSP(ByVal NombreSP As String, ByRef lst As List(Of clsParametro))
        Dim cmd As SqlCommand

        Try
            Conectar()
            cmd = New SqlCommand(NombreSP, conexion)
            cmd.CommandType = CommandType.StoredProcedure

            If lst IsNot Nothing Then

                For i As Integer = 0 To lst.Count - 1
                    If lst(i).Direccion = ParameterDirection.Input Then cmd.Parameters.AddWithValue(lst(i).Nombre, lst(i).Valor)
                    If lst(i).Direccion = ParameterDirection.Output Then cmd.Parameters.Add(lst(i).Nombre, lst(i).TipoDato, lst(i).Tamaño).Direction = ParameterDirection.Output
                Next

                cmd.ExecuteNonQuery()

                For i As Integer = 0 To lst.Count - 1
                    If cmd.Parameters(i).Direction = ParameterDirection.Output Then lst(i).Valor = cmd.Parameters(i).Value
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Desconectar()
    End Sub
End Class

