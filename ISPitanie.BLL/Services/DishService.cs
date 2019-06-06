using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using ISPitanie.BLL.Entities;
using ISPitanie.Infrastructure;
using ISPitanie.Interfaces;

namespace ISPitanie.Services
{
    public class DishService : IDishService
    {
        private IUnitOfWork Db { get; set; }

        public DishService(IUnitOfWork db)
        {
            this.Db = db;
        }

        public void CreateDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ValidationException("Некорректный продукт", "");
            }

            DishDTO dishDto = new DishDTO
            {
                Name = dish.Name,
                Carbohydrate = dish.Carbohydrate,
                Fat = dish.Fat,
                Protein = dish.Protein,
                Norm = dish.Norm,
                Vitamine_C = dish.Vitamine_C,
                ProductsDishes = Mapper.Map<List<ProductDishDTO>>(dish.ProductsDishes.ToList())
            };
            Db.Dishes.Create(dishDto);
            Db.Save();
        }

        public void AddProduct(Dish dish, Product product, int norm)
        {
            if (dish == null)
            {
                throw new ValidationException("Данного блюда не существует", "");
            }
            else if (product == null)
            {
                throw new ValidationException("Данного продукта не существует", "");
            }
            else if (norm <= 0)
            {
                throw new ValidationException("Переданна некорректная норма", "");
            }

            ProductDishDTO productDish = new ProductDishDTO
            {
                DishId = dish.Id,
                ProductId = product.Id,
                Norm = norm
            };

            Db.ProductDishes.Create(productDish);
            Db.Save();
        }

        public IEnumerable<Product> GetProducts(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id блюда", "");
            }

            var dish = Db.Dishes.Get(id.Value);
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }

            IEnumerable<ProductDTO> products = new List<ProductDTO>();
            foreach (var item in GetProductDishes(id))
            {
                if (item.Dish.Id == id.Value)
                {
                    products.ToList().Add(Db.Products.Get(item.Product.Id));
                }
            }
            return Mapper.Map<IEnumerable<ProductDTO>, List<Product>>(products);
        }

        public IEnumerable<Dish> GetDishes()
        {
            return Mapper.Map<IEnumerable<DishDTO>, List<Dish>>(Db.Dishes.GetAll());
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

            var productDish = Db.ProductDishes.GetAll().Where(x => x.ProductId == product.Id && x.DishId == dish.Id).FirstOrDefault();
            Db.ProductDishes.Delete(productDish.Id);
            Db.Save();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public Dish GetDish(int? id)
        {
            if (id == null)
            { 
                throw new ValidationException("Не установлено id блюда", "");
            }

            var dish = Db.Dishes.Get(id.Value);
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }

            return new Dish { Id = id.Value, Name = dish.Name, Norm = dish.Norm, Carbohydrate = dish.Carbohydrate, Fat = dish.Fat, ProductsDishes = GetProductDishes(dish.Id), Protein = dish.Protein, Vitamine_C = dish.Vitamine_C };
        }

        public IEnumerable<ProductDish> GetProductDishes(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Передано несуществующее блюдо", "");
            }

            var dish = Db.Dishes.Get(id.Value);
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }

            var productDishes = Db.ProductDishes.GetAll().Where(x => x.DishId == id.Value).ToList();
            return Mapper.Map<IEnumerable<ProductDishDTO>, List<ProductDish>>(productDishes);
        }

        public void RemoveDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найдено", "");
            }

            Db.Dishes.Delete(dish.Id);
            Db.Save();
        }
    }
}