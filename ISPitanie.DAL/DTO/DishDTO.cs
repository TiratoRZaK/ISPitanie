using System.Collections.Generic;

namespace DAL.DTO
{
    public class DishDTO
    {
        public DishDTO()
        {
            this.ProductsDishes = new HashSet<ProductDishDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Norm { get; set; }       //Норма на человека в день (не используется)
        public int? Vitamine_C { get; set; }
        public int? Fat { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }

        public virtual IEnumerable<ProductDishDTO> ProductsDishes { get; set; }
    }
}