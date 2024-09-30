using Store.G04.Core.Entites;
using Store.G04.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G04.Repository
{
    public static class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDbContext _context)
        {
            if(_context.Brands.Count() == 0)
            {
                // Read Jeson file 
                var branddata = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\brands.json");

                // 2 - convert string jeson to List<T>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);

                // 3 - seed Data in DB

                if (brands is not null && brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }
            }

            if (_context.Types.Count() == 0)
            {
                // Read Jeson file 
                var typedata = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\types.json");

                // 2 - convert string jeson to List<T>
                var types = JsonSerializer.Deserialize<List<ProductType>>(typedata);

                // 3 - seed Data in DB

                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }
            }

            if (_context.Products.Count() == 0)
            {
                // Read Jeson file 
                var productdata = File.ReadAllText(@"..\Store.G04.Repository\Data\DataSeed\products.json");

                // 2 - convert string jeson to List<T>
                var products = JsonSerializer.Deserialize<List<Product>>(productdata);

                // 3 - seed Data in DB

                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
