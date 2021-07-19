using Bogus;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Services
{
    public static class ProductService
    {
        public static List<ProductViewModel> Products = new List<ProductViewModel>();

        public static void FillListProduct()
        {
            var products = new Faker<ProductViewModel>()
                .CustomInstantiator(p
                    => new ProductViewModel
                    {
                        Id = p.Random.Number(0, 1000),
                        Name = p.Commerce.ProductName(),
                        Price = p.Finance.Amount(0, 500),
                        Sku = p.Commerce.Ean13()
                    }).Generate(1000);
            Products.AddRange(products);
        }
    }
}
