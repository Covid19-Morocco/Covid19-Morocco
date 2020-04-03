using Covid19.Morocco.Data.Models;
using System.Data.Entity;

namespace Covid19.Morocco.Data
{
    public class CoronaContext : DbContext
    {
        public CoronaContext() : base("name=Covid19MoroccoDatabase")
        {
        }

        //entities
        public DbSet<Cases> Cases { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }

    }
}