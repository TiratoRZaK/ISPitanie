using System.Windows;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Models;
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
                cfg.CreateMap<ProductDTO, Product>()
                    .ForMember(x => x.UnitName, opt => opt.MapFrom(c => c.Unit.Name));
                cfg.CreateMap<ProductDishDTO, ProductDish>();
                cfg.CreateMap<UnitDTO, Unit>();
                cfg.CreateMap<ProductViewModel, Product>()
                    .ForMember(x => x.ProductsDishes, opt => opt.Ignore());
            });


        }
    }
}