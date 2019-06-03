using System.Collections.Generic;
using ISPitanie.BLL.Entities;

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
        public int Count { get; set; }

        public IEnumerable<ProductDish> ProductDishes { get; set; }

        public ProductViewModel()
        {
            ProductDishes = new List<ProductDish>();
        }
    }
}