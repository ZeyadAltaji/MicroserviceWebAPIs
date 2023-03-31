using Customer.Appliction;
using Customer.Infrastructure;
using Customer.Infrastructure.Repository;
 
namespace User.Microservices.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
 
        public ICustomers CustomersRepository => new CustomerRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
