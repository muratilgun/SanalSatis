using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SanalSatis.Kernel.Entities.Identity;

namespace SanalSatis.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Muro",
                    Email = "muro@test.com",
                    UserName = "muro@test.com",
                    Address = new Address 
                    {
                        FirstName = "Muro",
                        LastName = "Murky",
                        Street = "10 The Street",
                        City = "Istanbul",
                        State = "ist",
                        Zipcode = "34210"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}