
/*
 * Librerias Personalizadas para Doc4us de Javascript y jquery
 * http://www.doc4us.com.co/
 *
 * Copyright (c) 2020 Oscar Mauricio Cortes
 *
 * Fecha: Marzo 25 de 2020
 * Version: 1.0.0
 */


function attachClipboardProgresBar() {
    TXTextControl.addEventListener("clipboardDataTransferStart", clipboardDataTransferStartHandler);
    TXTextControl.addEventListener("clipboardDataTransferComplete", clipboardDataTransferCompleteHandler);
    TXTextControl.addEventListener("clipboardDataTransferProgress", clipboardDataTransferProgressHandler);
    TXTextControl.addEventListener("clipboardDataTransferAborted", clipboardDataTransferAbortedHandler);

    $("#ribbonTabHome_tglBtnClientPaste").append("<div class='progress'><div class='progress-bar bg-success' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style='width: 0%'></div></div>");
}

function clipboardDataTransferStartHandler() {
    $(".progress-bar").attr("aria-valuenow", 0);
    $(".progress-bar").css("width", "0%");

    $(".progress-bar").removeClass("bg-success");
    $(".progress-bar").addClass("progress-bar-striped progress-bar-animated bg-danger");
}

function clipboardDataTransferCompleteHandler() {
    $(".progress-bar").removeClass("progress-bar-striped progress-bar-animated bg-danger");
    $(".progress-bar").addClass("bg-success");

    $(".progress-bar").attr("aria-valuenow", 100);
    $(".progress-bar").css("width", "100%");
}

function clipboardDataTransferProgressHandler(e) {
    $(".progress-bar").attr("aria-valuenow", e.progress);
    $(".progress-bar").css("width", e.progress + "%");
}

function clipboardDataTransferAbortedHandler() {
    clipboardDataTransferCompleteHandler();
}


