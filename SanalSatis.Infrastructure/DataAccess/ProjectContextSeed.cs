using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SanalSatis.Kernel.Entities;
using SanalSatis.Kernel.Entities.OrderAggregate;

namespace SanalSatis.Infrastructure.DataAccess
{
    public class ProjectContextSeed
    {
        public static async Task SeedAsync(ProjectContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(path + @"/DataAccess/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                
                
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(path + @"/DataAccess/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(path + @"/DataAccess/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText(path + @"/DataAccess/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
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