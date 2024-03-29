﻿Imports System
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

    Public Property IdEmpleado As String
        Get
            Return m_IdEmp
        End Get
        Set(ByVal value As String)
            m_IdEmp = value
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

    Public Property TipoDni As String
        Get
            Return m_TipoDni
        End Get
        Set(ByVal value As String)
            m_TipoDni = value
        End Set
    End Property

    Public Property Dni As String
        Get
            Return m_Dni
        End Get
        Set(ByVal value As String)
            m_Dni = value
        End Set
    End Property

    Public Property FechaIngreso As String
        Get
            Return m_FechaIngreso
        End Get
        Set(ByVal value As String)
            m_FechaIngreso = value
        End Set
    End Property

    Public Property SalarioBase As String
        Get
            Return m_SalarioBase
        End Get
        Set(ByVal value As String)
            m_SalarioBase = value
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
            lst.Add(New clsParametro("@TIPO_DNI", m_TipoDni))
            lst.Add(New clsParametro("@DNI", m_Dni))
            lst.Add(New clsParametro("@FECHA_INGRESO", m_FechaIngreso))
            lst.Add(New clsParametro("@SALARIO_BASE", m_SalarioBase))
            lst.Add(New clsParametro("@DIRECCION", m_Direccion))
            lst.Add(New clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50))
            M.EjecutarSP("RegistrarEmpleado", lst)
            Mensaje = lst(6).Valor.ToString()
        Catch ex As Exception
            Throw ex
        End Try

        Return Mensaje
    End Function

    Public Function ActualizarEmpleado() As String
        Dim lst As List(Of clsParametro) = New List(Of clsParametro)()
        Dim Mensaje As String = ""

        Try
            lst.Add(New clsParametro("@ID_EMPLEADO", m_IdEmp))
            lst.Add(New clsParametro("@Nombres", m_Nombre))
            lst.Add(New clsParametro("@TIPO_DNI", m_TipoDni))
            lst.Add(New clsParametro("@Dni", m_Dni))
            lst.Add(New clsParametro("@Fecha_Ingreso", m_FechaIngreso))
            lst.Add(New clsParametro("@Salario_Base", m_SalarioBase))
            lst.Add(New clsParametro("@Direccion", m_Direccion))
            lst.Add(New clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50))
            M.EjecutarSP("ActualizarEmpleado", lst)
            Mensaje = lst(7).Valor.ToString()
        Catch ex As Exception
            Throw ex
        End Try

        Return Mensaje
    End Function

    Public Function EliminarEmpleado() As String
        Dim lst As List(Of clsParametro) = New List(Of clsParametro)()
        Dim Mensaje As String = ""

        Try
            lst.Add(New clsParametro("@Id_Empleado", m_IdEmp))
            lst.Add(New clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50))
            M.EjecutarSP("EliminarEmpleado", lst)
            Mensaje = lst(1).Valor.ToString()
        Catch ex As Exception
            Throw ex
        End Try

        Return Mensaje
    End Function

End Class
