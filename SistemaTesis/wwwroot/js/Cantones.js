
class Cantones {
    constructor(nombre, estado, provincia, action) {
        this.nombre = nombre;
        this.estado = estado;
        this.provincia = provincia;
        this.action = action;
    }

    getProvincias(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                //console.log(response);
                document.getElementById('ProvinciaCantones').options[0] = new Option("Seleccione una provincia", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('ProvinciaCantones').options[count] = new Option(response[i].nombre, response[i].provinciaID);
                            count++;
                        } else {
                            if (id == response[i].provinciaID) {
                                document.getElementById('ProvinciaCantones').options[0] = new Option(response[i].nombre, response[i].provinciaID);
                                document.getElementById('ProvinciaCantones').selectedIndex = 0;
                                break;
                            }
                        }

                    }
                }
            }
        });
    }

    agregarCanton(id, funcion) {
        if (this.nombre == "") {
            document.getElementById("Nombre").focus();
        } else {
            if (this.provincia == "0") {
                document.getElementById("mensaje").innerHTML = "Seleccione una provincia";
            } else {
                var nombre = this.nombre;
                var estado = this.estado;
                var provincia = this.provincia;
                var action = this.action;
                //console.log(nombre);
                $.ajax({
                    type: "POST",
                    url: action,
                    data: {
                        id, nombre, estado, provincia, funcion
                    },
                    success: (response) => {
                        if ("Save" == response[0].code) {
                            this.restablecer();
                        } else {
                            document.getElementById("mensaje").innerHTML = "No se puede guardar el cantón";
                        }
                    }
                });
            }
        }
    }

    filtrarCanton(numPagina, order) {
        var valor = this.nombre;
        var action = this.action;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina, order },
            success: (response) => {
                $("#resultSearch").html(response[0]);
                $("#paginado").html(response[0]);
            }
        });
    }

    restablecer() {
        document.getElementById("Nombre").value = "";        
        document.getElementById("Estado").checked = false;
        document.getElementById('ProvinciaCantones').selectedIndex = 0;
        document.getElementById("mensaje").innerHTML = "";
        //filtrarCanton(1, "nombre");
        $('#modalCantones').modal('hide');
        //$('#ModalEstadoCurso').modal('hide');
        //$('.bs-example-modal-sm').modal('hide');
    }
}


