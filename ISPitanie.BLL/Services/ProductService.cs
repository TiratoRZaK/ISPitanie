using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ProductDTO productDto = new ProductDTO
            {
                Name = product.Name,
                Carbohydrate = product.Carbohydrate,
                Fat = product.Fat,
                Price = product.Price,
                Protein = product.Protein,
                Balance = product.Balance,
                Norm = product.Norm,
                TypeId = db.Types.GetAll().Where(x => x.Name == product.TypeName).First().Id,
                UnitId = db.Units.GetAll().Where(x => x.Name == product.UnitName).First().Id,
                Vitamine_C = product.Vitamine_C,
                ProductsDishes = new List<ProductDishDTO>(),
                Unit = db.Units.GetAll().Where(x => x.Name == product.UnitName).First(),
                Type = db.Types.GetAll().Where(x => x.Name == product.TypeName).First()
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

            return new Product { Id = id.Value, Name = product.Name, Norm = product.Norm, Carbohydrate = product.Carbohydrate, Fat = product.Fat, Price = product.Price, ProductsDishes = GetProductDishes(product.Id), Protein = product.Protein, Vitamine_C = product.Vitamine_C, Balance = product.Balance, UnitName = product.Unit.Name, TypeName = product.Type.Name };
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

            var productDishes = db.ProductDishes.GetAll().Where(x => x.ProductId == id.Value).ToList();
            // Настройка AutoMapper
            // сопоставление
            ObservableCollection<ProductDish> collection = Mapper.Map<IEnumerable<ProductDishDTO>, ObservableCollection<ProductDish>>(productDishes);
            return collection;
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
            db.Products.Delete(product.Id);
            db.Save();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ValidationException("Некорректный продукт", "");
            }
            // Настройка AutoMapper
            // сопоставление
            ProductDTO productDto = db.Products.Get(product.Id);

            productDto.Name = product.Name;
            productDto.Carbohydrate = product.Carbohydrate;
            productDto.Fat = product.Fat;
            productDto.Price = product.Price;
            productDto.Protein = product.Protein;
            productDto.Balance = product.Balance;
            productDto.Norm = product.Norm;
            productDto.UnitId = db.Units.GetAll().Where(x => x.Name == product.UnitName).First().Id;
            productDto.TypeId = db.Types.GetAll().Where(x => x.Name == product.TypeName).First().Id;
            productDto.Vitamine_C = product.Vitamine_C;
            productDto.ProductsDishes = db.Products.Get(product.Id).ProductsDishes;
            productDto.Unit = db.Units.GetAll().Where(x => x.Name == product.UnitName).First();
            productDto.Type = db.Types.GetAll().Where(x => x.Name == product.TypeName).First();

            db.Save();
        }
    }
}