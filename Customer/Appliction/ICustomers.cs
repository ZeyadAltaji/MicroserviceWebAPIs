using Customer.Domain;

namespace Customer.Appliction
{
    public interface ICustomers
    {
        Task<Customers> Login(string username, string password);
        void Register(string username, string password);
    }
}
