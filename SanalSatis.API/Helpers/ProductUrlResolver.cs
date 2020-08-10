using AutoMapper;
using Microsoft.Extensions.Configuration;
using SanalSatis.API.Dtos;
using SanalSatis.Kernel.Entities;

namespace SanalSatis.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration ["ApiUrl"] + source.PictureUrl;
            }

            return null;
            
        }
    }
}