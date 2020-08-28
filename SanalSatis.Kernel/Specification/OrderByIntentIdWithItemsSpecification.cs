using System;
using System.Linq.Expressions;
using SanalSatis.Kernel.Entities.OrderAggregate;

namespace SanalSatis.Kernel.Specification
{
    public class OrderByIntentIdWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderByIntentIdWithItemsSpecification(string paymentIntentId) : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}