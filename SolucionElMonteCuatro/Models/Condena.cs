using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionElMonteCuatro.Models
{
    public class Condena
    {
        public int Id { get; set; }
        public DateTime FechaInicioCondena { get; set; }
        public DateTime FechaCondena { get; set; }
        public int? PresoID { get; set; }
        public Preso Presos { get; set; }
        public int? JuezId { get; set; }
        public Juez Jueces { get; set; }
        public List<CondenaDelito> CondenaDelitos { get; set; }

        public int num { get; set; }

        

        







    }
}