<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_usuarios>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Alteração de clientes
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
                <%: Html.TextBoxFor(m=> m.nome, new { @class = "form-control", @required = true, @maxlength="50" }) %><br>
                <label for="fullname">
                    CEP* :</label>
                <%: Html.TextBoxFor(m => m.cep, new { @class = "form-control cep", @required = true, @maxlength = "50" })%>
                <br />
                <label for="fullname">
                    Logradouro* :</label>
                <%: Html.TextBoxFor(m => m.logradouro, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                <label for="fullname">
                    Número :</label>
                <%: Html.TextBoxFor(m => m.numero, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                <label for="fullname">
                    Complemento :</label>
                <%: Html.TextBoxFor(m => m.complemento, new { @class = "form-control", @maxlength = "50" })%></div>
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    CPF * :</label>
                <%: Html.TextBoxFor(m => m.cpf, new { @class = "form-control cpf", @required = true, @maxlength = "50" })%>
                <br>
                <label for="fullname">
                    Senha * :</label>
                <%: Html.TextBoxFor(m => m.senha, new { @class = "form-control", @required = true, @maxlength = "50", @type = "password" })%>
                <br />
                <label for="fullname">
                    Status * :
                </label>
                <%: Html.DropDownList("id_status", ViewBag.status as IEnumerable<SelectListItem>, "Selecione", new { @class = "form-control", @required = true, @maxlength = "50" }) %>
                <label for="message">
                    Observação :</label>
                <%: Html.TextAreaFor(m => m.obs, new { @class = "form-control", @maxlength = "50" })%>
                <br>
                <input type="submit" class="btn btn-success" value="Salvar">
                <a type="button" class="btn btn-danger" href="/Clientes/Index">Voltar</a>
            </div>
            <!-- CAMPOS OCULTOS -->
            <%:Html.HiddenFor(m=> m.id_tipo) %>
            <%:Html.HiddenFor(m=> m.id) %>
            <!-- /CAMPOS OCULTOS -->
            </form>
            <!-- end form for validations -->
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/clientes/funcoes-edit.js" type="text/javascript"></script>
    </div>
</asp:Content>
