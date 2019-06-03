using System;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PitanieContext db;
        private ProductRepository productRepository;
        private DishRepository dishRepository;
        private ProductDishesRepository productDishesRepository;
        private UnitRepository unitRepository;

        public EFUnitOfWork()
        {
            db = new PitanieContext();
        }

        public EFUnitOfWork(string connectionString)
        {
            db = new PitanieContext(connectionString);
        }

        public IRepository<ProductDTO> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public IRepository<DishDTO> Dishes
        {
            get
            {
                if (dishRepository == null)
                {
                    dishRepository = new DishRepository(db);
                }
                return dishRepository;
            }
        }

        public IRepository<ProductDishDTO> ProductDishes
        {
            get
            {
                if (productDishesRepository == null)
                {
                    productDishesRepository = new ProductDishesRepository(db);
                }
                return productDishesRepository;
            }
        }

        public IRepository<UnitDTO> Units
        {
            get
            {
                if (unitRepository == null)
                {
                    unitRepository = new UnitRepository(db);
                }
                return unitRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}