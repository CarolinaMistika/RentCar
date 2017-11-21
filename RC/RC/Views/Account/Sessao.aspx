<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sua sessão expirou</title>
    <link href="../../Content/erros/css/bootstrap.min.css" rel="stylesheet">
    <link href="../../Content/erros/css/animate.css" rel="stylesheet">
    <link href="../../Content/erros/css/style.css" rel="stylesheet">
    <link rel="stylesheet" href="/Content/addons/ionicons/css/ionicons.css" />
</head>
<body class="gray-bg">
    <div class="middle-box text-center animated fadeInDown">
        <h1>
            <span class="ion ion-alert-circled"></span>
        </h1>
        <h3 class="font-bold">
            Sua sessão expirou!</h3>
        <div class="error-desc">
            Você pode voltar para a página inicial para fazer o login
            <br />
            <a href="/Account/LogOn" class="btn btn-info m-t">Voltar</a>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script src="../../Content/erros/js/jquery-1.10.2.js"></script>
    <script src="../../Content/erros/js/bootstrap.min.js"></script>
</body>
</html>
