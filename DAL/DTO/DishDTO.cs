using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Norm { get; set; }
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Fat { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        
        public virtual IEnumerable<ProductDishDTO> ProductsDishes { get; set; }
    }
}
