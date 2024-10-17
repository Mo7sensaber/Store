using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.Contract;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }
        [HttpGet("Brand")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }
        [HttpGet("Types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductByID(int? Id)
        {
            if (Id == null)
                return BadRequest("Invalid Id !!");
            var result = await _productService.GetProductById(Id.Value);
            if (result == null)
                return NotFound($"The Product Id {Id} not Found");
            return Ok(result);
        }
    }
}
