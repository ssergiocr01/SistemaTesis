// Funciones Generales

$('#modalEditar').on('shown.bs.modal', function () {
    $('#myInput').focus()
});

$('#modalProvincias').on('shown.bs.modal', function () {
    $('#Nombre').focus();
});

$('#modalCantones').on('shown.bs.modal', function () {
    $('#Nombre').focus();
});

$('#modalDistritos').on('shown.bs.modal', function () {
    $('#Nombre').focus();
})

$().ready(() => {
    var URLactual = window.location;
    document.getElementById("filtrar").focus();

    switch (URLactual.pathname) {
        case "/Provincias":
            filtrarProvincias(1, "nombre");
            break;
        case "/Cantones":
            getProvincias(0, 0);
            filtrarCanton(1, "nombre");
            break;
        case "/Distritos":
            getDistritoProvincias(0, 0);
            //getCantones(0, 0);
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
        var action = "Distritos/editarDistrito";
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
    var distritos = new Distritos("", "","", "");
    distritos.restablecer();
}



