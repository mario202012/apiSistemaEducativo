using apiSistemaEducativo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace apiSistemaEducativo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class materiaEstudiantesController : ApiController
    {
        apicentroacademicoEntities context = new apicentroacademicoEntities();
        // GET: api/materiaEstudiantes
        public IEnumerable<DTOparaMostrarEstudiantesYsusCursos> Get()
        {
            var result = new List<DTOparaMostrarEstudiantesYsusCursos>();

            var MateriaEstudiante = context.materia_estudiante.ToList();

            foreach (var item in MateriaEstudiante)
            {
                result.Add(new DTOparaMostrarEstudiantesYsusCursos
                {
                    IDestudiante_materia = item.IDestudiante_materia,
                    IDestudiante = item.IDestudiante,
                    estudiante = item.estudiante.nombre,
                    IDmateria = item.IDmateria,
                    materia = item.materia.descripcion
                });
            }
            
            return result;
        }

        // GET: api/materiaEstudiantes/5
        public IEnumerable<DTOmateriaEstudiante> Get(int id)
        {
            var result = new List<DTOmateriaEstudiante>();

            var MateriaEstudiante = context.materia_estudiante.Find(id);

            if (MateriaEstudiante != null)
            {
                result.Add(new DTOmateriaEstudiante
                {
                    IDestudiante_materia = MateriaEstudiante.IDestudiante_materia,
                    IDestudiante = MateriaEstudiante.IDestudiante,
                    IDmateria = MateriaEstudiante.IDmateria
                });

                return result;
            }

            return result;
            //return "value";
        }

        // POST: api/materiaEstudiantes
        public IHttpActionResult Post([FromBody]DTOmateriaEstudiante value)
        {
            if(value != null){
                materia_estudiante info = new materia_estudiante
                {
                    IDestudiante_materia = value.IDestudiante_materia,
                    IDestudiante = value.IDestudiante,
                    IDmateria = value.IDmateria,
                };

                context.materia_estudiante.Add(info);
                context.SaveChanges();

                return Ok("Insertado");
            }

            return NotFound();
        }

        // PUT: api/materiaEstudiantes/5
        public IHttpActionResult Put( [FromBody]DTOmateriaEstudiante value)
        {
            if (value != null)
            {
               // if (id == value.IDestudiante_materia)
                //{   
                    materia_estudiante info = new materia_estudiante
                    {
                        IDestudiante_materia = value.IDestudiante_materia,
                        IDestudiante = value.IDestudiante,
                        IDmateria = value.IDmateria,
                    };
                

                    context.Entry(info).State = EntityState.Modified;
                    context.SaveChanges();

                    return Ok("Modificado");
                /*}
                else
                {
                    return Ok("No es igual el IDmateria_estudiante");
                }*/
            }

            return NotFound();
        }

        // DELETE: api/materiaEstudiantes/5
        public IHttpActionResult Delete(int id)
        {
            var materiaEstudiante = context.materia_estudiante.Find(id);

            if (materiaEstudiante != null)
            {
                context.materia_estudiante.Remove(materiaEstudiante);
                context.SaveChanges();
                return Ok("Materia Estudiante eliminado");

            }

            return NotFound();
        }
    }
}
