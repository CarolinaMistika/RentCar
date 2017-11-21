/*Variaveis usadas no arquivo*/
var controller = '/Carros/';
/* /Variaveis usadas no arquivo*/

$(document).ready(function () {
    $('.cpf').mask('999.999.999-99');
});

function Alterar(e) {
    e.preventDefault();
    if (ValidaForm() && ValidacaoImagem()) {
        swal({
            title: "Atenção!",
            text: "Deseja Alterar o registro?",
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
            alert("O tipo de arquivo selecionado é inválido!");
            return false;
        }
    }
    return true;
}

