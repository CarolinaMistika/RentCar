using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Class;
using RC.Models;

namespace RC.Controllers
{
    public class HomeController : Controller
    {
        private string Controller = "/Home/";

        [HttpGet]
        public ActionResult Index()
        {
            Usuarios USUARIO = (Usuarios)Session["USUARIO"];
            if (USUARIO != null)
            {
                if (USUARIO.tipo == TipoPermissao.ADMINISTRADOR)
                    return RedirectToAction("CarrosFuncionarios");
                else if (USUARIO.tipo == TipoPermissao.FUNCIONARIO)
                    return RedirectToAction("CarrosFuncionarios");
                if (USUARIO.tipo == TipoPermissao.CLIENTE)
                    return RedirectToAction("CarrosClientes");
                else
                    return RedirectToAction("LogOn", "Account");
            }
            else
                return RedirectToAction("Carros");

        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Carros()
        {
            FormCollection Form = new FormCollection();
            ViewBag.carros = CarrosModel.Buscar(Form);
            return View();
        }

        [HttpGet]
        public ActionResult CarrosClientes()
        {
            Usuarios USUARIO = (Usuarios)Session["USUARIO"];
            FormCollection Form = new FormCollection();
            ViewBag.carros = CarrosModel.Buscar(Form);
            ViewBag.idCliente = USUARIO.id.ToString();
            return View();
        }

        [HttpGet]
        public ActionResult CarrosFuncionarios()
        {
            FormCollection Form = new FormCollection();
            ViewBag.carros = CarrosModel.Buscar(Form);
            return View();
        }

        [HttpPost]
        public ActionResult Carros(FormCollection Form)
        {
            ViewBag.carros = HomeModel.Buscar(Form);
            return View();
        }

        [HttpPost]
        public ActionResult CarrosClientes(FormCollection Form)
        {
            ViewBag.carros = HomeModel.Buscar(Form);
            return View();
        }

        [HttpPost]
        public ActionResult CarrosFuncionarios(FormCollection Form)
        {
            ViewBag.carros = HomeModel.Buscar(Form);
            return View();
        }

        [HttpPost]
        public ActionResult Reservar(FormCollection form)
        {

            /* COMENTARIOS
             * Retorno 0: tipo de retorno true/false;
             * Retorno 1: Mensagem de retorno; 
             * Retorno 2: caminho caso queira redireciona para outro lugar 
             */
            string[] retorno = new string[3];
            int resultado = HomeModel.Salvar(form);
            switch (resultado)
            {
                case 0:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel salvar registro!";
                    retorno[2] = "";
                    break;
                case 1:
                    retorno[0] = "true";
                    retorno[1] = "Salvo com sucesso!";
                    retorno[2] = Controller + "Index";
                    break;
                case 2:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel salvar registro, Carro já adicionado para reserva!";
                    retorno[2] = "";
                    break;
                default:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel salvar registro!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);

        }

    }
}
