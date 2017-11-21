<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_carro>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Edição funcionários (Nome Funcionário)
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
            method="post">
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="fullname">
                    Modelo* :</label>
                <%: Html.TextBoxFor(m=> m.modelo, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                <br>
                <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback" style="padding-left: 0 !important;">
                    <label for="fullname">
                        Marca* :</label>
                    <%: Html.TextBoxFor(m => m.marca, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback" style="padding-right: 0 !important;">
                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                        <label for="fullname">
                            Ano :</label>
                        <%: Html.TextBoxFor(m => m.data_fabricacao, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback" style="padding-right: 0 !important;">
                        <label for="fullname">
                            Placa :</label>
                        <%: Html.TextBoxFor(m => m.placa, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                    </div>
                </div>
                <br>
                <label for="fullname">
                    Imagem :</label>
                <%: Html.TextBoxFor(m => m.imagem, new { @class = "form-control", @maxlength = "1000", @type = "file" })%>
                <br />
                <img src="../../Content/imagem-carros/<%:Model.imagem %>" style="width: 150px;" />
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                <label for="email">
                    Cor* :</label>
                <%: Html.TextBoxFor(m => m.cor, new { @class = "form-control", @required = true, @maxlength = "50" })%>
                <br>
                <label for="fullname">
                    Status* :
                </label>
                <%: Html.DropDownList("id_status", ViewBag.status as IEnumerable<SelectListItem>, "Selecione", new { @class = "form-control", @required = true, @maxlength = "50" }) %>
                <br>
                <label for="fullname">
                    Situação* :
                </label>
                <%: Html.DropDownList("id_situacao", ViewBag.situacao as IEnumerable<SelectListItem>, "Selecione", new { @class = "form-control", @required = true, @maxlength = "50" }) %>
                <br>
                <label for="fullname">
                    Diaria* :</label>
                <%: Html.TextBoxFor(m => m.valor_diaria, new { @class = "form-control", @required = true, @maxlength = "50" })%>
            </div>
            <div class="col-md-12 col-sm-12 col-xs-12 form-group has-feedback">
                <label for="message">
                    Observação :</label>
                <%: Html.TextAreaFor(m => m.obs, new { @class = "form-control", @maxlength = "50" })%>
                <br>
                <input type="button" onclick="Alterar(event);" class="btn btn-success" value="Salvar">
                <a type="button" class="btn btn-danger" href="/Carros/Index">Voltar</a>
            </div>
            <!-- CAMPOS OCULTOS -->
            <%: Html.HiddenFor(m => m.id)%>
            <!-- /CAMPOS OCULTOS -->
            </form>
            <!-- end form for validations -->
        </div>
    </div>
    <div name="scripts">
        <script src="../../Scripts/carros/funcoes-edit.js" type="text/javascript"></script>
    </div>
</asp:Content>
