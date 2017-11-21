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

function DevolverCarro(id) {
    var parametros = { id: id}
    FuncaoAjax("POST", parametros, controller + "Edit", "RetornoDevolverCarro");
}

function RetornoDevolverCarro(data) {
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
                { "targets": 13, "data": null,
                    "render": function (data, type, full, meta) {
                        var html = full.status;
                        if (full.data_devolucao == null)
                            html = '<div class="fa-hover text-center"><a href="#" title="Devolver" onclick="DevolverCarro(' + full.id + ');"><i class="fa  fa-external-link fa-2x"></i></a></div>';
                        else
                            html = '<div class="fa-hover text-center"><a href="#" title="Devolvido" ><i class="fa fa-check  fa-2x"></i></a></div>';
                        return html;
                    }
                },
                 
                  { "targets": 9, "data": null,
                      "render": function (data, type, full, meta) {
                          return FomataDataGrid(full.data_aluguel);
                      }
                  }
                  ,
                  { "targets": 10, "data": null,
                      "render": function (data, type, full, meta) {
                          return FomataDataGrid(full.data_inicial);
                      }
                  }
                  ,
                  { "targets": 11, "data": null,
                      "render": function (data, type, full, meta) {
                          return FomataDataGrid(full.data_final);
                      }
                  }
                  ,
                  { "targets": 12, "data": null,
                      "render": function (data, type, full, meta) {
                          return FomataDataGrid(full.data_devolucao);
                      }
                  }
                    ],
        data: data,
        columns: [
        { data: 'nome_cliente' },
        { data: 'nome_funcionario' },
        { data: 'modelo' },
        { data: 'marca' },
        { data: 'data_fabricacao' },
        { data: 'placa' },
        { data: 'cor' },
        { data: 'obs' },
        { data: 'valor_diaria' },
        { data: 'data_aluguel' },
        { data: 'data_inicial' },
        { data: 'data_final' },
        { data: 'data_devolucao' },
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