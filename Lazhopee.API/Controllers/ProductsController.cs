using Lazhopee.Contracts.Services;
using Lazhopee.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lazhopee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get product list
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <response code="500">Error encountered while processing request.</response>
        [HttpGet]
        public async ValueTask<ActionResult<IEnumerable<ProductReadDTO>>> GetProductsAsync()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error encountered while processing request.</response>
        [HttpGet("{id:guid}", Name = "GetProductById")]
        public async ValueTask<ActionResult<ProductReadDTO>> GetProductById(Guid id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <response code="500">Error encountered while processing request.</response>
        [HttpPost]
        public async ValueTask<ActionResult> PostProduct([FromBody] ProductCreationDTO value)
        {
            var product = await _productService.AddProductAsync(value);
            return CreatedAtRoute(nameof(GetProductById), product);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Error encountered while processing request.</response>
        [HttpPut("{id:guid}")]
        public async ValueTask<ActionResult> PutProduct(Guid id, [FromBody] ProductUpdateDTO value)
        {
            await _productService.UpdateProductAsync(id, value);
            return NoContent();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <response code="404">Not found</response>
        /// <response code="500">Error encountered while processing request.</response>
        [HttpDelete("{id:guid}")]
        public async ValueTask<ActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
