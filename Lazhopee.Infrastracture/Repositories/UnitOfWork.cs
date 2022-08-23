using Lazhopee.Contracts.Repositories;

namespace Lazhopee.Infrastracture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public UnitOfWork(AppDbContext context, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public async Task<int> SaveAsync() 
            => await _context.SaveChangesAsync();
    }
}
