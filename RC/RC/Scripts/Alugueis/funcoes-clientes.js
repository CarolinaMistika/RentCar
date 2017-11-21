/*Variaveis usadas no arquivo*/
var controller = '/Alugueis/';
var page = 0;
var row = 5;
/* /Variaveis usadas no arquivo*/

$(document).ready(function () {
    Pesquisa();
});



function GridPosCarregamento() {
    MarcaCheck();
}

function LiberarCarro(id, tipo) {
    var parametros = { id: id, tipo: tipo }
    FuncaoAjax("POST", parametros, controller + "AlterarListaEspera", "RetornoLiberarCarro");
}

function RetornoLiberarCarro(data) {
    Pesquisa();
}

function PesquisaPorFomulario(e) {
    e.preventDefault();
    Pesquisa();
    return false;
}

function Pesquisa() {
    var parametros = $("#pesquisa-form").serialize();
    FuncaoAjax("POST", parametros, controller + "DataListaEspera", "PreencheGrid");
}

function PreencheGrid(data) {
    $('#datatable-responsive').DataTable({
        "bDestroy": true,
        "bFilter": true,
        "bLengthChange": true,
        "lengthMenu": [[5, 25, 50, -1], [5, 25, 50, "All"]],
        "pageLength": page,
        "columnDefs": [
                {
                    "targets": 'no-sort',
                    "orderable": false
                },
                {
                    "targets": 'invisivel',
                    "visible": false
                },
                { "targets": 8, "data": null,
                    "render": function (data, type, full, meta) {
                        var html = full.id_status;
                        if (full.id_status == 0)
                            html = '<div class="fa-hover text-center"><a href="#" title="Liberar Carro" onclick="LiberarCarro(' + full.id + ',1);"><i class="fa  fa-external-link fa-2x"></i></a></div>';
                        else if (full.id_status == 1)
                            html = '<div class="fa-hover text-center"><a href="#" title="Cancelar" onclick="LiberarCarro(' + full.id + ',2);"><i class="fa fa-clock-o  fa-2x"></i></a></div>';
                        return html;
                    }
                }
                    ],
        data: data,
        columns: [
        { data: 'nome_cliente' },
        { data: 'modelo' },
        { data: 'marca' },
        { data: 'data_fabricacao' },
        { data: 'placa' },
        { data: 'cor' },
        { data: 'data_inicio' },
        { data: 'data_fim' },
        { data: 'id' }
    ],
        language: {
            processing: "Processando...",
            search: "Pesquisar:",
            lengthMenu: "Mostrar _MENU_ linhas",
            info: "Mostrando _START_ a _END_ de _TOTAL_ registros",
            infoEmpty: "",
            infoFiltered: "( _MAX_ )",
            infoPostFix: "",
            loadingRecords: "Carregando...",
            zeroRecords: "",
            emptyTable: "Não há dados disponíveis na tabela",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Proximo",
                last: "Ultimo"
            },
            aria: {
                sortAscending: ": ativar para ordenar a coluna em ordem crescente",
                sortDescending: ": ativar para classificar a coluna em ordem decrescente"
            }
        }
    });

    GridPosCarregamento();

}