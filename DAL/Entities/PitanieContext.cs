using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PitanieContext : DbContext
    {

        public PitanieContext()
            : base("name=PitanieContext")
        {
        }

        public PitanieContext(string PitanieContext) : base(PitanieContext)
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDish> ProductsDishes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
    }
}
