using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionElMonteCuatro.Models
{
    public class Preso
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string  Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public char Sexo { get; set; }
    }
}