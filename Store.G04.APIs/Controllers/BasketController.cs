using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Error;
using Store.G04.Core.Dtos;
using Store.G04.Core.Entites;
using Store.G04.Core.Repository.Contract;
using Store.G04.Core.Services.Contract;

namespace Store.G04.APIs.Controllers
{
    
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IBasketServices _basketServices;

        public BasketController(IBasketRepository basketRepository, IMapper mapper , IBasketServices basketServices)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _basketServices = basketServices;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string ? id)
        {
            if (id is null) return BadRequest(new ApiErrorResponse(400, "Invalid id !!"));

            //var basket = await _basketRepository.GetBasketAsync(id);
            var basket = await _basketServices.GetById(id);


            if (basket is null) new CustomerBasket() { Id = id };

            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateOrCreateBasket(CustomerBasketDto model)
        {
            var mapped = _mapper.Map<CustomerBasket>(model);
            //var basket = await _basketRepository.UpdateBasketAsync(mapped);
            var basket = await _basketServices.UpdateOrCreate(mapped);

            if (basket is null) return BadRequest(new ApiErrorResponse(400));

            return Ok(basket);
        }

        [HttpDelete]
        public async Task DeleteBasket (string? id)
        {
            //var basket = await _basketRepository.DeleteBasketAsync(id);

           await _basketServices.Deletebasket(id);

        }
    }
}
