using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data.Model.EntityConfigurations
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
           
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
  

            builder.Property(x => x.OrderId);
            builder.Property(x => x.ProductId);

            builder.HasOne<Product>(x => x.Product).WithMany(x => x.OrderProducts).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.ProductId);
            builder.HasOne<Order>(x => x.Order).WithMany(x => x.OrderProducts).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.OrderId);
           
        }
    }

}
