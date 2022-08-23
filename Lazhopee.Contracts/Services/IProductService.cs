using Lazhopee.Models.DTOs;

namespace Lazhopee.Contracts.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDTO>> GetProductsAsync();
        Task<ProductReadDTO> GetProductAsync(Guid id);
        Task<ProductReadDTO> AddProductAsync(ProductCreationDTO product);
        Task UpdateProductAsync(Guid id, ProductUpdateDTO product);
        Task DeleteProductAsync(Guid id);
    }
}
