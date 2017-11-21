<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_aluguel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Alugueis
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Lista de alugueis</h2>
            <ul class="nav navbar-right panel_toolbox">
                <a type="button" class="btn btn-info" href="/Alugueis/Create" style="float: left;">
                    Adicionar Aluguel</a>
                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
            </ul>
            <div class="clearfix">
            </div>
        </div>
        <div class="x_content">
            <table id="datatable-responsive" class="table table-striped table-bordered" cellspacing="0"
                width="100%">
                <thead>
                    <tr>
                        <th>
                            Cliente
                        </th>
                        <th>
                            Funcionario
                        </th>
                        <th>
                            Modelo
                        </th>
                        <th>
                            Marca
                        </th>
                        <th>
                            Ano
                        </th>
                        <th>
                            Placa
                        </th>
                        <th>
                            Cor
                        </th>
                        <th>
                            obs
                        </th>
                        <th>
                            Diaria
                        </th>
                        <th>
                            Data aluguel
                        </th>
                        <th>
                            Data inicial
                        </th>
                        <th>
                            Data final
                        </th>
                        <th>
                            Data devolucao
                        </th>
                        <th>
                            Devolver
                        </th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/alugueis/funcoes-index.js" type="text/javascript"></script>
    </div>
</asp:Content>
