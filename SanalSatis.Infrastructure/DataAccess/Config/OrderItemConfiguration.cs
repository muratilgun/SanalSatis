using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanalSatis.Kernel.Entities.OrderAggregate;

namespace SanalSatis.Infrastructure.DataAccess.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(i => i.ItemOrdered, io => {io.WithOwner();});
            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}