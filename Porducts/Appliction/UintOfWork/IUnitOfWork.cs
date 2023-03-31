using Porducts.Appliction;

namespace Product.Microservice.Appliction.UintOfWork
{
    public interface IUnitOfWork
    {
        IProducts productsRepoistroy { get; }
        Task<bool> SaveAsycn();

    }
}
