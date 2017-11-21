/*Variaveis usadas no arquivo*/
var controller = '/Alugueis/';
/* /Variaveis usadas no arquivo*/


$(document).ready(function () { });


$("#demo-form").submit(function (event) {
    return Salvar(event);
});

function Salvar(e) {
    e.preventDefault();
    if (ValidaForm()) {
        var parametros = $("#demo-form").serialize();
        AcaoRegistro(parametros, controller + "Create", "Deseja salvar o registro?", "", "");
    }
    return false;
}