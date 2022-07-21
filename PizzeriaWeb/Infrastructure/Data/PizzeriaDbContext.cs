using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Infrastructure.UoW;
using PizzeriaWeb.Infrastructure.Data.Model.EntityConfigurations;
using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Infrastructure.Data
{
    public class PizzeriaDbContext : DbContext, IUnitOfWork
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerAccount> customerAccount { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Order> order { get; set; }

        public DbSet<OrderProduct> orderProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomerAccountMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderProductMap());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
