using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using RC.Class;
using RC.DM;
using System.Linq;

namespace RC.Models
{

    public class Account
    {
        public static Usuarios Autentication(string user, string pass)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                Usuarios usuario = new Usuarios();
                pass = Funcoes.base64Encode(pass);
                var lista = db.v_get_usuarios.Where(c => c.login.ToLower().Trim() == user.ToLower().Trim() && c.senha == pass).FirstOrDefault();
                if (lista != null)
                {
                    usuario.id = lista.id;
                    usuario.login = lista.login;
                    usuario.nome = lista.nome;
                    if (lista.id_tipo == 1)
                    {
                        if (lista.id_cargo == 10)
                            usuario.tipo = TipoPermissao.ADMINISTRADOR;
                        else if (lista.id_cargo == 11)
                            usuario.tipo = TipoPermissao.FUNCIONARIO;
                    }
                    else if (lista.id_tipo == 2)
                        usuario.tipo = TipoPermissao.CLIENTE;
                }
                else
                    usuario = null;
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

    }

}
