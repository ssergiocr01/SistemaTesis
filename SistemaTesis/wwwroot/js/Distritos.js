var promesa = new Promise((resolve, reject) => {

});


class Distritos {

    constructor(nombre, estado, provincia, canton, action) {
        this.nombre = nombre;
        this.estado = estado;
        this.provincia = provincia;
        this.canton = canton;
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
                document.getElementById('ProvinciaDistritos').options[0] = new Option("[Seleccione una provincia]", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (0 == funcion) {
                            document.getElementById('ProvinciaDistritos').options[count] = new Option(response[i].nombre, response[i].provinciaID);
                            count++;
                        } else {
                            if (id == response[i].provinciaID) {
                                document.getElementById('ProvinciaDistritos').options[0] = new Option(response[i].nombre, response[i].provinciaID);
                                document.getElementById('ProvinciaDistritos').selectedIndex = 0;
                                break;
                            }
                        }

                    }
                }
            }
        });
    }    

}

