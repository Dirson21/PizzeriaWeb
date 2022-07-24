using PizzeriaWeb.Infrastructure.Data;

namespace PizzeriaWeb.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzeriaDbContext _ctx;

        public UnitOfWork(PizzeriaDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
             _ctx.SaveChanges();
           return await _ctx.SaveEntitiesAsync(cancellationToken);

        }
    }
}
