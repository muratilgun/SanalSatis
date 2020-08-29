using System.Threading.Tasks;
using SanalSatis.Kernel.Entities;
using SanalSatis.Kernel.Entities.OrderAggregate;

namespace SanalSatis.Kernel.Interfaces
{
    public interface IPaymentService
    {
         Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
         Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
         Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}