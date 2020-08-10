using System.Collections.Generic;
using System.Threading.Tasks;
using SanalSatis.Kernel.Entities;

namespace SanalSatis.Kernel.Interfaces
{
    public interface IProductRepository
    {
       Task<Product> GetProductByIdAsync(int id);  
       Task<IReadOnlyList<Product>> GetProductAsync();  
       Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();  
       Task<IReadOnlyList<ProductType>> GetProductTypesAsync();  

    }
}