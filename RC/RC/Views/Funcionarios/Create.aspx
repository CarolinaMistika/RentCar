<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_usuarios>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Registro de funcionários
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
                    Nome Completo * :</label>
                <%: Html.TextBox("nome","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
                <br>
                <label for="fullname">
                    Cargo :</label>
                <%: Html.DropDownList("id_cargo", ViewBag.cargo as IEnumerable<SelectListItem>, "Selecione", new { @class = "form-control", @required = true, @maxlength = "50" }) %>
                <br>
                <label for="fullname">
                    Login *:
                </label>
                <%: Html.TextBox("login","", new { @class = "form-control", @required = true, @maxlength="50" }) %>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    CPF * :</label>
                <%: Html.TextBox("cpf","", new { @class = "form-control cpf", @required = true, @maxlength="50" }) %>
                <br>
                <label for="fullname">
                    Senha * :</label>
                <%: Html.TextBox("senha","", new { @class = "form-control", @required = true, @maxlength="50" ,@type="password" }) %>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                <label for="message">
                    Observação :</label>
                <%: Html.TextArea("obs","", new { @class = "form-control", @maxlength="50" }) %>
                <br>
                <input type="submit" class="btn btn-success" value="Salvar">
                <a type="button" class="btn btn-danger" href="/Funcionarios/Index">Voltar</a>
            </div>
            <br />
            <!-- CAMPOS OCULTOS -->
            <input type="hidden" name="id_tipo" value="1" />
            <input type="hidden" name="id_status" value="5" />
            <!-- /CAMPOS OCULTOS -->
            </form>
            <!-- end form for validations -->
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/funcionarios/funcoes-create.js" type="text/javascript"></script>
    </div>
</asp:Content>
