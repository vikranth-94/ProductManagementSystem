using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Controllers;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                var createdProduct = await _productService.AddProductAsync(product);
                return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetAllProductDetailsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)//input validation
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            try
            {
                await _productService.UpdateProductAsync(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }

        [Authorize]
        [HttpPut("decrement-stock/{id}/{amount}")]
        public async Task<IActionResult> DecrementStock(int id, int amount)
        {
            try
            {
                await _productService.DecrementStockAsync(id, amount);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [Authorize]
        [HttpPut("add-to-stock/{id}/{amount}")]
        public async Task<IActionResult> AddToStock(int id, int amount)
        {
            try
            {
                await _productService.AddToStockAsync(id, amount);
                return Ok();
            }            
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing your request.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
