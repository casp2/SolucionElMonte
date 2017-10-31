using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionElMonteCuatro.Models
{
    public class CondenaDelito
    {
        public int Id { get; set; }
        public Condena CondenaId { get; set; }
        public Delito DelitoId { get; set; }
        public int Condena { get; set; }
    }
}