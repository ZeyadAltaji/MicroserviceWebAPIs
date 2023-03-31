using Porducts.Appliction;
using Product.Microservice.Infrastructure;
using Product.Microservice.Infrastructure.Repository;

namespace Product.Microservice.Appliction.UintOfWork
{
    public class UintOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UintOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public IProducts productsRepoistroy => new ProductsRepository(dc);

        public async Task<bool> SaveAsycn()
        {
            return await dc.SaveChangesAsync()>0;
        }
    }
}
