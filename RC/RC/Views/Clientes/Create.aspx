<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_usuarios>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Registro de clientes
            </h2>
            <ul class="nav navbar-right panel_toolbox">
                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
            </ul>
            <div class="clearfix">
            </div>
        </div>
        <div class="x_content">
            <!-- start form for validation -->
            <form id="demo-form" data-parsley-validate method="post">
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    Nome completo* :</label>
                <%: Html.TextBox("nome","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
                <br>
                <label for="fullname">
                    CEP* :</label>
                <%: Html.TextBox("cep","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
                <br />
                <label for="fullname">
                    Logradouro* :</label>
                <%: Html.TextBox("logradouro","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
                <label for="fullname">
                    Número :</label>
                <%: Html.TextBox("numero","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
                <label for="fullname">
                    Complemento :</label>
                <%: Html.TextBox("complemento","", new { @class = "form-control", @maxlength="50" }) %>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    Email/login *:
                </label>
                <%: Html.TextBox("login","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
                <br />
                <label for="fullname">
                    CPF * :</label>
                <%: Html.TextBox("cpf","", new { @class = "form-control cpf", @required = true, @maxlength="50" }) %>
                <br>
                <label for="fullname">
                    Senha * :</label>
                <%: Html.TextBox("senha","", new { @class = "form-control", @required = true, @maxlength="50" ,@type="password" }) %>
                <label for="message">
                    Observação :</label>
                <%: Html.TextArea("obs","", new { @class = "form-control", @maxlength="50" }) %>
                <br>
                <input type="submit" class="btn btn-success" value="Salvar">
                <a type="button" class="btn btn-danger" href="/Clientes/Index">Voltar</a>
            </div>
            <!-- CAMPOS OCULTOS -->
            <input type="hidden" name="id_tipo" value="2" />
            <input type="hidden" name="id_status" value="5" />
            <!-- /CAMPOS OCULTOS -->
            </form>
            <!-- end form for validations -->
        </div>
        <div name="scripts">
            <script src="../../Scripts/clientes/funcoes-create.js" type="text/javascript"></script>
        </div>
</asp:Content>
