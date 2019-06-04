using ISPitanie.BLL.Entities;
using Xunit;
using ISPitanie;
using System.Collections.Generic;
using AutoMapper;
using ISPitanie.Models;

namespace ISPitanie.UnitTests
{
    public class MappingUnitTests
    {
        public MappingUnitTests()
        {
            AutoMapperConfig.Initialize();
        }

        [Theory]
        [MemberData("GetProducts")]
        public void ProductModel_MappingTest(Product product)
        {
            var model = Mapper.Map<Product, ProductViewModel>(product);

            Assert.Equal(product.Id, model.Id);
            Assert.Equal(product.Name, model.Name);
            Assert.Equal(product.Count, model.Count);
            Assert.Equal(product.UnitName, model.UnitName);
            Assert.Equal(product.Fat, model.Fat);
            Assert.Equal(product.Norm, model.Norm);
            Assert.Equal(product.Price, model.Price);
            Assert.Equal(product.Protein, model.Protein);
            Assert.Equal(product.Vitamine_C, model.Vitamine_C);
            Assert.Equal(product.Carbohydrate, model.Carbohydrate);
        }

        public static IEnumerable<object[]> GetProducts()
        {
            yield return new object[] 
            {
                new Product()
                {
                    Id = 2,
                    Name = "Рис",
                    Count = 200, 
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
    }
}