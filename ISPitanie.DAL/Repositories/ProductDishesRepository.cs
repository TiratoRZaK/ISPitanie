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
            db.ProductDishes.Add(item);
        }

        public void Delete(int id)
        {
            ProductDishDTO productsDish = db.ProductDishes.Find(id);
            if (productsDish != null)
            {
                db.ProductDishes.Remove(productsDish);
            }
        }

        public IEnumerable<ProductDishDTO> Find(Func<ProductDishDTO, bool> predicate)
        {
            return db.ProductDishes.Where(predicate).ToList();
        }

        public ProductDishDTO Get(int id)
        {
            return db.ProductDishes.Find(id);
        }

        public IEnumerable<ProductDishDTO> GetAll()
        {
            return db.ProductDishes;
        }

        public void Update(ProductDishDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Clear(int id)
        {
            foreach(var item in db.ProductDishes.Where(x=>x.Id == id))
            {
                Delete(item.Id);
            }
        }
    }
}