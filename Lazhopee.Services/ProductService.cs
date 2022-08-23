using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lazhopee.Common.Helpers;
using Lazhopee.Contracts.Repositories;
using Lazhopee.Contracts.Services;
using Lazhopee.Models.DTOs;
using Lazhopee.Models.Entities;
using System.Net;

namespace Lazhopee.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductReadDTO> AddProductAsync(ProductCreationDTO product)
        {
            var (validationResult, errorMessage) = DataValidationHelper.ValidateObject(product);
            if (!validationResult)
                throw new HttpRequestException(errorMessage, null, HttpStatusCode.BadRequest);

            var isProductExist = _unitOfWork.ProductRepository.FindAll()
                                                              .Where(item => item.ProductName.Equals(product.ProductName))
                                                              .Any();

            if (isProductExist)
                throw new HttpRequestException($"Product name {product.ProductName} already exist", null, HttpStatusCode.BadRequest);

            var entity = _mapper.Map<Product>(product);

            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = "API";

            _unitOfWork.ProductRepository.Create(entity);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductReadDTO>(entity);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var entityProduct = await _unitOfWork.ProductRepository.FindByIdAsync(id);
            if (entityProduct is null)
                throw new HttpRequestException($"Product id {id} not exist", null, HttpStatusCode.NotFound);

            entityProduct.IsDeleted = true;
            entityProduct.ModifiedBy = "API";
            entityProduct.ModifiedAt = DateTime.UtcNow;

            _unitOfWork.ProductRepository.Update(entityProduct);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ProductReadDTO> GetProductAsync(Guid id)
        {
            var productEntity = await _unitOfWork.ProductRepository.FindByIdAsync(id);
            if (productEntity is null)
                throw new HttpRequestException($"Product id {id} not exist", null, HttpStatusCode.NotFound);

            return _mapper.Map<ProductReadDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductReadDTO>> GetProductsAsync() =>
            await Task.Run(() => _unitOfWork.ProductRepository.FindAll()
                                                              .ProjectTo<ProductReadDTO>(_mapper.ConfigurationProvider)
                                                              .AsEnumerable());

        public async Task UpdateProductAsync(Guid id, ProductUpdateDTO product)
        {
            var (validationResult, errorMessage) = DataValidationHelper.ValidateObject(product);
            if (!validationResult)
                throw new HttpRequestException(errorMessage, null, HttpStatusCode.BadRequest);

            var entityProduct = await _unitOfWork.ProductRepository.FindByIdAsync(id);
            if (entityProduct is null)
                throw new HttpRequestException($"Product id {id} not exist", null, HttpStatusCode.NotFound);

            entityProduct.ProductName = product.ProductName;
            entityProduct.ProductDescription = product.ProductDescription;
            entityProduct.Status = product.Status;
            entityProduct.DefaultPrice = product.DefaultPrice;
            entityProduct.Quantity = product.Quantity;
            entityProduct.ModifiedBy = "API";
            entityProduct.ModifiedAt = DateTime.UtcNow;

            _unitOfWork.ProductRepository.Update(entityProduct);
            await _unitOfWork.SaveAsync();
        }
    }
}
