using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.DM;
using System.Web.Mvc;
using RC.Class;

namespace RC.Models
{
    public class CarrosModel
    {
        public static List<v_get_carros> Buscar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            List<v_get_carros> carros = new List<v_get_carros>();
            try
            {
                carros = db.v_get_carros.ToList();
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

        public static tb_carro Carro(int id)
        {
            RentCarEntities db = new RentCarEntities();
            tb_carro carro = new tb_carro();
            try
            {
                var carros = db.tb_carro.Where(c => c.id == id).FirstOrDefault();
                if (carros != null)
                {
                    carro = carros;
                }
                return carro;
            }
            catch (Exception ex)
            {
                return carro;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int[] Salvar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            int[] retorno = new int[2];
            try
            {
                if (form.Count >= 9)
                {
                    tb_carro Carro = new tb_carro();
                    Carro.modelo = form["modelo"];
                    Carro.marca = form["marca"];
                    Carro.placa = form["placa"];
                    Carro.obs = form["obs"];
                    Carro.id_status = Convert.ToInt32(form["id_status"]);
                    Carro.id_situacao = Convert.ToInt32(form["id_situacao"]);
                    Carro.imagem = "";
                    Carro.data_fabricacao = form["data_fabricacao"];
                    Carro.valor_diaria = Convert.ToInt32(form["valor_diaria"]);
                    Carro.cor = form["cor"];
                    db.tb_carro.AddObject(Carro);
                    db.SaveChanges();

                    retorno[0] = 1;
                    retorno[1] = Carro.id;
                    return retorno;
                }
                else
                {
                    retorno[0] = 3;
                    retorno[1] = 0;
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                retorno[0] = 0;
                retorno[1] = 0;
                return retorno;
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
                tb_carro Carro = db.tb_carro.Where(c => c.id == id).FirstOrDefault();

                if (form.Count >= 9)
                {
                    if (Carro != null)
                    {
                        Carro.modelo = form["modelo"];
                        Carro.marca = form["marca"];
                        Carro.placa = form["placa"];
                        Carro.obs = form["obs"];
                        Carro.id_status = Convert.ToInt32(form["id_status"]);
                        Carro.id_situacao = Convert.ToInt32(form["id_situacao"]);
                        Carro.imagem = "";
                        Carro.data_fabricacao = form["data_fabricacao"];
                        Carro.valor_diaria = Convert.ToDecimal(form["valor_diaria"]);
                        Carro.cor = form["cor"];
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

        public static int SalvarImagem(int id, string img)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                tb_carro Carro = db.tb_carro.Where(c => c.id == id).FirstOrDefault();
                if (Carro != null)
                {
                    Carro.imagem = img;
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
                tb_carro Carro = db.tb_carro.Where(c => c.id == id).FirstOrDefault();
                if (Carro != null)
                {
                    Carro.id_status = status;
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

        public static IEnumerable<SelectListItem> getSituacao(string selecione)
        {
            RentCarEntities db = new RentCarEntities();
            SelectList _SelectList = null;
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                var retorno = db.tb_dominio.Where(c => c.categoria == 3).ToList();
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