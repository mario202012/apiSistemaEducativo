using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSistemaEducativo.Models
{
    public class DTOestudiantes
    {

        public int IDestudiante { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string estatus { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
    }
}