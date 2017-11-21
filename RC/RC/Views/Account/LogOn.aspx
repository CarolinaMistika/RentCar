<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteClin.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content" id="login-page">
        <div class="container-fluid col-md-6">
            <div class="panel" id="login-panel">
                <div class="panel-heading">
                    <div class="vcentered" style="text-align: center;">
                        <h1 class="logo-name">
                            <img src="../../Content/images/LOGO.png" width="100px" />
                        </h1>
                    </div>
                </div>
                <div class="panel-body">
                    <form role="form" method="post" action="/Account/LogOn">
                    <div class="row">
                        <center>
                            <strong>Bem-vindo ao sistema Rent Car</strong>
                        </center>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="Login">
                                    Login</label>
                                <input type="text" class="form-control" id="Text1" name="TxtUsuario" placeholder="Login"
                                    required>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="Password">
                                    Senha</label>
                                <input type="password" class="form-control" id="Password1" name="TxtSenha" placeholder="Senha"
                                    required>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <%if ((string)ViewBag.Erro != null)
                              { %>
                            <div class="alert alert-danger alert-dismissable" style="height: 43px;">
                                <button aria-hidden="true" data-dismiss="alert" class="close" type="button">
                                    ×</button>
                                <%=Html.Label("", (string)ViewBag.Erro)%>
                            </div>
                            <%} %>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <input type="submit" class="btn btn-lg btn-info btn-block" value="Entrar">
                        </div>
                    </div>
                    <p class="m-t" style="text-align: center">
                        <small>
                            <%= DateTime.Now.Year.ToString() %></small>
                    </p>
                    </form>
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>
