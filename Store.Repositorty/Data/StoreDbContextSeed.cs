using Store.Core.Entities;
using Store.Core.Entities.Order;
using Store.Repositorty.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repositorty.Data
{
    public class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDBContext _context)
        {
            if (_context.Brands.Count() == 0)
            {
                var brandsData = File.ReadAllText(@"..\Store.Repositorty\Data\DataSeed\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands is not null && brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                }
            }
            if (_context.Types.Count() == 0)
            {
                var typesData = File.ReadAllText(@"..\Store.Repositorty\Data\DataSeed\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                }
            }
            if (_context.Products.Count() == 0)
            {
                var productsData = File.ReadAllText(@"..\Store.Repositorty\Data\DataSeed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }
            }
            if (_context.DelevaryMethods.Count() == 0)
            {
                var delivaryData = File.ReadAllText(@"..\Store.Repositorty\Data\DataSeed\delivery.json");
                var delevaryMethod = JsonSerializer.Deserialize<List<DelevaryMethod>>(delivaryData);
                if (delevaryMethod is not null && delevaryMethod.Count() > 0)
                {
                    await _context.DelevaryMethods.AddRangeAsync(delevaryMethod);
                    await _context.SaveChangesAsync();

                }
            }
            await _context.SaveChangesAsync();

        }
    }
}
