using Microsoft.EntityFrameworkCore;
using Porducts.Appliction;
using Product.Microservice.Appliction;
using Product.Microservice.Domain;

namespace Product.Microservice.Infrastructure.Repository
{
    public class ProductsRepository : IProducts
    {
        private readonly DataContext dc;
        public ProductsRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddProducts(Products product)
        {
           dc.products.AddAsync(product);
        }

        public void DeletedProducts(int Id)
        {
            var products_ = dc.products.Find(Id);
            dc.products.Remove(products_);
        }

        public async Task<Products> FindProducts(int ID)
        {
            return await dc.products.FindAsync(ID);
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await dc.products.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await dc.SaveChangesAsync()>0;
        }
    }
}
