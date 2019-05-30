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
    public class UnitRepository : IRepository<Unit>
    {
        private PitanieContext db;
        public UnitRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(Unit item)
        {
            db.Units.Add(item);
        }

        public void Delete(int id)
        {
            Unit unit = db.Units.Find(id);
            if (unit != null)
            {
                db.Units.Remove(unit);
            }
        }

        public IEnumerable<Unit> Find(Func<Unit, bool> predicate)
        {
            return db.Units.Where(predicate).ToList();
        }

        public Unit Get(int id)
        {
            return db.Units.Find(id);
        }

        public IEnumerable<Unit> GetAll()
        {
            return db.Units;
        }

        public void Update(Unit item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
