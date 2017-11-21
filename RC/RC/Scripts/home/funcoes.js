/*Variaveis usadas no arquivo*/
var controller = '/Home/';
/* /Variaveis usadas no arquivo*/


$(document).ready(function () {

});

$("#demo-form").submit(function (event) {
    return Salvar(event);
});

function Salvar(e) {
    e.preventDefault();
    if (ValidaForm()) {
        var parametros = $("#demo-form").serialize();
        AcaoRegistro(parametros, controller + "Reservar", "Deseja salvar o registro?", "SalvarComplete", "");
    }
    return false;
}

function SalvarComplete() {
    $("#CalenderModalNew").modal('hide');
}

function Reservar(carro, cliente) {
    $("#id_carro").val(carro);
    $("#id_cliente").val(cliente);
    $("#CalenderModalNew").modal('show');
}