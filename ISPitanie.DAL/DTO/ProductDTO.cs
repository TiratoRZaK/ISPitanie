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
        public int Norm { get; set; }           //Норма продукта на человека в день, которая делится на все блюда в менюшке
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Balance { get; set; }       //Остаток продукта
        public int TypeId { get; set; }         //Тип продукта. Нужен для разделения на категории продуктов в договоре

        public virtual TypeDTO Type { get; set; }
        public virtual UnitDTO Unit { get; set; }
        public virtual IEnumerable<ProductDishDTO> ProductsDishes { get; set; }
    }
}