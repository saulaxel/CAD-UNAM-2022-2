Imports System.Text

Module Codigo
    ' --------------------------------------------------------------------------------
    ' Funciones matemáticas auxiliares
    ' --------------------------------------------------------------------------------

    Private Sub RedimAVec3SiHaceFalta(ByRef p1() As Double)
        If p1.Length <> 3 Then
            ReDim Preserve p1(2)
        End If
    End Sub

    Public Function MitadVec3(p1() As Double, p2() As Double) As Double()
        Dim middle(0 To 2) As Double
        middle(0) = (p1(0) + p2(0)) / 2
        middle(1) = (p1(1) + p2(1)) / 2
        If p1.Length = 3 Then
            middle(2) = (p1(2) + p2(2)) / 2
        End If
        Return middle
    End Function

    Public Function MitadPolar(p1() As Double, angle As Double, length As Double) As Double()
        RedimAVec3SiHaceFalta(p1)
        Return DOCUMENTO.Utility.PolarPoint(p1, angle, length / 2.0)
    End Function

    Public Function AnguloVec3(p1() As Double, p2() As Double) As Double
        RedimAVec3SiHaceFalta(p1) : RedimAVec3SiHaceFalta(p2)
        Return DOCUMENTO.Utility.AngleFromXAxis(p1, p2)
    End Function

    Private Function InterpolarVec3(v1() As Double,
                                    v2() As Double,
                                    porcentaje As Double) As Double()
        Dim angle As Double
        Dim longitud As Double
        RedimAVec3SiHaceFalta(v1) : RedimAVec3SiHaceFalta(v2)
        angle = AnguloVec3(v1, v2)
        longitud = LargoVec3(v1, v2)
        Return DOCUMENTO.Utility.PolarPoint(v1, angle, longitud * porcentaje)
    End Function

    Private Function DesplazarEnPerpendicularPolar(v() As Double,
                                              angulo As Double,
                                              distancia As Double) As Double()
        RedimAVec3SiHaceFalta(v)
        Return DOCUMENTO.Utility.PolarPoint(v, angulo + Math.PI / 2, distancia)
    End Function

    Public Function LargoVec3(p1() As Double, p2() As Double) As Double
        Dim suma As Double
        suma = Math.Pow(p2(0) - p1(0), 2) + Math.Pow(p2(1) - p1(1), 2)
        If p1.Length = 3 AndAlso p2.Length = 3 Then
            suma += Math.Pow(p2(2) - p1(2), 2)
        End If
        Return Math.Sqrt(suma)
    End Function

    Public Function CasiIgual(A As Double, B As Double) As Boolean
        Return A - 0.001 <= B And B <= A + 0.001
    End Function

    Public Function EsVerticalVec3(p1() As Double, p2() As Double) As Boolean
        Dim status As Boolean

        RedimAVec3SiHaceFalta(p1) : RedimAVec3SiHaceFalta(p2)

        If CasiIgual(p1(0), p2(0)) AndAlso
            CasiIgual(p1(1), p2(1)) AndAlso
            CasiIgual(p1(2), p2(2)) Then
            status = False
        ElseIf CasiIgual(p1(0), p2(0)) AndAlso
            CasiIgual(p1(2), p2(2)) AndAlso
            Not CasiIgual(p1(1), p2(1)) Then
            status = True
        End If
        Return status
    End Function

    Public Function GetEsquinasRectangulo(p1() As Double, p2() As Double)
        ' A partir de los extremos de un rectángulo se construye un arreglo
        ' con las coordenadas de las 4 esquinas
        Dim esquinas(0 To 11) As Double

        'cada 3 indices representan una coordenada XYZ
        esquinas(0) = p1(0) : esquinas(1) = p1(1) : esquinas(2) = 0 'coord1
        esquinas(3) = p2(0) : esquinas(4) = p1(1) : esquinas(5) = 0 'coord2
        esquinas(6) = p2(0) : esquinas(7) = p2(1) : esquinas(8) = 0 'coord3
        esquinas(9) = p1(0) : esquinas(10) = p2(1) : esquinas(11) = 0 'coord4

        Return esquinas
    End Function


    Public Function XyToXyz(v() As Double) As Double()
        If v.GetUpperBound(0) = 1 Then
            ReDim Preserve v(2)
        End If
        Return v
    End Function


    Public Function PuntoMedioVec3(v1() As Double, v2() As Double) As Double()
        Dim pm() As Double
        Dim angulo As Double
        Dim distancia As Double

        If v1.GetUpperBound(0) = 1 Then
            ReDim Preserve v1(2)
            ReDim Preserve v2(2)
        End If
        distancia = GetDistancia(v1, v2)

        angulo = AnguloVec3(v1, v2)
        pm = PuntoMedioVec3(v1, v2)

        Return pm
    End Function

    Public Function GetDistancia(v1() As Double, v2() As Double) As Double
        Return Math.Sqrt(Math.Pow(v1(0) - v2(0), 2) + Math.Pow(v1(1) - v2(1), 2) + Math.Pow(v1(2) - v2(2), 2))
    End Function

    Function EliminarDigitos(ByVal S As String) As String
        Return RegularExpressions.Regex.Replace(S, "\d", "")
    End Function

    Function EliminarLetras(ByVal S As String) As String
        Return RegularExpressions.Regex.Replace(S, "[a-zA-Z]", "")
    End Function

    ' --------------------------------------------------------------------------------
    ' Funciones auxiliares de autocad
    ' --------------------------------------------------------------------------------

    Public Sub Inicializa_conexion(ByVal version As String)
        Dim R As String
        Select Case version
            Case "2017"
                R = "AUTOCAD.Application.21"
            Case "2022"
                R = "AUTOCAD.Application.24"
            Case Else
                R = ""
        End Select
        Try
            DOCUMENTO = Nothing
            AUTOCADAPP = GetObject(, R)
            DOCUMENTO = AUTOCADAPP.ActiveDocument
            UTILITY = DOCUMENTO.Utility
            AUTOCADAPP.Visible = True
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    Public Function EsLinea(objeto As AcadEntity) As Boolean
        Return objeto.ObjectName = "AcDbLine" OrElse objeto.ObjectName = "AcDbXline"
    End Function

    Public Function GetConjunto(info As String) As AcadSelectionSet
        Dim conjunto As AcadSelectionSet
        conjunto = Conjunto_vacio(DOCUMENTO, info)
        If Not IsNothing(conjunto) Then
            conjunto.SelectOnScreen()
        End If
        Return conjunto
    End Function

    Public Function GetEntidad(mensaje As String) As AcadEntity
        Dim c(0 To 2) As Double
        Dim objeto As AcadEntity = Nothing
        Try
            AppActivateAutoCAD()
            DOCUMENTO.Utility.GetEntity(objeto, c, mensaje)
        Catch ex As Exception

        End Try
        Return objeto
    End Function


    Public Function Conjunto_vacio(ByRef documento As AcadDocument, ByVal nombre As String) As AcadSelectionSet
        Dim indice As Integer
        Dim conjunto As AcadSelectionSet = Nothing

        nombre = nombre.Trim.ToUpper
        Try
            For indice = 0 To documento.SelectionSets.Count - 1
                If documento.SelectionSets.Item(indice).Name = nombre Then
                    documento.SelectionSets.Item(indice).Delete()
                    Exit For
                End If
            Next
            conjunto = documento.SelectionSets.Add(nombre)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "CAD")
        End Try
        Return conjunto
    End Function

    Public Sub LibrarInterferencias(ByRef circulo As AcadCircle)
        'Buscar Intersecciones del circulo
        'Si hay interseciones entonces mover el circulo hacia arriba en su radio\
        'Repetir este ciclo hasta que no haya intersecciones
        Dim objetos As AcadSelectionSet
        Dim objeto As AcadEntity
        Dim p1() As Double = Nothing
        Dim p2() As Double = Nothing
        Dim pDestino() As Double
        Dim intersecciones As Boolean = True

        While intersecciones
            intersecciones = False
            circulo.GetBoundingBox(p1, p2)
            objetos = GetObjetosEnRectangulo(p1, p2)

            If Not IsNothing(objetos) Then
                For Each objeto In objetos
                    If objeto.ObjectName = "AcDbCircle" And objeto.Handle <> circulo.Handle Then
                        intersecciones = True
                        pDestino = circulo.Center
                        pDestino(1) = pDestino(1) + circulo.Radius
                        circulo.Move(circulo.Center, pDestino)
                        circulo.Update()
                    End If
                Next
            End If
        End While
    End Sub

    Public Function GetObjetosEnPoligono(esquinas() As Double) As AcadSelectionSet
        Dim conjunto As AcadSelectionSet = Conjunto_vacio(DOCUMENTO, "IDLE")
        If Not IsNothing(conjunto) Then
            conjunto.SelectByPolygon(AcSelect.acSelectionSetCrossingPolygon, esquinas)
        End If
        Return conjunto
    End Function

    Public Function GetObjetosEnRectangulo(p1() As Double, p2() As Double) As AcadSelectionSet
        Dim esquinas() As Double = GetEsquinasRectangulo(p1, p2)
        Return GetObjetosEnPoligono(esquinas)
    End Function

    Public Sub SeleccionDeObjetos(metodo As String)
        Dim conjunto As AcadSelectionSet
        Dim entidad As AcadEntity = Nothing
        Dim p(0 To 2) As Double
        Dim p1() As Double
        Dim esquinas(0 To 11) As Double

        Dim PickedPoint(0 To 2) As Double
        Dim TransMatrix(0 To 3, 0 To 3) As Double
        Dim ContextData As Object = Nothing
        Dim HasContextData As String
        Dim Objeto As AcadEntity = Nothing
        Dim ObjetoAsociado As AcadEntity

        AppActivateAutoCAD()
        Select Case metodo
            Case "A"
                'Seleccion selectiva'
                conjunto = Conjunto_vacio(DOCUMENTO, "IDLE")
                If Not IsNothing(conjunto) Then
                    conjunto.SelectOnScreen()
                End If
            Case "D"
                'Seleccion de un elemento'
                Try
                    DOCUMENTO.Utility.GetEntity(entidad, p, "Selecciona un elemento")
                Catch ex As Exception

                End Try
            Case "B"
                p = SolicitarCoordenada("Esquina 1")
                If Not IsNothing(p) Then
                    p1 = SolicitarCoordenada("Esquina opuesta", p)
                    If Not IsNothing(p1) Then
                        conjunto = GetObjetosEnRectangulo(p, p1)
                        If Not IsNothing(conjunto) Then
                            MsgBox(conjunto.Count)
                        End If
                    End If
                End If

            Case "F"
                ' Selección de un subElemento
                ' Obtención de información sobre el objeto seleccionado
                Dim atrObj As AcadAttribute

                Try
                    DOCUMENTO.Utility.GetSubEntity(Objeto, PickedPoint, TransMatrix, ContextData)
                Catch ex As Exception
                    ' No se seleccionó un objeto
                End Try
                If Not IsNothing(Objeto) Then
                    ' Procesa y muestra las propiedades del objeto seleccionado
                    HasContextData = IIf(VarType(ContextData) = vbEmpty, " does not ", " does ")
                    MsgBox("The object you chose was an: " & Objeto.ObjectName & vbCrLf &
                           "Your point of selection was: " &
                           PickedPoint(0) & ", " &
                           PickedPoint(1) & ", " &
                           PickedPoint(2) & ", " &
                           "The container object of the selected one " & HasContextData & "have nested objects.")

                    If Not IsNothing(ContextData) Then
                        ObjetoAsociado = DOCUMENTO.ObjectIdToObject(ContextData(0))
                        MsgBox("El contenedor asociado es " & ObjetoAsociado.ObjectName)
                    End If

                    ' Si tengo acceso a la subentidad entonces tendré acceso a sus propiedades?
                    ' En el caso que la subtentidad seleccionada sea un Atributo, puedo interrogarlo
                    If Not IsNothing(Objeto) AndAlso Objeto.ObjectName = "AcDbAttribute" Then
                        atrObj = Objeto
                        MsgBox(atrObj.Handle & "Tipo=" & atrObj.TagString & "  " & atrObj.TextString)
                    End If
                End If
        End Select
    End Sub

    Public Sub GetSubentidad(ByRef entidad As AcadEntity, mensaje As String,
                             Optional ByRef pExterno() As Double = Nothing,
                             Optional ByRef objContenedor As AcadEntity = Nothing)
        Dim TransMatrix(0 To 3, 0 To 3) As Double
        Dim ContextData As Object = Nothing
        Dim p() As Double = Nothing

        DOCUMENTO.Utility.Prompt(mensaje)
        Try
            DOCUMENTO.Utility.GetSubEntity(entidad, p, TransMatrix, ContextData)

            If Not IsNothing(objContenedor) Then
                objContenedor = ContextData
            End If
            If Not IsNothing(pExterno) Then
                pExterno = p
            End If
        Catch ex As Exception
            'no se selecciono un objeto 

            entidad = Nothing
            p = Nothing
        End Try
    End Sub

    Public Sub CrearLayer(nombre As String)
        Try
            DOCUMENTO.Layers.Add(nombre.Trim.ToUpper)
        Catch ex As Exception
            UTILITY.Prompt("La capa ya existe o su nombre es incorrecto")
        End Try
    End Sub

    Public Sub EtiquetaLado(distancia As Object, v1() As Double, v2() As Double)
        ' Coloca el texto en el centro del segmento y lo orienta
        Dim angulo As Double
        Dim etiqueta As AcadText
        Dim info As String
        Dim pm() As Double

        If v1.GetUpperBound(0) = 1 Then
            ' Las coordenadas son XY y debo convertirlas en XYZ
            ReDim Preserve v1(2)
            ReDim Preserve v2(2)
        End If
        angulo = AnguloVec3(v1, v2)
        pm = PuntoMedioVec3(v1, v2)
        info = distancia.ToString("#.00")  ' Formateado a 2 decimales
        etiqueta = DOCUMENTO.ModelSpace.AddText(info, pm, 2)
        etiqueta.Rotation = angulo
        etiqueta.Update()
    End Sub

    Public Sub AddXdata(ByRef entidad As AcadEntity, nameXrecord As String, valor As String)
        ' Agrega un Xrecord y un solo valor
        Dim dictASTI As AcadDictionary
        Dim astiXRec As AcadXRecord
        Dim keyCode() As Short  ' Obligatorio short. Int envia un error en el setxrecorddata
        Dim cptData() As Object ' Obligatorio object

        ReDim keyCode(0)
        ReDim cptData(0)

        dictASTI = entidad.GetExtensionDictionary
        astiXRec = dictASTI.AddXRecord(nameXrecord.ToUpper.Trim)
        keyCode(0) = 100 : cptData(0) = valor
        astiXRec.SetXRecordData(keyCode, cptData)
    End Sub

    Public Sub GetXData(entidad As AcadEntity, nameXrecord As String, ByRef valor As String)
        ' extrayendo datos
        ' estamos considerando que un Xrecord solo tiene un dato, lo cual
        ' no es así porque puede tener mucho datos
        Dim astiXRec As AcadXRecord = Nothing
        Dim dictASTI As AcadDictionary
        Dim getKey As Object = Nothing
        Dim getData As Object = Nothing

        valor = Nothing
        Try
            dictASTI = entidad.GetExtensionDictionary
            astiXRec = dictASTI.Item(nameXrecord.ToUpper.Trim) ' Revisando si existe el XRecord
        Catch ex As System.Runtime.InteropServices.COMException
            ' no existe el Xrecord con la entrada nameXrecord, lo cual causa la excepción
            ' Esta forma de manejar una expeción si funcionó y debe complementarse al momento de
            ' recibir el mensaje de excepciones que se produzcan y palomear el nombre de la aplicación
            ' para que no se detenga la ejecución en este programa
        End Try
        If Not IsNothing(astiXRec) Then
            astiXRec.GetXRecordData(getKey, getData)
            If Not IsNothing(getData) Then
                valor = getData(0)
            End If
        End If
    End Sub

    Public Sub GraficaPoligono(coords() As Double, cerrado As Boolean)
        Dim poligono As AcadEntity
        Dim lsup As Integer

        If cerrado Then
            lsup = coords.Length() - 1
            ReDim Preserve coords(lsup + 3)
            coords(lsup + 1) = coords(0)
            coords(lsup + 2) = coords(1)
            coords(lsup + 3) = coords(2)
        End If
        poligono = DOCUMENTO.ModelSpace.AddPolyline(coords)
        poligono.Update()
    End Sub

    Public Function SelectEntidad(mensaje As String) As AcadEntity
        'permite seleccionar una entidad y si no se selecciona nada regresa nothing
        Dim entidad As AcadEntity = Nothing
        Dim p() As Double = Nothing

        Try
            DOCUMENTO.Utility.GetEntity(entidad, p, mensaje)
        Catch ex As Exception

        End Try

        Return entidad
    End Function

    Public Function SolicitarCoordenada(mensaje As String, Optional pb() As Double = Nothing) As Double()
        Dim p() As Double = Nothing

        Try
            If IsNothing(pb) Then
                p = DOCUMENTO.Utility.GetPoint(, mensaje)
            Else
                p = DOCUMENTO.Utility.GetPoint(pb, mensaje)
            End If
        Catch e As Exception

        End Try
        Return p
    End Function


    Public Sub AppActivateAutoCAD()
        Dim AUTOCADWINDNAME As String
        Dim acadProcess() As Process = Process.GetProcessesByName("ACAD")

        Try
            AUTOCADWINDNAME = acadProcess(0).MainWindowTitle
            AppActivate(AUTOCADWINDNAME)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Public Function EsPoligonalCerrada(objeto As AcadEntity) As Boolean
        Return Not IsNothing(objeto) AndAlso objeto.ObjectName = "AcDbPolyline" AndAlso objeto.Closed
    End Function

    Public Function EsBloque(objeto As AcadEntity) As Boolean
        Return Not IsNothing(objeto) AndAlso objeto.ObjectName = "AcDbBlockReference"
    End Function

    ' --------------------------------------------------------------------------------
    ' Actividades
    ' --------------------------------------------------------------------------------

    Public Sub ClasificaContraLineaVertical()
        'Clasificacion de circulos y lineas
        'Los círculos quedan en la parte izquierda y las lineas en la derecha
        'Su punto de union queda en la mitad de la linea
        'Los circulos no deben intersectarse
        'Si se intersectan, deben moverse hacia arriba hasta que no haya interseccion
        'los circulos deben ser tangentes a la linea vertical
        Dim lineaRef As AcadLine
        Dim lineaInfRef As AcadXline
        Dim objetosAnalizar As AcadSelectionSet
        Dim objParticular As AcadEntity
        Dim lineaAnalizada As AcadLine
        Dim endPnt() As Double
        Dim startPnt() As Double
        Dim refStartPnt() As Double
        Dim refEndPnt() As Double
        Dim refMiddlePnt() As Double
        Dim refAngle As Double
        Dim refLength As Double
        Dim objeto As AcadEntity
        Dim pBase() As Double
        Dim circuloAnalizado As AcadCircle
        Dim pCentroCirculo() As Double
        Dim handle As String

        objeto = GetEntidad("selecciona una linea")

        If IsNothing(objeto) Then
            Return
        End If

        handle = objeto.Handle

        If objeto.ObjectName = "AcDbLine" Then
            lineaRef = objeto
            refStartPnt = lineaRef.StartPoint
            refEndPnt = lineaRef.EndPoint
            refAngle = lineaRef.Angle
            refLength = lineaRef.Length
        ElseIf objeto.ObjectName = "AcDbXline" Then
            lineaInfRef = objeto
            refStartPnt = lineaInfRef.BasePoint
            refEndPnt = lineaInfRef.SecondPoint
            refAngle = Math.Atan2(refEndPnt(1) - refStartPnt(1), refEndPnt(0) - refStartPnt(0))
            refLength = LargoVec3(refStartPnt, refEndPnt)
        Else
            Return
        End If

        If EsVerticalVec3(refStartPnt, refEndPnt) Then
            'Obtencion de puntos de la linea vertical en coordenadas X y Y
            refMiddlePnt = MitadPolar(refStartPnt, refAngle, refLength)
            'seleccionar los elementos que voy a analizar
            objetosAnalizar = GetConjunto("Selecciona Conjunto de objetos")
            For Each objParticular In objetosAnalizar
                If objParticular.Handle <> handle Then
                    Select Case objParticular.ObjectName
                        Case "AcDbLine"
                            lineaAnalizada = objParticular
                            objParticular = Nothing
                            startPnt = lineaAnalizada.StartPoint
                            endPnt = lineaAnalizada.EndPoint
                            If startPnt(0) < endPnt(0) Then
                                pBase = startPnt
                            Else
                                pBase = endPnt
                            End If
                            lineaAnalizada.Move(pBase, refMiddlePnt)
                            lineaAnalizada.Update()
                        Case "AcDbCircle"
                            circuloAnalizado = objParticular
                            pCentroCirculo = circuloAnalizado.Center
                            pCentroCirculo(0) = refMiddlePnt(0) - circuloAnalizado.Radius
                            circuloAnalizado.Center = pCentroCirculo
                            circuloAnalizado.Update()
                            LibrarInterferencias(circuloAnalizado)
                    End Select
                End If
            Next
        End If

    End Sub

    Public Sub AgregarDatos(manzana As String, lote As String, uso As String)
        ' Agregar la información empleado DICCIONARIO a una polilinea seleccionada
        ' La polilinea debe estar cerrada
        Dim poligono As AcadEntity
        Dim poligonal As AcadLWPolyline

        AppActivateAutoCAD()

        poligono = SelectEntidad("Selecciona una poligonal")
        If EsPoligonalCerrada(poligono) Then
            poligonal = poligono

            AddXdata(poligonal, "MANZANA", manzana)
            AddXdata(poligonal, "LOTE", lote)
            AddXdata(poligonal, "USO", uso)
        Else
            DOCUMENTO.Utility.Prompt("No seleccionaste una polilinea o la polilinea está abierta")
        End If
    End Sub

    Public Sub RecuperarDatosPoligonal(poligonal As AcadLWPolyline, ByRef manzana As String, ByRef lote As String, ByRef uso As String)
        GetXData(poligonal, "MANZANA", manzana)
        GetXData(poligonal, "LOTE", lote)
        GetXData(poligonal, "USO", uso)
    End Sub

    Public Sub RecuperarDatosSeleccion(ByRef manzana As String, ByRef lote As String, ByRef uso As String)
        Dim poligono As AcadEntity
        Dim poligonal As AcadLWPolyline

        AppActivateAutoCAD()
        poligono = SelectEntidad("Selecciona una poligonal")
        If EsPoligonalCerrada(poligono) Then
            poligonal = poligono
            RecuperarDatosPoligonal(poligonal, manzana, lote, uso)
        End If
    End Sub

    Public Sub DimensionesLado()
        ' Seleccionar una polilinea cerrada y documentar la longitud de sus lados

        Dim objeto As AcadEntity
        Dim poligonal As AcadLWPolyline
        Dim numCoordinates As Integer
        Dim p1(), p2() As Double
        Dim puntoMedio() As Double
        Dim longitud As Double
        Dim angulo As Double
        Dim text As AcadMText

        AppActivateAutoCAD()
        objeto = SelectEntidad("Selecciona una poligonal")
        If EsPoligonalCerrada(objeto) Then

            poligonal = objeto

            numCoordinates = poligonal.Coordinates().Length / 2
            For i = 0 To numCoordinates - 1 Step 1
                p1 = poligonal.Coordinate(i)
                p2 = poligonal.Coordinate((i + 1) Mod numCoordinates)

                puntoMedio = MitadVec3(p1, p2)
                longitud = String.Format("{0:0.00}", LargoVec3(p1, p2))
                angulo = Math.Atan2(p2(1) - p1(1), p2(0) - p1(0))

                text = DOCUMENTO.ModelSpace.AddMText(puntoMedio, 1, longitud.ToString)
                text.Height = 30
                text.Rotate(puntoMedio, angulo)
                text.Update()
            Next
        End If

    End Sub

    Public Sub EtiquetadoDeLadosDePoligonal()
        ' Versión de clase
        'seleccionar una polilínea y documentar la longitud de sus lados
        Dim c As Integer
        Dim coord() As Double
        Dim indice As Integer
        Dim i As Integer
        Dim numVertices As Integer
        Dim poligono As AcadEntity
        Dim poligonal As AcadLWPolyline
        Dim distancia As Double
        Dim v1() As Double
        Dim v2() As Double

        AppActivateAutoCAD()
        poligono = SelectEntidad("Selecciona una poligonal ")
        If EsPoligonalCerrada(poligono) Then
            poligonal = poligono
            coord = poligonal.Coordinates
            numVertices = (coord.GetUpperBound(0) + 1) / 2 ' Número de vértices de la poligonal

            indice = 0
            For i = 1 To numVertices
                v1 = poligonal.Coordinate(indice)
                c = IIf(indice = numVertices - 1, 0, indice + 1)
                v2 = poligonal.Coordinate(c)

                distancia = GetDistancia(v1, v2)
                EtiquetaLado(distancia, v1, v2)
                indice += 1
            Next
        End If

    End Sub

    Public Sub DocumentarAreaYPerimetroDePoligonal()
        ' Documentar el área y perímetro de la poligonal colocando el dato en el centroide de la misma

        Dim centroide() As Double
        Dim entidadSeleccionada As AcadEntity
        Dim objetos(0 To 0) As AcadEntity
        Dim region As Object
        Dim point As AcadPoint

        AppActivateAutoCAD()
        CrearLayer("CENTROIDES")

        entidadSeleccionada = SelectEntidad("Selecciona una polilinea cerrada")

        While EsPoligonalCerrada(entidadSeleccionada)
            Try

                region = DOCUMENTO.ModelSpace.AddRegion(objetos)
                centroide = region(0).centroid
                centroide = XyToXyz(centroide)
                centroide = XyToXyz(centroide)
                point = DOCUMENTO.ModelSpace.AddPoint(centroide)
                point.Layer = "Centroides"
                region(0).DELETE
            Catch ex As Exception
                UTILITY.Prompt(ex.Message & vbCrLf)
            End Try
            entidadSeleccionada = SelectEntidad("Selecciona una polilínea cerrada")

        End While

    End Sub

    Public Sub CalculoDeCentroideDePoligonal()
        ' Documentar el área y perímetro de la poligonal colocando el dato en el centroide de la misma

        Dim centroide() As Double
        Dim entidadSeleccionada As AcadEntity
        Dim objetos(0 To 0) As AcadEntity
        Dim region As Object
        Dim point As AcadPoint

        AppActivateAutoCAD()
        CrearLayer("CENTROIDES")

        entidadSeleccionada = SelectEntidad("Selecciona una polilinea cerrada")

        While EsPoligonalCerrada(entidadSeleccionada)
            Try

                region = DOCUMENTO.ModelSpace.AddRegion(objetos)
                centroide = region(0).centroid
                centroide = XyToXyz(centroide)
                centroide = XyToXyz(centroide)
                point = DOCUMENTO.ModelSpace.AddPoint(centroide)
                point.Layer = "Centroides"
                region(0).DELETE
            Catch ex As Exception
                UTILITY.Prompt(ex.Message & vbCrLf)
            End Try
            entidadSeleccionada = SelectEntidad("Selecciona una polilínea cerrada")

        End While

    End Sub

    Public Function ReporteColindancias() As IEnumerable(Of String)
        Dim objetosAnalizar As AcadSelectionSet
        Dim objeto As AcadEntity
        Dim poligonal As AcadLWPolyline
        Dim reporte As New List(Of String)
        Dim manzana As String = Nothing
        Dim nombreLote As String = Nothing
        Dim uso As String = Nothing

        AppActivateAutoCAD()
        objetosAnalizar = GetConjunto("Selecciona Conjunto de objetos")

        For Each objeto In objetosAnalizar
            If Not EsLote(objeto) Then
                Continue For
            End If
            poligonal = objeto

            RecuperarDatosPoligonal(poligonal, manzana, nombreLote, uso)
            reporte.Add(String.Format("MANZANA {0} LOTE {1} USO {2}",
                                      manzana, nombreLote, uso))
            ' Se van acumulando las colindancias de cada lote
            ColindanciasLote(poligonal, reporte)
        Next

        Return reporte
    End Function

    Private Sub ColindanciasLote(lote As AcadLWPolyline,
                                 ByRef reporte As List(Of String))
        Dim v1() As Double
        Dim v2() As Double
        Dim objetosColision As AcadSelectionSet
        Dim i, j As Integer
        Dim numVertices As Integer
        Dim lado As Char

        numVertices = (lote.Coordinates().Length) / 2 ' Número de vértices de la poligonal

        For i = 1 To numVertices
            v1 = lote.Coordinate(i - 1)
            j = IIf(i = numVertices, 0, i)
            v2 = lote.Coordinate(j)

            lado = Convert.ToChar(64 + i)
            reporte.Add(String.Format("    Lado {0}", lado))

            objetosColision = ObjetosCercanosSegmento(v1, v2)

            FiltrarLotesColindantes(lote, objetosColision, reporte)
        Next
    End Sub

    Private Sub FiltrarLotesColindantes(loteReferencia As AcadLWPolyline,
                                        objetosColision As AcadSelectionSet,
                                        ByRef reporte As List(Of String))
        Dim handle As String = loteReferencia.Handle
        Dim manzana1 As String = Nothing
        Dim manzana2 As String = Nothing
        Dim nombreLote1 As String = Nothing
        Dim nombreLote2 As String = Nothing
        Dim uso1 As String = Nothing
        Dim uso2 As String = Nothing
        Dim objeto As AcadEntity
        Dim segundoLote As AcadLWPolyline

        RecuperarDatosPoligonal(loteReferencia, manzana1, nombreLote1, uso1)

        For Each objeto In objetosColision
            If EsLote(objeto) AndAlso handle <> objeto.Handle Then
                segundoLote = objeto
                RecuperarDatosPoligonal(segundoLote, manzana2, nombreLote2, uso2)
                reporte.Add(String.Format("        MANZANA {0} LOTE {1} USO {2}",
                                          manzana2, nombreLote2, uso2))
            End If
        Next
    End Sub

    Private Function ObjetosCercanosSegmento(v1() As Double, v2() As Double) As AcadSelectionSet
        Dim esquinas() As Double
        esquinas = GetEsquinasCuadrilateroCircundante(v1, v2)
        Return GetObjetosEnPoligono(esquinas)
    End Function

    Private Function GetEsquinasCuadrilateroCircundante(v1() As Double, v2() As Double) As Double()
        Dim longitud As Double
        Dim angulo As Double
        Dim ref1() As Double
        Dim ref2() As Double
        Dim p1(), p2(), p3(), p4() As Double
        Dim esquinas(0 To 11) As Double

        Const porcentaje1 As Double = 10.0 / 100.0
        Const porcentaje2 As Double = 90.0 / 100.0
        Const distancia As Double = 10

        angulo = AnguloVec3(v1, v2)
        longitud = LargoVec3(v1, v2)

        ref1 = InterpolarVec3(v1, v2, porcentaje1)
        ref2 = InterpolarVec3(v1, v2, porcentaje2)

        p1 = DesplazarEnPerpendicularPolar(ref1, angulo, distancia)
        p2 = DesplazarEnPerpendicularPolar(ref1, angulo, -distancia)

        p3 = DesplazarEnPerpendicularPolar(ref2, angulo, -distancia)
        p4 = DesplazarEnPerpendicularPolar(ref2, angulo, distancia)

        esquinas(0) = p1(0) : esquinas(1) = p1(1) : esquinas(2) = p1(2) 'coord1
        esquinas(3) = p2(0) : esquinas(4) = p2(1) : esquinas(5) = p2(2) 'coord2
        esquinas(6) = p3(0) : esquinas(7) = p3(1) : esquinas(8) = p3(2) 'coord3
        esquinas(9) = p4(0) : esquinas(10) = p4(1) : esquinas(11) = p4(2) 'coord4

        GraficaPoligono(esquinas, True)

        Return esquinas
    End Function

    Private Function EsLote(objeto As AcadEntity) As Boolean
        Dim lote As String = Nothing
        If Not EsPoligonalCerrada(objeto) Then
            Return False
        End If

        GetXData(objeto, "LOTE", lote)
        Return lote IsNot Nothing
    End Function

    ' Promblema de circuitos
    Public Sub AsociaSenalDirecto()
        ' Asigna una señal de entrada tipo string 010100101 a una pata de una compuerta
        ' La pata está indicada por una Atributo cuyo TAG es ENTRADA
        ' y el valor del atributo indica que pata es
        ' El archivo DWG que tiene el BLOQUE que requerimos se llama
        ' RESOLVIENDO UNA COMPUERTA AND y esta en el directorio de la UNAM (buscar en las subcadenas de proyectos

        Dim entidad As AcadEntity = Nothing
        Dim p(0 To 2) As Double
        Dim senal As AcadEntity
        Dim tipo As String = Nothing

        AppActivateAutoCAD()
        Try
            GetSubentidad(entidad, "Selecciona la terminal de una compuerta ", p)
            If Not IsNothing(entidad) Then
                GetXData(entidad, "TIPO", tipo)

                If tipo = "ENTRADA" OrElse tipo = "SALIDA" Then
                    ' Seleccionando una señal
                    senal = GetEntidad("Selecciona una señal ")
                    If (tipo = "SALIDA" AndAlso SalidaValida(senal)) OrElse
                        (tipo = "ENTRADA" AndAlso EntradaValida(senal)) Then
                        ' Asignando al atributo el apuntador a la señal
                        AddXdata(entidad, "SENAL", senal.Handle)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try

    End Sub

    Private Function EntradaValida(senal As AcadEntity) As Boolean
        If IsNothing(senal) Then
            Return False
        End If

        Return EsCompuerta(senal) OrElse senal.ObjectName = "AcDbText"
    End Function

    Private Function SalidaValida(senal As AcadEntity) As Boolean
        Return Not IsNothing(senal) AndAlso senal.ObjectName = "AcDbText"
    End Function

    Private Function EsCompuerta(entidad As AcadEntity) As Boolean
        Dim tipoCompuerta As String
        If Not EsBloque(entidad) Then
            Return False
        End If

        tipoCompuerta = ObtenerTipoCompuerta(entidad)
        Return Not IsNothing(tipoCompuerta)
    End Function

    Private Function EsTexto(entidad As AcadEntity) As Boolean
        Return Not IsNothing(entidad) AndAlso entidad.ObjectName = "AcDbText"
    End Function

    Public Sub PrepararDiccionarioTerminal(tipo As String)
        Dim entidad As AcadEntity

        entidad = GetEntidad("Selecciona una terminal de tipo " & tipo)

        Try
            If Not IsNothing(entidad) AndAlso entidad.ObjectName = "AcDbLine" Then
                AddXdata(entidad, "TIPO", tipo)
                AddXdata(entidad, "SENAL", "")
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    Public Sub PrepararElDiccionarioDeUnaCompuerta()
        ' Va a asignar a cada pata de una compuerta (no encapsulada) el diccionario
        ' con las propiedades XRECORD siguientes
        ' TIPO - Valores ENTRADA o SALIDA
        ' SENAL - Contiene un apuntador al HANDLER del texto que representa la senal

        PrepararDiccionarioTerminal("ENTRADA")
        PrepararDiccionarioTerminal("ENTRADA")
        PrepararDiccionarioTerminal("SALIDA")
    End Sub

    Public Sub RealizarOperacionCompuerta()
        Dim entidad As AcadEntity
        Dim bloque As AcadBlockReference
        Dim tipoCompuerta As String
        Dim partesCompuerta() As Object
        Dim entradas As IEnumerable(Of AcadText)
        Dim strEntrada As String
        Dim salida As AcadText
        Dim strSalida As String

        entidad = GetEntidad("Selecciona una compuerta")

        If EsBloque(entidad) Then
            bloque = entidad
            tipoCompuerta = ObtenerTipoCompuerta(bloque)

            If IsNothing(tipoCompuerta) Then
                ' El bloque seleccionado no es una compuerta
                Exit Sub
            End If

            partesCompuerta = SepararPartesCompuerta(bloque)
            entradas = ObtenerEntradasCompuerta(partesCompuerta)
            salida = ObtenerSalidaCompuerta(partesCompuerta)

            If EsCompuertaDeUnaEntrada(tipoCompuerta) Then
                strEntrada = entradas(0).TextString
                strSalida = OperarCompuertaUnaria(tipoCompuerta, strEntrada)
            Else
                strSalida = OperarCompuertaMultiplesEntradas(tipoCompuerta, entradas)
            End If
            salida.TextString = strSalida
            salida.Update()
        End If

    End Sub

    Private Function SepararPartesCompuerta(compuerta As AcadBlockReference) As Object()
        Dim partesCompuerta() As Object
        partesCompuerta = compuerta.Explode
        Return partesCompuerta
    End Function

    Private Function ObtenerTipoCompuerta(compuerta As AcadBlockReference) As String
        Dim tipo As String = compuerta.EffectiveName
        tipo = EliminarDigitos(tipo)
        Select Case tipo
            Case "AND", "OR", "XOR", "SEG", "NAND", "NOR", "XNOR", "NOT"
                Return tipo
            Case Else
                Return Nothing
        End Select
    End Function


    Private Function NumEntradasCompuerta(compuerta As AcadBlockReference) As Integer
        Dim nombreCompuerta As String
        Dim digitos As String
        Dim resultado As Integer

        nombreCompuerta = compuerta.EffectiveName
        digitos = EliminarLetras(nombreCompuerta)

        If digitos = "" Then
            ' Si no tiene insertada la información del número
            ' de entradas, usamos los valores por defecto
            Select Case nombreCompuerta
                Case "AND", "OR", "XOR", "NAND", "NOR", "XNOR"
                    resultado = 2
                Case "SEG", "NOT"
                    resultado = 1
                Case Else
                    Throw New ArgumentException("compuerta")
            End Select
        Else
            ' Si la compuerta tiene un número, por ejemplo AND3,
            ' el 3 indica el número de entradas que espera
            resultado = Integer.Parse(digitos)
        End If

        Return resultado
    End Function

    Private Function ObtenerEntradasCompuerta(partesCompuerta() As Object) As IEnumerable(Of AcadText)
        Dim entradasCompuerta As New List(Of AcadText)
        Dim objeto As AcadEntity
        Dim linea As AcadLine
        Dim tipo As String = Nothing
        Dim handleSenal As String = Nothing

        For Each objeto In partesCompuerta
            If Not EsLinea(objeto) Then
                Continue For
            End If

            linea = objeto
            GetXData(linea, "TIPO", tipo)
            GetXData(linea, "SENAL", handleSenal)

            If tipo = "ENTRADA" Then
                entradasCompuerta.Add(ObtenerObjetoDelHandle(handleSenal))
            End If
        Next
        Return entradasCompuerta
    End Function

    Private Function ObtenerSalidaCompuerta(partesCompuerta() As Object) As AcadText
        Dim objeto As AcadEntity
        Dim linea As AcadLine
        Dim tipo As String = Nothing
        Dim handleSenal As String = Nothing

        For Each objeto In partesCompuerta
            If Not EsLinea(objeto) Then
                Continue For
            End If

            linea = objeto
            GetXData(linea, "TIPO", tipo)
            GetXData(linea, "SENAL", handleSenal)

            If tipo = "SALIDA" Then
                ' Se ha encontrado la terminal de salida y la señal correspondiente es handleSenal
                ' Si dicha señal no está vacía, la regresamos
                ' En caso contrario, la función regresa Nothing
                If handleSenal = "" Then
                    Return Nothing
                End If

                Exit For
            End If
        Next

        Return ObtenerObjetoDelHandle(handleSenal)
    End Function

    Private Function EsCompuertaDeUnaEntrada(tipoCompuerta As String) As Boolean
        Return tipoCompuerta = "NOT" OrElse tipoCompuerta = "SEG"
    End Function

    Private Function OperarCompuertaUnaria(tipoCompuerta As String,
                                           strEntrada As String) As String
        Dim Operacion As Func(Of Boolean, Boolean)
        Dim strSalida As String
        Dim caracter As Char
        Dim operado As Char

        Select Case tipoCompuerta
            Case "NOT"
                Operacion = AddressOf NegGate
            Case "SEG"
                Operacion = AddressOf SegGate
            Case Else
                Throw New ArgumentOutOfRangeException("tipoCompuerta")
        End Select

        strSalida = ""

        For Each caracter In strEntrada
            operado = BoolToChar(Operacion(CharToBool(caracter)))
            strSalida &= operado
        Next
        Return strSalida
    End Function

    Private Function OperarCompuertaMultiplesEntradas(tipoCompuerta As String,
                                                      entradas As IEnumerable(Of String)) As String
        Dim Operacion As Func(Of Boolean, Boolean, Boolean)
        Dim strAuxiliar As String
        Dim strEntrada As String
        Dim strSalida As String
        Dim a, b As Boolean
        Dim primeraEntrada As Boolean

        Select Case tipoCompuerta
            Case "AND", "NAND"
                Operacion = AddressOf AndGate
            Case "OR", "NOR"
                Operacion = AddressOf OrGate
            Case "XOR", "XNOR"
                Operacion = AddressOf XorGate
            Case Else
                Throw New ArgumentOutOfRangeException("tipoCompuerta")
        End Select

        primeraEntrada = True
        strSalida = ""

        For Each strEntrada In entradas

            If primeraEntrada Then
                strSalida = strEntrada
                primeraEntrada = False
            Else
                ' La salida de una etapa se convierte en entrada de la siguiente
                strAuxiliar = strSalida
                strSalida = ""
                EquilibrarLongitud(strEntrada, strAuxiliar)

                For i = 1 To strAuxiliar.Length
                    a = CharToBool(Strings.GetChar(strAuxiliar, i))
                    b = CharToBool(Strings.GetChar(strEntrada, i))
                    strSalida &= BoolToChar(Operacion(a, b))
                Next
            End If
        Next

        ' En compuertas con salida negada, la operación de negación se realiza al final
        If tipoCompuerta = "NAND" OrElse tipoCompuerta = "NOR" OrElse tipoCompuerta = "XNOR" Then
            strSalida = OperarCompuertaUnaria("NOT", strSalida)
        End If

        Return strSalida
    End Function

    Private Sub EquilibrarLongitud(ByRef strEntrada As String, ByRef strSalida As String)
        Dim diff As Integer
        Dim fill As String
        diff = Math.Abs(strEntrada.Length - strSalida.Length)

        If diff = 0 Then
            Return
        End If

        fill = New String("0", diff)

        If strEntrada.Length > strSalida.Length Then
            strSalida = fill & strSalida
        Else
            strEntrada = fill & strEntrada
        End If
    End Sub

    Private Function ObtenerObjetoDelHandle(handleSenal As String) As AcadEntity
        Return DOCUMENTO.HandleToObject(handleSenal)
    End Function

    Private Function CharToBool(c As Char) As Boolean
        Select Case c
            Case "0"
                Return False
            Case "1"
                Return True
        End Select
        Throw New ArgumentOutOfRangeException("c")
    End Function

    Private Function BoolToChar(a As Boolean) As Char
        Select Case a
            Case False
                Return "0"
            Case Else
                Return "1"
        End Select
    End Function

    Private Function SegGate(a As Boolean) As Boolean
        Return a
    End Function
    Private Function NegGate(a As Boolean) As Boolean
        Return Not a
    End Function

    Private Function AndGate(a As Boolean, b As Boolean) As Boolean
        Return a AndAlso b
    End Function
    Private Function OrGate(a As Boolean, b As Boolean) As Boolean
        Return a OrElse b
    End Function
    Private Function XorGate(a As Boolean, b As Boolean) As Boolean
        Return (a AndAlso Not b) OrElse (Not a AndAlso b)
    End Function

    Public Sub MostrarHandleSubentidad()
        ' Asigna una señal de entrada tipo string 010100101 a una pata de una compuerta
        ' La pata está indicada por una Atributo cuyo TAG es ENTRADA
        ' y el valor del atributo indica que pata es
        ' El archivo DWG que tiene el BLOQUE que requerimos se llama
        ' RESOLVIENDO UNA COMPUERTA AND y esta en el directorio de la UNAM (buscar en las subcadenas de proyectos

        Dim entidad As AcadEntity = Nothing

        AppActivateAutoCAD()
        Try
            GetSubentidad(entidad, "Selecciona la terminal de salida una compuerta ")
            MsgBox("El handle de la entidad es: " & entidad.Handle, MsgBoxStyle.Information, "CAD")
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    ' ---------------------------------------------------------------------------------------
    Public Sub AsociarTerminalesAlBloque()
        Dim objeto1 As AcadEntity
        Dim objeto2 As AcadEntity = Nothing
        Dim compuerta As AcadBlockReference
        Dim terminal As AcadLine
        Dim tipo As String = Nothing
        Dim numEntrada As Integer = 1
        Dim etiqueta As String

        Try
            AppActivateAutoCAD()
            objeto1 = GetEntidad("Seleccione una compuerta")

            If Not EsCompuerta(objeto1) Then
                Exit Sub
            End If
            compuerta = objeto1

            ' Asociar al diccionario la entrada 1

            GetSubentidad(objeto2, "Selecciona una terminal de la compuerta")
            While Not IsNothing(objeto2) AndAlso EsLinea(objeto2)
                terminal = objeto2
                GetXData(terminal, "TIPO", tipo)

                If tipo = "ENTRADA" Then
                    etiqueta = "ENTRADA-" & numEntrada
                    AddXdata(compuerta, etiqueta, terminal.Handle)
                    numEntrada += 1
                ElseIf tipo = "SALIDA" Then
                    AddXdata(compuerta, "SALIDA", terminal.Handle)
                End If

                GetSubentidad(objeto2, "Selecciona una terminal de la compuerta")
            End While
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    ' ------------------------------------------------------------------------------------------------
    ' Proyecto 1
    ' ------------------------------------------------------------------------------------------------
    Private Class ListaEntidades
        Implements IEnumerable

        Private ReadOnly handlesCompuertas As New List(Of String)

        Public Sub Add(compuerta As AcadEntity)
            handlesCompuertas.Add(compuerta.Handle)
        End Sub

        Public Sub AddRange(handlesNuevos As IEnumerable(Of String))
            handlesCompuertas.AddRange(handlesNuevos)
        End Sub

        Public Function Contains(compuerta As AcadEntity) As Boolean
            Return handlesCompuertas.Contains(compuerta.Handle)
        End Function

        Public Function Count() As Integer
            Return handlesCompuertas.Count()
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Dim handle As String
            Dim compuerta As AcadEntity

            For Each handle In handlesCompuertas
                compuerta = ObtenerObjetoDelHandle(handle)
                Yield compuerta
            Next
        End Function
    End Class

    Public Sub AsociarTextoSalida()
        ' Permite especificar el texto en el que poner el resultado
        ' de una compuerta

        Dim entidad As AcadEntity
        Dim texto As AcadEntity

        AppActivateAutoCAD()
        Try
            entidad = GetEntidad("Selecciona la terminal de una compuerta ")
            If EsBloque(entidad) Then
                texto = GetEntidad("Selecciona el texto Decimal salida ")
                If EsTexto(texto) Then
                    AddXdata(entidad, "TEXTO_SALIDA", texto.Handle)
                End If
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try

    End Sub

    Private Function AniadirSeparadoPorComa(cadena As String, nuevoElemento As String) As String
        Dim resultado As String
        If IsNothing(cadena) OrElse cadena = "" Then
            resultado = nuevoElemento
        Else
            resultado = cadena & "," & nuevoElemento
        End If
        Return resultado
    End Function

    Public Sub AsociarEntradas()
        ' Asigna la entradas de la compuerta actual

        Dim entidad As AcadEntity
        Dim compuerta As AcadBlockReference
        Dim entrada As AcadEntity
        Dim handlesEntradas As String = ""
        Dim handlesSubsecuentes As String = Nothing
        Dim numEntradas As Integer
        Dim i As Integer

        AppActivateAutoCAD()
        Try
            entidad = GetEntidad("Seleccina la compuerta")
            ' El objeto base seleccionado tiene que ser una compuerta
            If EsCompuerta(entidad) Then
                compuerta = entidad

                numEntradas = NumEntradasCompuerta(compuerta)

                For i = 1 To numEntradas
                    ' Cada objeto que se marque como "entrada" puede ser una compuerta
                    ' o un simple texto que indique la secuencia binaria de la señal
                    entrada = GetEntidad("Selecciona une entrada")

                    If Not EntradaValida(entrada) Then
                        MsgBox("Tipo de objeto incorrecto", MsgBoxStyle.Information, "CAD")
                        i -= 1 ' No tonamos en cuenta este objeto
                    ElseIf compuerta.Handle <> entrada.Handle Then
                        ' Se asigna una lista separada por comas de handles de los subsecuentes
                        ' hasta que se termine el ciclo al seleccionar un objeto inválido
                        handlesEntradas = AniadirSeparadoPorComa(handlesEntradas, entrada.Handle)

                        ' Además del enlace desde la compuerta a sus entradas, también se añade
                        ' el enlace en la dirección contraria (una compuerta de entrada marca como "subsecuente"
                        ' a la compuerta actual)
                        If EsCompuerta(entrada) Then
                            GetXData(entrada, "SUBSECUENTES", handlesSubsecuentes)
                            handlesSubsecuentes = AniadirSeparadoPorComa(handlesSubsecuentes, compuerta.Handle)
                            AddXdata(entrada, "SUBSECUENTES", handlesSubsecuentes)
                        End If
                    Else
                        MsgBox("No se puede usar la misma compuerta como entrada", MsgBoxStyle.Information, "CAD")
                        i -= 1 ' No tonamos en cuenta esta entrada
                    End If
                Next

                ' Asignando al atributo la lista de handles a la entrada "ENTRADAS"
                AddXdata(compuerta, "ENTRADAS", handlesEntradas)
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    Public Sub BorrarEnlacesCompuertas()
        Dim elementos As AcadSelectionSet
        Dim elemento As AcadEntity
        elementos = GetConjunto("Seleccione compuertas para borrar sus enlaces")
        For Each elemento In elementos
            If EsCompuerta(elemento) Then
                AddXdata(elemento, "ENTRADAS", "")
                AddXdata(elemento, "SUBSECUENTES", "")
                AddXdata(elemento, "TEXTO_SALIDA", "")
            End If
        Next
    End Sub

    Public Sub ResolverCircuito()
        Dim objeto As AcadEntity
        Dim compuerta As AcadBlockReference
        Dim compuertasCircuito As ListaEntidades
        Dim salidas As ListaEntidades
        Dim s As AcadBlockReference

        ' Obteniendo una compuerta desde la cual comenzar
        ' el análisis
        objeto = GetEntidad("Seleccione una compuerta de la red")
        If Not EsCompuerta(objeto) Then
            Exit Sub
        End If
        compuerta = objeto

        ' Obtener todas las compuertas de la red a partir de la
        ' compuerta inicial
        compuertasCircuito = ObtenerCompuertasCircuito(compuerta)

        ' Filtramos solo las salidas, a partir de las cuales se va a comenzar
        ' la resolución
        salidas = ObtenerSoloSalidas(compuertasCircuito)

        If salidas.Count() = 0 Then
            MsgBox("No se han encontrado compuertas terminales que resolver, probablemente existan ciclos", MsgBoxStyle.Information, "CAD")
            Exit Sub
        End If

        ' La resolución solo se va a efectuar una vez por cada 
        ' compuerta. La forma de marcar cosas ya resueltas será
        ' irlas añadiendo a una lista
        For Each s In salidas
            ResolverCompuerta(s)
        Next
    End Sub

    Private Sub ResolverCompuerta(compuerta As AcadBlockReference)
        Dim compuertasResueltas As New ListaEntidades
        Dim compuertasVisitadas As New ListaEntidades
        Dim exito As Boolean
        exito = ResolverCompuertaAux(compuerta, compuertasResueltas, compuertasVisitadas)

        If Not exito Then
            MsgBox("No fue posible resolver el circuito, probablemente tenga ciclos", MsgBoxStyle.Information, "CAD")
        End If
    End Sub

    Private Function ObtenerCompuertasCircuito(compuertaDePartida As AcadBlockReference) As ListaEntidades
        Dim compuertasCircuito As New ListaEntidades
        ObtenerCompuertasCircuitoAux(compuertaDePartida, compuertasCircuito)
        Return compuertasCircuito
    End Function

    Private Sub ObtenerCompuertasCircuitoAux(compuerta As AcadBlockReference,
                                          ByRef compuertasVisitadas As ListaEntidades)
        Dim entradas As ListaEntidades
        Dim subsecuentes As ListaEntidades
        Dim entidad As AcadEntity

        compuertasVisitadas.Add(compuerta)

        ' Obteniendo terminales internas de la compuerta
        entradas = ObtenerEntradas(compuerta)
        subsecuentes = ObtenerSubsecuentes(compuerta)

        ' Visitamos compuertas en dirección a las entradas

        For Each entidad In entradas
            ' Hay entradas que son texto y otras que son compuertas
            ' Los textos no los requerimos guardar en la lista por lo
            ' que no entramos a la condición
            If EsCompuerta(entidad) Then
                ' Si una compuerta ya está visitada no la volvemos a visitar
                If Not compuertasVisitadas.Contains(entidad) Then
                    ObtenerCompuertasCircuitoAux(entidad, compuertasVisitadas)
                End If
            End If
        Next

        ' Visitamos compuertas en dirección a las salidas
        For Each entidad In subsecuentes
            ' Las subsecuentes siempre deben de ser compuertas
            If Not compuertasVisitadas.Contains(entidad) Then
                ObtenerCompuertasCircuitoAux(entidad, compuertasVisitadas)
            End If
        Next

    End Sub


    Private Function ObtenerListaEntidadesDelDiccionario(compuerta As AcadBlockReference,
                                                         entradaDiccionario As String)
        Dim handlesSubsecuentes As String = Nothing
        Dim resultado As New ListaEntidades
        ' Se obtiene una lista de handles separados por coma del diccionario
        ' del objeto
        GetXData(compuerta, entradaDiccionario, handlesSubsecuentes)
        ' Se separan los handles en un arreglo y se añaden a la lista resultante
        resultado.AddRange(SepararHandles(handlesSubsecuentes))
        Return resultado
    End Function

    Private Function ObtenerEntradas(compuerta As AcadBlockReference) As ListaEntidades
        Return ObtenerListaEntidadesDelDiccionario(compuerta, "ENTRADAS")
    End Function

    Private Function ObtenerSubsecuentes(compuerta As AcadBlockReference) As ListaEntidades
        Return ObtenerListaEntidadesDelDiccionario(compuerta, "SUBSECUENTES")
    End Function

    Private Function SepararHandles(handlesSeparadosComa As String) As String()
        If IsNothing(handlesSeparadosComa) OrElse handlesSeparadosComa = "" Then
            Return New String() {} ' Ningún elemento que regresar
        End If
        Return handlesSeparadosComa.Split(",")
    End Function

    Private Function ObtenerSoloSalidas(compuertasRed As ListaEntidades) As ListaEntidades
        Dim salidas As New ListaEntidades
        For Each compuerta In compuertasRed
            If EsSalida(compuerta) Then
                salidas.Add(compuerta)
            End If
        Next
        Return salidas
    End Function

    Private Function EsSalida(compuerta As AcadBlockReference) As Boolean
        Dim subsecuentes As ListaEntidades
        subsecuentes = ObtenerSubsecuentes(compuerta)
        ' Las compuertas que no tengan handles subsecuentes que
        ' dependan de ellas son consideradas verdadereas "salidas"
        ' El resto son compuertas intermedias
        Return subsecuentes.Count() = 0
    End Function

    Private Function ResolverCompuertaAux(compuerta As AcadBlockReference,
                                     resueltas As ListaEntidades,
                                     visitadas As ListaEntidades) As Boolean
        Dim entradas As ListaEntidades
        Dim entrada As AcadEntity
        Dim tipoCompuerta As String
        Dim senalesEntrada As List(Of String)
        Dim strEntrada As String
        Dim strSalida As String
        Dim textoSalida As AcadText
        Dim exito As Boolean

        If visitadas.Contains(compuerta) Then
            Return False
        End If

        visitadas.Add(compuerta)

        entradas = ObtenerEntradas(compuerta)

        ' Resolvemos recursivamente las entradas que sean compuertas.
        ' Si la entrada no es una compuerta entonces es un texto, lo cual
        ' se considera ya resuelto
        For Each entrada In entradas

            If EsCompuerta(entrada) Then
                If Not resueltas.Contains(entrada) Then
                    exito = ResolverCompuertaAux(entrada, resueltas, visitadas)

                    If Not exito Then
                        Return False
                    End If
                End If
            End If

        Next

        ' Ya resueltas todas las entradas, podemos tomar su señal sin problema
        ' Procedemos a resolver la compuerta actual
        tipoCompuerta = ObtenerTipoCompuerta(compuerta)
        senalesEntrada = ObtenerSenalesEntrada(entradas)
        If EsCompuertaDeUnaEntrada(tipoCompuerta) Then
            strEntrada = senalesEntrada(0)
            strSalida = OperarCompuertaUnaria(tipoCompuerta, strEntrada)
        Else
            strSalida = OperarCompuertaMultiplesEntradas(tipoCompuerta, senalesEntrada)
        End If

        ' Mostrar el resultado en autocad
        textoSalida = ObtenerAcadTextSenal(compuerta)
        textoSalida.TextString = strSalida
        textoSalida.Update()

        ' Marcamos la compuerta como completada para no volverla a calcular
        resueltas.Add(compuerta)

        Return True
    End Function

    Public Sub ReiniciarCircuito()
        Dim compuerta As AcadEntity
        Dim texto As AcadText
        Dim c As AcadEntity
        ' Se parte de cualquier compuerta del circuito
        compuerta = GetEntidad("Selecciona una compuerta del circuito")
        If Not EsCompuerta(compuerta) Then
            Exit Sub
        End If

        For Each c In ObtenerCompuertasCircuito(compuerta)
            texto = ObtenerAcadTextSenal(c)
            texto.TextString = "???"
            texto.Update()
        Next
    End Sub

    Private Function ObtenerSenalesEntrada(entradas As ListaEntidades) As List(Of String)
        Dim entrada As AcadEntity
        Dim texto As AcadText
        Dim resultado As New List(Of String)

        For Each entrada In entradas
            texto = ObtenerAcadTextSenal(entrada)
            resultado.Add(texto.TextString)
        Next
        Return resultado
    End Function

    Private Function ObtenerAcadTextSenal(entrada As AcadEntity) As AcadText
        Dim handle As String = Nothing
        Dim texto As AcadText
        ' La entrada puede ser una compuerta o simplemente un texto
        ' Si es una compuerta, dicha compuerta tiene asociada una salida
        ' de tipo texto
        If EsCompuerta(entrada) Then
            GetXData(entrada, "TEXTO_SALIDA", handle)
            texto = ObtenerObjetoDelHandle(handle)
        Else
            texto = entrada
        End If
        Return texto
    End Function

End Module