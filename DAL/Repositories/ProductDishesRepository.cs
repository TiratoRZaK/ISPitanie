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
    public class ProductDishesRepository : IRepository<ProductsDish>
    {
        private PitanieContext db;

        public ProductDishesRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(ProductsDish item)
        {
            db.ProductsDishes.Add(item);
        }

        public void Delete(int id)
        {
            ProductsDish productsDish = db.ProductsDishes.Find(id);
            if (productsDish != null)
            {
                db.ProductsDishes.Remove(productsDish);
            }
        }

        public IEnumerable<ProductsDish> Find(Func<ProductsDish, bool> predicate)
        {
            return db.ProductsDishes.Where(predicate).ToList();
        }

        public ProductsDish Get(int id)
        {
            return db.ProductsDishes.Find(id);
        }

        public IEnumerable<ProductsDish> GetAll()
        {
            return db.ProductsDishes;
        }

        public void Update(ProductsDish item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
