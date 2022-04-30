<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Me.ConexionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CAD2022ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EjemplosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionDeObjetosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnElementoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionSelectivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionDentroDeUnRectanguloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelecciónDeSubElementoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClasificacionDeLineaVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompuertasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RealizarOperaciónDeLaCompuertaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarHandleDelSubobjetoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsociarCompuertasDeEntradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsociarTextoDeSalidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResolverCircuitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiccionariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dwgActual = New System.Windows.Forms.Label()
        Me.ReiniciarCircuitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarEnlacesCompuertasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConexionToolStripMenuItem, Me.EjemplosToolStripMenuItem, Me.DiccionariosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConexionToolStripMenuItem
        '
        Me.ConexionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CAD2022ToolStripMenuItem})
        Me.ConexionToolStripMenuItem.Name = "ConexionToolStripMenuItem"
        Me.ConexionToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ConexionToolStripMenuItem.Text = "Conexion"
        '
        'CAD2022ToolStripMenuItem
        '
        Me.CAD2022ToolStripMenuItem.Name = "CAD2022ToolStripMenuItem"
        Me.CAD2022ToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.CAD2022ToolStripMenuItem.Text = "CAD 2022"
        '
        'EjemplosToolStripMenuItem
        '
        Me.EjemplosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeleccionDeObjetosToolStripMenuItem, Me.ClasificacionDeLineaVerticalToolStripMenuItem, Me.CompuertasToolStripMenuItem})
        Me.EjemplosToolStripMenuItem.Name = "EjemplosToolStripMenuItem"
        Me.EjemplosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.EjemplosToolStripMenuItem.Text = "Ejemplos"
        '
        'SeleccionDeObjetosToolStripMenuItem
        '
        Me.SeleccionDeObjetosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnElementoToolStripMenuItem, Me.SeleccionSelectivaToolStripMenuItem, Me.SeleccionDentroDeUnRectanguloToolStripMenuItem, Me.SelecciónDeSubElementoToolStripMenuItem})
        Me.SeleccionDeObjetosToolStripMenuItem.Name = "SeleccionDeObjetosToolStripMenuItem"
        Me.SeleccionDeObjetosToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SeleccionDeObjetosToolStripMenuItem.Text = "Seleccion de objetos"
        '
        'UnElementoToolStripMenuItem
        '
        Me.UnElementoToolStripMenuItem.Name = "UnElementoToolStripMenuItem"
        Me.UnElementoToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.UnElementoToolStripMenuItem.Text = "Un elemento"
        '
        'SeleccionSelectivaToolStripMenuItem
        '
        Me.SeleccionSelectivaToolStripMenuItem.Name = "SeleccionSelectivaToolStripMenuItem"
        Me.SeleccionSelectivaToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SeleccionSelectivaToolStripMenuItem.Text = "Seleccion selectiva"
        '
        'SeleccionDentroDeUnRectanguloToolStripMenuItem
        '
        Me.SeleccionDentroDeUnRectanguloToolStripMenuItem.Name = "SeleccionDentroDeUnRectanguloToolStripMenuItem"
        Me.SeleccionDentroDeUnRectanguloToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SeleccionDentroDeUnRectanguloToolStripMenuItem.Text = "Seleccion dentro de un rectangulo"
        '
        'SelecciónDeSubElementoToolStripMenuItem
        '
        Me.SelecciónDeSubElementoToolStripMenuItem.Name = "SelecciónDeSubElementoToolStripMenuItem"
        Me.SelecciónDeSubElementoToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SelecciónDeSubElementoToolStripMenuItem.Text = "Selección de sub elemento"
        '
        'ClasificacionDeLineaVerticalToolStripMenuItem
        '
        Me.ClasificacionDeLineaVerticalToolStripMenuItem.Name = "ClasificacionDeLineaVerticalToolStripMenuItem"
        Me.ClasificacionDeLineaVerticalToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.ClasificacionDeLineaVerticalToolStripMenuItem.Text = "Clasificacion de linea vertical"
        '
        'CompuertasToolStripMenuItem
        '
        Me.CompuertasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RealizarOperaciónDeLaCompuertaToolStripMenuItem, Me.MostrarHandleDelSubobjetoToolStripMenuItem, Me.BorrarEnlacesCompuertasToolStripMenuItem, Me.AsociarCompuertasDeEntradaToolStripMenuItem, Me.AsociarTextoDeSalidaToolStripMenuItem, Me.ResolverCircuitoToolStripMenuItem, Me.ReiniciarCircuitoToolStripMenuItem})
        Me.CompuertasToolStripMenuItem.Name = "CompuertasToolStripMenuItem"
        Me.CompuertasToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.CompuertasToolStripMenuItem.Text = "Resolución de circuitos"
        '
        'RealizarOperaciónDeLaCompuertaToolStripMenuItem
        '
        Me.RealizarOperaciónDeLaCompuertaToolStripMenuItem.Name = "RealizarOperaciónDeLaCompuertaToolStripMenuItem"
        Me.RealizarOperaciónDeLaCompuertaToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.RealizarOperaciónDeLaCompuertaToolStripMenuItem.Text = "Realizar operación de la compuerta"
        '
        'MostrarHandleDelSubobjetoToolStripMenuItem
        '
        Me.MostrarHandleDelSubobjetoToolStripMenuItem.Name = "MostrarHandleDelSubobjetoToolStripMenuItem"
        Me.MostrarHandleDelSubobjetoToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.MostrarHandleDelSubobjetoToolStripMenuItem.Text = "Mostrar handle del subobjeto"
        '
        'AsociarCompuertasDeEntradaToolStripMenuItem
        '
        Me.AsociarCompuertasDeEntradaToolStripMenuItem.Name = "AsociarCompuertasDeEntradaToolStripMenuItem"
        Me.AsociarCompuertasDeEntradaToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.AsociarCompuertasDeEntradaToolStripMenuItem.Text = "Asociar entradas"
        '
        'AsociarTextoDeSalidaToolStripMenuItem
        '
        Me.AsociarTextoDeSalidaToolStripMenuItem.Name = "AsociarTextoDeSalidaToolStripMenuItem"
        Me.AsociarTextoDeSalidaToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.AsociarTextoDeSalidaToolStripMenuItem.Text = "Asociar texto de salida"
        '
        'ResolverCircuitoToolStripMenuItem
        '
        Me.ResolverCircuitoToolStripMenuItem.Name = "ResolverCircuitoToolStripMenuItem"
        Me.ResolverCircuitoToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.ResolverCircuitoToolStripMenuItem.Text = "Resolver circuito"
        '
        'DiccionariosToolStripMenuItem
        '
        Me.DiccionariosToolStripMenuItem.Name = "DiccionariosToolStripMenuItem"
        Me.DiccionariosToolStripMenuItem.Size = New System.Drawing.Size(143, 20)
        Me.DiccionariosToolStripMenuItem.Text = "Manejo de Diccionarios"
        '
        'dwgActual
        '
        Me.dwgActual.AutoSize = True
        Me.dwgActual.Location = New System.Drawing.Point(12, 78)
        Me.dwgActual.Name = "dwgActual"
        Me.dwgActual.Size = New System.Drawing.Size(68, 13)
        Me.dwgActual.TabIndex = 1
        Me.dwgActual.Text = "Sin conexion"
        '
        'ReiniciarCircuitoToolStripMenuItem
        '
        Me.ReiniciarCircuitoToolStripMenuItem.Name = "ReiniciarCircuitoToolStripMenuItem"
        Me.ReiniciarCircuitoToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.ReiniciarCircuitoToolStripMenuItem.Text = "Reiniciar circuito"
        '
        'BorrarEnlacesCompuertasToolStripMenuItem
        '
        Me.BorrarEnlacesCompuertasToolStripMenuItem.Name = "BorrarEnlacesCompuertasToolStripMenuItem"
        Me.BorrarEnlacesCompuertasToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.BorrarEnlacesCompuertasToolStripMenuItem.Text = "Borrar enlaces compuertas"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dwgActual)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.Text = "Curso de CAD"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ConexionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dwgActual As Label
    Friend WithEvents CAD2022ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EjemplosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionDeObjetosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnElementoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionSelectivaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClasificacionDeLineaVerticalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionDentroDeUnRectanguloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiccionariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelecciónDeSubElementoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompuertasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RealizarOperaciónDeLaCompuertaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResolverCircuitoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostrarHandleDelSubobjetoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsociarCompuertasDeEntradaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsociarTextoDeSalidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReiniciarCircuitoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BorrarEnlacesCompuertasToolStripMenuItem As ToolStripMenuItem
End Class