(function ($) {



    /*
    *
    *  FUNCIONES globales o de carga general
    *
    */



    /*
    *
    *  DEFINICION DE VARIABLES GENERALES
    *
    */




    /*
    *
    *  EVENTOS DEL DOM  (Document Object Model)
    *
    */


    $(document).on("focus", ".datepicker", function () {
        $(this).datepicker();
    });

    //On your document ready function, add this:
    $('html').bind('keypress', function (e) {
        if (e.keyCode == 13) {
            // toastr.warning("segundo enter");
            return false;
        }
    });

    $(".onlyNumber").keydown(function (e) {
        ////
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) ||
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            ////
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    $(".NotEnter").keydown(function (e) {
        ////
        //toastr.warning(NotEnter)
        if (e.keyCode == 13) {
            return false;
        }

    });

    $("#To").css("display", "none");
    $("#To1").css("display", "none");
    $("#Cc").css("display", "none");
    $("#Search").css("display", "none");

    $("#UploadAnexos").css("display", "none");
    $("#SearchGroups").css("visibility", "hidden");
    $("#Botontercero").css("visibility", "hidden");
    $("#crearTerceroPara").css("display", "none");


    /*
    * 
    *  FUNCIONES
    * 
    */

    function LimpiarCombo(nombre) {
        var select = $(nombre);
        select.empty();
        select.append($('<option/>', {
            value: 0,
            text: "--Seleccione --"
        }));
        select.prop('disabled', 'disabled');
        select.trigger("chosen:updated");
        select.chosen({});
        OcultarLoading("LimpiarCombo");
    }
    function DeshabilitarCombo(nombre) {
        var select = $(nombre);
        select.prop('disabled', 'disabled');
        select.trigger("chosen:updated");
        $(nombre + " option[value=0]").attr("selected", "selected");
        select.chosen({});
        OcultarLoading("DeshabilitarCombo");
    }
    function HabilitarCombo(nombre) {
        var select = $(nombre);
        var valor = $(nombre + " option:selected").val();
        var valor1 = $(nombre).val();
        //var valor2 = $( nombre+" option:selected" ).text();
        //var valor3 = document.getElementById('dllTemas').value;
        select.attr('disabled', false);
        select.trigger("chosen:updated");
        select.chosen({});
        //var select = $(nombre+"_chosen");
        //select.removeClass("chosen-disabled");
        //$(nombre).prop('disabled', false);
        select.val(valor);
        select.trigger("chosen:updated");
        //OcultarLoading("HabilitarCombo");
    }
    function GotoLogon() {
        document.location.href = '@Url.Content("~/")Account/LogOn';

    }
    function ViewErrorLabel(Mensaje) {
        OcultarLoading("ViewErrorLabel");
        if (Mensaje != "") {
            $(".mensajeTimeOut").html(Mensaje);
            $(".mensajeTimeOut").css("display", "block");
        }
        else {
            $(".mensajeTimeOut").html("");
            $(".mensajeTimeOut").css("display", "none");
        }
    }
    function mostrarMetadatos(Mensaje) {

        $.getJSON("GetcamposMetadatos", { idDocumento:@Model.Documento.ID, date: new Date().getTime()
    },
    function (carData) {
        var documentos;
        var i = 0;
        var offset_key = 9;
        if (carData.Count < 0) {
            $("#divMetadatos").append(campo);
        }
        else {
            var campo = '<ul class="nav nav-list">';
            $.each(carData, function (index, itemData) {

                campo += '<li><h4 class="panel-title"><a href="#demo' + index + '" class="dropdown-toggle" data-toggle="collapse" data-parent="#accordion" data-target="#demo' + index + '"><span class="text-info">' + itemData.categoriaMetadatos.DESCRIPCION + '</span></a></h4>';
                campo += '<div id="demo' + index + '" class="panel-collapse collapse">';
                campo += '<table>';
                campo += '<tr>';
                campo += '<td>';
                for (var j = 0 in itemData.camposLST) {
                    campo += '<div class="control-group exp_group"><label id="camposMetadatosLST.camposLST[' + j + '].DESCRIPCION" name="camposLST[' + j + '].DESCRIPCION" contentplaceholder="camposLST[' + j + '].DESCRIPCION">' + itemData.camposLST[j].DESCRIPCION + '</label>';
                    var val_default = "";
                    if (itemData.camposLST[j].VALORDEFECTO != null || itemData.camposLST[j].VALORDEFECTO != "") val_default = itemData.camposLST[j].VALORDEFECTO;
                    //
                    if (itemData.camposLST[j].ID_TS_TIPOCAMPO == 1) {
                        if (@Model.Documento.ID == null)
            campo += '<div class="editor-field controls"><input type="text" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOINT" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOINT" contentplaceholder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + val_default + '" >';
                                else
            campo += '<div class="editor-field controls"><input type="text" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOINT" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOINT" contentplaceholder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + (itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOINT != null ? itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOINT : 0) + '" >';
        }
                            else if (itemData.camposLST[j].ID_TS_TIPOCAMPO == 2) {
            if (@Model.Documento.ID == null)
            campo += '<div class="editor-field controls"><input type="checkbox"  name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOBIT" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOBIT" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + val_default + '">';
                                else
            campo += '<div class="editor-field controls"><input type="checkbox"  name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOBIT" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOBIT" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + (itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOBIT != null ? itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOBIT : false) + '">';
        }
        else if (itemData.camposLST[j].ID_TS_TIPOCAMPO == 3) {
            if (@Model.Documento.ID == null)
            campo += '<div class="editor-field controls"><input type="file" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARBINARY" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARBINARY" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + val_default + '">';
                                else
            campo += '<div class="editor-field controls"><input type="file" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARBINARY" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARBINARY" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOVARBINARY + '">';
        }
        else if (itemData.camposLST[j].ID_TS_TIPOCAMPO == 4) {
            if (@Model.Documento.ID == null)
            campo += '<div class="editor-field controls"><input type="text" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARCHAR" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARCHAR" ContentPlaceHolder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + val_default + '">';
                                else
            campo += '<div class="editor-field controls"><input type="text" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARCHAR" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDOVARCHAR" ContentPlaceHolder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + (itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOVARCHAR != null ? itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDOVARCHAR : "") + '">';
        }
        else if (itemData.camposLST[j].ID_TS_TIPOCAMPO == 5) {
            if (@Model.Documento.ID == null)
            campo += '<div class="editor-field controls"><input type="text" class="datepicker" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" ContentPlaceHolder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + val_default + '">';
                                else
            var fechaa = itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDODATE;
            if (fechaa != null) {
                fechab = fechaa.replace(/[Date()//]/g, "");

                var fechac = new Date(Number(fechab));//new Date(Number(fechab)).toString();
                var year = fechac.getFullYear();
                var month = (1 + fechac.getMonth()).toString();
                month = month.length > 1 ? month : '0' + month;
                var day = fechac.getDate().toString();
                day = day.length > 1 ? day : '0' + day;
                var fechafin = year + '-' + month + '-' + day; //month + '/' + day + '/' + year;
                //campo += '<div class="editor-field controls"><input type="date" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" ContentPlaceHolder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + (itemData.camposLST[j].CONTENIDOMETADATOS.CONTENIDODATE) + '">';
                campo += '<div class="editor-field controls"><input type="text" class="datepicker" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" ContentPlaceHolder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value=' + fechafin + '>';
            }
            else {
                campo += '<div class="editor-field controls"><input type="text" class="datepicker" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].CONTENIDOMETADATOS.CONTENIDODATE" ContentPlaceHolder="camposLST[' + j + '].DESCRIPCION" tabindex="' + (offset_key + index) + '" acceskey="' + (offset_key + index) + '" value="' + val_default + '">';
            }
        }
        campo += '<input type="hidden" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].ID" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].ID" value=' + itemData.camposLST[j].ID + '>';
        campo += '<input type="hidden" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].ID_TS_TIPOCAMPO" id="camposMetadatosLST[' + index + '].camposLST[' + j + '].ID_TS_TIPOCAMPO" value=' + itemData.camposLST[j].ID_TS_TIPOCAMPO + '>';
        campo += '<input type="hidden" name="camposMetadatosLST[' + index + '].camposLST[' + j + '].CODIGO_INTERNO" id="camposMetadatosLST[' + index + '].camposLST[' + j + ']..CODIGO_INTERNO" value=' + itemData.camposLST[j].CODIGO_INTERNO + '>';
        campo += '</div>';
        campo += '</div>';
    }
    campo += '</td></tr>'
    campo += '</table>';
    campo += '</div>';
    campo += '</li>';
});
campo += '</ul>';
$('#divMetadatos').html('');
$("#divMetadatos").append(campo);
                }

               // OcultarLoading("GetcamposMetadatos");
            });

function changeIframeSrc(url) {
    document.getElementById('iframeTarget').src = url;
    $("#Editar1").modal('show');
}

function AsignarExpediente(url) {
    document.getElementById('iframeAsignarExpediente').src = url;
    $("#AsignarExpe").css("display", "block");
    return false;
}
function CerrarFrameAsigExpe() {
    $("#AsignarExpe").css("display", "none");
    return false;
}
TXTextControl.addEventListener("ribbonTabsLoaded", function (e) {
    attachEvents();
});
// this function attaches events after the ribbon has been loaded completely
function attachEvents() {
    // attach click event handler to 'load' button
    document.getElementById("fileMnuItemOpen").addEventListener("click", function (e) {
        waitForFileOpenDialog();
    });
    // attach click event handler to 'save' button, show an alert message box and
    // stop the bubbling of the click event to Web.TextControl
    document.getElementById("fileMnuItemSave").addEventListener("click", function (e) {
        jQueryAlert("TX Text Control", "Saving documents is not supported in this live demo.\r\n\Download the <a href='http://www.textcontrol.com/en_US/downloads/trials/index/default/dotnetserver/'>trial version</a> to learn more about the file management.");
        e.cancelBubble = true;
    });
}
// wait until the file open dialog is opened
function waitForFileOpenDialog() {
    var checkExist = setInterval(function () {
        if (document.getElementById("txOFDSelFileType") != null) {
            clearInterval(checkExist);
            reorderListView();
        }
    }, 100);
}
// select 'All Files' and fire the Change event to update the file list
function reorderListView() {
    setTimeout(function () { document.getElementById("txOFDSelFileType").selectedIndex = 0; fireEvent(document.getElementById("txOFDSelFileType"), "change"); }, 300);
}
// this function fires an event of a specific element
function fireEvent(element, event) {
    if (document.createEventObject) {
        // dispatch for IE
        var evt = document.createEventObject();
        return element.fireEvent('on' + event, evt);
    }
    else {
        // dispatch for firefox + others
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent(event, true, true);
        return !element.dispatchEvent(evt);
    }
}

//Funcion para saber cuando se termina de cargar una plantilla el text control
document.addEventListener("waitDialogMessageReceived", waitDialogHandler);
//document.getElementById("Borrador").addEventListener( "click" ,waitDialogHandler)


function waitDialogHandler(e) {
    var msg = e.detail;

    if (msg.hasOwnProperty("show")) {
        if (msg.show == false) {
            //toastr.warning("Plantilla Cargada!");
            $("#dllPlantillaEmpresa").focus();
            OcultarLoading("Funcion waitDialogHandler");
            $("#YaCargoPlantilla").val("SI");
        }
    }
}


function validarPlantillaCargada() {
    debugger;
    if ($("#YaCargoPlantilla").val() == "SI") {
        //toastr.warning("por fin cargada");
        return true;
    } else {
        //toastr.warning("NO ha cargado");
        OcultarLoading("validarPlantillaCargada");
        toastr.warning("Por favor espere a que cargue la plantilla y vuelva a intentarlo", "Validación");
        return false;
    }

    TXTextControl.addEventListener("ribbonTabsLoaded", function (e) { waitDialogHandler(); });
}

function OcultarLoading(smg) {

    let element = document.getElementById('loadingModal');
    let elementStyle = window.getComputedStyle(element);
    let elementDisplay = elementStyle.getPropertyValue('display');

    if (elementDisplay == "block") {
        //toastr.warning("Ocultando loadind desde:" + smg);
        $("#loadingModal").css("display", "none");
    }
}
function clearForm(form) {
    var myFormElement = document.getElementById(form);
    var elements = myFormElement.elements;
    myFormElement.reset();
    for (i = 0; i < elements.length; i++) {
        field_type = elements[i].type.toLowerCase();
        switch (field_type) {
            case "text":
            case "password":
            case "textarea":
                elements[i].value = "";
                break;
            case "radio":
            case "checkbox":
                if (elements[i].checked) {
                    elements[i].checked = false;
                }
                break;
            case "select-one":
            case "select-multi":
                elements[i].selectedIndex = 0;
                break;

            default:
                break;
        }
    }
    OcultarLoading("clearForm");
};

$('#FileUpload1').bind('change', function () {
    //this.files[0].size gets the size of your file.
    if (this.files[0].size > 8388608)//archivos menores de 8 megas
    {
        toastr.warning("El archivo debe ser maximo de 8 megas");
        $('#FileUpload1').val('');
        return false;
    }
    else {
        return true;
    }

    OcultarLoading("Funcion FileUpload1");
});
$('#SubmitBtnUploadFile').click(function () {
    if ($('#FileUpload1')[0].files.length == 0) {
        toastr.warning("Debe seleccionar un archivo");
        OcultarLoading("SubmitBtnUploadFile");
        return false;
    }

    OcultarLoading("SubmitBtnUploadFile");
});
$("#NumRadPadre").focusin(function () {
    ////
    if (!$(this).is('[readonly]')) {
        $("#btnCerrarBuscarDocumento2").modal();
        $('#fechainiBuscarDocumento').attr('readonly', false).datepicker({
            format: 'dd/mm/yyyy',
            autoclose: true
        });
        $('#fechafinBuscarDocumento').attr('readonly', false).datepicker({
            format: 'dd/mm/yyyy',
            autoclose: true
        });
        $('#fechainiBuscarDocumento').mask('99/99/9999');
        $('#fechafinBuscarDocumento').mask('99/99/9999');
    }
});

function replaceAllSubString(targetString, subString, replaceWith) {
    while (targetString.indexOf(subString) != -1) {
        targetString = targetString.replace(subString, replaceWith);
    }
    return targetString;
}




var idClaseDocumento = document.getElementById('dllClaseDocumento').value
if (idClaseDocumento == "") {
    OcultarLoading("document.Ready 1")
}


$("#tbl").load("_ObtenerContactoDestinatario", { Id: 0 }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });



if ('@ViewBag.IsTab' == 'True') { nextTab('@Model.Tab'); }
function nextTab(tabValue) {
    $('#test1 a').click(saveCacheStatus);
    $('#test2 a').click(saveCacheStatus);
    $('#test3 a').click(saveCacheStatus);
    $('#test4 a').click(saveCacheStatus);
}
function saveCacheStatus() {

    $("#txtContenido").val($("#editor1").html());
    $('#frmtype1').ajaxSubmit({
        url: 'saveCache', type: 'post',
        error: function (data) {
            GotoLogon();
        }
    });
    OcultarLoading("saveCacheStatus");
}

$("#input1").unbind();
$("#cadenaBuscarDocumento").unbind();

$('#input1').keypress(function (e) {
    if (e.which == 13) {
        var vFiltro = document.getElementById('input1').value;
        var vTipoCorrespondencia = document.getElementById('dllClaseDocumento').value;

        $("#message-list").load("Buscar", { filtro: vFiltro, tipoCorrespondencia: vTipoCorrespondencia }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
    }
});
$('#btnSearchDocumento').click(function () {
    var vFechaIni = document.getElementById('fechainiBuscarDocumento').value;
    var vFechaFin = document.getElementById('fechafinBuscarDocumento').value;
    var vBusqueda = document.getElementById('cadenaBuscarDocumento').value;
    var vNumeroRadicado = document.getElementById('numeroRadicadoBusqueda').value;
    var vContenido = document.getElementById('contenido ').value;
    var vDestinatario = document.getElementById('destinatario').value;
    $("#resultadobusquedadocumento").load("../correspondenciaElaborar/BuscarDocumentos", { fechaini: vFechaIni, fechafin: vFechaFin, busqueda: vBusqueda, NumeroRad: vNumeroRadicado, Contenido: vContenido, Destinatario: vDestinatario }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
});

$('#btnCerrar').click(function () {
    $("#message-list").load("LimpiarBuscar", function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
});

$("#To").click(function (e) {

    e.preventDefault();
    //
    var e = document.getElementById("dllDestinario");
    var j = document.getElementById("hfEntidadDepFrom");
    var idValue = e.options[e.selectedIndex].value;
    //var idEntidad = j.options[j.selectedIndex].value;
    var idEntidad = document.getElementById("hfEntidadDepFrom").value;
    var idTipoCorrespondencia = document.getElementById("dllClaseDocumento").value;

    var isGrupo = false;
    if (idTipoCorrespondencia > 0 && idValue > 0) {
        $("#tbl").load("../CorrespondenciaElaborar/_ContactoDestinatario", { idDestinatarioContacto: idValue, idEntidadDependencia: idEntidad, tipoCorrespondencia: idTipoCorrespondencia, Grupo: isGrupo }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
    }
    else {
        toastr.warning("Por Favor seleccione Clase de documento y el contacto", "Validación");
    };

    @*//jcb desabilita porque la plantilla solo se debe cargar desde el combo de seleccionar plantilla
                if (@ViewBag.Repetir != null && @ViewBag.Repetir != 1 ) {
    cargarplantilla();
}*@
OcultarLoading("#to.click");
        });

$("#To1").click(function (e) {

    //

    e.preventDefault();
    var e = document.getElementById("dllDestinario2");
    //var j = document.getElementById("dllEntidadDependencia2");
    var idValue = e.options[e.selectedIndex].value;
    //var idEntidad = j.options[j.selectedIndex].value;
    var idEntidad = document.getElementById("hfEntidadDepTo2").value;
    var idTipoCorrespondencia = 1;
    var isGrupo = false;
    if (idTipoCorrespondencia > 0 && idValue > 0) {
        $("#tbl").load("../CorrespondenciaElaborar/_ContactoDestinatario", { idDestinatarioContacto: idValue, idEntidadDependencia: idEntidad, tipoCorrespondencia: idTipoCorrespondencia, Grupo: isGrupo }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
    }
    else {
        toastr.warning("Por Favor seleccione Clase de documento y el contacto", "Validación");
    }
    OcultarLoading("#To1.click");
});
$("#ToGroup").click(function (e) {
    //
    e.preventDefault();
    var idValue = document.getElementById("ddlBusquedaGrupo").value;
    var idEntidad = 0;
    var idTipoCorrespondencia = document.getElementById("dllClaseDocumento").value;

    var isGrupo = true;
    if (idTipoCorrespondencia > 0 && idValue > 0) {
        $("#tbl").load("../CorrespondenciaElaborar/_ContactoDestinatario", { idDestinatarioContacto: idValue, idEntidadDependencia: idEntidad, tipoCorrespondencia: idTipoCorrespondencia, Grupo: isGrupo }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
        $("#myModalGrupos").modal('hide');
    }
    else {
        toastr.warning("Por Favor seleccione Clase de documento y grupo", "Validación");
    }
    OcultarLoading("#toGroup.click");
});

function getTareas() {
    $("#contentTareas").load("_Tareas", function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
}


$("#AddTarea").click(function () {
    getTareas();
});

$("#Cc").click(function (e) {
    e.preventDefault();
    var e = document.getElementById("dllDestinario");
    //var j = document.getElementById("dllEntidadDependencia");
    var idValue = e.options[e.selectedIndex].value;
    //var idEntidad = j.options[j.selectedIndex].value;
    var idEntidad = document.getElementById("hfEntidadDepFrom").value;

    var idTipoCorrespondencia = document.getElementById("dllClaseDocumento").value;

    var isGrupo = false;
    if (idTipoCorrespondencia > 0) {
        if (idValue != "") {
            $("#tbl").load("_ContactoDestinatarioCC", { idDestinatarioContacto: idValue, idEntidadDependencia: idEntidad, tipoCorrespondencia: idTipoCorrespondencia, Grupo: isGrupo }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
        } else {
            toastr.warning("Por favor seleccione un destinatario", "Validación");
        }
    } else {
        toastr.warning("Por Favor seleccione clase de documento", "Validación");

    }
    //jcb cargarplantilla();
    OcultarLoading("CC.Click");
});
$("#CcGroup").click(function (e) {
    e.preventDefault();
    var idValue = document.getElementById("ddlBusquedaGrupo").value;
    var idEntidad = 0;
    var idTipoCorrespondencia = document.getElementById("dllClaseDocumento").value;

    var isGrupo = true;
    if (idTipoCorrespondencia > 0) {
        $("#tbl").load("_ContactoDestinatarioCC", { idDestinatarioContacto: idValue, idEntidadDependencia: idEntidad, tipoCorrespondencia: idTipoCorrespondencia, Grupo: isGrupo }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
        $("#myModalGrupos").modal('hide');
    } else {
        z
    }
    OcultarLoading("CCGroup.Click");
});

$('#btnCerrarUploadFile').click(function () {
    OcultarLoading("btnCerrarUploadFile");
    clearForm('frmUploadFile');
});
$('#btnCerrarBuscarDocumento').click(function () {
    clearForm('frmBuscarDocumento');
});

$('#btnCerrarBuscarDocumento2').click(function () {
    OcultarLoading("Oculatando Previo");
});

$('#chkbox2').change(function () {
    var today = new Date();
    var dd = today.getDate();
    today.setDate(dd - 1);
    if ($(this).is(':checked')) {
        $('#FEsperada').attr('disabled', false).datepicker({
            format: 'dd/mm/yyyy',
            autoclose: true,
            startDate: today,
            mindate: today
        });
        $('#FEsperada').mask('99/99/9999');
        $("#FEsperada").datepicker({ startDate: today, mindate: today, autoclose: true });
        $('#FEsperada').datepicker.autoclose = true;
        $('#FEsperada').datepicker.mindate = today;
        $('#FEsperada').datepicker.startDate = today;
    }
    else {
        $('#FEsperada').attr('disabled', true);
        //$('#FEsperada').datepicker("remove").val("");
        $('#FEsperada').datepicker.empty = true;
        $('#FEsperada').text.value = "";
        //$('#FEsperada').attr('readonly', true).datepicker('remove').val(null);
    }
});
$("#FEsperada").on("keypress", function (event) {
    if (event.which < 47 || event.which > 57) {
        return false;
    }
});

$('#chkbox1').change(function () {
    if ($(this).is(':checked')) {
        $('#NumRadPadre').attr('disabled', false);
    } else {
        $('#NumRadPadre').attr('disabled', true);
        $('#NumRadPadre').val(null);
    }
});

function cargarDependenciaPARA(idModel) {
    if (idModel != null) {
        if (idModel > 0) {
            $.getJSON("ValidateEntidadDependenciaClaseDocumento", { idClaseDocumento: idModel },
                function (carData) {
                    /*Limpiamos los otros combos*/
                    LimpiarCombo("#dllDestinario");
                    var select = $("#dllEntidadDependencia");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));

                    /*Fin Funcion Original Limpiamos los otros combos*/
                    $.each(carData, function (index, itemData) {
                        select.append($('<option/>', {
                            value: itemData.ID,
                            text: itemData.NOMBRE
                        }));
                    });
                    select.trigger("chosen:updated");
                    select.chosen({});
                });
        }
        else {
            LimpiarCombo("#dllDestinario");
            DeshabilitarCombo("#dllDestinario");
        }
    }
    else {
        LimpiarCombo("#dllDestinario");
        DeshabilitarCombo("#dllDestinario");
    }
}

$("#To").css("display", "");
$("#To1").css("display", "none");
$("#Cc").css("display", "");
$("#UploadAnexos").css("display", "");
$("#Search").css("display", "");
$("#SearchGroups").css("visibility", "hidden");
$("#Botontercero").css("visibility", "visible");
$("#crearTerceroPara").css("display", "none");
$('#chkbox3').prop('checked', false);
$('#chkbox3').attr('disabled', true);
$("#div_CONCOPIAAINTERNO").css("display", "none");
$("#div_CONCOPIAAINTERNO2").css("display", "none");
//LimpiarCombo("#dllEntidadDependencia2");
//DeshabilitarCombo("#dllEntidadDependencia2");
//$('#dllEntidadDependencia2').attr('disabled', true);
LimpiarCombo("#dllDestinario2");
DeshabilitarCombo("#dllDestinario2");
$('#dllDestinario2').attr('disabled', true);
                            }
                            else if (idModel == 3) {
    $("#To").css("display", "");
    $("#To1").css("display", "");
    $("#Cc").css("display", "");
    $("#UploadAnexos").css("display", "");
    $("#Search").css("display", "");
    $("#SearchGroups").css("visibility", "hidden");
    $("#Botontercero").css("visibility", "visible");
    $("#crearTerceroPara").css("display", "");
    $('#chkbox3').attr('disabled', false);
    $("#div_CONCOPIAAINTERNO").css("display", "");
    $("#div_CONCOPIAAINTERNO2").css("display", "");
}
else {
    $("#To").css("display", "none");
    $("#To1").css("display", "none");
    $("#Cc").css("display", "none");
    $("#Search").css("display", "none");
    $("#SearchGroups").css("visibility", "hidden");
    $("#Botontercero").css("visibility", "hidden");
    $("#crearTerceroPara").css("display", "none");
    $('#chkbox3').prop('checked', false);
    $('#chkbox3').attr('disabled', true);
    $("#div_CONCOPIAAINTERNO").css("display", "none");
    $("#div_CONCOPIAAINTERNO2").css("display", "none");
    //LimpiarCombo("#dllEntidadDependencia2");
    //DeshabilitarCombo("#dllEntidadDependencia2");
    //$('#dllEntidadDependencia2').attr('disabled', true);
    LimpiarCombo("#dllDestinario2");
    DeshabilitarCombo("#dllDestinario2");
    $('#dllDestinario2').attr('disabled', true);
}
var vSucursal = @ViewBag.var_ID_TBR_SUCURSAL;
$.getJSON("ValidateTramiteClaseDocumento", { idClaseDocumento: idModel, IdSucursal: vSucursal },
    function (carData) {/*Limpiamos los otros combos*/
        var select = $("#dllTramite");
        select.empty();
        select.append($('<option/>', {
            value: 0,
            text: "--Seleccione --"
        }));
        /*Fin Funcion Original Limpiamos los otros combos*/
        $.each(carData, function (index, itemData) {
            select.append($('<option/>', {
                value: itemData.ID,
                text: itemData.NOMBRE
            }));
        });
        select.trigger("chosen:updated");
        select.chosen({});
    });

$("#tbl").load("_CleanContactoDestinatario", function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
$('#dllTramite').attr('disabled', false);
$('#dllRemitentes').attr('disabled', false);
//$('#dllEntidadDependencia').attr('disabled', false);
//$('#dllEntidadDependenciaDE').attr('disabled', false);
HabilitarCombo("#dllClaseCorrespon");
HabilitarCombo("#dllTemas");
$('#chkbox1').attr('disabled', false);
$('#chkbox2').attr('disabled', false);
                        }
                        else
{
    LimpiarCombo("#dllTramite");
    LimpiarCombo("#dllRemitentes");
    //LimpiarCombo("#dllEntidadDependencia");
    //LimpiarCombo("#dllEntidadDependencia2");
    //LimpiarCombo("#dllEntidadDependenciaDE");
    DeshabilitarCombo("#dllClaseCorrespon");
    DeshabilitarCombo("#dllTemas");
    $('#chkbox1').attr('disabled', 'disabled');
    $('#chkbox2').attr('disabled', 'disabled');
    $('#chkbox3').attr('disabled', 'disabled');
    $("#div_CONCOPIAAINTERNO").css("display", "none");
    $("#div_CONCOPIAAINTERNO2").css("display", "none");
    $("#To").css("display", "none");
    $("#To1").css("display", "none");
    $("#Cc").css("display", "none");
    $("#UploadAnexos").css("display", "none");
    $("#Search").css("display", "none");
    $("#SearchGroups").css("visibility", "hidden");
    $("#Botontercero").css("visibility", "hidden");
    $("#crearTerceroPara").css("display", "none");
}
                    }
                    else
{
    LimpiarCombo("#dllTramite");
    LimpiarCombo("#dllRemitentes");
    LimpiarCombo("#dllEntidadDependencia");
    //LimpiarCombo("#dllEntidadDependencia2");
    //LimpiarCombo("#dllEntidadDependenciaDE");
    DeshabilitarCombo("#dllClaseCorrespon");
    DeshabilitarCombo("#dllTemas");
    $('#chkbox1').attr('disabled', 'disabled');
    $('#chkbox2').attr('disabled', 'disabled');
    $('#chkbox3').attr('disabled', 'disabled');
    $("#div_CONCOPIAAINTERNO").css("display", "none");
    $("#div_CONCOPIAAINTERNO2").css("display", "none");
    $("#To").css("display", "none");
    $("#To1").css("display", "none");
    $("#Cc").css("display", "none");
    $("#UploadAnexos").css("display", "none");
    $("#Search").css("display", "none");
    $("#SearchGroups").css("visibility", "hidden");
    $("#Botontercero").css("visibility", "hidden");
    $("#crearTerceroPara").css("display", "none");
}

OcultarLoading("dllClaseDocumento.change");
                });

$("#previewPlantilla").click(function () {
    var idPlantilla = $("#dllPlantillaEmpresa").val();
    if (idPlantilla != "")
        $("#modalPreview").modal();
    var url;
    url = "previewPlantilla?idPlantilla=" + idPlantilla;
    document.getElementById('imgPreview').src = url;
});

$("#dllTramite").change(
    function () {
        var idModel = $(this).val();
        if (idModel != "") {
            if (idModel > 0) {
                var vSucursal = @ViewBag.var_ID_TBR_SUCURSAL;
                var myjson = null;
                var func = null;
                var sel = null;
                var idTipoCorrespondencia = document.getElementById("dllClaseDocumento").value;
                var isGrupo = false;
                document.getElementById("dllDestinario").disabled = false;
                $("#tbl").load("_ContactoDestinatario_clear", { id: idModel }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });
                $.getJSON("Tramitesdestinatarios", { idtramite: idModel }, function (json) {
                    myjson = json.Something;
                    sel = $("#dllEntidadDependencia").val(json);
                    //////
                    if (sel.val() != null) {
                        $.getJSON("ValidateContactoEntidadDependencia", { idEntidadDependencia: sel.val() }, function (carData) {
                            /*Limpiamos los otros combos*/
                            var select = $("#dllDestinario");
                            select.empty();
                            select.append($('<option/>', {
                                value: 0,
                                text: "--Seleccione --"
                            }));
                            $.each(carData, function (index, itemData) {
                                select.append($('<option/>', {
                                    value: itemData.ID,
                                    text: itemData.NOMBRE
                                }));
                            });
                            select.trigger("chosen:updated");
                            select.chosen({});
                        });
                    }
                    //
                    $.getJSON("Tramitesdestinatarios_fun", { idTramite: idModel, idClaseDocumento: idTipoCorrespondencia }, function (json2) {
                        func = json2.Something;
                        var fun = $("#dllDestinario").val(json2);
                        if (json2 != "0") {
                            $("#tbl").load("../CorrespondenciaElaborar/_ContactoDestinatario", { idDestinatarioContacto: json2, idEntidadDependencia: json, tipoCorrespondencia: idTipoCorrespondencia, Grupo: isGrupo }, function (response, status, xhr) { if (status == "error" && xhr.status == 409) GotoLogon(); else if (status == "error") ViewErrorLabel(response); });

                            if (idTipoCorrespondencia == 1) {

                                document.getElementById("dllDestinario").disabled = true;
                                //document.getElementById("dllEntidadDependencia").disabled = true;
                            }
                        }
                    });
                });
                $.ajax({
                    type: "POST",
                    async: true,
                    url: "GetPlantillaEmpresaByTramite",
                    contentType: 'application/json',
                    data: JSON.stringify({
                        IdTramite: idModel, idSucursal: vSucursal
                    }),
                    success: function (carData) {
                        /*Limpiamos los otros combos*/
                        var select = $("#dllPlantillaEmpresa");
                        select.empty();
                        select.append($('<option/>', {
                            value: 0,
                            text: "--Seleccione --"
                        }));
                        /*Fin Funcion Original Limpiamos los otros combos*/
                        $.each(carData, function (index, itemData) {
                            select.append($('<option/>', {
                                value: itemData.ID,
                                text: itemData.NOMBRE
                            }));
                        });
                        select.attr('disabled', false);
                        select.trigger("chosen:updated");
                        select.chosen({});
                    },
                    error: errorFunc
                });
                function errorFunc(jqXHR, textStatus, errorThrown) {
                    toastr.warning('GetPlantillaEmpresaByTramite: Error!!');
                }
                //-----------------------------//
                HabilitarCombo("#dllPlantillaEmpresa");
                HabilitarCombo("#dllMedioEnvio");
                HabilitarCombo("#dllGradoReserva");
                HabilitarCombo("#dllPriorida");
                HabilitarCombo("#ddlTabla");
                $('#Folios').attr('disabled', false);
                $('#ASUNTO').attr('disabled', false);
                $('#ContenidoResumen').attr('disabled', false);
            }
            else {
                LimpiarCombo("#dllPlantillaEmpresa");
                DeshabilitarCombo("#dllMedioEnvio");
                DeshabilitarCombo("#dllGradoReserva");
                DeshabilitarCombo("#dllPriorida");
                DeshabilitarCombo("#ddlTabla");
                DeshabilitarCombo("#ddlFondo");
                DeshabilitarCombo("#ddlDependendia");
                DeshabilitarCombo("#ddlSerie");
                $('#Folios').attr('disabled', 'disabled');
                $('#ASUNTO').attr('disabled', 'disabled');
                $('#ContenidoResumen').attr('disabled', 'disabled');
            }
        }
        else {
            LimpiarCombo("#dllPlantillaEmpresa");
            DeshabilitarCombo("#dllMedioEnvio");
            DeshabilitarCombo("#dllGradoReserva");
            DeshabilitarCombo("#dllPriorida");
            DeshabilitarCombo("#ddlTabla");
            DeshabilitarCombo("#ddlFondo");
            DeshabilitarCombo("#ddlDependendia");
            DeshabilitarCombo("#ddlSerie");
            $('#Folios').attr('disabled', 'disabled');
            $('#ASUNTO').attr('disabled', 'disabled');
            $('#ContenidoResumen').attr('disabled', 'disabled');
        }

        OcultarLoading("$(#dllTramite).change(");
    });

$("#dllEntidadDependencia").change(function () {
    var idModel = $(this).val();
    if (idModel != "") {
        if (idModel > 0) {
            var idFirmante = $("#dllRemitentes").val();
            $("#dllRemitentes").val();
            /*  ID  Descripcion
                1   Interna - Interna
                2   Externa - Interna
                3   Interna - Externa
            */
            var vTipoCorrespondenciapre = document.getElementById('dllClaseDocumento').value;
            $.getJSON("ValidateContactoEntidadDependencia", { idEntidadDependencia: idModel, idFirmante: idFirmante, idClaseDocumento: vTipoCorrespondenciapre },
                function (carData) {
                    /*Limpiamos los otros combos*/
                    var select = $("#dllDestinario");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccionar --"
                    }));
                    /*Fin Funcion Original Limpiamos los otros combos*/
                    $.each(carData, function (index, itemData) {
                        select.append($('<option/>', {
                            value: itemData.ID,
                            text: itemData.NOMBRE
                        }));
                    });
                    select.attr('disabled', false);
                    select.trigger("chosen:updated");
                    select.chosen({});
                });
        }
        else {
            LimpiarCombo("#dllDestinario");

        }
    }
    else {
        LimpiarCombo("#dllDestinario");

    }

});
               

$("#dllEntidadDependencia2").change(function () {
    var idModel = $(this).val();
    if (idModel != "") {
        if (idModel > 0) {
            var idFirmante = $("#dllRemitentes").val();
            var idinterno = 1;
            $.getJSON("ValidateContactoEntidadDependencia2", { idEntidadDependencia2: idModel, idFirmante: idFirmante, interno: idinterno },
                function (carData) {
                    /*Limpiamos los otros combos*/
                    var select = $("#dllDestinario2");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccionar--"
                    }));
                    /*Fin Funcion Original Limpiamos los otros combos*/
                    $.each(carData, function (index, itemData) {
                        select.append($('<option/>', {
                            value: itemData.ID,
                            text: itemData.NOMBRE
                        }));
                    });
                    select.attr('disabled', false);
                    select.trigger("chosen:updated");
                    select.chosen({});
                });
        }
        else {
            LimpiarCombo("#dllDestinario2");

        }
    }
    else {
        LimpiarCombo("#dllDestinario2");

    }
    OcultarLoading("$(#dllEntidadDependencia2).change");
});
$('#chkbox3').change(function () {
    if ($(this).is(':checked')) {
        //
        //$('#dllEntidadDependencia2').attr('disabled', false);
        $('#dllDestinario2').attr('disabled', false);
        $(function () {
            //
            $("#EntidadDependencia2").autocomplete({

                source: function (request, response) {
                    //
                    $.ajax({
                        url: '@Url.Action("ConsultarDE", "TP_TERCERO")',
                        datatype: "json",
                        data: {
                            filtro: request.term,
                            idClaseDocumento: document.getElementById('dllClaseDocumento').value
                        },
                        success: function (data) {
                            //
                            response($.map(data, function (item) {
                                //toastr.warning(item.ID);
                                //toastr.warning(val.ID);
                                return {

                                    label: item.NOMBRE,
                                    value: item.NOMBRE,
                                    Destinatario2: item.ID
                                };
                            }));

                        },
                        error: function (response) {
                            toastr.warning(response.responseText);
                        },
                        failure: function (response) {
                            toastr.warning(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("#hfEntidadDepTo2").val(i.item.Destinatario2);
                    //
                    var idModel = i.item.Destinatario2;
                    if (idModel != null) {
                        if (idModel > 0) {
                            /*  ID  Descripcion
                                1   Interna - Interna
                                2   Externa - Interna
                                3   Interna - Externa
                            */
                            $('#dllDestinario2').attr('disabled', false);
                            var vTipoCorrespondenciapre = document.getElementById('dllClaseDocumento').value;
                            $.getJSON("../CAD/ValidateContactoEntidadDependencia_all", { idEntidadDependencia: idModel, idClaseDocumento: 1 },
                                function (carData) {
                                    /*Limpiamos los otros combos*/
                                    var select = $("#dllDestinario2");
                                    select.empty();
                                    select.append($('<option/>', {
                                        value: 0,
                                        text: "--Seleccione --"
                                    }));
                                    /*Fin Funcion Original Limpiamos los otros combos*/
                                    $.each(carData, function (index, itemData) {
                                        select.append($('<option/>', {
                                            value: itemData.ID,
                                            text: itemData.NOMBRE
                                        }));
                                    });
                                    select.attr('disabled', false);
                                    select.trigger("chosen:updated");
                                    select.chosen({});
                                });
                        }
                        else {
                            toastr.warning("Es necesario limpiar el selector");
                            //LimpiarCombo("#dllDestinario");
                        }

                    }




                },
                minLength: 3,
                close: function () {
                    OcultarLoading("EntidadDependencia_remitente .autocomplete 1");
                }
            }).focus(function () {
                $(this).autocomplete("search");
            });
        });

        //HabilitarCombo("#dllEntidadDependencia2");
        //    $.getJSON("ValidateEntidadDependenciaClaseDocumento2", { idClaseDocumento2: 1 },
        //       function (carData) {
        //           /*Limpiamos los otros combos*/
        //           LimpiarCombo("#dllDestinario2");
        //           var select = $("#dllEntidadDependencia2");
        //           select.empty();
        //           select.append($('<option/>', {
        //               value: 0,
        //               text: "--Seleccionar--"
        //           }));
        //           /*Fin Funcion Original Limpiamos los otros combos*/
        //           $.each(carData, function (index, itemData) {
        //               select.append($('<option/>', {
        //                   value: itemData.ID,
        //                   text: itemData.NOMBRE
        //               }));
        //           });
        //           select.trigger("chosen:updated");
        //           select.chosen({});
        //       });
        //} else {
        //    $('#dllEntidadDependencia2').attr('disabled', false);
        //    //$('#dllDestinario2').attr('disabled', true);
        //    LimpiarCombo("#dllEntidadDependencia2");
        //    LimpiarCombo("#dllDestinario2");
        //    $('#dllEntidadDependencia2').val(null);
        //    $('#dllDestinario2').val(null);
    }
    OcultarLoading("$(#chkbox3).change(function ()");
});

$('#input1').placeholder('Criterio de Búsqueda');


$('#dllEntidadDependencia').val('');

$("#editor1").html($("#txtContenido").val());
//OcultarLoading("$(#editor1)");
$('[name="submit"]').bind('click', function (e) {
    $("#frmtype1").find(':input:disabled').attr("disabled", false);
    $("#txtContenido").val($("#editor1").html());
    $("#loadingModal").css("display", "block");
    switch ($(this).attr("value")) {
        case "act Radicar":
            if (confirm("¿Está seguro de querer radicar el documento?")) {
                return true;
            } else {
                OcultarLoading(" switch ($(this).attr(value))");
                e.preventDefault();
            }
            break;
    }
});

$("#enviar").click(function () {
    $("#submit").val("act Descartar2");
    $("#submit").trigger("click");
    OcultarLoading("$(#enviar).click");
});

$("#dllPlantillaEmpresa").change(function () {

    /*if ($("#YaCargoPlantilla").val() == "SI") {
        $("#YaCargoPlantilla").val("");*/
    cargarplantilla();
    //OcultarLoading("$(#enviar).click");
    //}
});

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};
$("#previewTextControl2").click(function () {

    $("#modalPreviewControl").modal();

    var dataA = $("form").serializeObject();

    TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat,
        function (e) {
            $.ajax({
                type: "POST",
                async: true,
                url: "PrevioTxtControl",
                //url: "PreviewDocument",
                contentType: 'application/json',
                data: JSON.stringify({
                    BinaryDocument: e.data,
                    modelCo: dataA
                }),
                success: function (datares) {
                    var pdfIframe = "data:application/pdf;base64," + datares;
                    document.getElementById('imgPreviewCtr').src = pdfIframe;
                    OcultarLoading("Oculatando Previo");

                },
                error: function (response) {
                    toastr.warning("PrevioTxtControl: Error!! ");
                    OcultarLoading("Oculatando Previo");

                }
            });
        });
});

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};
$("#Borrador,#Preradicar,#Radicar").click(function () {
    $("#loadingModal").css("display", "block");
    var dataA = $("form").serializeObject();
    var vclick = "act " + this.id;
    if (validarPlantillaCargada()) {

        TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat,
            function (e) {
                var serviceURL = "CreateWithTX";

                $.ajax({
                    type: "POST",
                    async: true,
                    url: serviceURL,
                    contentType: 'application/json',
                    data: JSON.stringify({
                        submit: vclick,
                        pTM_DOCUMENTO: dataA,
                        BinaryDocument: e.data
                    }),
                    success: function (response) {
                        ////
                        if (response != null && response.success) {
                            toastr.warning(response.responseText);
                        }
                        else if (response.result == 'NoValidate') {
                            toastr.warning(response.responseText, "Validación");
                            OcultarLoading("CreateWithTX NoValidate");
                            return false;
                        }
                        else if (response.result == 'return') {
                            OcultarLoading("CreateWithTX return");
                            return false;
                        }
                        else if (response.result == 'Redirect') {
                            //redirecting to main page from here for the time being.
                            OcultarLoading("CreateWithTX Redirect");
                            toastr.success("Estado Actualizado Correctamente", "Exitoso");
                            window.location = response.responseText;
                        }
                        else if (response.result == 'Redirect.Guardado') {
                            //redirecting to main page from here for the time being.
                            // OcultarLoading("CreateWithTX Guardado");
                            $("#YaCargoPlantilla").val("");
                            toastr.success("El documento se guardó satisfactoriamente", "Exitoso");
                            window.location = response.responseText;
                        }
                        else {
                            // DoSomethingElse()
                            OcultarLoading("CreateWithTX error");
                            toastr.error(response.responseText, "Error");
                            return false;
                        }
                    },
                    error: function (response) {

                        toastr.warning("CreateWithTX: error!");
                        OcultarLoading("CreateWithTX ");
                    }
                });
            });
    }
});

function changeIframeSrcModalX(url) {
    document.getElementById('iframeVisorFile').src = url;
    return false;
}


function _SetFocus() {
    //$("#frmtype1 #dllClaseDocumento").first().focus();
    //$("#dllClaseDocumento").focus();
    //$( "#dllClaseDocumento" ).delay( 8000 ).focus();
    //////
    setTimeout(function () {
        $("#campoInicial1").focus();
        $("#campoInicial1").css("display", "none");
        $("#div_CONCOPIAAINTERNO").css("display", "none");
        $("#div_CONCOPIAAINTERNO2").css("display", "none");
    }, 4000);
}
window.onload = _SetFocus;


$("#UploadAnexos").css("display", "");
                }
                else
{
    $("#crearTerceroDe").css("display", "none");
    $("#crearTerceroPara").css("display", "none");
    $("#To").css("display", "none");
    $("#To1").css("display", "none");
    $("#Cc").css("display", "none");
    $("#Search").css("display", "none");
    $("#UploadAnexos").css("display", "none");
    $("#CopiaTercero").css('display', "none");
}
            });

