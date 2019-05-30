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
    public class DishRepository : IRepository<Dish>
    {
        private PitanieContext db;
        public DishRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(Dish item)
        {
            db.Dishes.Add(item);
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
            {
                db.Dishes.Remove(dish);
            }
        }

        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            return db.Dishes.Where(predicate).ToList();
        }

        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Dishes;
        }

        public void Update(Dish item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
