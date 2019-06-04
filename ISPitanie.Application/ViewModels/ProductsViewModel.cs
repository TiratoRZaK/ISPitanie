using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Services;

namespace ISPitanie.Models
{
    public class ProductViewModel
    {
        ProductService productService = new ProductService(new EFUnitOfWork());

        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public int Norm { get; set; }
        public int Price { get; set; }
        public int? Vitamine_C { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbohydrate { get; set; }
        public int Count { get; set; }

        //public ProductViewModel(int Id)
        //{
        //    Product prod = productService.GetProduct(Id);

        //}
    }
}