function CargaFondosTabla(idModel) {
    if (idModel != "") {
        if (idModel > 0) {
            $.getJSON("../TM_EXPEDIENTE/GetFondoXtabla", { id: idModel },
                function (carData) {
                    /*Limpiamos los otros mbos*/

                    var select = $("#ddlFondo");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));
                    var selectdep = $("#ddlDependendia");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));
                    var selectSerie = $("#ddlSerie");
                    selectSerie.empty();
                    selectSerie.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));
                    /*Fin Funcion Original Limpiamos los otros combos*/
                    var grupoX, $prevGroup;
                    $.each(carData, function (index, itemData) {
                        /*select.append($('<option/>', {
                            value: itemData.ID,
                            text: itemData.CODIGO + ' - ' + itemData.TITULO
                        }));
                        */
                        if (grupoX != itemData.grupo) {
                            $prevGroup = $('<optgroup />').prop('label', itemData.grupo).appendTo(select);
                        }
                        $("<option />").val(itemData.ID).text(itemData.CODIGO + ' - ' + itemData.TITULO).appendTo($prevGroup);
                        grupoX = itemData.grupo;

                    });
                    $("#ddlFondo option[value='@Model.Documento.objFondo.ID']").attr("selected", "selected");
                    select.attr('disabled', false);
                    select.trigger("chosen:updated");
                    select.chosen({});
                });
        }
        else {
            LimpiarCombo("#ddlFondo");
            LimpiarCombo("#ddlDependendia");
            LimpiarCombo("#ddlSerie");
        }
    }
    else {
        LimpiarCombo("#ddlFondo");
        LimpiarCombo("#ddlDependendia");
        LimpiarCombo("#ddlSerie");
    }
    OcultarLoading("CargaFondosTabla");
}
function CargarDependenciaXFondoXTabla(idTablaModel, idModel) {
    if (idModel != "") {
        if (idModel > 0) {
            $.getJSON("../TM_EXPEDIENTE/GetDependenciaXFondoXTabla", { id_trd: idTablaModel, id_tb_fondo: idModel },
                function (carData) {
                    /*Limpiamos los otros mbos*/
                    var select = $("#ddlDependendia");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));
                    var selectSerie = $("#ddlSerie");
                    selectSerie.empty();
                    selectSerie.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));
                    /*Fin Funcion Original Limpiamos los otros combos*/
                    $.each(carData, function (index, itemData) {
                        select.append($('<option/>', {
                            value: itemData.ID,
                            text: itemData.NOMBRE
                        }));
                    });
                    $("#ddlDependendia option[value='@Model.Documento.objDependencia.ID']").attr("selected", "selected");
                    select.attr('disabled', false);
                    select.trigger("chosen:updated");
                    select.chosen({});
                });
        }
        else {
            LimpiarCombo("#ddlDependendia");
            LimpiarCombo("#ddlSerie");
        }
    }
    else {
        LimpiarCombo("#ddlDependendia");
        LimpiarCombo("#ddlSerie");
    }
}
function CargarDependenciaXTablaXFondoXSerie(idModel, idTablaModel, idfondo) {
    if (idModel != "") {
        if (idModel > 0) {
            $.getJSON("../TM_EXPEDIENTE/GetSerieXDependencia", { id: idModel, idTabla: idTablaModel, idFondo: idfondo },
                function (carData) {
                    var select = $("#ddlSerie");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "--Seleccione --"
                    }));
                    /*Fin Funcion Original Limpiamos los otros combos*/
                    var grupoX, $prevGroup;
                    $.each(carData, function (index, itemData) {
                        /*select.append($('<option/>', {
                            value: itemData.ID,
                            text: itemData.CODIGO + ' - ' + itemData.DESCRIPCION
                        }));*/
                        if (grupoX != itemData.grupo) {
                            $prevGroup = $('<optgroup />').prop('label', itemData.grupo).appendTo(select);
                        }
                        $("<option />").val(itemData.ID).text(itemData.CODIGO + ' - ' + itemData.DESCRIPCION).appendTo($prevGroup);
                        grupoX = itemData.grupo;
                    });
                    $("#ddlSerie option[value=@Model.Documento.objSerie.ID]").attr("selected", "selected");
                    select.attr('disabled', false);
                    select.trigger("chosen:updated");
                    select.chosen({});
                });
        }
        else {
            LimpiarCombo("#ddlSerie");
        }
    }
    else {
        LimpiarCombo("#ddlSerie");
    }
}
function CargaCCDVariablesSerie(idModel, varidTRD, varidDependencia) {
    $("#divAdicionales").empty();
    var campo = "";
    $.getJSON("../TM_EXPEDIENTE/GetCCD", { idTRD: varidTRD, idDependencia: varidDependencia, idSerie: idModel },
        function (carData) {
            /*Limpiamos los otros mbos*/
            $("#nombreCCDlabel").text(carData.CCDNombre);
            $(".id_tb_ccd2").val(carData.ID);
        });
}
function changeIframeSrctercero(url) {

    debugger
    var vUrl = url;
    var iddllClaseDocumento = $("#dllClaseDocumento").val();
    if (iddllClaseDocumento == 3) {
        var idEntidad2 = document.getElementById('hfEntidadDepFrom').value;
        if (idEntidad2 != "0" || idEntidad != null || idEntidad != "") {
            var vUrl = url + '?idTercero=' + idEntidad2;
        }
        document.getElementById('hfEntidadDepFrom').value = '';
        document.getElementById('EntidadDependencia').value = '';
        LimpiarCombo("#dllDestinario");
    }
    document.getElementById('iframeagregarTercero').src = vUrl;
    return false;
}



