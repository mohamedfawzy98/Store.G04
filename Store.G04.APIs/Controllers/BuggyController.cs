using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Error;
using Store.G04.Repository.Data.Context;

namespace Store.G04.APIs.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _context;

        public BuggyController(StoreDbContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public async Task<IActionResult> GetNotFoundRequsetError()
        {
            var brand = await _context.Brands.FindAsync(100);

            //if (brand is null) return NotFound(new {Message = "Resourse Not Found" , StutasCode = 404});
            if (brand is null) return NotFound(new ApiErrorResponse(404));

            return Ok(brand);
            
        }
        [HttpGet("servererror")]
        public async Task<IActionResult> GetServerError()
        {
            var brand = await _context.Brands.FindAsync(100);

             var branderror = brand.ToString();  // null expection

            return Ok(brand);

        }
        [HttpGet("badrequset")]
        public async Task<IActionResult> GetBadRequestError()
        {
            return BadRequest(new ApiErrorResponse(400,"Bad requset here !!"));

        }
        [HttpGet("badrequset/{id}")]
        public async Task<IActionResult> GetBadRequestError(int id)
        {
            // will send valdtion error
            return Ok();

        }

        [HttpGet("Unauthorized")]
        public async Task<IActionResult> GetUnauthorizedError()
        {
            return Unauthorized(new ApiErrorResponse(401));

        }

    }
}
