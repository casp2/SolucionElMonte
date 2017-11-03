using SolucionElMonteCuatro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SolucionElMonteCuatro.Controllers
{
    public class PresoController : ApiController
    {


        private MonteDBContext context;

        public PresoController()
        {
            this.context = new MonteDBContext();
        }


        public IEnumerable<Object> get()
        {
            return context.Presos.Include("Condenas").Select(c => new
            {
                Id = c.Id,
                Rut = c.Rut,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                FechaNac = c.FechaNacimiento,
                Domicilio = c.Domicilio,
                Sexo = c.Sexo,
                Condena = from o in context.Condenas where c.Id == o.PresoID select new
                {
                    IdCondena = o.Id,
                    FechaInicio = o.FechaInicioCondena,
                    FechaCondena = o.FechaCondena,
                },
                    Delito = from a in context.Condenas
                             join cd in context.CondenaDelitos on a.Id equals cd.CondenaID
                             join d in context.Delitos on cd.DelitoID equals d.Id

                             where c.Id == a.PresoID

                             select new
                             {
                                 delitoid = d.Id,
                                 
                                 nombre = d.Nombre,
                                 
                                

                             }



                
            });
                
        }

        public IHttpActionResult get(int id)
        {
            Preso preso = context.Presos.Find(id);

            if (preso == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(preso);//retornamos codigo 200 junto con el cliente buscado
        }

        public IHttpActionResult post(Preso preso)
        {

            context.Presos.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }


        //api/clientes/{id}
        public IHttpActionResult delete(int id)
        {
            //buscamos el cliente a eliminar
            Preso preso = context.Presos.Find(id);

            if (preso == null) return NotFound();//404

            context.Presos.Remove(preso);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }
    }
}