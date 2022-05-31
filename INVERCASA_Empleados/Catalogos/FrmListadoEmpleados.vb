Imports CapaLogicaNegocio
Public Class FrmListadoEmpleados

    Private E As clsEmpleado = New clsEmpleado
    Private Sub FrmListadoEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarEmpleados()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try

            FrmRegistroEmpleados.ShowDialog()

            listarEmpleados()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub listarEmpleados()
        Dim dt As DataTable = New DataTable()
        dt = E.Listado()

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
End Class