// Funciones Generales

$('#modalEditar').on('shown.bs.modal', function () {
    $('#myInput').focus()
});

$('#modalProvincias').on('shown.bs.modal', function () {
    $('#Nombre').focus();
});

$('#modalTiposDocumentos').on('shown.bs.modal', function () {
    $('#Descripcion').focus();
})

$('#modalCantones').on('shown.bs.modal', function () {
    $('#Nombre').focus();
});

$('#modalDistritos').on('shown.bs.modal', function () {
    $('#Nombre').focus();
});

$('#modalAsentamientos').on('shown.bs.modal', function () {
    $('#Nombre').focus();
});

$('#modalAmenazas').on('shown.bs.modal', function () {
    $('#Descripcion').focus();
});

$('#modalCatalogo').on('shown.bs.modal', function () {
    $('#Descripcion').focus();
});

$().ready(() => {
    var URLactual = window.location;
    document.getElementById("filtrar").focus();

    switch (URLactual.pathname) {
        case "/Asentamientos":
            getAsentamientoProvincias(0, 0);
            getAsentamientoTiposDocumentos(0, 0);
            //filtrarAsentamientos(1, "nombre");
            break;
        case "/Amenazas":
            filtrarAmenazas(1, "descripcion");
            break;
        case "/Provincias":
            filtrarProvincias(1, "nombre");
            break;
        case "/TiposDocumentos":
            filtrarTiposDocumentos(1, "descripcion");
            break;
        case "/Cantones":
            getProvincias(0, 0);
            filtrarCanton(1, "nombre");
            break;
        case "/CatalogosAmenazas":
            getAmenazas(0, 0);
            filtrarCatalogo(1, "descripcion");
            break;
        case "/Distritos":
            getDistritoProvincias(0, 0);
            filtrarDistrito(1, "nombre");
            break;
    }
});

var funcion = 0;

/*
 * Mantenimiento Módulos de Usuarios
 */

function getUsuario(id, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            mostrarUsuario(response);
        }

    });
}
var items;
var j = 0;
//Variables globales por cada propiedad del usuario
var id;
var userName;
var email;
var phoneNumber;
var role;
var selectRole;

//Otras variables donde almacenaremos los datos del registro, pero estos datos no serán modificados
var accessFailedCount;
var concurrencyStamp;
var emailConfirmed;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var phoneNumberConfirmed;
var securityStamp;
var twoFactorEnabled;

function mostrarUsuario(response) {
    items = response;
    j = 0;
    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        x.remove(i);
    }

    $.each(items, function (index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
        document.getElementById('Select').options[0] = new Option(val.role, val.roleId);

        //Mostrar los detalles del usuario
        $("#dEmail").text(val.email);
        $("#dUserName").text(val.userName);
        $("#dPhoneNumber").text(val.phoneNumber);
        $("#dRole").text(val.role);

        // Mostrar los datos que deseo eliminar
        $("#eUsuario").text(val.email);
        $('input[name=EIdUsuario]').val(val.id);
    });
}

function getRoles(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j == 0) {
                for (var i = 0; i < response.length; i++) {
                    document.getElementById('Select').options[i] = new Option(response[i].text, response[i].value);
                    document.getElementById('SelectNuevo').options[i] = new Option(response[i].text, response[i].value);
                }
                j = 1;
            }
        }
    });
}

