using Customer.Appliction;

namespace User.Microservices.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomers CustomersRepository { get; }
        Task<bool> SaveAsync();

    }
}
