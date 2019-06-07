using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Services;

namespace ISPitanie.ViewModels
{
    public class DishesViewModel
    {
        public IDishService dishService = new DishService(new EFUnitOfWork());

        public DishesViewModel()
        {
        }

        public DishesViewModel(int idDish)
        {
            Dish dish = dishService.GetDish(idDish);
            Id = dish.Id;
            Name = dish.Name;
            Norm = dish.Norm;
            Vitamine_C = dish.Vitamine_C;
            Fat = dish.Fat;
            Protein = dish.Protein;
            Carbohydrate = dish.Carbohydrate;
            ProductsDishes = ProductDishesViewModel.GetProductDishesViewModel(idDish);
            Products = ProductsDishes.ToString();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Norm { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Fat { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public ProductDishesViewModel ProductsDishes { get; set; }
        public string Products { get; set; }
    }
}