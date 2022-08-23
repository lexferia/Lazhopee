using Lazhopee.Contracts.Repositories;
using Lazhopee.Models.Entities;

namespace Lazhopee.Infrastracture.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
