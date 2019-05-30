using DAL.Entities;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IRepository<ProductDish> ProductDishes
        {
            get
            {
                if (productDishesRepository == null)
                    productDishesRepository = new ProductDishesRepository(db);
                return productDishesRepository;
            }
        }

        public IRepository<Unit> Units
        {
            get
            {
                if (unitRepository == null)
                    unitRepository = new UnitRepository(db);
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
