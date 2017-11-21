<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_usuarios>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Lista de Reservas de clientes</h2>
            <ul class="nav navbar-right panel_toolbox">
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
                            Data inicial
                        </th>
                        <th>
                            Data final
                        </th>
                        <th>
                            Ação
                        </th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/alugueis/funcoes-clientes.js" type="text/javascript"></script>
    </div>
</asp:Content>
