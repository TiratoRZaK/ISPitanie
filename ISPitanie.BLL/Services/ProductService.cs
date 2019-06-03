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
    public class ProductService : IProductService
    {
        private IUnitOfWork db { get; set; }

        public ProductService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ValidationException("Некорректный продукт", "");
            }
            // Настройка AutoMapper
            // сопоставление
            var prodDishes = Mapper.Map<IEnumerable<ProductDish>, List<ProductDishDTO>>(GetProductDishes(product.Id));

            ProductDTO productDto = new ProductDTO
            {
                Name = product.Name,
                Carbohydrate = product.Carbohydrate,
                Fat = product.Fat,
                Price = product.Price,
                Protein = product.Protein,
                Count = product.Count,
                Norm = product.Norm,
                UnitId = db.Units.GetAll().Where(x => x.Name == product.UnitName).First().Id,
                Vitamine_C = product.Vitamine_C,
                ProductsDishes = prodDishes,
                Unit = db.Units.GetAll().Where(x => x.Name == product.UnitName).First()
            };
            db.Products.Create(productDto);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Product GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id продукта", "");
            var product = db.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Подукт не найден", "");

            return new Product { Id = id.Value, Name = product.Name, Norm = product.Norm, Carbohydrate = product.Carbohydrate, Fat = product.Fat, Price = product.Price, ProductsDishes = GetProductDishes(product.Id), Protein = product.Protein, Vitamine_C = product.Vitamine_C, Count = product.Count, UnitName = product.Unit.Name };
        }

        public IEnumerable<ProductDish> GetProductDishes(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Передан несуществующий продукт", "");
            }
            var product = db.Products.Get(id.Value);
            if (product == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }

            var productDishes = db.ProductDishes.GetAll().Where(x => x.ProductId == id.Value);
            // Настройка AutoMapper
            // сопоставление
            return Mapper.Map<IEnumerable<ProductDishDTO>, List<ProductDish>>(productDishes);
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> prods = Mapper.Map<IEnumerable<ProductDTO>, List<Product>>(db.Products.GetAll().ToList()).ToList();
            return prods;
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
            {
                throw new ValidationException("Данного продукта не существует", "");
            }
            var productDish = db.ProductDishes.GetAll().Where(x => x.ProductId == product.Id);
            foreach (var item in productDish)
            {
                db.ProductDishes.Delete(item.Id);
            }
            db.Save();
        }
    }
}