using Customer.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Customer.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Customers> customers { get; set; }
    }
}
