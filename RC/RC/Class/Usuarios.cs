using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Class
{
    public class Usuarios
    {
        public string nome { get; set; }
        public string login { get; set; }
        public int id { get; set; }
        public TipoPermissao tipo { get; set; }
    }
}