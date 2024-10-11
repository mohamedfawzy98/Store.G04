using Store.G04.Core.Dtos;
using Store.G04.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Services.Contract
{
    public interface IBasketServices
    {
        Task<CustomerBasket> UpdateOrCreate(CustomerBasket basket);
        Task<CustomerBasket> GetById(string ? basketid);
        Task Deletebasket(string ? basketid);

    }
}
