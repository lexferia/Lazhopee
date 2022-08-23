using Lazhopee.Models.DTOs;

namespace Lazhopee.Contracts.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDTO>> GetOrdersAsync();
        Task<OrderReadDTO> GetOrderAsync(Guid id);
        Task<OrderReadDTO> AddOrderAsync(OrderCreationDTO order);
        Task UpdateOrderAsync(OrderUpdateDTO order);
        Task DeleteOrderAsync(Guid id);
    }
}
