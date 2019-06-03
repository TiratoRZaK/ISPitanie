using System.Collections.Generic;

namespace DAL.DTO
{
    public class UnitDTO
    {
        public UnitDTO()
        {
            this.Products = new HashSet<ProductDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<ProductDTO> Products { get; set; }
    }
}