function CerrarFrameAgregartercero() {
    /*
    1   Interna - Interna
    2   Externa - Interna
    3   Interna - Externa
    */
    var iddllClaseDocumento = $("#dllClaseDocumento").val();

    if (iddllClaseDocumento == 2) {
        //cargarDependenciasDE(iddllClaseDocumento);
    }
    else if (iddllClaseDocumento == 3) {
        cargarDependenciaPARA(iddllClaseDocumento);
    }
    $("#Cancelaragregar").click();
}

function cargarplantilla() {

    //if($("#YaCargoPlantilla").val()=="SI")
    //{
    //}
    //else
    //{
    var idModel = $("#dllPlantillaEmpresa").val();
    if (idModel > 0) {
        $.ajax({
            type: "POST",
            async: true,
            url: "LoadTemplate",
            contentType: 'application/json',
            data: JSON.stringify({
                pID: idModel
            }),
            success: successFunc,
            error: errorFunc
        });
    }
    function successFunc(data, status) {
        TXTextControl.loadDocument(TXTextControl.streamType.InternalUnicodeFormat, data);
        //$("#YaCargoPlantilla").val("SI");
    }
    function errorFunc(xhr, textStatus, exceptionThrown) {
        toastr.warning('Error en el cargue plantilla 2:' + xhr.responseText);
        $("#YaCargoPlantilla").val("");
    }
    //}
}

