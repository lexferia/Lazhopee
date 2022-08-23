using Lazhopee.Contracts.Repositories;
using Lazhopee.Models.Entities;

namespace Lazhopee.Infrastracture.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }
    }
}
