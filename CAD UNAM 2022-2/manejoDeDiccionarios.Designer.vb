<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManejoDeDiccionarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdministracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiccionarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarCamposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DimensionesDeCadaLadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÁreaYPerímetroDelPoligonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CálculoDelCentroideDelPoligonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtManzana = New System.Windows.Forms.TextBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.txtUso = New System.Windows.Forms.TextBox()
        Me.manzana = New System.Windows.Forms.Label()
        Me.predio = New System.Windows.Forms.Label()
        Me.uso = New System.Windows.Forms.Label()
        Me.datosPredio = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministracionToolStripMenuItem, Me.DiccionarioToolStripMenuItem, Me.DocumentarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministracionToolStripMenuItem
        '
        Me.AdministracionToolStripMenuItem.Name = "AdministracionToolStripMenuItem"
        Me.AdministracionToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.AdministracionToolStripMenuItem.Text = "Administracion"
        '
        'DiccionarioToolStripMenuItem
        '
        Me.DiccionarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarDatosToolStripMenuItem, Me.ConsultarDatosToolStripMenuItem, Me.LimpiarCamposToolStripMenuItem})
        Me.DiccionarioToolStripMenuItem.Name = "DiccionarioToolStripMenuItem"
        Me.DiccionarioToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.DiccionarioToolStripMenuItem.Text = "Diccionario"
        '
        'AgregarDatosToolStripMenuItem
        '
        Me.AgregarDatosToolStripMenuItem.Name = "AgregarDatosToolStripMenuItem"
        Me.AgregarDatosToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AgregarDatosToolStripMenuItem.Text = "Agregar Datos"
        '
        'ConsultarDatosToolStripMenuItem
        '
        Me.ConsultarDatosToolStripMenuItem.Name = "ConsultarDatosToolStripMenuItem"
        Me.ConsultarDatosToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ConsultarDatosToolStripMenuItem.Text = "Consultar Datos"
        '
        'LimpiarCamposToolStripMenuItem
        '
        Me.LimpiarCamposToolStripMenuItem.Name = "LimpiarCamposToolStripMenuItem"
        Me.LimpiarCamposToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.LimpiarCamposToolStripMenuItem.Text = "Limpiar campos"
        '
        'DocumentarToolStripMenuItem
        '
        Me.DocumentarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DimensionesDeCadaLadoToolStripMenuItem, Me.ÁreaYPerímetroDelPoligonalToolStripMenuItem, Me.CálculoDelCentroideDelPoligonalToolStripMenuItem, Me.ReporteToolStripMenuItem})
        Me.DocumentarToolStripMenuItem.Name = "DocumentarToolStripMenuItem"
        Me.DocumentarToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.DocumentarToolStripMenuItem.Text = "Documentar"
        '
        'DimensionesDeCadaLadoToolStripMenuItem
        '
        Me.DimensionesDeCadaLadoToolStripMenuItem.Name = "DimensionesDeCadaLadoToolStripMenuItem"
        Me.DimensionesDeCadaLadoToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.DimensionesDeCadaLadoToolStripMenuItem.Text = "Dimensiones de cada lado del lote"
        '
        'ÁreaYPerímetroDelPoligonalToolStripMenuItem
        '
        Me.ÁreaYPerímetroDelPoligonalToolStripMenuItem.Name = "ÁreaYPerímetroDelPoligonalToolStripMenuItem"
        Me.ÁreaYPerímetroDelPoligonalToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ÁreaYPerímetroDelPoligonalToolStripMenuItem.Text = "Área y perímetro del poligonal"
        '
        'CálculoDelCentroideDelPoligonalToolStripMenuItem
        '
        Me.CálculoDelCentroideDelPoligonalToolStripMenuItem.Name = "CálculoDelCentroideDelPoligonalToolStripMenuItem"
        Me.CálculoDelCentroideDelPoligonalToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.CálculoDelCentroideDelPoligonalToolStripMenuItem.Text = "Cálculo del centroide del poligonal"
        '
        'ReporteToolStripMenuItem
        '
        Me.ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem"
        Me.ReporteToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ReporteToolStripMenuItem.Text = "Reporte de colindancias"
        '
        'txtManzana
        '
        Me.txtManzana.Location = New System.Drawing.Point(119, 31)
        Me.txtManzana.Name = "txtManzana"
        Me.txtManzana.Size = New System.Drawing.Size(100, 20)
        Me.txtManzana.TabIndex = 1
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(119, 57)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(100, 20)
        Me.txtLote.TabIndex = 2
        '
        'txtUso
        '
        Me.txtUso.Location = New System.Drawing.Point(119, 86)
        Me.txtUso.Name = "txtUso"
        Me.txtUso.Size = New System.Drawing.Size(100, 20)
        Me.txtUso.TabIndex = 3
        '
        'manzana
        '
        Me.manzana.AutoSize = True
        Me.manzana.Location = New System.Drawing.Point(56, 31)
        Me.manzana.Name = "manzana"
        Me.manzana.Size = New System.Drawing.Size(51, 13)
        Me.manzana.TabIndex = 4
        Me.manzana.Text = "Manzana"
        '
        'predio
        '
        Me.predio.AutoSize = True
        Me.predio.Location = New System.Drawing.Point(56, 60)
        Me.predio.Name = "predio"
        Me.predio.Size = New System.Drawing.Size(28, 13)
        Me.predio.TabIndex = 5
        Me.predio.Text = "Lote"
        '
        'uso
        '
        Me.uso.AutoSize = True
        Me.uso.Location = New System.Drawing.Point(56, 89)
        Me.uso.Name = "uso"
        Me.uso.Size = New System.Drawing.Size(26, 13)
        Me.uso.TabIndex = 6
        Me.uso.Text = "Uso"
        '
        'datosPredio
        '
        Me.datosPredio.FormattingEnabled = True
        Me.datosPredio.Location = New System.Drawing.Point(50, 115)
        Me.datosPredio.Name = "datosPredio"
        Me.datosPredio.Size = New System.Drawing.Size(220, 95)
        Me.datosPredio.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.datosPredio)
        Me.GroupBox1.Controls.Add(Me.txtUso)
        Me.GroupBox1.Controls.Add(Me.txtManzana)
        Me.GroupBox1.Controls.Add(Me.predio)
        Me.GroupBox1.Controls.Add(Me.uso)
        Me.GroupBox1.Controls.Add(Me.manzana)
        Me.GroupBox1.Controls.Add(Me.txtLote)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 214)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de una poligonal"
        '
        'ManejoDeDiccionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ManejoDeDiccionarios"
        Me.Text = "Form2"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdministracionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiccionarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultarDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LimpiarCamposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtManzana As TextBox
    Friend WithEvents txtLote As TextBox
    Friend WithEvents txtUso As TextBox
    Friend WithEvents manzana As Label
    Friend WithEvents predio As Label
    Friend WithEvents uso As Label
    Friend WithEvents datosPredio As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DocumentarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DimensionesDeCadaLadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÁreaYPerímetroDelPoligonalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CálculoDelCentroideDelPoligonalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As ToolStripMenuItem
End Class
