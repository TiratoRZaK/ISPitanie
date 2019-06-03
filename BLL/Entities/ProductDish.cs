namespace ISPitanie.BLL.Entities
{
    public class ProductDish
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public int Norm { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Product Product { get; set; }
    }
}