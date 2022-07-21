using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Infrastructure.UoW;
using PizzeriaWeb.Infrastructure.Data.CustomerAccountModel.EntityConfigurations;
using SQLHomeWork.Domain;

namespace PizzeriaWeb.Infrastructure.Data
{
    public class PizzeriaDbContext : DbContext, IUnitOfWork
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerAccount> customerAccount { get; set; }
        public DbSet<Product> product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomerAccountMap());
            builder.ApplyConfiguration(new ProductMap());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
