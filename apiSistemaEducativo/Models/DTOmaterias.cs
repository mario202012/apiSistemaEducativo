using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSistemaEducativo.Models
{
    public class DTOmaterias
    {
        public int IDmateria { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> credito { get; set; }
        public Nullable<int> precio { get; set; }
        public string estatus { get; set; }
    }
}