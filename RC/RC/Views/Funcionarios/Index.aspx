<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Funcionarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Lista de Funcionários</h2>
            <ul class="nav navbar-right panel_toolbox">
                <a type="button" class="btn btn-info" href="/Funcionarios/Create" style="float: left;">
                    Adicionar Funcionário</a>
                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
            </ul>
            <div class="clearfix">
            </div>
        </div>
        <div class="x_content">
            <table id="datatable-responsive" class="table table-striped table-bordered"
                cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>
                            Nome Completo
                        </th>
                        <th>
                            Cargo
                        </th>
                        <th>
                            CPF
                        </th>
                        <th>
                            login
                        </th>
                        <th style="">
                            Editar
                        </th>
                        <th style="">
                            status
                        </th>
                    </tr>
                </thead>
            </table>
        </div>
    </div><div name="scripts">
        <script src="../../Scripts/funcionarios/funcoes-index.js" type="text/javascript"></script>
    </div>
</asp:Content>
