var promesa = new Promise((resolve, reject) => {

});


class Asentamientos {

    constructor(nombre, provincia, canton, distrito, direccion, longitud, latitud, nombrePropietario, apellidosPropietario, tipoDocumento, numDocumento, ocupacion, numViviendas, estado, action) {
        this.nombre = nombre;
        this.provincia = provincia;
        this.canton = canton;
        this.distrito = distrito;
        this.direccion = direccion;
        this.longitud = longitud;
        this.latitud = latitud;
        this.nombrePropietario = nombrePropietario;
        this.apellidosPropietario = apellidosPropietario;
        this.tipoDocumento = tipoDocumento;
        this.numDocumento = numDocumento;
        this.ocupacion = ocupacion;
        this.numViviendas = numViviendas;
        this.estado = estado;
        this.action = action;
    }

    getAsentamientoProvincias(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                document.getElementById('ProvinciaAsentamientos').options[0] = new Option("[Seleccione una provincia]", 0);
                
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('ProvinciaAsentamientos').options[count] = new Option(response[i].nombre, response[i].provinciaID);
                            count++;
                        } else {
                            if (id == response[i].provinciaID) {
                                document.getElementById('ProvinciaAsentamientos').options[0] = new Option(response[i].nombre, response[i].provinciaID);
                                document.getElementById('ProvinciaAsentamientos').selectedIndex = 0;
                                break;
                            }
                        }
                    }
                }
            }
        });
    }

    getAsentamientoTiposDocumentos(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                document.getElementById('TipoDocumentoAsentamientos').options[0] = new Option("[Seleccione un tipo de documento]", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('TipoDocumentoAsentamientos').options[count] = new Option(response[i].descripcion, response[i].tipoDocumentoID);
                            count++;
                        } else {
                            if (id == response[i].provinciaID) {
                                document.getElementById('TipoDocumentoAsentamientos').options[0] = new Option(response[i].descripcion, response[i].tipoDocumentoID);
                                document.getElementById('TipoDocumentoAsentamientos').selectedIndex = 0;
                                break;
                            }
                        }
                    }
                }
            }
        });
    }

    agregarAsentamiento(id, funcion) {
        if (this.nombre == "") {
            document.getElementById("mensaje").innerHTML = "Seleccione un nombre";
            document.getElementById("Nombre").focus();
        } else {
            if (this.provincia == "0") {
                document.getElementById("mensaje").innerHTML = "Seleccione una provincia";
            } else {
                if (this.canton == "0") {
                    document.getElementById("mensaje").innerHTML = "Seleccione un cantón";
                } else {
                    if (this.distrito == "0") {
                        document.getElementById("mensaje").innerHTML = "Seleccione un distrito";
                    } else {
                        if (this.direccion == "") {
                            document.getElementById("Direccion").focus();
                        } else {
                            if (this.nombrePropietario == "") {
                                document.getElementById("nombrePropietario").focus();
                            } else {
                                if (this.apellidosPropietario == "") {
                                    document.getElementById("nombrePropietario").focus();
                                } else {
                                    if (this.tipoDocumento == "0") {
                                        document.getElementById("mensaje").innerHTML = "Seleccione un tipo de documento";
                                    } else {
                                        if (this.numDocumento == "") {
                                            document.getElementById("numDocumento").focus();
                                        } else {
                                            if (this.ocupacion == "") {
                                                document.getElementById("mensaje").innerHTML = "Seleccione una fecha de ocupación";
                                            } else {
                                                if (this.numViviendas == "") {
                                                    document.getElementById("numDocumento").focus();
                                                } else {
                                                    var nombre = this.nombre;
                                                    var provincia = this.provincia;
                                                    var canton = this.canton;
                                                    var distrito = this.distrito;
                                                    var direccion = this.direccion;
                                                    var longitud = this.longitud;
                                                    var latitud = this.latitud;
                                                    var nombrePropietario = this.nombrePropietario;
                                                    var apellidosPropietario = this.apellidosPropietario;
                                                    var tipoDocumento = this.tipoDocumento;
                                                    var numDocumento = this.numDocumento;
                                                    var ocupacion = this.ocupacion;
                                                    var numViviendas = this.numViviendas;
                                                    var estado = this.estado;
                                                    var action = this.action;
                                                    $.ajax({
                                                        type: "POST",
                                                        url: action,
                                                        data: {
                                                            id, nombre, provincia, canton, distrito, direccion, longitud, latitud, nombrePropietario, apellidosPropietario,
                                                            tipoDocumento, numDocumento, ocupacion, numViviendas, estado, funcion
                                                        },
                                                        success: (response) => {
                                                            if ("Save" == response[0].code) {
                                                                this.restablecer();
                                                            } else {
                                                                document.getElementById("mensaje").innerHTML = "No se puede guardar el asentamiento";
                                                            }
                                                        }
                                                    });
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    filtrarAsentamiento(numPagina, order) {
        var valor = this.nombre;
        var action = this.action;
        var funcion = 1;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina, order, funcion },
            success: (response) => {
                $("#resultSearch").html(response[0][0]);
                $("#paginado").html(response[0][1]);
            }
        });
    }

    getAsentamientos(asentamientoID, funcion) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { asentamientoID },
            success: (response) => {
                console.log(response);
                if (funcion == 0) {
                    if (response[0].estado) {
                        document.getElementById("titleAsentamiento").innerHTML = "Esta seguro de desactivar el asentamiento " + response[0].nombre;
                    } else {
                        document.getElementById("titleAsentamiento").innerHTML = "Esta seguro de habilitar el asentamiento " + response[0].nombre;
                    }
                    promesa = Promise.resolve({
                        id: response[0].distritoID,
                        nombre: response[0].nombre,
                        provincia: response[0].provinciaID,
                        canton: response[0].cantonID,
                        distrito: response[0].distritoID,
                        direccion: response[0].direccion,
                        longitud: response[0].longitud,
                        latitud: response[0].latitud,
                        nombrePropietario: response[0].nombrePropietario,
                        apellidosPropietario: response[0].apellidosPropietario,
                        tipoDocumento: response[0].tipoDocumentoID,
                        numDocumento: response[0].numDocumento,
                        ocupacion: response[0].ocupacion,
                        numViviendas: response[0].numViviendas,
                        estado: response[0].estado,                        
                    });
                } else {
                    document.getElementById("Nombre").value = response[0].nombre;
                    getAsentamientoProvincias(response[0].provinciaID, 1);
                    getAsentamientoTiposDocumentos(response[0].tipoDocumentoID, 1);
                    document.getElementById("Direccion").value = response[0].direccion;
                    document.getElementById("Longitud").value = response[0].longitud;
                    document.getElementById("Latitud").value = response[0].latitud;
                    document.getElementById("NombrePropietario").value = response[0].nombrePropietario;
                    document.getElementById("ApellidosPropietario").value = response[0].apellidosPropietario;
                    document.getElementById("NumDocumento").value = response[0].numDocumento;
                    document.getElementById("Ocupacion").value = response[0].ocupacion;
                    document.getElementById("NumViviendas").value = response[0].numViviendas;
                    if (response[0].estado) {
                        document.getElementById("Estado").checked = true;
                    } else {
                        document.getElementById("Estado").checked = false;
                    }
                }
                //if (funcion == 2 || funcion == 3) {
                //    document.getElementById("cursoTitle").innerHTML = response[0].nombre;
                //}
            }
        });
    }

    editarEstadoAsentamiento(id, funcion) {
        var nombre, provincia, canton, distrito, direccion,
            longitud, latitud, nombrePropietario, apellidosPropietario,
            tipoDocumento, numDocumento, ocupacion, numViviendas,
            estado;
        var action = this.action;
        promesa.then(data => {
            // id = data.id;
            nombre = data.nombre;            
            provincia = data.provincia;
            canton = data.canton;
            distrito = data.distrito;
            direccion = data.direccion;
            longitud = data.longitud;
            latitud = data.latitud;
            nombrePropietario = data.nombrePropietario;
            apellidosPropietario = data.apellidosPropietario;
            tipoDocumento = data.tipoDocumento;
            numDocumento = data.numDocumento;
            ocupacion = data.ocupacion;
            numViviendas = data.numViviendas;
            estado = data.estado;
            $.ajax({
                type: "POST",
                url: action,
                data: {
                    id, nombre, provincia, canton, distrito, direccion,
                    longitud, latitud, nombrePropietario, apellidosPropietario,
                    tipoDocumento, numDocumento, ocupacion, numViviendas,
                    estado, funcion
                },
                success: (response) => {
                    if (response[0].code == "Save") {
                        this.restablecer();
                    } else {
                        document.getElementById("titleAsentamiento").innerHTML = response[0].description;
                    }
                }
            });
        });
    }

    restablecer() {
        document.getElementById("Nombre").value = "";        
        document.getElementById('ProvinciaAsentamientos').selectedIndex = 0;
        document.getElementById('CantonAsentamientos').selectedIndex = 0;
        document.getElementById('DistritoAsentamientos').selectedIndex = 0;
        document.getElementById("Direccion").value = "";
        document.getElementById("Longitud").value = "";
        document.getElementById("Latitud").value = "";
        document.getElementById("NombrePropietario").value = "";
        document.getElementById("ApellidosPropietario").value = "";
        document.getElementById('TipoDocumentoAsentamientos').selectedIndex = 0;
        document.getElementById("NumDocumento").value = "";
        document.getElementById("Ocupacion").value = "";
        document.getElementById("NumViviendas").value = "";
        document.getElementById("Estado").checked = false;
        document.getElementById("mensaje").innerHTML = "";
        filtrarAsentamiento(1, "nombre");
        $('#modalAsentamientos').modal('hide');
        $('#ModalEstadoAsentamiento').modal('hide');
    }
}

$('#ProvinciaAsentamientos').change(function () {
    var provinciaID = $(this).val();
    var count = 1;
    document.getElementById("CantonAsentamientos").innerHTML = "";
    $.ajax({
        type: "POST",
        url: "Asentamientos/getCantones?provinciaID=" + provinciaID,
        data: {},
        success: (response) => {
            //console.log(response);
            document.getElementById('CantonAsentamientos').options[0] = new Option("[Seleccione un cantón]", 0);
            if (0 < response.length) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('CantonAsentamientos').options[count] = new Option(response[i].nombre, response[i].cantonID);
                    count++;
                }
            }
        }
    });
});

$('#CantonAsentamientos').change(function () {
    var cantonID = $(this).val();
    var count = 1;
    document.getElementById("DistritoAsentamientos").innerHTML = "";
    $.ajax({
        type: "POST",
        url: "Asentamientos/getDistritos?cantonID=" + cantonID,
        data: {},
        success: (response) => {
            //console.log(response);
            document.getElementById('DistritoAsentamientos').options[0] = new Option("[Seleccione un distrito]", 0);
            if (0 < response.length) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('DistritoAsentamientos').options[count] = new Option(response[i].nombre, response[i].distritoID);
                    count++;
                }
            }
        }
    });
});