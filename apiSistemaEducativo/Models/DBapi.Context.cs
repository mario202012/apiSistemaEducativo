﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class apicentroacademicoEntities : DbContext
    {
        public apicentroacademicoEntities()
            : base("name=apicentroacademicoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aula> aulas { get; set; }
        public virtual DbSet<horario> horarios { get; set; }
        public virtual DbSet<materia> materias { get; set; }
        public virtual DbSet<materia_estudiante> materia_estudiante { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<estudiante> estudiantes { get; set; }
    }
}
