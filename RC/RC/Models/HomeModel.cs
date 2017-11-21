using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.DM;
using System.Web.Mvc;

namespace RC.Models
{
    public class HomeModel
    {
        public static List<v_get_carros> Buscar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            List<v_get_carros> carros = new List<v_get_carros>();
            try
            {
                string parametros = string.Empty;
                if (!string.IsNullOrEmpty(form["modelo"]))
                {
                    if (!string.IsNullOrEmpty(parametros))
                        parametros += " and ";
                    parametros += " modelo like'%" + form["modelo"] + "%'";
                }
                if (!string.IsNullOrEmpty(form["marca"]))
                {
                    if (!string.IsNullOrEmpty(parametros))
                        parametros += " and ";
                    parametros += " marca like'%" + form["marca"] + "%'";
                }
                if (!string.IsNullOrEmpty(form["data_fabricacao"]))
                {
                    if (!string.IsNullOrEmpty(parametros))
                        parametros += " and ";
                    parametros += " data_fabricacao like'%" + form["data_fabricacao"] + "%'";
                }
                if (!string.IsNullOrEmpty(form["cor"]))
                {
                    if (!string.IsNullOrEmpty(parametros))
                        parametros += " and ";
                    parametros += " cor like'%" + form["cor"] + "%'";
                }
                if (!string.IsNullOrEmpty(form["placa"]))
                {
                    if (!string.IsNullOrEmpty(parametros))
                        parametros += " and ";
                    parametros += " placa like'%" + form["placa"] + "%'";
                }

                if (!string.IsNullOrEmpty(parametros))
                    parametros = " where " + parametros;
                string sql = "select * from v_get_carros" + parametros + ";";
                carros = db.ExecuteStoreQuery<v_get_carros>(sql, null).ToList();
                return carros;
            }
            catch (Exception ex)
            {
                return carros;
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
                if (form.Count >= 1)
                {

                    string[] datas = form["datas"].Split('-');
                    tb_lista_espera lista = new tb_lista_espera();
                    lista.id_carro = Convert.ToInt32(form["id_carro"]);
                    lista.id_cliente = Convert.ToInt32(form["id_cliente"]);
                    lista.data_inicio = datas[0];
                    lista.data_fim = datas[1];
                    lista.id_status = 0;
                    if (db.tb_lista_espera.Where(c => c.id_carro == lista.id_carro && c.id_cliente == lista.id_cliente && c.id_status != 1).Count() == 0)
                    {
                        db.tb_lista_espera.AddObject(lista);
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

    }
}