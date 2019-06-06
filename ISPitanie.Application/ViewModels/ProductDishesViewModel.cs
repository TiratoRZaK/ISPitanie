using DAL.DTO;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPitanie.ViewModels
{
    public class ProductDishesViewModel
    {
        public IDishService dishesService = new DishService(new EFUnitOfWork());
        public IProductService productesService = new ProductService(new EFUnitOfWork());

        public int DishId { get; set; }
        public List<ProductInDish> products = new List<ProductInDish>();

        public ProductDishesViewModel(int idDishes)
        {
            DishId = idDishes;
            List<ProductDish> productDishes = dishesService.GetProductDishes(idDishes).ToList();
            foreach(ProductDish productDish in productDishes)
            {
                products.Add(new ProductInDish
                {
                    Product = productesService.GetProduct(productDish.Product.Id),
                    Norm = productDish.Norm
                });
            }
        }

        public override string ToString()
        {
            String str = "";
            foreach(ProductInDish item in products)
            {
                str = String.Concat(str, item.Product.Name+'\n');
            }
            return str;

        }

        public static ProductDishesViewModel GetProductDishesViewModel(int idDish)
        {
            return new ProductDishesViewModel(idDish);
        }
    }
}
