using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data.Model.EntityConfigurations
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CustomerId);
            builder.HasOne<CustomerAccount>().WithMany(x => x.Orders).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.CustomerId);

         
            builder.Property(x => x.TimeOrder);
        }
    }
}
