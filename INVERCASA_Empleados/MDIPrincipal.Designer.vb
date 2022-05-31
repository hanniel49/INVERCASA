<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MSOpciones = New System.Windows.Forms.MenuStrip()
        Me.tsmCatalogo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmVacaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsiEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MSOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(138, 461)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(697, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'MSOpciones
        '
        Me.MSOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.MSOpciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.MSOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCatalogo, Me.tsmVacaciones})
        Me.MSOpciones.Location = New System.Drawing.Point(0, 0)
        Me.MSOpciones.Name = "MSOpciones"
        Me.MSOpciones.Size = New System.Drawing.Size(138, 483)
        Me.MSOpciones.TabIndex = 9
        Me.MSOpciones.Text = "MenuStrip1"
        '
        'tsmCatalogo
        '
        Me.tsmCatalogo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiEmpleados})
        Me.tsmCatalogo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmCatalogo.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.tsmCatalogo.Image = CType(resources.GetObject("tsmCatalogo.Image"), System.Drawing.Image)
        Me.tsmCatalogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmCatalogo.Name = "tsmCatalogo"
        Me.tsmCatalogo.Size = New System.Drawing.Size(125, 36)
        Me.tsmCatalogo.Text = "CATALOGOS"
        '
        'tsmVacaciones
        '
        Me.tsmVacaciones.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmVacaciones.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.tsmVacaciones.Image = CType(resources.GetObject("tsmVacaciones.Image"), System.Drawing.Image)
        Me.tsmVacaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsmVacaciones.Name = "tsmVacaciones"
        Me.tsmVacaciones.Size = New System.Drawing.Size(125, 36)
        Me.tsmVacaciones.Text = "VACACIONES"
        '
        'tsiEmpleados
        '
        Me.tsiEmpleados.Image = CType(resources.GetObject("tsiEmpleados.Image"), System.Drawing.Image)
        Me.tsiEmpleados.Name = "tsiEmpleados"
        Me.tsiEmpleados.Size = New System.Drawing.Size(180, 22)
        Me.tsiEmpleados.Text = "Empleados"
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(835, 483)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MSOpciones)
        Me.IsMdiContainer = True
        Me.Name = "MDIPrincipal"
        Me.Text = "MDIPrincipal"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MSOpciones.ResumeLayout(False)
        Me.MSOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MSOpciones As MenuStrip
    Friend WithEvents tsmCatalogo As ToolStripMenuItem
    Friend WithEvents tsmVacaciones As ToolStripMenuItem
    Friend WithEvents tsiEmpleados As ToolStripMenuItem
End Class
