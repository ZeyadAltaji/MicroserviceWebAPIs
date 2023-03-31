using Product.Microservice.Domain;

namespace Porducts.Appliction
{
    public interface IProducts
    {
        Task<IEnumerable<Products>> GetAll();
        void AddProducts(Products product);
        void DeletedProducts(int Id);
        Task<Products> FindProducts(int ID);

        Task<bool> Save();
    }
}
