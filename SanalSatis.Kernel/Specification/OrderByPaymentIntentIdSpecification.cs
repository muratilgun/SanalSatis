using System;
using System.Linq.Expressions;
using SanalSatis.Kernel.Entities.OrderAggregate;

namespace SanalSatis.Kernel.Specification
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId) : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}