using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
