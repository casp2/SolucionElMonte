using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionElMonteCuatro.Models
{
    public class CondenaDelito
    {
        public int Id { get; set; }
        public int CondenaID { get; set; }
        public Condena Condenas { get; set; }
        
        
        public int? DelitoID { get; set; }
        public Delito Delitos { get; set; }

        
        
        public int Condena { get; set; }

        

        public CondenaDelito (int id_Condena)
        {
        
        }
    }


    
}