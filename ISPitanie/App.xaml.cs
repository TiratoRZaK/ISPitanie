using System.Windows;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Services;

namespace ISPitanie
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DishDTO, Dish>();
                cfg.CreateMap<ProductDTO, Product>().ForMember("Unit", opt => opt.MapFrom(c => c.Unit.Name));
                cfg.CreateMap<ProductDishDTO, ProductDish>();
                cfg.CreateMap<UnitDTO, Unit>();
            });

            IUnitOfWork unitOfWork = new EFUnitOfWork();
            IProductService productService = new ProductService(unitOfWork);
            IDishService dishService = new DishService(unitOfWork);
            MainWindow window = new MainWindow(productService, dishService);
        }
    }
}