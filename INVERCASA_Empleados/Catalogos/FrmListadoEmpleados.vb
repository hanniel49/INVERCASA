Imports CapaLogicaNegocio
Public Class FrmListadoEmpleados

    Private Emp As clsEmpleado = New clsEmpleado
    Private Sub FrmListadoEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarEmpleados()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim FrmE As FrmRegistroEmpleados = New FrmRegistroEmpleados(0)
            FrmE.ShowDialog()

            listarEmpleados()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub listarEmpleados()
        Dim dt As DataTable = New DataTable()
        dt = Emp.Listado()

        Try
            dgvEmpleados.Rows.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1
                dgvEmpleados.Rows.Add(dt.Rows(i)(0))
                dgvEmpleados.Rows(i).Cells(0).Value = dt.Rows(i)(0).ToString()
                dgvEmpleados.Rows(i).Cells(1).Value = dt.Rows(i)(1).ToString()
                dgvEmpleados.Rows(i).Cells(2).Value = dt.Rows(i)(2).ToString()
                dgvEmpleados.Rows(i).Cells(3).Value = dt.Rows(i)(3).ToString()
                dgvEmpleados.Rows(i).Cells(4).Value = dt.Rows(i)(4).ToString()
                dgvEmpleados.Rows(i).Cells(5).Value = dt.Rows(i)(5).ToString()
                dgvEmpleados.Rows(i).Cells(6).Value = dt.Rows(i)(6).ToString()

            Next

            dgvEmpleados.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If dgvEmpleados.SelectedRows.Count > 0 Then
                Dim FrmE As FrmRegistroEmpleados = New FrmRegistroEmpleados(1)
                FrmE.txtId.Text = dgvEmpleados.CurrentRow.Cells(0).Value.ToString()
                FrmE.txtNombre.Text = dgvEmpleados.CurrentRow.Cells(1).Value.ToString()
                FrmE.cbTipoDni.Text = dgvEmpleados.CurrentRow.Cells(2).Value.ToString()
                FrmE.txtIdentificacion.Text = dgvEmpleados.CurrentRow.Cells(3).Value.ToString()
                FrmE.dtpFechaIngreso.Text = dgvEmpleados.CurrentRow.Cells(4).Value.ToString()
                FrmE.txtSalarioBase.Text = dgvEmpleados.CurrentRow.Cells(5).Value.ToString()
                FrmE.txtDireccion.Text = dgvEmpleados.CurrentRow.Cells(6).Value.ToString()
                FrmE.txtNombre.Focus()
                FrmE.Show()

                'If dgvEmpleados.SelectedRows.Count > 0 Then
                '    Program.Evento = 1
                'Else
                '    Program.Evento = 0
                'End If

                dgvEmpleados.ClearSelection()
            Else
                MessageBox.Show("Por Favor Seleccione la Fila a Editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If

            listarEmpleados()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvEmpleados.SelectedRows.Count > 0 Then
                Emp.IdEmpleado = dgvEmpleados.CurrentRow.Cells(0).Value.ToString()
                MessageBox.Show(Emp.EliminarEmpleado(), "INVERCASA.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class