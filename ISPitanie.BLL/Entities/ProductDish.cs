﻿namespace ISPitanie.BLL.Entities
{
    public class ProductDish
    {
        public int Id { get; set; }

        //public int DishId { get; set; }
        //public int ProductId { get; set; }
        public int Norm { get; set; }

        public Dish Dish { get; set; }

        public Product Product { get; set; }
    }
}