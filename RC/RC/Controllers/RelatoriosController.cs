using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RC.Controllers
{
    public class RelatoriosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExecelMes()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExecelAno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataMes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataAno()
        {
            return View();
        }


    }
}
