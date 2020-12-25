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
    [EnableCors(origins: "*",headers:"*",methods:"*")]
    public class aulasController : ApiController
    {
        apicentroacademicoEntities context = new apicentroacademicoEntities();
        // GET: api/aulas
        public IEnumerable<DTOAulaParaMostrar> Get()
        {
            var result = new List<DTOAulaParaMostrar>();
            var aulas = context.aulas.ToList();
            //var materias = "";
            foreach (var item in aulas)
            {
                result.Add(new DTOAulaParaMostrar
                {
                    IDaula = item.IDaula,
                    descripcion = item.descripcion,
                    IDmateria = item.IDmateria,
                    materia = item.materia.descripcion,
                    IDhorario = item.IDhorario,
                    horario = item.horario.descripcio
                });
            }
            
            return result;
        }

        // GET: api/aulas/5
        public IEnumerable<DTOaulas> Get(int id)
        {
            var result = new List<DTOaulas>();
            var aulas = context.aulas.Find(id);

            if (aulas != null)
            {
                result.Add(new DTOaulas
                {
                    IDaula = aulas.IDaula,
                    descripcion = aulas.descripcion,
                    IDmateria = aulas.IDmateria,
                    IDhorario = aulas.IDhorario
                });
            
                return result;
            }

            return result;
        }

        // POST: api/aulas
        public IHttpActionResult Post([FromBody]DTOaulas value)
        {
            if (value != null)
            {
                aula datosAula = new aula
                {
                    descripcion = value.descripcion,
                    IDmateria = value.IDmateria,
                    IDhorario = value.IDhorario
                };

                context.aulas.Add(datosAula);
                context.SaveChanges();

                return Ok("Aula Insertada");
            }

            return NotFound();
        }

        // PUT: api/aulas/5
        public IHttpActionResult Put( [FromBody]DTOaulas value)
        {
            if (value != null)
            {
               // if (id == value.IDaula)
                //{
                    aula datosAula = new aula
                    {
                        IDaula = value.IDaula,
                        descripcion = value.descripcion,
                        IDmateria = value.IDmateria,
                        IDhorario = value.IDhorario
                    };

                    context.Entry(datosAula).State = EntityState.Modified;
                    context.SaveChanges();

                    return Ok("Aula Modificada");
                //}
                //return Ok("El id enviado y el ID del aula no es igual");
            }

            return NotFound();
        }

        // DELETE: api/aulas/5
        public IHttpActionResult Delete(int id)
        {
            var aula = context.aulas.Find(id);

            if (aula != null)
            {
                context.aulas.Remove(aula);
                context.SaveChanges();

                return Ok("Aula eliminada");

            }

            return NotFound();
        }
    }
}
