using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.DM;
using RC.Class;

namespace RC.Models
{
    public class FuncionariosModel
    {
        public static List<v_get_usuarios> Buscar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            List<v_get_usuarios> usuarios = new List<v_get_usuarios>();
            try
            {
                usuarios = db.v_get_usuarios.Where(c => c.id_tipo == 1).ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                return usuarios;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static tb_usuarios Funcionario(int id)
        {
            RentCarEntities db = new RentCarEntities();
            tb_usuarios usuario = new tb_usuarios();
            try
            {
                var usuarios = db.tb_usuarios.Where(c => c.id == id).FirstOrDefault();
                if (usuarios != null)
                {
                    usuarios.senha = Funcoes.base64Decode(usuarios.senha);
                    usuario = usuarios;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                return usuario;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int Salvar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                if (form.Count >= 7)
                {
                    string login = Convert.ToString(form["login"]);
                    var QtdeUsuarios = db.v_get_usuarios.Where(c => c.login.Trim().ToLower() == login.Trim().ToLower()).Count();
                    if (QtdeUsuarios <= 0)
                    {
                        tb_usuarios Usuario = new tb_usuarios();
                        Usuario.cpf = form["cpf"];
                        Usuario.id_cargo = Convert.ToInt32(form["id_cargo"]);
                        Usuario.id_tipo = Convert.ToInt32(form["id_tipo"]);
                        Usuario.id_status = Convert.ToInt32(form["id_status"]);
                        Usuario.login = form["login"];
                        Usuario.nome = form["nome"];
                        Usuario.senha = Funcoes.base64Encode(form["senha"]);
                        db.tb_usuarios.AddObject(Usuario);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                        return 2;
                }
                else
                    return 3;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int Alterar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                int id = Convert.ToInt32(form["id"]);
                tb_usuarios Usuario = db.tb_usuarios.Where(c => c.id == id).FirstOrDefault();
                if (Usuario != null)
                {

                    Usuario.cpf = form["cpf"];
                    Usuario.id_cargo = Convert.ToInt32(form["id_cargo"]);
                    Usuario.id_tipo = Convert.ToInt32(form["id_tipo"]);
                    Usuario.id_status = Convert.ToInt32(form["id_status"]);
                    Usuario.nome = form["nome"];
                    Usuario.senha = Funcoes.base64Encode(form["senha"]);
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 2;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int Excluir(int id)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                tb_usuarios Usuario = db.tb_usuarios.Where(c => c.id == id).FirstOrDefault();
                if (Usuario != null)
                {
                    db.tb_usuarios.DeleteObject(Usuario);
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 2;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int HabilitarDesabolitar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                int id = Convert.ToInt32(form["id"]);
                int status = Convert.ToInt32(form["tipo"]);
                tb_usuarios Usuario = db.tb_usuarios.Where(c => c.id == id).FirstOrDefault();
                if (Usuario != null)
                {
                    Usuario.id_status = status;
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 2;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static IEnumerable<SelectListItem> getCargo(string selecione)
        {
            RentCarEntities db = new RentCarEntities();
            SelectList _SelectList = null;
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                var retorno = db.tb_dominio.Where(c => c.categoria == 7).ToList();
                foreach (var item in retorno)
                {
                    SelectListItem unidade = new SelectListItem();
                    unidade.Value = item.id.ToString();
                    unidade.Text = item.descricao;
                    lista.Add(unidade);
                }
                return _SelectList = new SelectList(lista, "Value", "Text", selecione);
            }
            catch (Exception ex)
            {
                return _SelectList = new SelectList(lista, "Value", "Text", selecione);
            }
            finally
            {
                db.Dispose();
            }
        }

        public static IEnumerable<SelectListItem> getStatus(string selecione)
        {
            RentCarEntities db = new RentCarEntities();
            SelectList _SelectList = null;
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                var retorno = db.tb_dominio.Where(c => c.categoria == 6).ToList();
                foreach (var item in retorno)
                {
                    SelectListItem unidade = new SelectListItem();
                    unidade.Value = item.id.ToString();
                    unidade.Text = item.descricao;
                    lista.Add(unidade);
                }
                return _SelectList = new SelectList(lista, "Value", "Text", selecione);
            }
            catch (Exception ex)
            {
                return _SelectList = new SelectList(lista, "Value", "Text", selecione);
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}