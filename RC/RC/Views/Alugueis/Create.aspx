<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_aluguel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Alugueis
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Registro de alugueis
            </h2>
            <ul class="nav navbar-right panel_toolbox">
                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
            </ul>
            <div class="clearfix">
            </div>
        </div>
        <div class="x_content">
            <!-- start form for validation -->
            <form id="demo-form" data-parsley-validate enctype="multipart/form-data" action=""
            method="Post">
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    Cliente* :</label>
                <%: Html.DropDownList("id_cliente", ViewBag.usuarios as IEnumerable<SelectListItem>, "Selecione", new { @class = "form-control", @required = true, @maxlength = "50" })%>
                <br>
                <label for="fullname">
                    Carros* :</label>
                <%: Html.DropDownList("id_carro", ViewBag.carros as IEnumerable<SelectListItem>, "Selecione", new { @class = "form-control", @required = true, @maxlength = "50" })%>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    Data Inicio :</label>
                <%: Html.TextBox("data_inicial", "", new { @class = "form-control", @required = true, @maxlength = "50" ,@type="date"})%>
                <br>
                <label for="fullname">
                    Data Final :</label>
                <%: Html.TextBox("data_final", "", new { @class = "form-control", @required = true, @maxlength = "50", @type = "date" })%>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <input type="submit" class="btn btn-success" value="Salvar">
                <a type="button" class="btn btn-danger" href="/Alugueis/Index">Voltar</a>
            </div>
            <!-- CAMPOS OCULTOS -->
            <%: Html.HiddenFor(m => m.id_funcionario) %>
            <!-- /CAMPOS OCULTOS -->
            </form>
            <!-- end form for validations -->
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/alugueis/funcoes-create.js" type="text/javascript"></script>
    </div>
</asp:Content>
