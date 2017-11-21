using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Models;
using RC.DM;
using RC.Class;

namespace RC.Controllers
{
    public class AlugueisController : Controller
    {
        private string Controller = "/Alugueis/";
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Usuarios USUARIO = (Usuarios)Session["USUARIO"];
            ViewBag.usuarios = AlugueisModel.getClientes("");
            ViewBag.carros = AlugueisModel.getCarros("");
            tb_aluguel aluguel = new tb_aluguel();
            aluguel.id_funcionario = USUARIO.id;
            return View(aluguel);
        }

        [HttpGet]
        public ActionResult Clientes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataIndex(FormCollection form)
        {
            var consulta = AlugueisModel.Buscar(form);
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DataListaEspera(FormCollection form)
        {
            var consulta = AlugueisModel.BuscarListaEspera(form);
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            /* COMENTARIOS
             * Retorno 0: tipo de retorno true/false;
             * Retorno 1: Mensagem de retorno; 
             * Retorno 2: caminho caso queira redireciona para outro lugar 
             */
            string[] retorno = new string[3];
            int resultado = AlugueisModel.Salvar(form);
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
                    retorno[1] = "Não foi possivel salvar registro, Login já cadastrado!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            /* COMENTARIOS
            * Retorno 0: tipo de retorno true/false;
            * Retorno 1: Mensagem de retorno; 
            * Retorno 2: caminho caso queira redireciona para outro lugar 
            */
            string[] retorno = new string[3];
            int resultado = AlugueisModel.Alterar(form);
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
                    retorno[1] = "Não foi possivel salvar registro, Usuario não encontrado!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AlterarListaEspera(FormCollection form)
        {
            /* COMENTARIOS
            * Retorno 0: tipo de retorno true/false;
            * Retorno 1: Mensagem de retorno; 
            * Retorno 2: caminho caso queira redireciona para outro lugar 
            */
            string[] retorno = new string[3];
            int resultado = AlugueisModel.AlterarListaEspera(form);
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
                    retorno[1] = "Não foi possivel salvar registro, Registro não encontrado!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}