function editarUsuario(action) {
    //Obtenemos los datos del input respectivo del formulario
    id = $('input[name=Id]')[0].value;
    email = $('input[name=Email]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;
    role = document.getElementById('Select');
    selectRole = role.options[role.selectedIndex].text;

    $.each(items, function (index, val) {
        accessFailedCount = val.accessFailedCount;
        concurrencyStamp = val.concurrencyStamp;
        emailConfirmed = val.emailConfirmed;
        lockoutEnabled = val.lockoutEnabled;
        lockoutEnd = val.lockoutEnd;
        userName = val.userName;
        normalizedUserName = val.normalizedUserName;
        normalizedEmail = val.normalizedEmail;
        passwordHash = val.passwordHash;
        phoneNumberConfirmed = val.phoneNumberConfirmed;
        securityStamp = val.securityStamp;
        twoFactorEnabled = val.twoFactorEnabled;
    });
    $.ajax({
        type: "POST",
        url: action,
        data: {
            id, userName, email, phoneNumber, accessFailedCount,
            concurrencyStamp, emailConfirmed, lockoutEnabled, lockoutEnd,
            normalizedEmail, normalizedUserName, passwordHash, phoneNumberConfirmed,
            securityStamp, twoFactorEnabled, selectRole
        },
        success: function (response) {
            if (response == "Save") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede editar los datos del usuario");
            }
        }
    });

}

function ocultarDetalleUsuario() {
    $("#modalDetalle").modal("hide");
}

function eliminarUsuario(action) {
    var id = $('input[name=EIdUsuario]')[0].value;
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            if (response === "Delete") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede eliminar el registro");
            }
        }
    });
}

function crearUsuario(action) {
    // Obtener los datos ingresados en los inputs respectivos
    email = $('input[name=EmailNuevo]')[0].value;
    phoneNumber = $('input[name=PhoneNumberNuevo]')[0].value;
    passwordHash = $('input[name=PasswordHashNuevo]')[0].value;
    role = document.getElementById('SelectNuevo');
    selectRole = role.options[role.selectedIndex].text;

    // Vamos a validar ahora que los datos del usuario no estén vacíos
    if (email == "") {
        $('#EmailNuevo').focus();
        alert("Ingrese el email del usuario");
    }
    else {
        if (passwordHash == "") {
            $('#PasswordHashNuevo').focus();
            alert("Ingrese el password del usuario");
        }
        else {
            $.ajax({
                type: "POST",
                url: action,
                data: {
                    email, phoneNumber, passwordHash, selectRole
                },
                success: function (response) {
                    if (response == "Save") {
                        window.location.href = "Usuarios";
                    }
                    else {
                        $("#mensajenuevo").html("No se puede guardar el usuario. <br/>Seleccione un rol. <br/> Ingrese un email correcto. <br/> La contraseña debe tener de 6-100 caracteres, al menos un caracter especial, una letra mayúscula y un número");
                    }
                }
            })
        }
    }
}

/*
 * Mantenimiento Módulo Provincias
 */

var idProvincia;

var agregarProvincia = () => {
    var nombre = document.getElementById("Nombre").value;
    var estados = document.getElementById('Estado');
    var estado = estados.options[estados.selectedIndex].value;
    if (funcion == 0) {
        var action = 'Provincias/guardarProvincia';
    } else {
        var action = 'Provincias/editarProvincia';
    }
    var provincia = new Provincias(nombre, estado, action);
    provincia.agregarProvincia(idProvincia, funcion);
}

var filtrarProvincias = (numPagina, order) => {
    var valor = document.getElementById("filtrar").value;
    var action = 'Provincias/filtrarProvincias';
    var provincia = new Provincias(valor, "", action);
    provincia.filtrarProvincias(numPagina, order);
}

var editarEstadoProvincia = (id, fun) => {
    idProvincia = id;
    funcion = fun;
    var action = 'Provincias/getProvincias';
    var provincia = new Provincias("", "", action);
    provincia.qetProvincia(id, funcion);
}

var editarProvincia = () => {
    var action = 'Provincias/editarProvincia';
    var provincia = new Provincias("", "", action);
    provincia.editarProvincia(idProvincia, funcion);
}


/*
 * Mantenimiento Módulo Amenazas
 */

var idAmenaza;

