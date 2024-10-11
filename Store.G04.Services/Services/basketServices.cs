using AutoMapper;
using Store.G04.Core;
using Store.G04.Core.Dtos;
using Store.G04.Core.Entites;
using Store.G04.Core.Repository.Contract;
using Store.G04.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Services
{
    public class basketServices : IBasketServices
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public basketServices(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task Deletebasket(string? basketid)
        {
           await _basketRepository.DeleteBasketAsync(basketid);
        }

        public async Task<CustomerBasket> GetById(string? basketid)
        {
            return await _basketRepository.GetBasketAsync(basketid);
        }

        public async Task<CustomerBasket> UpdateOrCreate(CustomerBasket basket)
        {

            return await _basketRepository.UpdateBasketAsync(basket);
        }
    }
}
