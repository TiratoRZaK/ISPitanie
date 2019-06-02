using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ProductDishDTO
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public int Norm { get; set; }

        public virtual DishDTO Dish { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}
