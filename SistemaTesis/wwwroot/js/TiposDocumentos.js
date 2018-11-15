﻿var localStorage = window.localStorage;

class TiposDocumentos {

    constructor(descripcion, estado, action) {
        this.descripcion = descripcion;
        this.estado = estado;
        this.action = action;
    }

    agregarTipoDocumento(id, funcion) {
        if (this.descripcion == "") {
            document.getElementById("Descripcion").focus();
        } else {
            if (this.estado == "0") {
                document.getElementById("mensaje").innerHTML = "Seleccione un estado";
            } else {
                var descripcion = this.descripcion;
                var estado = this.estado;
                var action = this.action;
                var mensaje = '';
                $.ajax({
                    type: "POST",
                    url: action,
                    data: {
                        id, descripcion, estado, funcion
                    },
                    success: (response) => {
                        $.each(response, (index, val) => {
                            mensaje = val.code;
                        });
                        if (mensaje === "Save") {
                            this.restablecer();
                        } else {
                            document.getElementById("mensaje").innerHTML = "No se puede guardar el tipo de documento";
                        }
                        //console.log(response);
                    }
                });
            }
        }
    }

    filtrarTiposDocumentos(numPagina, order) {
        var valor = this.descripcion;
        var action = this.action;
        if (valor == "") {
            valor = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { valor, numPagina, order },
            success: (response) => {
                console.log(response);
                $.each(response, (index, val) => {
                    $("#resultSearch").html(val[0]);
                    $("#paginado").html(val[1]);
                });

            }
        });
    }

    qetTipoDocumento(id, funcion) {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);
                if (funcion == 0) {
                    if (response[0].estado) {
                        document.getElementById("titleTipoDocumento").innerHTML = "¿Está seguro(a) de desactivar el tipo de documento? " + response[0].descripcion;
                    } else {
                        document.getElementById("titleTipoDocumento").innerHTML = "¿Está seguro(a) de habilitar el tipo de documento? " + response[0].descripcion;
                    }
                } else {
                    document.getElementById("Descripcion").value = response[0].descripcion;
                    if (response[0].estado) {
                        document.getElementById("Estado").selectedIndex = 1;
                    } else {
                        document.getElementById("Estado").selectedIndex = 2;
                    }
                }
                localStorage.setItem("tipoDocumento", JSON.stringify(response));
            }
        });
    }

    editarTipoDocumento(id, funcion) {
        var action = this.action;
        var response = JSON.parse(localStorage.getItem("tipoDocumento"));
        var descripcion = response[0].descripcion;
        var estado = response[0].estado;
        localStorage.removeItem("tipoDocumento");
        $.ajax({
            type: "POST",
            url: action,
            data: { id, descripcion, estado, funcion },
            success: (response) => {
                console.log(response);
                this.restablecer();
            }
        });
    }

    restablecer() {
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("Estado").selectedIndex = 0;
        $('#modalTiposDocumentos').modal('hide');
        $('#ModalEstadoTipoDocumento').modal('hide');
        filtrarTiposDocumentos(1, "descripcion");
    }
}
