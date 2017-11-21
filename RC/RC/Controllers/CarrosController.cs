using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Models;
using RC.DM;
using System.IO;
using RC.Class;

namespace RC.Controllers
{
    public class CarrosController : Controller
    {
        private string Controller = "/Carros/";

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.situacao = CarrosModel.getSituacao("");
            ViewBag.status = CarrosModel.getStatus("5");
            tb_carro carro = new tb_carro();
            return View(carro);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            tb_carro carro = CarrosModel.Carro(id);
            ViewBag.situacao = CarrosModel.getSituacao(carro.id_situacao.ToString());
            ViewBag.status = CarrosModel.getStatus(carro.id_status.ToString());
            return View(carro);
        }

        [HttpPost]
        public ActionResult DataIndex(FormCollection form)
        {
            var consulta = CarrosModel.Buscar(form);
            return Json(consulta, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            string action = string.Empty;
            int[] resultado = CarrosModel.Salvar(form);
            SalvarImagem(CarrosModel.Carro(resultado[1]));
            switch (resultado[0])
            {
                case 0:
                    action = "Create";
                    break;
                case 1:
                    action = "Index";
                    break;
                case 2:
                    action = "Create";
                    break;
            }
            return RedirectToAction(action);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            string action = string.Empty;
            int id = Convert.ToInt32(form["id"]);
            int resultado = CarrosModel.Alterar(form);
            SalvarImagem(CarrosModel.Carro(id));
            switch (resultado)
            {
                case 0:
                    action = "Edit";
                    break;
                case 1:
                    action = "Index";
                    break;
                case 2:
                    action = "Edit";
                    break;
            }
            return RedirectToAction(action);
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
            int resultado = CarrosModel.HabilitarDesabolitar(form);
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
                    retorno[1] = "Não foi possivel alterar registro, Registro não encontrado!";
                    retorno[2] = "";
                    break;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        private void SalvarImagem(tb_carro carro)
        {
            try
            {
                HttpPostedFileBase arquivo = Request.Files[0];
                if (arquivo.ContentLength > 0)
                {
                    if (arquivo.ContentType.Contains("image"))
                    {
                        var uploadPath = Server.MapPath("~/Content/imagem-carros/");
                        ///string extensao = Path.GetExtension(arquivo.FileName);
                        string nomeArquivo = carro.id + ".jpg";
                        string caminhoArquivo = Path.Combine(@uploadPath, Path.GetFileName(nomeArquivo));
                        arquivo.SaveAs(caminhoArquivo);
                        RedefinirImagem.ResizeImage(caminhoArquivo, caminhoArquivo, 300, 300, true);
                        //RedefinirImagem.MudaExtencaoImagem(caminhoArquivo, nomeArquivo, carro.id.ToString());
                        //DeletaImagens(carro.id);
                        CarrosModel.SalvarImagem(carro.id, nomeArquivo);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void DeletaImagens(int id)
        {
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(@Server.MapPath("~/Content/imagem-carros/"));
                FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);

                if (id != null)
                {
                    foreach (FileInfo item in Files)
                    {
                        string img = item.Name.Split('.')[0];
                        if (item.Extension.ToLower() != "jpg" && item.Extension.ToLower() != "jpge")
                        {
                            if (img == id.ToString())
                            {
                                string arquivo = item.Name;
                                System.IO.FileInfo fi = new System.IO.FileInfo(item.FullName);
                                fi.Delete();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private bool VerificaImagem(tb_carro carro)
        {
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(@Server.MapPath("~/Content/imagem-carros/"));
                FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);

                if (carro != null)
                {
                    foreach (FileInfo File in Files)
                    {
                        string img = File.Name.Split('.')[0];
                        if (img == carro.id.ToString())
                            return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
