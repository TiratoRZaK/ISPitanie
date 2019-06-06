using ISPitanie.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPitanie.ViewModels
{
    public class ProductInDish
    {
        public Product Product { get; set; }
        public int Norm { get; set; }

        public override string ToString()
        {
            return Product.Name+"( "+Norm.ToString()+" )";
        }
    }
}
