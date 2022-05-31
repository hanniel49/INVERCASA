Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient


Public Class clsParametro
    Private m_Nombre As String
    Private m_Valor As Object
    Private m_TipoDato As SqlDbType
    Private m_Direccion As ParameterDirection
    Private m_Tamaño As Integer

    Public Property Nombre As String
        Get
            Return m_Nombre
        End Get
        Set(ByVal value As String)
            m_Nombre = value
        End Set
    End Property

    Public Property Valor As Object
        Get
            Return m_Valor
        End Get
        Set(ByVal value As Object)
            m_Valor = value
        End Set
    End Property

    Public Property TipoDato As SqlDbType
        Get
            Return m_TipoDato
        End Get
        Set(ByVal value As SqlDbType)
            m_TipoDato = value
        End Set
    End Property

    Public Property Direccion As ParameterDirection
        Get
            Return m_Direccion
        End Get
        Set(ByVal value As ParameterDirection)
            m_Direccion = value
        End Set
    End Property

    Public Property Tamaño As Integer
        Get
            Return m_Tamaño
        End Get
        Set(ByVal value As Integer)
            m_Tamaño = value
        End Set
    End Property

    Public Sub New(ByVal objNombre As String, ByVal objValor As Object)
        m_Nombre = objNombre
        m_Valor = objValor
        m_Direccion = ParameterDirection.Input
    End Sub

    Public Sub New(ByVal objNombre As String, ByVal objValor As Object, ByVal objTipoDato As SqlDbType, ByVal objDireccion As ParameterDirection, ByVal objTamaño As Integer)
        m_Nombre = objNombre
        m_Valor = objValor
        m_TipoDato = objTipoDato
        m_Direccion = objDireccion
        m_Tamaño = objTamaño
    End Sub
End Class
