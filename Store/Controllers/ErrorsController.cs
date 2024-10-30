using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Error;

namespace Store.Controllers
{
    [Route("error/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return NotFound(new APIErrorResponse(StatusCodes.Status404NotFound,"not found End Point!!"));
        }
    }
}