//////
$(function () {
    $('input.enfocar').focus();
});


$("#EntidadDependencia_remitente").autocomplete({

    source: function (request, response) {

        //
        $.ajax({
            url: '@Url.Action("ConsultarDE", "TP_TERCERO")',
            datatype: "json",
            data: {
                filtro: request.term,
                idClaseDocumento: document.getElementById('dllClaseDocumento').value
            },
            success: function (data) {

                response($.map(data, function (item) {
                    //toastr.warning(item.ID);
                    //toastr.warning(val.ID);
                    return {
                        label: item.NOMBRE,
                        value: item.NOMBRE,
                        Remitente: item.ID
                    }
                }));
                //
                OcultarLoading("EntidadDependencia_remitente .autocomplete sucess");

            },
            error: function (response) {
                toastr.warning(response.responseText);
                OcultarLoading("EntidadDependencia_remitente .autocomplete 2");
            },
            failure: function (response) {
                toastr.warning(response.responseText);
                OcultarLoading("EntidadDependencia_remitente .autocomplete 3");
            }

        });
    },
    select: function (e, i) {
        $("#hfEntidadDep").val(i.item.Remitente);

        //
        var idModel = i.item.Remitente;
        if (idModel != null) {
            if (idModel > 0) {
                /*  ID  Descripcion
                    1   Interna - Interna
                    2   Externa - Interna
                    3   Interna - Externa
                */
                var vTipoCorrespondenciapre = document.getElementById('dllClaseDocumento').value;
                $.getJSON("../CAD/ValidateContactoEntidadDependencia_CAD", { idEntidadDependencia: idModel, idClaseDocumento: vTipoCorrespondenciapre },
                    function (carData) {
                        /*Limpiamos los otros combos*/
                        var select = $("#dllRemitentes");
                        select.empty();
                        select.append($('<option/>', {
                            value: 0,
                            text: "--Seleccione --"
                        }));
                        /*Fin Funcion Original Limpiamos los otros combos*/
                        $.each(carData, function (index, itemData) {
                            select.append($('<option/>', {
                                value: itemData.ID,
                                text: itemData.NOMBRE
                            }));
                        });
                        select.attr('disabled', false);
                        select.trigger("chosen:updated");
                        select.chosen({});
                        OcultarLoading("hfentidaddep");
                    });
            }
            else {
                toastr.warning("Es necesario limpiar el selector");
                //LimpiarCombo("#dllDestinario");
            }
        }
    },
    minLength: 3,
    //select: function (event, ui)
    //{
    //    OcultarLoading("EntidadDependencia_remitente .autocomplete 12");
    //},
    //open: function () {
    //    OcultarLoading("EntidadDependencia_remitente .autocomplete 11");
    //},
    //close: function () {
    //    OcultarLoading("EntidadDependencia_remitente .autocomplete 1");
    //}
}).focus(function () {
    $(this).autocomplete("search");
});

