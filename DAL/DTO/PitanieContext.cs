using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
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

        public virtual DbSet<DishDTO> Dishes { get; set; }
        public virtual DbSet<ProductDTO> Products { get; set; }
        public virtual DbSet<ProductDishDTO> ProductsDishes { get; set; }
        public virtual DbSet<UnitDTO> Units { get; set; }
    }
}
