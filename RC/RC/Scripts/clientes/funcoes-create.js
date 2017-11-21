/*Variaveis usadas no arquivo*/
var controller = '/Clientes/';
/* /Variaveis usadas no arquivo*/


$(document).ready(function () {
    $('.cpf').mask('999.999.999-99');
    $('.cep').mask('99999-999');
});

$("#demo-form").submit(function (event) {
    return Salvar(event);
});

function Salvar(e) {
    e.preventDefault();
    if (ValidaForm() && VerificaCPF("#cpf")) {
        var parametros = $("#demo-form").serialize();
        AcaoRegistro(parametros, controller + "Create", "Deseja salvar o registro?", "", "");
    }
    return false;
}