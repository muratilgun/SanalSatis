using SanalSatis.Kernel.Entities.Identity;

namespace SanalSatis.Kernel.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}