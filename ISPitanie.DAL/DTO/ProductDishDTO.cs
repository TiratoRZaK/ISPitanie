namespace DAL.DTO
{
    public class ProductDishDTO
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public int Norm { get; set; }   // норма продукта определённого блюда. Используется в меню.

        public virtual DishDTO Dish { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}