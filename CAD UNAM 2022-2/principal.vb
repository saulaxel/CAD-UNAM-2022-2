Public Class Principal
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Inicializa_conexion("2022")
        If IsNothing(DOCUMENTO) Then
            dwgActual.Text = "Sin conexion"
        Else
            dwgActual.Text = DOCUMENTO.Name
        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles dwgActual.Click

    End Sub

    Private Sub DwgActual_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UnElementoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnElementoToolStripMenuItem.Click
        Me.Visible = False
        SeleccionDeObjetos("D")
        Me.Visible = True
    End Sub

    Private Sub ConexionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConexionToolStripMenuItem.Click

    End Sub

    Private Sub CAD2022ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CAD2022ToolStripMenuItem.Click
        Inicializa_conexion("2022")
        If IsNothing(DOCUMENTO) Then
            dwgActual.Text = "Sin conexion"
        Else
            dwgActual.Text = DOCUMENTO.Name
        End If
    End Sub

    Private Sub SeleccionSelectivaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionSelectivaToolStripMenuItem.Click
        Me.Visible = False
        SeleccionDeObjetos("A")
        Me.Visible = True
    End Sub

    Private Sub ClasificacionDeLineaVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClasificacionDeLineaVerticalToolStripMenuItem.Click
        Me.Visible = False
        ClasificaContraLineaVertical()
        Me.Visible = True
    End Sub

    Private Sub SeleccionDentroDeUnRectanguloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionDentroDeUnRectanguloToolStripMenuItem.Click
        Me.Visible = False
        SeleccionDeObjetos("B")
        Me.Visible = True
    End Sub

    Private Sub DiccionariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiccionariosToolStripMenuItem.Click
        Me.Visible = False
        ManejoDeDiccionarios.ShowDialog()
        Me.Visible = True
    End Sub

    Private Sub SelecciónDeSubElementoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelecciónDeSubElementoToolStripMenuItem.Click
        Me.Visible = False
        SeleccionDeObjetos("F")
        Me.Visible = True
    End Sub

    Private Sub AsociarSeñalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Visible = False
        AsociaSenalDirecto()
        Me.Visible = True
    End Sub

    Private Sub AgregarDiccionarioACompuertaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Visible = False
        PrepararElDiccionarioDeUnaCompuerta()
        Me.Visible = True
    End Sub

    Private Sub RealizarOperaciónDeLaCompuertaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealizarOperaciónDeLaCompuertaToolStripMenuItem.Click
        Me.Visible = False
        RealizarOperacionCompuerta()
        Me.Visible = True
    End Sub

    Private Sub ResolverCircuitoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResolverCircuitoToolStripMenuItem.Click
        Me.Visible = False
        ResolverCircuito()
        Me.Visible = True
    End Sub

    Private Sub MostrarHandleDelSubobjetoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarHandleDelSubobjetoToolStripMenuItem.Click
        Me.Visible = False
        MostrarHandleSubentidad()
        Me.Visible = True
    End Sub

    Private Sub AsociarCompuertasDeEntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsociarCompuertasDeEntradaToolStripMenuItem.Click
        Me.Visible = False
        AsociarEntradas()
        Me.Visible = True
    End Sub

    Private Sub AsociarTextoDeSalidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsociarTextoDeSalidaToolStripMenuItem.Click
        Me.Visible = False
        AsociarTextoSalida()
        Me.Visible = True
    End Sub

    Private Sub ReiniciarCircuitoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReiniciarCircuitoToolStripMenuItem.Click
        Me.Visible = False
        ReiniciarCircuito()
        Me.Visible = True
    End Sub

    Private Sub BorrarEnlacesCompuertasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarEnlacesCompuertasToolStripMenuItem.Click
        Me.Visible = False
        BorrarEnlacesCompuertas()
        Me.Visible = True
    End Sub
End Class

