
using ISPitanie.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPitanie.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(Product product);                      //Добавить продукт в БД
        IEnumerable<Product> GetProducts();                          //Вернуть все продукты из БД
        IEnumerable<ProductDish> GetProductDishes(int? id);          //Вернуть все вхождения продукта в блюда
        Product GetProduct(int? id);                                 //Вернуть продукт по ID
        void RemoveProduct(Product product);                      //Удалить продукт из БД
        void Dispose();
    }
}
