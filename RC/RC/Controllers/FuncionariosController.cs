using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Models;
using RC.DM;

namespace RC.Controllers
{
    public class FuncionariosController : Controller
    {
        private string Controller = "/Funcionarios/";

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.cargo = FuncionariosModel.getCargo("");
            ViewBag.status = FuncionariosModel.getStatus("5");
            tb_usuarios usuario = new tb_usuarios();
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            tb_usuarios usuario = FuncionariosModel.Funcionario(id);
            ViewBag.cargo = FuncionariosModel.getCargo(usuario.id_cargo.ToString());
            ViewBag.status = FuncionariosModel.getStatus(usuario.id_status.ToString());
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            /* COMENTARIOS
            * Retorno 0: tipo de retorno true/false;
            * Retorno 1: Mensagem de retorno; 
            * Retorno 2: caminho caso queira redireciona para outro lugar 
            */
            string[] retorno = new string[3];
            int resultado = FuncionariosModel.Excluir(id);
            switch (resultado)
            {
                case 0:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel excluir registro!";
                    retorno[2] = "";
                    break;
                case 1:
                    retorno[0] = "true";
                    retorno[1] = "Excluido com sucesso!";
                    retorno[2] = "";
                    break;
                case 2:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel excluir registro, registro não encontrado!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DataIndex(FormCollection form)
        {
            var consulta = FuncionariosModel.Buscar(form);
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
            int resultado = FuncionariosModel.Salvar(form);
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
                default:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel salvar registro!";
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
            int resultado = FuncionariosModel.Alterar(form);
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
        public ActionResult HabilitaDesabilita(FormCollection form)
        {
            /* COMENTARIOS
            * Retorno 0: tipo de retorno true/false;
            * Retorno 1: Mensagem de retorno; 
            * Retorno 2: caminho caso queira redireciona para outro lugar 
            */
            string[] retorno = new string[3];
            int resultado = FuncionariosModel.HabilitarDesabolitar(form);
            switch (resultado)
            {
                case 0:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel alterar registro!";
                    retorno[2] = "";
                    break;
                case 1:
                    retorno[0] = "true";
                    retorno[1] = "Alterado com sucesso!";
                    retorno[2] = Controller + "Index";
                    break;
                case 2:
                    retorno[0] = "false";
                    retorno[1] = "Não foi possivel alterar registro, Usuario não encontrado!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

    }
}
