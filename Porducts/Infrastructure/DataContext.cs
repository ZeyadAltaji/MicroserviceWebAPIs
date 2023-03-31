using Microsoft.EntityFrameworkCore;
using Product.Microservice.Domain;

namespace Product.Microservice.Infrastructure
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options) { }
        

        public DbSet<Products> products { get; set; }
    }
}
