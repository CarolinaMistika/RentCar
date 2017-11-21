<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Http Status 401</title>
    <link href="../../Content/erros/css/bootstrap.min.css" rel="stylesheet">
    <link href="../../Content/erros/css/animate.css" rel="stylesheet">
    <link href="../../Content/erros/css/style.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <div class="middle-box text-center animated fadeInDown">
        <h1>401</h1>
        <h3 class="font-bold">Não Autorizado</h3>

        <div class="error-desc">
            A solicitação requer autenticação. O servidor pode retornar essa resposta para uma página que necessita de login.<br/>
            Você pode voltar para a página inicial: <br/><a href="/Home/Index" class="btn btn-info m-t">Voltar</a>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script src="../../Content/erros/js/jquery-1.10.2.js"></script>
    <script src="../../Content/erros/js/bootstrap.min.js"></script>
</body>
</html>
