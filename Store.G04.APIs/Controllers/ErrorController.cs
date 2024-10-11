using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Error;

namespace Store.G04.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult error(int code)
        {
            return NotFound(new ApiErrorResponse( 404, "End Point Not Found !!"));
        }
    }
}
