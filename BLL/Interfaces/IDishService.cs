using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPitanie.Services;
using ISPitanie.BLL.Entities;

namespace ISPitanie.Interfaces
{
    public interface IDishService
    {
        void AddProduct(Dish dish, Product product, int norm);      //Добавить продукт в блюдо
        IEnumerable<Product> GetProducts(int? id);                           //Вернуть все продукты из состава блюда
        IEnumerable<ProductDish> GetProductDishes(int? id);                  //Вернуть все вхождения продуктов в блюдо
        IEnumerable<Dish> GetDishes();                                       //Вернуть все блюда из БД
        Dish GetDish(int? id);                                               //Вернуть блюдо по ID
        void RemoveProduct(Dish dish, Product product);             //Удалить продукт из блюда
        void RemoveDish(Dish dish);                                       //Удалить блюдо из БД
        void Dispose();
    }
}
