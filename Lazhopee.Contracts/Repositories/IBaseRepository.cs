namespace Lazhopee.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        Task<T> FindByIdAsync(object id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
