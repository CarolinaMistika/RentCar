using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;

namespace RC.Class
{
    public class Permissao : AuthorizeAttribute
    {
        public TipoPermissao[] _TipoPermissao { get; set; }
        private bool sessaoExpirada = false;
        private bool autorizado = false;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            IPrincipal user = httpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                this.sessaoExpirada = true;
                return false;
            }
            if (httpContext.Session.Count == 0)
            {
                this.sessaoExpirada = true;
                return false;
            }

            bool temPermissao = false;

            if (_TipoPermissao.Contains(TipoPermissao.TODOS))
            {
                temPermissao = true;
                return true;
            }

            Usuarios USUARIO = (Usuarios)httpContext.Session["USUARIO"];

            foreach (TipoPermissao permissao in _TipoPermissao)
            {
                if (USUARIO.tipo == permissao)
                {
                    temPermissao = true;
                    break;
                }
            }

            if (temPermissao)
            {
                this.autorizado = true;
                return true;
            }
            else
            {
                this.autorizado = false;
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            UrlHelper urlHelper = new UrlHelper(context.RequestContext);
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                if (this.sessaoExpirada)
                {
                    context.HttpContext.Response.StatusCode = 601;
                    context.Result = Funcoes.RetornaJsonResult(urlHelper.Action("Sessao", "Account"));
                }
                else if (!this.autorizado)
                {
                    context.HttpContext.Response.StatusCode = 602;
                    context.Result = Funcoes.RetornaJsonResult(urlHelper.Action("Erro401", "Account"));
                }
            }
            else
            {
                if (this.sessaoExpirada)
                    context.Result = new RedirectResult(urlHelper.Action("Sessao", "Account"));
                else if (!this.autorizado)
                    context.Result = new RedirectResult(urlHelper.Action("Erro401", "Account"));
            }
        }
    }

}