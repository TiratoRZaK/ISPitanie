using System.Collections.Generic;

namespace ISPitanie.BLL.Entities
{
    public class Dish
    {
        public Dish()
        {
            ProductsDishes = new HashSet<ProductDish>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Norm { get; set; }
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Fat { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }

        public virtual IEnumerable<ProductDish> ProductsDishes { get; set; }
    }
}