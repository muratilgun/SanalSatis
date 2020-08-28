using System.Threading.Tasks;
using SanalSatis.Kernel.Entities;

namespace SanalSatis.Kernel.Interfaces
{
    public interface IPaymentService
    {
         Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    }
}