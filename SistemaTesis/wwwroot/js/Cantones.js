var promesa = new Promise((resolve, reject) => {

});

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
                document.getElementById('ProvinciaCantones').options[0] = new Option("[Seleccione una provincia]", 0);
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

    getCantones(id, funcion) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                if (funcion == 0) {
                    if (response[0].estado) {
                        document.getElementById("titleCanton").innerHTML = "Esta seguro de desactivar el canton " + response[0].nombre;
                    } else {
                        document.getElementById("titleCanton").innerHTML = "Esta seguro de habilitar el canton " + response[0].nombre;
                    }
                    promesa = Promise.resolve({
                        id: response[0].provinciaID,
                        nombre: response[0].nombre,                        
                        estado: response[0].estado,
                        provincia: response[0].provinciaID
                    });
                } else {
                    document.getElementById("Nombre").value = response[0].nombre;
                    getProvincias(response[0].provinciaID, 1);
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

    editarEstadoCanton(id, funcion) {
        var nombre, estado, provincia;
        var action = this.action;
        promesa.then(data => {
            // id = data.id;
            nombre = data.nombre
            estado = data.estado;
            estado = data.estado;
            provincia = data.provincia;
            $.ajax({
                type: "POST",
                url: action,
                data: { id, nombre, estado, provincia, funcion },
                success: (response) => {
                    if (response[0].code == "Save") {
                        this.restablecer();
                    } else {
                        document.getElementById("titleCurso").innerHTML = response[0].description;
                    }
                }
            });
        });
    }

    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Estado").checked = false;
        document.getElementById('ProvinciaCantones').selectedIndex = 0;
        document.getElementById("mensaje").innerHTML = "";
        filtrarCanton(1, "nombre");
        $('#modalCantones').modal('hide');
        $('#ModalEstadoCanton').modal('hide');
        //$('.bs-example-modal-sm').modal('hide');
    }
}


