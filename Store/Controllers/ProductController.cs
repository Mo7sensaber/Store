using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Attributes;
using Store.Core.Dtos.Products;
using Store.Core.Helper;
using Store.Core.Services.Contract;
using Store.Core.Specifications.Product;
using Store.Error;

namespace Store.Controllers
{
 
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [ProducesResponseType(typeof(PaginationResponse<ProductDtos>),StatusCodes.Status200OK)]
        [HttpGet]
        [Cashed(100)]
        [Authorize]
        public async Task<ActionResult<PaginationResponse<ProductDtos>>> GetAllProduct([FromQuery]ProductSpaceParams productSpace)
        {
            var result = await _productService.GetAllProductsAsync(productSpace);
            return Ok(result);
        }
        [HttpGet("Brand")]
        [ProducesResponseType(typeof(IEnumerable<TypeBrandDtos>), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TypeBrandDtos>>> GetAllBrands()
        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }
        [ProducesResponseType(typeof(IEnumerable<TypeBrandDtos>), StatusCodes.Status200OK)]
        [HttpGet("Types")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TypeBrandDtos>>> GetAllTypes()
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(TypeBrandDtos), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIErrorResponse), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetProductByID(int? Id)
        {
            if (Id == null)
                return BadRequest(new APIErrorResponse(400));
            var result = await _productService.GetProductById(Id.Value);
            if (result == null)
                return NotFound(new APIErrorResponse(404 ,$"The Product Id {Id} not Found"));
            return Ok(result);
        }
    }
}
