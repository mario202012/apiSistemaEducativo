//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apiSistemaEducativo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estudiante()
        {
            this.materia_estudiante = new HashSet<materia_estudiante>();
        }
    
        public int IDestudiante { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string estatus { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materia_estudiante> materia_estudiante { get; set; }
    }
}
