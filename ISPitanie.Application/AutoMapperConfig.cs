using AutoMapper;
using DAL.DTO;
using ISPitanie.BLL.Entities;
using ISPitanie.Models;
using ISPitanie.ViewModels;

namespace ISPitanie
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(AddMappings);
        }

        private static void AddMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DishDTO, Dish>();

            cfg.CreateMap<Dish, DishesViewModel>()
                .ForMember(x => x.ProductsDishes, opt => opt.Ignore())
                .ForMember(x => x.Products, opt => opt.Ignore());
            cfg.CreateMap<DishesViewModel, Dish>()
                .ForMember(x => x.ProductsDishes, opt => opt.Ignore());
            
            cfg.CreateMap<ProductDTO, Product>()
                .ForMember(x => x.UnitName, opt => opt.MapFrom(c => c.Unit.Name))
                .ForMember(x => x.TypeName, opt => opt.MapFrom(c => c.Type.Name));

            cfg.CreateMap<ProductDish, ProductDishDTO>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(c => c.Product.Id))
                .ForMember(x => x.DishId, opt => opt.MapFrom(c => c.Dish.Id))
                .ForMember(x => x.Product, opt => opt.Ignore())
                .ForMember(x => x.Dish, opt => opt.Ignore());

            cfg.CreateMap<UnitDTO, Unit>();

            cfg.CreateMap<Product, ProductViewModel>();
            cfg.CreateMap<ProductViewModel, Product>()
                .ForMember(x => x.ProductsDishes, opt => opt.Ignore());
        }
    }
}