var agregarAmenaza = () => {
    var descripcion = document.getElementById("Descripcion").value;
    var porcentaje = document.getElementById("Porcentaje").value;
    var estados = document.getElementById('Estado');
    var estado = estados.options[estados.selectedIndex].value;
    if (funcion == 0) {
        var action = 'Amenazas/guardarAmenaza';
    } else {
        var action = 'Amenazas/editarAmenaza';
    }
    var amenaza = new Amenazas(descripcion, porcentaje, estado, action);
    amenaza.agregarAmenaza(idAmenaza, funcion);
}

var filtrarAmenazas = (numPagina, order) => {
    var valor = document.getElementById("filtrar").value;
    var action = 'Amenazas/filtrarAmenazas';
    var amenaza = new Amenazas(valor, "", "", action);
    amenaza.filtrarAmenazas(numPagina, order);
}

var editarEstadoAmenaza = (id, fun) => {
    idAmenaza = id;
    funcion = fun;
    var action = 'Amenazas/getAmenazas';
    var amenaza = new Amenazas("", "", "", action);
    amenaza.qetAmenaza(id, funcion);
}

var editarAmenaza = () => {
    var action = 'Amenazas/editarAmenaza';
    var amenaza = new Amenazas("", "", "", action);
    amenaza.editarAmenaza(idAmenaza, funcion);
}
/*
 * Mantenimiento Módulo Tipos Documentos
 */

var idTipoDocumento;

var agregarTipoDocumento = () => {
    var descripcion = document.getElementById("Descripcion").value;
    var estados = document.getElementById('Estado');
    var estado = estados.options[estados.selectedIndex].value;
    if (funcion == 0) {
        var action = 'TiposDocumentos/guardarTipoDocumento';
    } else {
        var action = 'TiposDocumentos/editarTipoDocumento';
    }
    var tipoDocumento = new TiposDocumentos(descripcion, estado, action);
    tipoDocumento.agregarTipoDocumento(idTipoDocumento, funcion);
}

var filtrarTiposDocumentos = (numPagina, order) => {
    var valor = document.getElementById("filtrar").value;
    var action = 'TiposDocumentos/filtrarTiposDocumentos';
    var tipoDocumento = new TiposDocumentos(valor, "", action);
    tipoDocumento.filtrarTiposDocumentos(numPagina, order);
}

var editarEstadoTipoDocumento = (id, fun) => {
    idTipoDocumento = id;
    funcion = fun;
    var action = 'TiposDocumentos/getTiposDocumentos';
    var tipoDocumento = new TiposDocumentos("", "", action);
    tipoDocumento.qetTipoDocumento(id, funcion);
}

var editarTipoDocumento = () => {
    var action = 'TiposDocumentos/editarTipoDocumento';
    var tipoDocumento = new TiposDocumentos("", "", action);
    tipoDocumento.editarTipoDocumento(idTipoDocumento, funcion);
}

/*
 * Mantenimiento Módulo Cantones
 */

var idCanton;

var getProvincias = (id, fun) => {
    var action = 'Cantones/getProvincias';
    var cantones = new Cantones("", "", "", action);
    cantones.getProvincias(id, fun);
}

var agregarCanton = () => {
    if (funcion == 0) {
        var action = 'Cantones/agregarCanton';
    } else {
        var action = "Cantones/editarCanton";
    }

    var nombre = document.getElementById("Nombre").value;
    var estado = document.getElementById("Estado").checked
    var provincias = document.getElementById('ProvinciaCantones');
    var provincia = provincias.options[provincias.selectedIndex].value;
    var cantones = new Cantones(nombre, estado, provincia, action);
    cantones.agregarCanton(idCanton, funcion);
    funcion = 0;
}

var filtrarCanton = (numPagina, order) => {
    var action = 'Cantones/filtrarCanton';
    var valor = document.getElementById("filtrar").value;
    var cantones = new Cantones(valor, "", "", action);
    if (funcion == 0) {
        cantones.filtrarCanton(numPagina, order);
    }
}

