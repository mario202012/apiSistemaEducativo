using apiSistemaEducativo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Common;
using System.Data.SqlClient;

namespace apiSistemaEducativo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class estudiantesController : ApiController
    {
        apicentroacademicoEntities context = new apicentroacademicoEntities();
        // GET: api/estudiantes
        public IEnumerable<DTOestudiantes> Get()
        {
            var result = new List<DTOestudiantes>();

            var estudiantes = context.estudiantes.ToList();
            foreach (var item in estudiantes)
            {
                result.Add(new DTOestudiantes { 
                    IDestudiante = item.IDestudiante,
                    nombre = item.nombre +' '+ item.apellido,
                    telefono = item.telefono,
                    estatus = item.estatus,
                    correo = item.correo,
                    direccion = item.direccion,
                    clave = item.clave,
                    rol = item.rol
                });
           
            }
            
            return result;
        }

        // GET: api/estudiantes/5
        public IEnumerable<DTOestudiantes> Get(int id)
        {
            var result = new List<DTOestudiantes>();
            var estudiantePorID = context.estudiantes.Find(id);
        
                result.Add(new DTOestudiantes
                {
                    IDestudiante = estudiantePorID.IDestudiante,
                    nombre = estudiantePorID.nombre,
                    apellido = estudiantePorID.apellido,
                    telefono = estudiantePorID.telefono,
                    estatus = estudiantePorID.estatus,
                    correo = estudiantePorID.correo,
                    direccion = estudiantePorID.direccion,
                    clave = estudiantePorID.clave,
                    rol = estudiantePorID.rol
                });
            
            return result;
        }
        // GET: api/estudiantes/email/clave
        public IEnumerable<DTOestudiantes> getPorUsuario (string value)
        {
            var result = new List<DTOestudiantes>();
            var prueba = value;
            //var estudiantePorCorreo = context.estudiantes.Where(a => a.correo == email).Select(x => new { x.IDestudiante,x.nombre,x.apellido
            //,x.telefono,x.estatus,x.correo,x.direccion,x.clave,x.rol}).ToList();

           // var estudiantePorC = estudiantePorCorreo.Any(a=>a.IDestudiante!=null);

            //foreach (var item in estudiantePorCorreo)
            //{
                /*result.Add(new DTOestudiantes
                {
                    IDestudiante = estudiantePorCorreo[0].IDestudiante,
                     nombre = estudiantePorCorreo[0].nombre,
                     apellido = estudiantePorCorreo[0].apellido,
                     telefono = estudiantePorCorreo[0].telefono,
                     estatus = estudiantePorCorreo[0].estatus,
                     correo = estudiantePorCorreo[0].correo,
                     direccion = estudiantePorCorreo[0].direccion,
                     clave = estudiantePorCorreo[0].clave,
                     rol = estudiantePorCorreo[0].rol

                });*/
            //}

            return result;
        }
        // POST: api/estudiantes
        public IHttpActionResult Post([FromBody]DTOestudiantes value)
        {   
            if(value != null) { 
                estudiante info = new estudiante
                {
                    nombre = value.nombre,
                    apellido = value.apellido,
                    telefono = value.telefono,
                    estatus = value.estatus,
                    correo = value.correo,
                    direccion = value.direccion,
                    clave = value.clave,
                    rol = value.rol
                };

                context.estudiantes.Add(info);
                context.SaveChanges();
                return Ok("Estudiante insertado");
            }
            return NotFound();
        }

        // PUT: api/estudiantes/5
        public void Put([FromBody] DTOestudiantes value)
        {
            //var estudiante = context.estudiantes.Find(value.IDestudiante);

            /*if(estudiante.IDestudiante == id)
            {

            }*/

            estudiante info = new estudiante
            {   
                IDestudiante = value.IDestudiante,
                nombre = value.nombre,
                apellido = value.apellido,
                telefono = value.telefono,
                estatus = value.estatus,
                correo = value.correo,
                direccion = value.direccion,
                clave = value.clave,
                rol = value.rol
            };
            //context.estudiantes
            context.Entry(info).State = EntityState.Modified;
            context.SaveChanges();
        }

        // DELETE: api/estudiantes/5
        public IHttpActionResult Delete(int id)
        {
            var estudiante = context.estudiantes.Find(id);
            if (estudiante != null){
                context.estudiantes.Remove(estudiante);
                context.SaveChanges();
                return Ok("Estudiante eliminado");
             }

            return NotFound();
        }
    }
}
