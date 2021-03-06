using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SanalSatis.Kernel.Entities;
using SanalSatis.Kernel.Interfaces;

namespace SanalSatis.Infrastructure.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectContext _context;
        public ProductRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            

            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            var typeId =  1;
            var products = _context.Products.Where(x => x.ProductTypeId == typeId).Include(x => x.ProductType).ToListAsync();


            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}