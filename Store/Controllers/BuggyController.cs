using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Error;
using Store.Repositorty.Data.Contexts;

namespace Store.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly StoreDBContext _context;

        public BuggyController(StoreDBContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public async Task<IActionResult> GetNotfoundRequestError()
        {
            var brand=await _context.Brands.FindAsync(100);
            if (brand is null)
            {
                return NotFound(new APIErrorResponse(404));
            }
            return Ok(brand);
        }
        [HttpGet("servererror")]
        public async Task<IActionResult> GetServerError()
        {
            var brand = await _context.Brands.FindAsync(100);
            var brandToString= brand.ToString();
            return Ok(brand);
        }
        [HttpGet("badrequest")]
        public async Task<IActionResult> GetbadRequestError()
        {
            return BadRequest(new APIErrorResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public async Task<IActionResult> GetbadRequestError(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIErrorResponse(400));
            }
            return Ok();
        }
        [HttpGet("unauthorized")]
        public async Task<IActionResult> GetUnauthorizedError(int id)
        {

            return Unauthorized(new APIErrorResponse(401));
        }
    }
}
