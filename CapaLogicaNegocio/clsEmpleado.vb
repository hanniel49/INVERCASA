Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports CapaEnlaceDatos
Public Class clsEmpleado

    Private M As clsManejador = New clsManejador()
    Private m_IdEmp As Integer
    Private m_Nombre As String
    Private m_TipoDni As String
    Private m_Dni As String
    Private m_FechaIngreso As Date
    Private m_SalarioBase As Double
    Private m_Direccion As String

    Public Property Dni As String
        Get
            Return m_Dni
        End Get
        Set(ByVal value As String)
            m_Dni = value
        End Set
    End Property


    Public Property Nombres As String
        Get
            Return m_Nombre
        End Get
        Set(ByVal value As String)
            m_Nombre = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return m_Direccion
        End Get
        Set(ByVal value As String)
            m_Direccion = value
        End Set
    End Property

    Public Function Listado() As DataTable
        Return M.Listado("ListarEmpleados", Nothing)
    End Function

    Public Function BuscarEmpleado(ByVal objDatos As String) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim lst As List(Of clsParametro) = New List(Of clsParametro)()
        lst.Add(New clsParametro("@Datos", objDatos))
        Return M.Listado("FiltrarDatosCliente", lst)
    End Function

    Public Function RegistrarEmpleado() As String
        Dim lst As List(Of clsParametro) = New List(Of clsParametro)()
        Dim Mensaje As String = ""

        Try
            lst.Add(New clsParametro("@Nombres", m_Nombre))
            lst.Add(New clsParametro("@TipoDni", m_TipoDni))
            lst.Add(New clsParametro("@Dni", m_Dni))
            lst.Add(New clsParametro("@FechaIngreso", m_FechaIngreso))
            lst.Add(New clsParametro("@SalarioBase", m_SalarioBase))
            lst.Add(New clsParametro("@Direccion", m_Direccion))
            lst.Add(New clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50))
            M.EjecutarSP("RegistrarCliente", lst)
            Mensaje = lst(5).Valor.ToString()
        Catch ex As Exception
            Throw ex
        End Try

        Return Mensaje
    End Function

    Public Function ActualizarEmpleado() As String
        Dim lst As List(Of clsParametro) = New List(Of clsParametro)()
        Dim Mensaje As String = ""

        Try
            lst.Add(New clsParametro("@IdEmpleado", m_IdEmp))
            lst.Add(New clsParametro("@Nombres", m_Nombre))
            lst.Add(New clsParametro("@TipoDni", m_TipoDni))
            lst.Add(New clsParametro("@Dni", m_Dni))
            lst.Add(New clsParametro("@FechaIngreso", m_FechaIngreso))
            lst.Add(New clsParametro("@SalarioBase", m_SalarioBase))
            lst.Add(New clsParametro("@Direccion", m_Direccion))
            lst.Add(New clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50))
            M.EjecutarSP("ActualizarCliente", lst)
            Mensaje = lst(5).Valor.ToString()
        Catch ex As Exception
            Throw ex
        End Try

        Return Mensaje
    End Function

    Public Function EliminarCliente() As String
        Dim lst As List(Of clsParametro) = New List(Of clsParametro)()
        Dim Mensaje As String = ""

        Try
            lst.Add(New clsParametro("@IdEmpleado", m_IdEmp))
            lst.Add(New clsParametro("@Nombres", m_Nombre))
            lst.Add(New clsParametro("@TipoDni", m_TipoDni))
            lst.Add(New clsParametro("@Dni", m_Dni))
            lst.Add(New clsParametro("@FechaIngreso", m_FechaIngreso))
            lst.Add(New clsParametro("@SalarioBase", m_SalarioBase))
            lst.Add(New clsParametro("@Direccion", m_Direccion))
            lst.Add(New clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50))
            M.EjecutarSP("ActualizarCliente", lst)
            Mensaje = lst(5).Valor.ToString()
        Catch ex As Exception
            Throw ex
        End Try

        Return Mensaje
    End Function

End Class
