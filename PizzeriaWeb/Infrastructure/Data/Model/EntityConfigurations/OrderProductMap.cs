using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data.Model.EntityConfigurations
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.OrderId);
            builder.HasOne<Order>().WithMany(x=> x.OrderProducts).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=> x.OrderId);

            builder.Property(x => x.ProductId);
            builder.HasOne<Product>().WithMany(x => x.Products).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.ProductId);
        }
    }

}
