var g_Dominio = "localhost";
var TLTC = 60;

$(document).ready(function () {
    //Evaluamos la página en la que estamos para determinar si ejecuto o no una función o proceso específico
    var pageName = window.location.pathname.split('/').pop();

    if (pageName != "frmInicioSesion.aspx") {
        cargaOpcionesUsuarios();
    }
});

function cargaOpcionesUsuarios() {
    $("#nombreUsuario").html($.cookie("GLBDSC"));
    $("#emlUsuario").html($.cookie("GLBCOD"));
    $("#lblNombreUsuario").html($.cookie("GLBDSC"));
    $("#lblEmlUsuario").html($.cookie("GLBCOD"));
}


function inicioSesion() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#txtUsuario").val();
    obj_Parametros_JS[1] = $("#txtPassword").val();
    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    jQuery.ajax({
        type: "POST",
        url: "frmInicioSesion.aspx/InicioSesionUsuarios",
        data: parametros,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (msg) {
            var res = msg.d;

            if (res === undefined) {
                Swal.fire({
                    title: "Error en la conexión",
                    text: "Error de conexión a la base de datos",
                    icon: "error"
                });
            }
            else {
                var arreglo = new Array();
                var str;

                str = res;

                arreglo = (str.split("<SPLITER>"));
                var resultado = arreglo[0];

                if ((resultado != "-1") && (resultado != "0")) {
                    //nombre, valor, [expiracion, path, domain]
                    $.cookie("GLBUNI", arreglo[0], { expires: TLTC, path: '/', domain: g_Dominio });
                    $.cookie("GLBCOD", arreglo[2], { expires: TLTC, path: '/', domain: g_Dominio });
                    $.cookie("GLBDSC", arreglo[3], { expires: TLTC, path: '/', domain: g_Dominio });

                    Swal.fire({
                        position: 'center-center',
                        icon: 'success',
                        title: "Inicio de Sesión de Usuario",
                        text: arreglo[1],
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
                    });

                    setTimeout(function () {
                        location.href = "/Base/pages/dashboard.aspx";
                    }, 4000);
                }
                else {

                    Swal.fire({
                        position: 'center-center',
                        icon: 'error',
                        title: "Inicio de Sesión de Usuario",
                        text: arreglo[1],
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
                    });

                }
            }
        },
        failure: function (msg) {

        },
        error: function (msg) {

        }
    });

}