namespace Lazhopee.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task<int> SaveAsync();
    }
}
