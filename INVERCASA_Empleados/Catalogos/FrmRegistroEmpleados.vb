Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Imports CapaLogicaNegocio

Public Class FrmRegistroEmpleados

    Private Emp As clsEmpleado = New clsEmpleado

    'Variable para indicar Inserta nuevo registro o Actualizar
    '0 Inserta / 1 Actualiza
    Dim accion As Integer
    Sub New(ByVal var As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        accion = var
    End Sub





    Private Sub FrmRegistroEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If accion = 0 Then
        txtNombre.Focus()
        'Else
        '    cargarEmpleado()
        ' End If
    End Sub

    Private Sub cargarEmpleado()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If accion = 0 Then
            Emp.Nombres = txtNombre.Text
            Emp.TipoDni = cbTipoDni.Text
            Emp.Dni = txtIdentificacion.Text
            Emp.FechaIngreso = dtpFechaIngreso.Text
            Emp.SalarioBase = txtSalarioBase.Text
            Emp.Direccion = txtDireccion.Text
            MessageBox.Show(Emp.RegistrarEmpleado(), "INVERCASA.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar()
        Else
            Emp.IdEmpleado = txtId.Text
            Emp.Nombres = txtNombre.Text
            Emp.TipoDni = cbTipoDni.Text
            Emp.Dni = txtIdentificacion.Text
            Emp.FechaIngreso = dtpFechaIngreso.Text
            Emp.SalarioBase = txtSalarioBase.Text
            Emp.Direccion = txtDireccion.Text
            MessageBox.Show(Emp.ActualizarEmpleado(), "INVERCASA.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar()
        End If
    End Sub

    Private Sub Limpiar()
        txtId.Text = ""
        txtNombre.Text = ""
        cbTipoDni.SelectedIndex = 0
        txtIdentificacion.Text = ""
        dtpFechaIngreso.Value = Date.Today
        txtSalarioBase.Text = ""
        txtDireccion.Text = ""
    End Sub
End Class