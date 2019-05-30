using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Dish> Dishes { get; }
        IRepository<ProductsDish> ProductDishes { get; }
        IRepository<Unit> Units { get; }
        void Save();
    }
}
