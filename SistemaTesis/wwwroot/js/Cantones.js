
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
                document.getElementById('ProvinciaCantones').options[0] = new Option("[Seleccione una provincia...]", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('ProvinciaCantones').options[count] = new Option(response[i].nombre, response[i].provinciaID);
                            count++;
                        } else {
                            if (id == response[i].categoriaID) {
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




}
