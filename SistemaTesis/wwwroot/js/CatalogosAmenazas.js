var promesa = new Promise((resolve, reject) => {

});

class CatalogosAmenazas {
    constructor(descripcion, estado, amenaza, porcentaje, action) {
        this.descripcion = descripcion;
        this.estado = estado;
        this.amenaza = amenaza;
        this.porcentaje = porcentaje;
        this.action = action;
    }

    getAmenazas(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                document.getElementById('AmenazaCatalogo').options[0] = new Option("[Seleccione una amenaza]", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('AmenazaCatalogo').options[count] = new Option(response[i].descripcion, response[i].amenazaID);
                            count++;
                        } else {
                            if (id == response[i].provinciaID) {
                                document.getElementById('AmenazaCatalogo').options[0] = new Option(response[i].descripcion, response[i].amenazaID);
                                document.getElementById('AmenazaCatalogo').selectedIndex = 0;
                                break;
                            }
                        }

                    }
                }
            }
        });
    }

    agregarCatalogo(id, funcion) {
        if (this.descripcion == "") {
            document.getElementById("Descripcion").focus();
        } else {
            if (this.amenaza == "0") {
                document.getElementById("mensaje").innerHTML = "Seleccione una amenaza";
            } else {
                if (this.porcentaje == "") {
                    document.getElementById("Porcentaje").focus();
                } else {
                    var descripcion = this.descripcion;
                    var estado = this.estado;
                    var amenaza = this.amenaza;
                    var porcentaje = this.porcentaje;
                    var action = this.action;
                    //console.log(nombre);
                    $.ajax({
                        type: "POST",
                        url: action,
                        data: {
                            id, descripcion, estado, amenaza, porcentaje, funcion
                        },
                        success: (response) => {
                            if ("Save" == response[0].code) {
                                this.restablecer();
                            } else {
                                document.getElementById("mensaje").innerHTML = "No se puede guardar la opción";
                            }
                        }
                    });
                }
            }
        }
    }

    filtrarCatalogo(numPagina, order) {
        var valor = this.descripcion;
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

    getCatalogos(id, funcion) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                if (funcion == 0) {
                    if (response[0].estado) {
                        document.getElementById("titleCatalogo").innerHTML = "Esta seguro de desactivar la opcion " + response[0].descripcion;
                    } else {
                        document.getElementById("titleCatalogo").innerHTML = "Esta seguro de habilitar la opcion " + response[0].descripcion;
                    }
                    promesa = Promise.resolve({
                        id: response[0].catalogoAmenazaID,
                        descripcion: response[0].descripcion,
                        estado: response[0].estado,
                        amenaza: response[0].amenazaID,
                        porcentaje: response[0].porcentaje,
                    });
                } else {
                    document.getElementById("Descripcion").value = response[0].descripcion;
                    getAmenazas(response[0].amenazaID, 1);
                    if (response[0].estado) {
                        document.getElementById("Estado").checked = true;
                    } else {
                        document.getElementById("Estado").checked = false;
                    }
                    document.getElementById("Porcentaje").value = response[0].porcentaje;
                }
                //if (funcion == 2 || funcion == 3) {
                //    document.getElementById("cursoTitle").innerHTML = response[0].nombre;
                //}
            }
        });
    }

    editarEstadoCatalogo(id, funcion) {
        var descripcion, estado, amenaza, porcentaje;
        var action = this.action;
        promesa.then(data => {
            // id = data.id;
            descripcion = data.descripcion
            estado = data.estado;
            estado = data.estado;
            amenaza = data.amenaza;
            porcentaje = data.porcentaje;
            $.ajax({
                type: "POST",
                url: action,
                data: { id, descripcion, estado, amenaza, porcentaje, funcion },
                success: (response) => {
                    if (response[0].code == "Save") {
                        this.restablecer();
                    } else {
                        document.getElementById("titleCatalogo").innerHTML = response[0].description;
                    }
                }
            });
        });
    }

    restablecer() {
        document.getElementById("Descripcion").value = "";
        document.getElementById("Estado").checked = false;
        document.getElementById('AmenazaCatalogo').selectedIndex = 0;
        document.getElementById('Porcentaje').value = "";
        document.getElementById("mensaje").innerHTML = "";
        filtrarCatalogo(1, "descripcion");
        $('#modalCatalogo').modal('hide');
        $('#ModalEstadoCatalogo').modal('hide');
        //$('.bs-example-modal-sm').modal('hide');
    }
}


