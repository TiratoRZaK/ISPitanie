using AutoMapper;
using DAL.DTO;
using ISPitanie.BLL.Entities;
using ISPitanie.Models;

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
            cfg.CreateMap<ProductDTO, Product>()
                .ForMember(x => x.UnitName, opt => opt.MapFrom(c => c.Unit.Name));
            cfg.CreateMap<ProductDishDTO, ProductDish>();
            cfg.CreateMap<UnitDTO, Unit>();

            cfg.CreateMap<ProductViewModel, Product>()
                .ForMember(x => x.ProductsDishes, opt => opt.Ignore());

            cfg.CreateMap<Product, ProductViewModel>();
        }
    }
}