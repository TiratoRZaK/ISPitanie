using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPitanie.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public int Norm { get; set; }
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbohydrate { get; set; }

        public ICollection<ProductDish> ProductDishes { get; set; }

        public ProductViewModel(int id)
        {
            EFUnitOfWork db = new EFUnitOfWork();
            Product prod = db.Products.Get(id);
            Id = id;
            Name = prod.Name;
            UnitName = prod.Unit.Name;
            Price = prod.Price;
            Vitamine_C = prod.Vitamine_C;
            Protein = prod.Protein;
            Fat = prod.Fat;
            Carbohydrate = prod.Carbohydrate;
            ProductDishes = db.ProductDishes.GetAll().Where(x => x.ProductId == id).ToList();
        }

    }
}
