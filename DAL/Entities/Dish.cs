﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Dish
    {
        public Dish()
        {
            this.ProductsDishes = new HashSet<ProductsDish>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Norm { get; set; }
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Fat { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        
        public virtual ICollection<ProductsDish> ProductsDishes { get; set; }
    }
}
