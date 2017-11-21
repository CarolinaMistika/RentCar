/*Variaveis usadas no arquivo*/
var controller = '/Clientes/';
var page = 0;
var row = 5;
/* /Variaveis usadas no arquivo*/


$(document).ready(function () {
    Pesquisa();
});

function GridPosCarregamento() {
    MarcaCheck();
}

function HabilitaDesabilita(id, tipo) {
    var parametros = { id: id, tipo: tipo }
    FuncaoAjax("POST", parametros, controller + "HabilitaDesabilita", "RetornoHabilitaDesabilita");
}

function RetornoHabilitaDesabilita(data) {
    Pesquisa();
}

function PesquisaPorFomulario(e) {
    e.preventDefault();
    Pesquisa();
    return false;
}

function Pesquisa() {
    var parametros = $("#pesquisa-form").serialize();
    FuncaoAjax("POST", parametros, controller + "DataIndex", "PreencheGrid");
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
                {
                    "targets": 8, "data": null,
                    "render": function (data, type, full, meta) {
                        var html = '<center><a href="' + controller + 'Edit/' + full.id + '" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i></a></center>';
                        return html;
                    }
                },
                { "targets": 9, "data": null,
                    "render": function (data, type, full, meta) {
                        var html = full.status;
                        if (full.id_status == 5)
                            html = '<div class="fa-hover text-center"><a href="#" title="Desabilitar" onclick="HabilitaDesabilita(' + full.id + ', 6)";><i class="fa fa-toggle-on fa-2x"></i></a></div>'; //'<div class="text-center"><a href="#"><i class="fa fa-toogle-on" ></i></a></div>';
                        else
                            html = '<div class="fa-hover text-center"><a href="#" title="Habilitar" onclick="HabilitaDesabilita(' + full.id + ', 5)";><i class="fa fa-toggle-off  fa-2x"></i></a></div>';
                        return html;
                    }
                }
                    ],
        data: data,
        columns: [
        { data: 'nome' },
        { data: 'cpf' },
        { data: 'login' },
        { data: 'logradouro' },
        { data: 'cep' },
        { data: 'numero' },
        { data: 'complemento' },
        { data: 'obs' },
        { data: 'id' },
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