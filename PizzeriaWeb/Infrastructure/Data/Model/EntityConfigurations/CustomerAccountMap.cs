using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLHomeWork.Domain;

namespace PizzeriaWeb.Infrastructure.Data.CustomerAccountModel.EntityConfigurations
{
    public class CustomerAccountMap : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Login);
            builder.HasIndex(x => x.Login).IsUnique();

            builder.Property(x => x.Password);
            builder.Property(x => x.Balance);
            
        }
    }
}
