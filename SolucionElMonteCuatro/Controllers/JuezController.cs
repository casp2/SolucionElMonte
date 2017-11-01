using SolucionElMonteCuatro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SolucionElMonteCuatro.Controllers
{
    public class JuezController : ApiController
    {

        private MonteDBContext context;


        public JuezController()
        {
            this.context = new MonteDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Jueces.Select(c => new
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Rut = c.Rut,
                Domicilio = c.Domicilio,
                Sexo = c.Sexo
            });


        }

        public IHttpActionResult get(int id)
        {
            Juez juez = context.Jueces.Find(id);

            if (juez == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(juez);//retornamos codigo 200 junto con el cliente buscado
        }

        public IHttpActionResult post(Juez juez)
        {

            context.Jueces.Add(juez);
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
            Juez juez = context.Jueces.Find(id);

            if (juez == null) return NotFound();//404

            context.Jueces.Remove(juez);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Juez juez)
        {
            context.Entry(juez).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }
    }
}