$("#EntidadDependencia").autocomplete({
    source: function (request, response) {

        $.ajax({
            url: '@Url.Action("ConsultarPARA", "TP_TERCERO")',
            datatype: "json",
            data: {
                filtro: request.term,
                idClaseDocumento: document.getElementById('dllClaseDocumento').value
            },
            success: function (data) {
                //
                response($.map(data, function (item) {
                    //toastr.warning(item.ID);
                    //toastr.warning(val.ID);
                    return {

                        label: item.NOMBRE,
                        value: item.NOMBRE,
                        Destinatario: item.ID
                    }
                }));

                OcultarLoading("EntidadDependencia .autocomplete 1");
            },
            error: function (response) {
                toastr.warning(response.responseText);
                OcultarLoading("EntidadDependencia .autocomplete 2");
            },
            failure: function (response) {
                toastr.warning(response.responseText);
                OcultarLoading("EntidadDependencia .autocomplete 3");
            }
        });
    },
    select: function (e, i) {
        $("#hfEntidadDepFrom").val(i.item.Destinatario);

        //
        var idModel = i.item.Destinatario;
        if (idModel != null) {
            if (idModel > 0) {
                /*  ID  Descripcion
                    1   Interna - Interna
                    2   Externa - Interna
                    3   Interna - Externa
                */
                var vTipoCorrespondenciapre = document.getElementById('dllClaseDocumento').value;
                $.getJSON("../CAD/ValidateContactoEntidadDependencia_all", { idEntidadDependencia: idModel, idClaseDocumento: vTipoCorrespondenciapre },
                    function (carData) {
                        /*Limpiamos los otros combos*/
                        var select = $("#dllDestinario");
                        select.empty();
                        select.append($('<option/>', {
                            value: 0,
                            text: "--Seleccione --"
                        }));
                        /*Fin Funcion Original Limpiamos los otros combos*/
                        $.each(carData, function (index, itemData) {
                            select.append($('<option/>', {
                                value: itemData.ID,
                                text: itemData.NOMBRE
                            }));
                        });
                        select.attr('disabled', false);
                        select.trigger("chosen:updated");
                        select.chosen({});
                        OcultarLoading("hfEntidadDepFrom");
                    });
            }
            else {
                toastr.warning("Es necsario limpiar el selector");
                //LimpiarCombo("#dllDestinario");
            }

        }
    },
    minLength: 3,
    //open: function() {
    //    //toastr.warning("open");
    //},
    //close: function() {
    //    OcultarLoading("EntidadDependencia .autocomplete 3");
    //}
}).focus(function () {

    $(this).autocomplete("search");

});

function PreviewTXT() {
    //toastr.warning(url);

    var dataA = $("form").serializeObject();

    TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat,
        function (e) {
            $.ajax({
                type: "POST",
                async: true,
                url: "PrevioDocument",
                contentType: 'application/json',
                data: JSON.stringify({
                    BinaryDocument: e.data,
                    modelCo: dataA
                }),
                success: function (data) {
                    toastr.warning("Exitoso");
                    $('#modalContainerPreview').html(data);
                    $('#PreviewModal').modal('show');
                    OcultarLoading("Ocultando Previo");

                },
                error: function (response) {
                    toastr.warning("Previo: Error!! ");
                    OcultarLoading("Ocultando Previo");

                }
            });
        });


    //Importante el false para que no vaya al controlador del actionLink
    return false;

    if ($(this).is(':checked')) {
        document.getElementById('esMasiva2').value = "1";
        //alert(document.getElementById('esMasiva').value);
    }
    else {
        document.getElementById('esMasiva2').value = "0";
        //alert(document.getElementById('esMasiva').value);
    }

}) (jQuery);
