using System;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ProductDTO> Products { get; }
        IRepository<DishDTO> Dishes { get; }
        IRepository<ProductDishDTO> ProductDishes { get; }
        IRepository<UnitDTO> Units { get; }
        IRepository<TypeDTO> Types { get; }

        void Save();
    }
}