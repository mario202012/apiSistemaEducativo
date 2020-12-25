using apiSistemaEducativo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace apiSistemaEducativo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class materiasController : ApiController
    {
        apicentroacademicoEntities context = new apicentroacademicoEntities();
        // GET: api/materias
        public IEnumerable<DTOmaterias> Get()
        {
            var result = new List<DTOmaterias>();

            var materias = context.materias.ToList();

            foreach (var items in materias) { 
                result.Add(new DTOmaterias  {
                    IDmateria = items.IDmateria,
                    descripcion = items.descripcion,
                    credito = items.credito,
                    precio = items.precio,
                    estatus = items.estatus,
                });
            }
            
            return result;
        }

        // GET: api/materias/5
        public IEnumerable<DTOmaterias> Get(int id)
        {
            //var result
            var materiaPorID = context.materias.Find(id);
            var result =  new List<DTOmaterias>();
            if(materiaPorID != null) { 
                result.Add ( new DTOmaterias{
                    IDmateria   = materiaPorID.IDmateria,
                    descripcion = materiaPorID.descripcion,
                    credito     = materiaPorID.credito,
                    precio      = materiaPorID.precio,
                    estatus     = materiaPorID.estatus
                });
    
                return result;
            }
            else
            {
                return result;
            }
        }

        // POST: api/materias
        public IHttpActionResult Post([FromBody]DTOmaterias value)
        {
            if (value != null)
            {
                materia info = new materia
                {
                    descripcion = value.descripcion,
                    credito = value.credito,
                    precio = value.precio,
                    estatus = value.estatus,
                };

                context.materias.Add(info);
                context.SaveChanges();
                return Ok("Materia insertada");
            }

            return NotFound();
        }

        // PUT: api/materias/5
        public void Put( [FromBody]DTOmaterias value)
        {
            materia info = new materia
            {   
                IDmateria = value.IDmateria,
                descripcion = value.descripcion,
                credito = value.credito,
                precio = value.precio,
                estatus = value.estatus,
            };

            context.Entry(info).State = EntityState.Modified;
            context.SaveChanges();
        }

        // DELETE: api/materias/5
        public IHttpActionResult Delete(int id)
        {
            var materias = context.materias.Find(id);

            if (materias != null)
            {
                context.materias.Remove(materias);
                context.SaveChanges();
                return Ok("Materia eliminada");
            }
            return NotFound();
        }
    }
}