var editarEstadoCanton = (id, fun) => {
    funcion = fun;
    idCanton = id;
    var action = 'Cantones/getCantones';
    var cantones = new Cantones("", "", "", action);
    cantones.getCantones(id, fun);
}

var editarEstadoCanton1 = () => {
    var action = 'Cantones/editarCanton';
    var cantones = new Cantones("", "", "", action);
    cantones.editarEstadoCanton(idCanton, funcion);
}

var restablecerCantones = () => {
    var cantones = new Cantones("", "", "");
    cantones.restablecer();
}

/*
 * Mantenimiento Módulo Catalogo Amenazas
 */

var idCatalogo;

var getAmenazas = (id, fun) => {
    var action = 'CatalogosAmenazas/getAmenazas';
    var catalogos = new CatalogosAmenazas("", "", "", "", action);
    catalogos.getAmenazas(id, fun);
}

var agregarCatalogo = () => {
    if (funcion == 0) {
        var action = 'CatalogosAmenazas/agregarCatalogo';
    } else {
        var action = "CatalogosAmenazas/editarCatalogo";
    }
    var descripcion = document.getElementById("Descripcion").value;
    var estado = document.getElementById("Estado").checked
    var amenazas = document.getElementById('AmenazaCatalogo');
    var amenaza = amenazas.options[amenazas.selectedIndex].value;
    var porcentaje = document.getElementById("Porcentaje").value;
    var catalogos = new CatalogosAmenazas(descripcion, estado, amenaza, porcentaje, action);
    catalogos.agregarCatalogo(idCatalogo, funcion);
    funcion = 0;
}

var filtrarCatalogo = (numPagina, order) => {
    var action = 'CatalogosAmenazas/filtrarCatalogo';
    var valor = document.getElementById("filtrar").value;
    var catalogos = new CatalogosAmenazas(valor, "", "", "", action);
    if (funcion == 0) {
        catalogos.filtrarCatalogo(numPagina, order);
    }
}

var editarEstadoCatalogo = (id, fun) => {
    funcion = fun;
    idCatalogo = id;
    var action = 'CatalogosAmenazas/getCatalogos';
    var catalogos = new CatalogosAmenazas("", "", "", "", action);
    catalogos.getCatalogos(id, fun);
}

var editarEstadoCatalogo1 = () => {
    var action = 'CatalogosAmenazas/editarCatalogo';
    var catalogos = new CatalogosAmenazas("", "", "", "", action);
    catalogos.editarEstadoCatalogo(idCatalogo, funcion);
}

var restablecerCatalogos = () => {
    var catalogos = new CatalogosAmenazas("", "", "", "", "");
    catalogos.restablecer();
}

/*
 * Mantenimiento Módulo Distritos
 */

var idDistrito;

var getDistritoProvincias = (id, fun) => {
    var action = 'Distritos/getProvincias';
    var distritos = new Distritos("", "", "", "", action);
    distritos.getDistritoProvincias(id, fun);
}

var agregarDistrito = () => {
    if (funcion == 0) {
        var action = 'Distritos/agregarDistrito';
    } else {
        var action = 'Distritos/editarDistrito';
    }
    var nombre = document.getElementById("Nombre").value;
    var estado = document.getElementById("Estado").checked
    var provincias = document.getElementById('ProvinciaDistritos');
    var provincia = provincias.options[provincias.selectedIndex].value;
    var cantones = document.getElementById("CantonDistritos");
    var canton = cantones.options[cantones.selectedIndex].value;
    var distritos = new Distritos(nombre, estado, provincia, canton, action);
    distritos.agregarDistrito(idDistrito, funcion);
    funcion = 0;
}

var filtrarDistrito = (numPagina, order) => {
    var action = 'Distritos/filtrarDistrito';
    var valor = document.getElementById("filtrar").value;
    var distritos = new Distritos(valor, "", "", "", action);
    if (funcion == 0) {
        distritos.filtrarDistrito(numPagina, order);
    }
}

