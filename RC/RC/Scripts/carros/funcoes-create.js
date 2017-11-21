/*Variaveis usadas no arquivo*/
var controller = '/Carros/';
/* /Variaveis usadas no arquivo*/


$(document).ready(function () { });


function Salvar(e) {
    e.preventDefault();
    if (ValidaForm() && ValidacaoImagem()) {
        swal({
            title: "Atenção!",
            text: "Deseja salvar o registro?",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Confirmar",
            closeOnConfirm: false,
            cancelButtonText: "Sair",
            showLoaderOnConfirm: true
        },
            function (isConfirm) {
                if (isConfirm == true)
                    $("#demo-form").submit();
            });
    }
}

function ValidacaoImagem() {
    var img = $("#imagem");
    img = img[0].files[0];

    if (img != undefined) {
        var tipo = img.type.split('/');
        if (tipo[0] == "image")
            return true;
        else {
            swal({
                title: "Atenção!",
                text: "O tipo de arquivo selecionado é inválido!",
                type: "warning"
            });
            return false;
        }
    }
    return true;
}

function Upload(e) {

    e.preventDefault();
    var img = $("#imagem");
    img = img[0].files[0];
    if (img != undefined)
        $("#txtimagem").val(img.name);
    else
        $("#txtimagem").val("");
}