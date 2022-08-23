using Lazhopee.Common.Helpers;
using Lazhopee.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lazhopee.Infrastracture.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll() => 
            _context.Set<T>().AsNoTracking();

        public virtual async Task<T> FindByIdAsync(object id) => 
            await _context.Set<T>().FindAsync(id);

        public virtual void Delete(T entity) =>
            _context.Set<T>().Remove(entity);

        public virtual void Create(T entity)
        {
            var (validationResult, errorMessage) = DataValidationHelper.ValidateObject(entity);
            if (!validationResult)
                throw new ValidationException(errorMessage);

            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            var (validationResult, errorMessage) = DataValidationHelper.ValidateObject(entity);
            if (!validationResult)
                throw new ValidationException(errorMessage);

            _context.Set<T>().Update(entity);
        }
    }
}
