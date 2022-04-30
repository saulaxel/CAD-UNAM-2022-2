Public Class ManejoDeDiccionarios
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles manzana.Click

    End Sub

    Private Sub ManejoDeDiccionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub AgregarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarDatosToolStripMenuItem.Click
        Me.Visible = False
        AgregarDatos(txtManzana.Text, txtLote.Text, txtUso.Text)
        Me.Visible = True
    End Sub

    Private Sub ConsultarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarDatosToolStripMenuItem.Click
        Dim m As String = Nothing
        Dim l As String = Nothing
        Dim u As String = Nothing
        Me.Visible = False
        RecuperarDatosSeleccion(m, l, u)
        txtManzana.Text = m
        txtLote.Text = l
        txtUso.Text = u
        Me.Visible = True
    End Sub

    Private Sub LimpiarCamposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarCamposToolStripMenuItem.Click
        txtManzana.Text = ""
        txtLote.Text = ""
        txtUso.Text = ""
        datosPredio.Items.Clear()
    End Sub

    Private Sub DimensionesDeCadaLadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DimensionesDeCadaLadoToolStripMenuItem.Click
        Me.Visible = False
        DimensionesLado()
        Me.Visible = True
    End Sub

    Private Sub ÁreaYPerímetroDelPoligonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÁreaYPerímetroDelPoligonalToolStripMenuItem.Click
        Me.Visible = False
        DocumentarAreaYPerimetroDePoligonal()
        Me.Visible = True
    End Sub

    Private Sub CálculoDelCentroideDelPoligonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CálculoDelCentroideDelPoligonalToolStripMenuItem.Click
        Me.Visible = False
        CalculoDeCentroideDePoligonal()
        Me.Visible = True
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem.Click
        Dim reporte As IEnumerable(Of String)
        Dim linea As String

        Me.Visible = False
        reporte = ReporteColindancias()

        For Each linea In reporte
            datosPredio.Items.Add(linea)
        Next
        Me.Visible = True
    End Sub


End Class