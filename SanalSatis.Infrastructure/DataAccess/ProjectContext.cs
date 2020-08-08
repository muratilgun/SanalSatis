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
    }
}