using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using RC.Models;
using RC.Class;

namespace RC.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection form)
        {
            try
            {
                string login = form["TxtUsuario"];
                string senha = form["TxtSenha"];
                if ((login != "") && (senha != ""))
                {
                    Usuarios dadosAutenticacao = Account.Autentication(login, senha);
                    if (dadosAutenticacao != null)
                    {
                        FormsAuthentication.SetAuthCookie(dadosAutenticacao.login, false);
                        Session["USUARIO"] = dadosAutenticacao;

                        if (dadosAutenticacao.tipo == TipoPermissao.ADMINISTRADOR)
                            return RedirectToAction("CarrosFuncionarios", "Home");
                        else if (dadosAutenticacao.tipo == TipoPermissao.FUNCIONARIO)
                            return RedirectToAction("CarrosFuncionarios", "Home");
                        if (dadosAutenticacao.tipo == TipoPermissao.CLIENTE)
                            return RedirectToAction("CarrosClientes", "Home");
                        else
                            return View();
                    }
                    else
                    {
                        ViewBag.Erro = "Login ou senha incorretos!";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("LogOn", "Account");
        }

        public ActionResult Sessao()
        {
            return View();
        }

        [Authorize]
        public ActionResult Erro401()
        {
            return View();
        }

        [Authorize]
        public ActionResult Erro404()
        {
            return View();
        }

        [Authorize]
        public ActionResult Erro500()
        {
            return View();
        }
    }
}
