using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSistemaEducativo.Models
{
    public class DTOparaMostrarEstudiantesYsusCursos
    {
        public int IDestudiante_materia { get; set; }
        public int IDestudiante { get; set; }

        public string estudiante{ get; set; }
        public int IDmateria { get; set; }

        public string materia { get; set; }
    }
}