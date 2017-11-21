<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Lista de Clientes</h2>
            <ul class="nav navbar-right panel_toolbox">
                <a type="button" class="btn btn-info" href="/Clientes/Create" style="float: left;">Adicionar
                    Cliente</a>
                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
            </ul>
            <div class="clearfix">
            </div>
        </div>
        <div class="x_content">
            <div>
                <table id="datatable-responsive" class="table table-striped table-bordered " cellspacing="0"
                    width="100%">
                    <thead>
                        <tr>
                            <th>
                                Nome Completo
                            </th>
                            <th>
                                CPF
                            </th>
                            <th>
                                login/E-mail
                            </th>
                            <th>
                                Logradouro
                            </th>
                            <th>
                                CEP
                            </th>
                            <th>
                                Número
                            </th>
                            <th>
                                Complemento
                            </th>
                            <th>
                                Observação
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
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/clientes/funcoes-index.js" type="text/javascript"></script>
    </div>
</asp:Content>
