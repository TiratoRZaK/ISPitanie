using System.Data.Entity;
using DAL.DTO;

namespace DAL
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
        public virtual DbSet<ProductDishDTO> ProductDishes { get; set; }
        public virtual DbSet<UnitDTO> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishDTO>().ToTable("Dishes");
            modelBuilder.Entity<ProductDTO>().ToTable("Products");
            modelBuilder.Entity<ProductDishDTO>().ToTable("ProductDishes");
            modelBuilder.Entity<UnitDTO>().ToTable("Units");
        }
    }
}