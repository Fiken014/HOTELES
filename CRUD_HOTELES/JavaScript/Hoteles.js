//Check
$(document).ready(function () {
    //Evaluamos la página en la que estamos para determinar si ejecuto o no una función o proceso específico
    var pageName = window.location.pathname.split('/').pop();

    if (pageName == "frmConsultaHoteles.aspx") {
        cargaListaHoteles();
    }
    else if (pageName == "frmMantenimientoHoteles.aspx") {
        obtieneDetalleHotel();
    }
});

function crearHotel() {
    //Al crear un registro nuevo, la cookie del identificador de la entidad vamos a ponerla en 0 
    //nombre, valor, [expiracion, path, domain]
    $.cookie("HOTUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoHoteles.aspx";
}

function regresar() {
    location.href = "frmConsultaHoteles.aspx";
}

function cargaListaHoteles() {
    $.cookie("HOTUNI", 0, { expires: TLTC, path: '/', domain: g_Dominio });


    // [0]=Codigo, [1]=Nombre, [2]=Estado
    var obj_Parametros_JS = [];
    obj_Parametros_JS[0] = $("#bsqCodigoHotel").val();
    obj_Parametros_JS[1] = $("#bsqNombreHotel").val();
    obj_Parametros_JS[2] = $("#bsqEstado").val();

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    // Validar sesión con GLBUNI, pero NO lo envíes como parámetro de filtro
    var usuario = $.cookie("GLBUNI");

    if ((usuario != 0) && (usuario != undefined)) {
        $.ajax({
            type: "POST",
            url: "frmConsultaHoteles.aspx/CargaListaHoteles",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;
                if (res === undefined) {
                    Swal.fire({ title: "Error en la conexión", text: "Error de conexión a la base de datos", icon: "error" });
                } else {
                    if (res === "No se encontraron registros") {
                        $("#tblHoteles").html("");
                        Swal.fire({ title: "Búsqueda de Registros", text: res, icon: "info" });
                    } else {
                        $("#tblHoteles").html(res);
                        paginar("#tblHoteles");
                    }
                }
            }
        });
    } else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        setTimeout(function () { location.href = "/Login/frmInicioSesion.aspx"; }, 4000);
    }
}

function defineHotel(uni) {
    $.cookie("HOTUNI", uni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoHoteles.aspx";
}

function obtieneDetalleHotel() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("HOTUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");
    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoHoteles.aspx/CargaInfoHoteles",
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

                    if (resultado === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        if (resultado != "") {
                            $("#txtCodigo").val(arreglo[1]);
                            $("#txtNombre").val(arreglo[2]);
                            $("#txtDescripcion").val(arreglo[3]);
                            $("#txtDireccion").val(arreglo[4]);
                            $("#txtTelefono").val(arreglo[5]);
                            $("#txtCorreo").val(arreglo[6]);
                            $("#txtUrl").val(arreglo[7]);
                            $("#txtArea").val(arreglo[8]);
                            $("#txtFecha").val(formatDate(arreglo[9]));
                            $("#cboEstado").val(arreglo[10]);

                        }
                    }
                }
            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function formatDate(dateStr) {
    var dateParts = dateStr.split("/");
    var day = dateParts[0].padStart(2, '0');
    var month = dateParts[1].padStart(2, '0');
    var year = dateParts[2];
    return `${year}-${month}-${day}`;
}

function mantenimientoHotel() {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("HOTUNI");
    obj_Parametros_JS[1] = $("#txtCodigo").val();
    obj_Parametros_JS[2] = $("#txtNombre").val();
    obj_Parametros_JS[3] = $("#txtDescripcion").val();
    obj_Parametros_JS[4] = $("#txtDireccion").val();
    obj_Parametros_JS[5] = $("#txtTelefono").val();
    obj_Parametros_JS[6] = $("#txtCorreo").val();
    obj_Parametros_JS[7] = $("#txtUrl").val();
    obj_Parametros_JS[8] = $("#txtArea").val();
    obj_Parametros_JS[9] = $("#txtFecha").val();
    obj_Parametros_JS[10] = $("#cboEstado").val();
    obj_Parametros_JS[11] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[11] != 0) && (obj_Parametros_JS[11] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoHoteles.aspx/MantenimientoHotel",
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

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: "center-center",
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        //Se redirecciona a la página de consulta
                        setTimeout(function () {
                            location.href = "frmConsultaHoteles.aspx";
                        }, 5000);
                    }
                    else {
                        Swal.fire({
                            title: "Información de Registros",
                            text: arreglo[1],
                            icon: "info"
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
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4000);
    }

}

function eliminaHotel(uni) {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoHoteles.aspx/eliminarHotel",
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

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: "center-center",
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        //Se redirecciona a la página de consulta
                        setTimeout(function () {
                            cargaListaHoteles();
                        }, 3000);
                    }
                    else {
                        Swal.fire({
                            title: "Información de Registros",
                            text: arreglo[1],
                            icon: "info"
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
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4000);
    }

}

function paginar(elemento) {


    var table;

    if ($.fn.DataTable.isDataTable(elemento)) {

        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });
    }
    else {
        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });

    }
    // Activación visual de Material Dashboard para inputs
    document.querySelectorAll('.input-group.input-group-outline .form-control').forEach(function (el) {
        const parent = el.closest('.input-group.input-group-outline');
        const toggle = () => parent.classList[el.value ? 'add' : 'remove']('is-filled');
        el.addEventListener('focus', () => parent.classList.add('is-focused'));
        el.addEventListener('blur', () => {
            parent.classList.remove('is-focused');
            toggle();
        });
        toggle();
    });


};