Imports System.Data
Imports System.Data.OleDb
Imports System.Reflection
Imports System.Configuration


Public Class ClsAccesoBD
    Private _StrConexion As String 'Cadena de Conexion 
    Private _StrComandoInicial As String = "" 'Comando Inicial 
    Private _bconexion_directa As Boolean = False

    Private ConexionDirecta As OleDbConnection


#Region "Contructores"
    Sub New(ByVal CadenaConexion As String)
        _StrConexion = CadenaConexion
    End Sub
    'Contruccion de la clase automatica con el connectionString
    Sub New(ByVal CadenaConexion As String, ByVal StrEjecutaComandoInical As String)
        _StrConexion = CadenaConexion
        _StrComandoInicial = StrEjecutaComandoInical
    End Sub

    Sub New(ByVal CadenaConexion As String, ByVal bconexion_directa As Boolean)
        _StrConexion = CadenaConexion
        _bconexion_directa = bconexion_directa
        Try
            'Se abre la conexion mantenida
            ConexionDirecta = New OleDbConnection(_StrConexion)
            ConexionDirecta.Open()
        Catch ex As Exception
            MsgBox("No se puede abrir la conexion directa con la BD", MsgBoxStyle.Critical)
        End Try

    End Sub



#End Region

#Region "Propiedades"
    'Cadena de Conexion
    Public Property StrConexion As String
        Get
            StrConexion = _StrConexion
        End Get

        Set(ByVal value As String)
            _StrConexion = value
        End Set
    End Property

    'Comando Inicial al abrir la conexion
    Public Property StrComandoInical As String
        Get
            StrComandoInical = _StrComandoInicial
        End Get

        Set(ByVal value As String)
            _StrComandoInicial = value
        End Set
    End Property


#End Region

#Region "Procedimientos"
    Public Function CrearConexion(Optional ByVal StrConnectionString As String = "", Optional ByVal SComandoInicial As String = "") As OleDbConnection
        Try
            If StrConnectionString = "" Then StrConnectionString = _StrConexion
            If SComandoInicial = "" Then SComandoInicial = _StrComandoInicial

            '  Dim cnn As New OleDbConnection(StrConnectionString)
            Dim cnn As OleDbConnection


            If _bconexion_directa = True Then
                cnn = ConexionDirecta
            Else
                cnn = New OleDbConnection(StrConnectionString)
            End If


            Dim cmd As New OleDbCommand
            If cnn.State <> ConnectionState.Open Then
                cnn.Open()
            End If

            If SComandoInicial <> "" Then
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = SComandoInicial
                'cmd.CommandText = _StrComandoInicial
                cmd.Connection = cnn
                cmd.ExecuteNonQuery()
            End If
            Return cnn
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub CerrarConexion()

        If _bconexion_directa Then

            ConexionDirecta.Close()
            ConexionDirecta = Nothing
            _bconexion_directa = False
        End If


    End Sub

    Public Function GetDTable(ByVal StrSQL As String) As DataTable
        Try
            Dim dtRes As DataTable
            Dim daQry As OleDbDataAdapter
            daQry = New OleDbDataAdapter(StrSQL, CrearConexion())
            dtRes = New DataTable
            daQry.Fill(dtRes)
            daQry.Dispose()
            Return (dtRes)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function GetDReader(ByVal StrSQL As String) As OleDbDataReader
        Dim DR As OleDbDataReader
        Dim cmd As New OleDbCommand
        Try
            cmd.CommandType = 1
            cmd.CommandText = StrSQL
            cmd.Connection = CrearConexion()
            DR = cmd.ExecuteReader
            'cmd.Connection.Close()
            Return DR
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function ejecutaSQL(ByVal StrSQL As String) As Boolean
        Dim cmd As New OleDbCommand
        Try
            cmd.CommandType = 1
            cmd.CommandText = StrSQL
            cmd.Connection = CrearConexion()
            cmd.ExecuteNonQuery()
            If _bconexion_directa = False Then
                cmd.Connection.Close()
            End If
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function ejecutaSP(ByVal SPName As String, ByVal PEntrada() As OleDbParameter, ByRef PSalida() As OleDbParameter) As String
        Dim cmd As New OleDbCommand
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SPName
            cmd.Connection = CrearConexion()
            For i As Integer = 0 To UBound(PEntrada)
                cmd.Parameters.Add(PEntrada(i))
            Next i

            For j As Integer = 0 To UBound(PSalida)
                cmd.Parameters.Add(PSalida(j))
            Next j


            cmd.ExecuteNonQuery()
            'cmd.Parameters.CopyTo(PSalida, 0)
            If _bconexion_directa = False Then
                cmd.Connection.Close()
            End If

            Return cmd.Parameters(cmd.Parameters.Count - 1).Value.ToString
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function


    Public Function ejecutaSP(ByVal SPName As String, ByVal PEntrada() As OleDbParameter) As Boolean
        Dim cmd As New OleDbCommand
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SPName
            cmd.Connection = CrearConexion()
            For i As Integer = 0 To UBound(PEntrada)
                cmd.Parameters.Add(PEntrada(i))
            Next i
            cmd.ExecuteNonQuery()

            If _bconexion_directa = False Then
                cmd.Connection.Close()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function


    Public Function ExecuteScalar(ByVal StrSQL As String) As String
        Dim cmd As New OleDbCommand
        Dim resultado As String
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = StrSQL
            cmd.Connection = CrearConexion()
            resultado = cmd.ExecuteScalar()
            If _bconexion_directa = False Then
                cmd.Connection.Close()
            End If
            Return resultado
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
    Public Function VerificaPermiso(ByVal login As String, ByVal permiso As String) As Boolean
        Dim sqlquery As String = "SELECT CONTROLGANADERO.PKG_SEGURIDAD.FN_VERIFICA_ACCESO('" & UCase(login) & "','" & permiso & "') from dual"
        Dim cmd As New OleDbCommand
        Dim resultado As String
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sqlquery
            cmd.Connection = CrearConexion()
            resultado = cmd.ExecuteScalar()
            If _bconexion_directa = False Then
                cmd.Connection.Close()
            End If
            Return resultado
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region
End Class

