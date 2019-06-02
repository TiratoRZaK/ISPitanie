using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using ISPitanie.BLL.Entities;
using ISPitanie.Infrastructure;
using ISPitanie.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPitanie.Services
{
    public class DishService : IDishService
    {
        IUnitOfWork db { get; set; }

        public DishService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void AddProduct(Dish dish, Product product, int norm)
        {
            if (dish == null)
            {
                throw new ValidationException("Данного блюда не существует", "");
            } else if (product == null)
            {
                throw new ValidationException("Данного продукта не существует", "");
            } else if (norm <= 0)
            {
                throw new ValidationException("Переданна некорректная норма", "");
            }
            DishDTO dishDTO = db.Dishes.Get(dish.Id);
            ProductDishDTO productDish = new ProductDishDTO
            {
                DishId = dish.Id,
                ProductId = product.Id,
                Norm = norm
            };
            db.ProductDishes.Create(productDish);
            db.Save();
        }

        public IEnumerable<Product> GetProducts(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id блюда", "");
            var dish = db.Dishes.Get(id.Value);
            if (dish == null)
                throw new ValidationException("Блюдо не найдено", "");
            IEnumerable<ProductDTO> products = new List<ProductDTO>();
            foreach (var item in GetProductDishes(id))
            {
                if(item.DishId == id.Value)
                {
                    products.ToList().Add(db.Products.Get(item.ProductId));
                }
            }
            return Mapper.Map<IEnumerable<ProductDTO>, List<Product>>(products);
        }

        public IEnumerable<Dish> GetDishes()
        {
            // Настройка AutoMapper
            
            // сопоставление
            return Mapper.Map<IEnumerable<DishDTO>, List<Dish>>(db.Dishes.GetAll());
        }

        public void RemoveProduct(Dish dish, Product product)
        {
            if (dish == null)
            {
                throw new ValidationException("Данного блюда не существует", "");
            }
            else if (product == null)
            {
                throw new ValidationException("Данного продукта не существует", "");
            }
            var productDish = db.ProductDishes.GetAll().Where(x => x.ProductId == product.Id && x.DishId == dish.Id).FirstOrDefault();
            db.ProductDishes.Delete(productDish.Id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Dish GetDish(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id блюда", "");
            var dish = db.Dishes.Get(id.Value);
            if (dish == null)
                throw new ValidationException("Блюдо не найдено", "");

            return new Dish { Id = id.Value, Name = dish.Name, Norm = dish.Norm, Carbohydrate = dish.Carbohydrate, Fat = dish.Fat, Price = dish.Price, ProductsDishes = GetProductDishes(dish.Id), Protein = dish.Protein, Vitamine_C = dish.Vitamine_C };
        }

        public IEnumerable<ProductDish> GetProductDishes(int? id)
        {
            if(id == null)
            {
                throw new ValidationException("Передано несуществующее блюдо", "");
            }
            var dish = db.Dishes.Get(id.Value);
            if(dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }

            var productDishes = db.ProductDishes.GetAll().Where(x => x.DishId == id.Value);
            // Настройка AutoMapper
            // сопоставление
            return Mapper.Map<IEnumerable<ProductDishDTO>, List<ProductDish>>(productDishes);
        }

        public void RemoveDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }
            db.Dishes.Delete(dish.Id);
            db.Save();
        }
    }
}
