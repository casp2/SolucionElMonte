using SolucionElMonteCuatro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SolucionElMonteCuatro.Controllers
{
    public class CondenaController : ApiController
    {


        private MonteDBContext context;

        public CondenaController()
        {
            this.context = new MonteDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Condenas.Select(c => new
            {
                Id = c.Id,
                FechaInicioCondena = c.FechaInicioCondena,
                FechaCondena = c.FechaCondena,
                JuezID = c.JuezId,

                preso = from p in context.Presos where c.PresoID == p.Id
                        select new
                        {
                            preso_id= p.Id,
                            Nombre = p.Nombre,
                            Apellido = p.Apellido,
                            Rut = p.Rut
                        },
                Delito = from p in context.Presos
                         join cd in context.CondenaDelitos on c.Id equals cd.CondenaID
                         join d in context.Delitos on cd.DelitoID equals d.Id

                         where p.Id == c.PresoID

                         select new
                         {
                             delitoid = d.Id,

                             nombre = d.Nombre,



                         }


            });


        }

        public IHttpActionResult get(int id)
        {
            Condena condena = context.Condenas.Find(id);

            if (condena == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(condena);//retornamos codigo 200 junto con el cliente buscado
        }

        public IHttpActionResult post(Condena condena)

        {

            
            
            context.Condenas.Add(condena);
            
       
         
            
            

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
            Condena condena = context.Condenas.Find(id);

            if (condena == null) return NotFound();//404

            context.Condenas.Remove(condena);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Condena condena)
        {
            context.Entry(condena).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }
    }
}