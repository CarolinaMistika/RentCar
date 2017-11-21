<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteClin.Master" Inherits="System.Web.Mvc.ViewPage<RC.DM.tb_carro>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="pesquisa" class="form-horizontal" method="post">
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-2">
                <label>
                    Modelo</label>
                <%: Html.TextBox("modelo", "", new { @class = "form-control", @maxlength = "50" })%>
            </div>
            <div class="col-md-2">
                <label>
                    Marca</label>
                <%: Html.TextBox("marca", "", new { @class = "form-control", @maxlength = "50" })%>
            </div>
            <div class="col-md-2">
                <label>
                    Ano</label>
                <%: Html.TextBox("data_fabricacao", "", new { @class = "form-control", @maxlength = "50" })%>
            </div>
            <div class="col-md-2">
                <label>
                    Cor</label>
                <%: Html.TextBox("cor", "", new { @class = "form-control", @maxlength = "50" })%>
            </div>
            <div class="col-md-2">
                <label>
                    Placa</label>
                <%: Html.TextBox("placa", "", new { @class = "form-control", @maxlength = "50" })%>
            </div>
            <br />
            <input type="submit" class="btn btn-success" value="Pesquisar" />
        </div>
    </div>
    <br />
    <br />
    <div class="x_panel">
        <div class="x_title">
            <h2>
                Lista de carros</h2>
            <ul class="nav navbar-right panel_toolbox">
            </ul>
            <div class="clearfix">
            </div>
        </div>
        <div class="x_content">
            <% List<RC.DM.v_get_carros> carros = (List<RC.DM.v_get_carros>)ViewBag.carros; %>
            <%foreach (RC.DM.v_get_carros item in carros)
              { %>
            <div class="col-md-6 col-sm-6 col-xs-12 profile_details">
                <div class="well profile_view">
                    <div class="col-sm-12">
                        <h4 class="brief">
                            <span class="label label-success">Disponível</span></h4>
                        <div class="left col-xs-7">
                            <h2>
                                <%:item.modelo%></h2>
                            <p>
                                <strong>Marca: </strong>
                                <%:item.marca%></p>
                            <ul class="list-unstyled">
                                <li><i class="fa fa-calendar"></i><strong>A. Fabricação:</strong>
                                    <%:item.data_fabricacao%></li>
                                <li><i class="fa fa-eyedropper"></i><strong>Cor : </strong>
                                    <%:item.cor%></li>
                                <li><i class="fa fa-car"></i><strong>Placa : </strong>
                                    <%:item.placa%></li>
                                <li><i class="fa fa-info-circle"></i><strong>Observação : </strong>
                                    <br>
                                    <%:item.obs%></li>
                            </ul>
                        </div>
                        <div class="right col-xs-5 text-center">
                            <img src="../../Content/imagem-carros/<%:item.imagem%>" alt="" class="img-circle img-responsive">
                        </div>
                    </div>
                    <div class="col-xs-12 bottom text-center">
                        <div class="col-xs-8 col-sm-8 emphasis">
                        </div>
                        <div class="col-xs-4 col-sm-4 emphasis">
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
        </div>
    </div>
    </form>
</asp:Content>
