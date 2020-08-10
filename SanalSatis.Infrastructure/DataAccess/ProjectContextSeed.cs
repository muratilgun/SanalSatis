using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SanalSatis.Kernel.Entities;

namespace SanalSatis.Infrastructure.DataAccess
{
    public class ProjectContextSeed
    {
        public static async Task SeedAsync(ProjectContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../SanalSatis.Infrastructure/DataAccess/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                
                
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../SanalSatis.Infrastructure/DataAccess/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../SanalSatis.Infrastructure/DataAccess/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProjectContextSeed>();
                logger.LogError(e.Message);
            }
        }
    }
}