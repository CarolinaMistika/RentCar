<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Erro 500</title>
    <link href="../../Content/erros/css/bootstrap.min.css" rel="stylesheet">
    <link href="../../Content/erros/css/animate.css" rel="stylesheet">
    <link href="../../Content/erros/css/style.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <div class="middle-box text-center animated fadeInDown">
        <h1>
            500</h1>
        <h3 class="font-bold">
            Erro do Servidor Interno</h3>
        <div class="error-desc">
            O servidor encontrou algo inesperado que não permite que ele possa concluir a solicitação.
            Pedimos desculpas.<br />
            Você pode voltar para página principal:
            <br />
            <a href="/Home/Index" class="btn btn-info">Voltar</a>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script src="../../Content/erros/js/jquery-1.10.2.js"></script>
    <script src="../../Content/erros/js/bootstrap.min.js"></script>
</body>
</html>
