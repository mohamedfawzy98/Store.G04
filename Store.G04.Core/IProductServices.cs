using Store.G04.Core.Dtos;
using Store.G04.Core.Dtos.Product;
using Store.G04.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core
{
    public interface IProductServices
    {
        Task<PagnationResponse<ProductDto>> GetAllProductAsync(string? sort,int? brandid, int? typeid, int? pagesize, int? pageindex ,string search);
        Task<IEnumerable<BrandTypeDto>> GetAllBrandAsync();
        Task<IEnumerable<BrandTypeDto>> GetAllTypeAsync();
        Task<ProductDto> GetProductById(int? id);
    }
}
