using Microsoft.EntityFrameworkCore;
using SanalSatis.Kernel.Entities;

namespace SanalSatis.Infrastructure.DataAccess
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products {get; set;}
        public DbSet<ProductType> ProductTypes {get; set;}
        public DbSet<ProductBrand> ProductBrands {get; set;}
    }
}