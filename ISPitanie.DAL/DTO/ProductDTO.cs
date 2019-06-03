using System.Collections.Generic;

namespace DAL.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            this.ProductsDishes = new HashSet<ProductDishDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int Norm { get; set; }
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbohydrate { get; set; }
        public int Count { get; set; }

        public virtual UnitDTO Unit { get; set; }
        public virtual IEnumerable<ProductDishDTO> ProductsDishes { get; set; }
    }
}