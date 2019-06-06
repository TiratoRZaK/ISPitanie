using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPitanie.ViewModels
{
    public class DishesViewModel
    {
        public IDishService dishService = new DishService(new EFUnitOfWork());
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
            ProductDishes = ProductDishesViewModel.GetProductDishesViewModel(idDish);
            Products = ProductDishes.ToString();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Norm { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Fat { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public ProductDishesViewModel ProductDishes { get; set; }
        public string Products { get; set; }
    }
}
