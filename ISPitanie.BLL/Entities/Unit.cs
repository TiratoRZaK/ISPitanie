using System.Collections.Generic;

namespace ISPitanie.BLL.Entities
{
    public class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}