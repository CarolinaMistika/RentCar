using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.DM;
using System.Web.Mvc;
using RC.Class;
using System.Net.Mail;

namespace RC.Models
{
    public class AlugueisModel
    {
        public static List<v_get_aluguel> Buscar(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            List<v_get_aluguel> aluguel = new List<v_get_aluguel>();
            try
            {
                aluguel = db.v_get_aluguel.OrderByDescending(c => c.id).ToList();
                return aluguel;
            }
            catch (Exception ex)
            {
                return aluguel;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static List<v_get_lista_espera> BuscarListaEspera(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            List<v_get_lista_espera> lista = new List<v_get_lista_espera>();
            try
            {
                lista = db.v_get_lista_espera.Where(c => c.id_status != 2).OrderByDescending(c => c.id).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static tb_aluguel Aluguel(int id)
        {
            RentCarEntities db = new RentCarEntities();
            tb_aluguel aluguel = new tb_aluguel();
            try
            {
                var alugueis = db.tb_aluguel.Where(c => c.id == id).FirstOrDefault();
                if (alugueis != null)
                {
                    aluguel = alugueis;
                }
                return aluguel;
            }
            catch (Exception ex)
            {
                return aluguel;
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
                if (form.Count >= 5)
                {
                    tb_aluguel Aluguel = new tb_aluguel();
                    Aluguel.data_aluguel = DateTime.Now; ;
                    //Aluguel.data_devolucao 
                    Aluguel.data_final = Convert.ToDateTime(form["data_final"]);
                    Aluguel.data_inicial = Convert.ToDateTime(form["data_inicial"]);
                    Aluguel.id_carro = Convert.ToInt32(form["id_carro"]);
                    Aluguel.id_cliente = Convert.ToInt32(form["id_cliente"]);
                    Aluguel.id_funcionario = Convert.ToInt32(form["id_funcionario"]);
                    db.tb_aluguel.AddObject(Aluguel);
                    db.SaveChanges();
                    AlterarCarro(Convert.ToInt32(form["id_funcionario"]));
                    return 1;
                }
                else
                {
                    return 3;
                }
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
                tb_aluguel Aluguel = db.tb_aluguel.Where(c => c.id == id).FirstOrDefault();
                if (Aluguel != null)
                {
                    Aluguel.data_devolucao = DateTime.Now;
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

        public static int AlterarCarro(int id)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                tb_carro Carro = db.tb_carro.Where(c => c.id == id).FirstOrDefault();
                if (Carro != null)
                {
                    Carro.id_situacao = 8;
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

        public static int AlterarListaEspera(FormCollection form)
        {
            RentCarEntities db = new RentCarEntities();
            try
            {
                int id = Convert.ToInt32(form["id"]);
                tb_lista_espera registro = db.tb_lista_espera.Where(c => c.id == id).FirstOrDefault();
                if (registro != null)
                {
                    registro.id_status = Convert.ToInt32(form["tipo"]);
                    if (registro.id_status == 1)
                    {
                        var cli = ClientesModel.Cliente(registro.id_cliente);
                        Email(cli.login);
                    }
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

        public static IEnumerable<SelectListItem> getClientes(string selecione)
        {
            RentCarEntities db = new RentCarEntities();
            SelectList _SelectList = null;
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                var retorno = db.v_get_usuarios.Where(c => c.id_tipo == 2).ToList();
                foreach (var item in retorno)
                {
                    SelectListItem unidade = new SelectListItem();
                    unidade.Value = item.id.ToString();
                    unidade.Text = item.nome + " / " + item.cpf;
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

        public static IEnumerable<SelectListItem> getCarros(string selecione)
        {
            RentCarEntities db = new RentCarEntities();
            SelectList _SelectList = null;
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                var retorno = db.v_get_carros.Where(c => c.id_situacao == 7 && c.id_status == 5).ToList();
                foreach (var item in retorno)
                {
                    SelectListItem unidade = new SelectListItem();
                    unidade.Value = item.id.ToString();
                    unidade.Text = item.modelo + " / " + item.placa + " / " + item.cor;
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

        private static void Email(string email)
        {
            try
            {
                string assunto = "Carro Liberado para Aluguel";
                string corpo = "O carro que voçê escolheu já esta disponivel para alugar, vá até a loja para realizar o pagamento";
                Funcoes.EMail(assunto, corpo, email);
            }
            catch (Exception ex)
            {
            }
        }
    }
}