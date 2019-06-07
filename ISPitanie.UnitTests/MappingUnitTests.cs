using AutoMapper;
using DAL.DTO;
using ISPitanie.BLL.Entities;
using ISPitanie.Models;
using ISPitanie.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ISPitanie.UnitTests
{
    public class MappingFixture
    {
        public MappingFixture()
        {
            AutoMapperConfig.Initialize();
        }
    }

    public class MappingUnitTests : IClassFixture<MappingFixture>
    {
        private MappingFixture fixture;

        public MappingUnitTests(MappingFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [MemberData("GetProducts")]
        public void ProductModel_MappingTest(Product product)
        {
            var model = Mapper.Map<Product, ProductViewModel>(product);

            Assert.Equal(product.Id, model.Id);
            Assert.Equal(product.Name, model.Name);
            Assert.Equal(product.Balance, model.Balance);
            Assert.Equal(product.UnitName, model.UnitName);
            Assert.Equal(product.Fat, model.Fat);
            Assert.Equal(product.Norm, model.Norm);
            Assert.Equal(product.Price, model.Price);
            Assert.Equal(product.Protein, model.Protein);
            Assert.Equal(product.Vitamine_C, model.Vitamine_C);
            Assert.Equal(product.Carbohydrate, model.Carbohydrate);
        }

        [Theory]
        [MemberData("GetDishes")]
        public void DishModel_MappingTest(Dish dish)
        {
            var model = Mapper.Map<Dish, DishesViewModel>(dish);

            Assert.Equal(dish.Id, model.Id);
            Assert.Equal(dish.Name, model.Name);
            Assert.Equal(dish.Fat, model.Fat);
            Assert.Equal(dish.Norm, model.Norm);
            Assert.Equal(dish.Protein, model.Protein);
            Assert.Equal(dish.Vitamine_C, model.Vitamine_C);
            Assert.Equal(dish.Carbohydrate, model.Carbohydrate);

            var entity = Mapper.Map<DishesViewModel, Dish>(model);

            Assert.Equal(dish.Id, entity.Id);
            Assert.Equal(dish.Name, entity.Name);
            Assert.Equal(dish.Fat, entity.Fat);
            Assert.Equal(dish.Norm, entity.Norm);
            Assert.Equal(dish.Protein, entity.Protein);
            Assert.Equal(dish.Vitamine_C, entity.Vitamine_C);
            Assert.Equal(dish.Carbohydrate, entity.Carbohydrate);
        }

        [Theory]
        [MemberData("GetDishes")]
        public void DishDTO_MappingTest(Dish dish)
        {
            var model = Mapper.Map<Dish, DishDTO>(dish);

            Assert.Equal(dish.Id, model.Id);
            Assert.Equal(dish.Name, model.Name);
            Assert.Equal(dish.Fat, model.Fat);
            Assert.Equal(dish.Norm, model.Norm);
            Assert.Equal(dish.Protein, model.Protein);
            Assert.Equal(dish.Vitamine_C, model.Vitamine_C);
            Assert.Equal(dish.Carbohydrate, model.Carbohydrate);
        }

        [Fact]
        public void ProductDishDTO_MappingTest()
        {
            var dish = GetDishes().First().Cast<Dish>();
            var product = GetProducts().First().Cast<Product>();

            ProductDish productDish = new ProductDish()
            {
                Id = 5,
                Norm = 10,
                Dish = dish.First(),
                Product = product.First(),
            };

            var model = Mapper.Map<ProductDish, ProductDishDTO>(productDish);

            Assert.Equal(productDish.Id, model.Id);
            Assert.Equal(productDish.Norm, model.Norm);
        }

        public static IEnumerable<object[]> GetProducts()
        {
            yield return new object[]
            {
                new Product()
                {
                    Id = 2,
                    Name = "Рис",
                    Balance = 200,
                    UnitName = "граммы",
                    Fat = 2,
                    Norm = 1,
                    Price = 40,
                    Protein = 2,
                    Vitamine_C = 6,
                    Carbohydrate = 32,
                }
            };
        }

        public static IEnumerable<object[]> GetDishes()
        {
            yield return new object[]
            {
                new Dish()
                {
                    Id = 2,
                    Name = "Плов",
                    Norm = 1,
                    Vitamine_C = 6,
                    Fat = 2,
                    Protein = 2,
                    Carbohydrate = 32,
                }
            };
        }
    }
}