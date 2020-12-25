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
    public class horariosController : ApiController
    {
        apicentroacademicoEntities context = new apicentroacademicoEntities();
        // GET: api/horarios
        public IEnumerable<DTOhorario> Get()
        {
            var result = new List<DTOhorario>();

            var horarios = context.horarios.ToList();

            foreach (var item in horarios)
            {
                result.Add(new DTOhorario
                {
                    IDhorario = item.IDhorario,
                    descripcion = item.descripcio,
                });
            }

            return result;
        }

        // GET: api/horarios/5
        public IEnumerable<DTOhorario> Get(int id)
        {
            var result = new List<DTOhorario>();

            var horarios = context.horarios.Find(id);

            if (horarios!=null)
            {
                result.Add(new DTOhorario
                {
                    IDhorario = horarios.IDhorario,
                    descripcion = horarios.descripcio,
                });

                return result;
            }
            return result;
        }

        // POST: api/horarios
        public IHttpActionResult Post([FromBody]DTOhorario value)
        {
            if (value != null)
            {
                horario info = new horario
                {
                    descripcio = value.descripcion
                };

                context.horarios.Add(info);
                context.SaveChanges();

              return  Ok("Horario Insertado");
            }

            return NotFound();
        }

        // PUT: api/horarios/5
        public IHttpActionResult Put( [FromBody]DTOhorario value)
        {
            if (value != null)
            {
               /* if (id == value.IDhorario)
                {*/
                    horario info = new horario
                    {
                        IDhorario = value.IDhorario,
                        descripcio = value.descripcion,
                    };


                    context.Entry(info).State = EntityState.Modified;
                    context.SaveChanges();

                    return Ok("Modificado");
                /*}
                else
                {
                    return Ok("No es igual el ID del horario");
                }*/
            }

            return NotFound();
        }

        // DELETE: api/horarios/5
        public IHttpActionResult Delete(int id)
        {
            var horario = context.horarios.Find(id);

            if (horario != null)
            {
                context.horarios.Remove(horario);
                context.SaveChanges();

                return Ok("Estudiante Modificado");
            }

            return NotFound();
        }
    }
}
