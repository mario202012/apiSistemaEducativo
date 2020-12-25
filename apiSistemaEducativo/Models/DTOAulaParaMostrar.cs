using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSistemaEducativo.Models
{
    public class DTOAulaParaMostrar
    {
        public int IDaula { get; set; }
        public string descripcion { get; set; }
        public int IDmateria { get; set; }

        public string materia { get; set; }
        public int IDhorario { get; set; }

        public string horario { get; set; }
    }
}