var editarEstadoDistrito = (id, fun) => {
    funcion = fun;
    idDistrito = id;
    var action = 'Distritos/getDistritos';
    var distritos = new Distritos("", "", "", "", action);
    distritos.getDistritos(id, fun);
}

var editarEstadoDistrito1 = () => {
    var action = 'Distritos/editarDistrito';
    var distritos = new Distritos("", "", "", "", action);
    distritos.editarEstadoDistrito(idDistrito, funcion);
}

var restablecerDistritos = () => {
    var distritos = new Distritos("", "", "", "");
    distritos.restablecer();
}

/*
 * Mantenimiento Módulo Asentamientos
 */

var idAsentamiento;

var getAsentamientoProvincias = (id, fun) => {
    var action = 'Asentamientos/getProvincias';
    var asentamientos = new Asentamientos("", "", "", "", "", "", "", "", "", "", "", "", action);
    asentamientos.getAsentamientoProvincias(id, fun);
}

var getAsentamientoTiposDocumentos = (id, fun) => {
    var action = 'Asentamientos/getTiposDocumentos';
    var asentamientos = new Asentamientos("", "", "", "", "", "", "", "", "", "", "", "", action);
    asentamientos.getAsentamientoTiposDocumentos(id, fun);
}

var agregarAsentamiento = () => {
    if (funcion == 0) {
        var action = 'Asentamientos/agregarAsentamiento';
    } else {
        var action = 'Asentamientos/editarAsentamiento';
    }
    var nombre = document.getElementById("Nombre").value;
    var provincias = document.getElementById('ProvinciaDistritos');
    var provincia = provincias.options[provincias.selectedIndex].value;
    var cantones = document.getElementById('CantonDistritos');
    var canton = cantones.options[cantones.selectedIndex].value;
    var distritos = document.getElementById('DistritoAsentamientos');
    var distrito = distritos.options[distritos.selectedIndex].value;
    var direccion = document.getElementById("Direccion").value;
    var coordenadas = document.getElementById("Coordenadas").value;
    var nombrePropietario = document.getElementById("NombrePropietario").value;
    var apellidosPropietario = document.getElementById("ApellidosPropietario").value;
    var tiposDocumentos = document.getElementById('DistritoTipoDocumento');
    var tipoDocumento = tiposDocumentos.options[tiposDocumentos.selectedIndex].value;
    var numDocumento = document.getElementById("NumDocumento");
    var estado = document.getElementById("Estado").checked
    var asentamientos = new Asentamientos(nombre, estado, provincia, canton, distrito, direccion, coordenadas, nombrePropietario, apellidosPropietario, tipoDocumento, action);
    asentamientos.agregarAsentamiento(idAsentamiento, funcion);
    funcion = 0;
}

var filtrarAsentamiento = (numPagina, order) => {
    var action = 'Asentamientos/filtrarAsentamiento';
    var valor = document.getElementById("filtrar").value;
    var asentamientos = new Asentamientos(valor, "", "", "", "", "", "", "", "", "", "", "", action);
    if (funcion == 0) {
        asentamientos.filtrarAsentamiento(numPagina, order);
    }
}

var editarEstadoAsentamiento = (id, fun) => {
    funcion = fun;
    idAsentamiento = id;
    var action = 'Asentamientos/getAsentamientos';
    var asentamientos = new Asentamientos("", "", "", "", "", "", "", "", "", "", "", "", action);
    asentamientos.getAsentamientos(id, fun);
}

var editarEstadoAsentamiento1 = () => {
    var action = 'Asentamientos/editarAsentamiento';
    var asentamientos = new Asentamientos("", "", "", "", "", "", "", "", "", "", "", "", action);
    asentamientos.editarEstadoAsentamiento(idAsentamiento, funcion);
}

var restablecerAsentamientos = () => {
    var asentamientos = new Asentamientos("", "", "", "", "", "", "", "", "", "", "", "");
    asentamientos.restablecer();
}



