using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Core;

namespace Store.G04.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // Get/Base/api/product
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var Result = await _productServices.GetAllProductAsync();
            return Ok(Result);
        }
        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrand()
        {
            var Result = await _productServices.GetAllBrandAsync();
            return Ok(Result);
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetAllType()
        {
            var Result = await _productServices.GetAllTypeAsync();
            return Ok(Result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id is null) return BadRequest("Invalid id !!");
            var Result = await _productServices.GetProductById(id);
            if (Result is null) return NotFound($"Id {id} Not Found");
            return Ok(Result);
        }
    }
}
