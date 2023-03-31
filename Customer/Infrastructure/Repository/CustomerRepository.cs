using Customer.Appliction;
using Customer.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Customer.Infrastructure.Repository
{
    public class CustomerRepository : ICustomers
    {
        private readonly DataContext dc;
        public CustomerRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<Customers> Login(string username, string password)
        {
            return await dc.customers.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public void Register(string username, string password)
        {
            byte[] passwordsec;
            byte[] passwordKey;
            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordsec = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            Customers customers = new Customers();
            customers.UserName = username;
            customers.password = passwordsec;
            customers.PasswordKey = passwordKey;

            dc.customers.Add(customers);
        }
    }
}
