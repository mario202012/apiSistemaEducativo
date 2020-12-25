using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSistemaEducativo.Models
{
    public class DTOaulas
    {
        public int IDaula { get; set; }
        public string descripcion { get; set; }
        public int IDmateria { get; set; }
        public int IDhorario { get; set; }
    }
}