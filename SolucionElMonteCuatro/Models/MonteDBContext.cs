using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SolucionElMonteCuatro.Models
{
    public class MonteDBContext : DbContext

    {
        public DbSet<Condena> Condenas { get; set; }
        public DbSet<Juez> Jueces { get; set; }
        public DbSet<Preso> Presos { get; set; }
        public DbSet<Delito> Delitos { get; set; }
        public DbSet<CondenaDelito> CondenaDelitos { get; set; }

        







    }
}