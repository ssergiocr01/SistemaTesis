var promesa = new Promise((resolve, reject) => {

});


class Asentamientos {

    constructor(nombre, provincia, canton, distrito, direccion, coordenadas, propietario, tipoDocumento, numDocumento, ocupacion, numViviendas, estado, action) {
        this.nombre = nombre;
        this.provincia = provincia;
        this.canton = canton;
        this.distrito = distrito;
        this.direccion = direccion;
        this.coordenadas = coordenadas;
        this.propietario = propietario;
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