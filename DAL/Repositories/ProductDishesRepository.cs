using DAL.Entities;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductDishesRepository : IRepository<ProductDish>
    {
        private PitanieContext db;

        public ProductDishesRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(ProductDish item)
        {
            db.ProductsDishes.Add(item);
        }

        public void Delete(int id)
        {
            ProductDish productsDish = db.ProductsDishes.Find(id);
            if (productsDish != null)
            {
                db.ProductsDishes.Remove(productsDish);
            }
        }

        public IEnumerable<ProductDish> Find(Func<ProductDish, bool> predicate)
        {
            return db.ProductsDishes.Where(predicate).ToList();
        }

        public ProductDish Get(int id)
        {
            return db.ProductsDishes.Find(id);
        }

        public IEnumerable<ProductDish> GetAll()
        {
            return db.ProductsDishes;
        }

        public void Update(ProductDish item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
