using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProductDishesRepository : IRepository<ProductDishDTO>
    {
        private PitanieContext db;

        public ProductDishesRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(ProductDishDTO item)
        {
            db.ProductsDishes.Add(item);
        }

        public void Delete(int id)
        {
            ProductDishDTO productsDish = db.ProductsDishes.Find(id);
            if (productsDish != null)
            {
                db.ProductsDishes.Remove(productsDish);
            }
        }

        public IEnumerable<ProductDishDTO> Find(Func<ProductDishDTO, bool> predicate)
        {
            return db.ProductsDishes.Where(predicate).ToList();
        }

        public ProductDishDTO Get(int id)
        {
            return db.ProductsDishes.Find(id);
        }

        public IEnumerable<ProductDishDTO> GetAll()
        {
            return db.ProductsDishes;
        }

        public void Update(ProductDishDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}