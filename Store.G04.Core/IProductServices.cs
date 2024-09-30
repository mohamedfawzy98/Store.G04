using Store.G04.Core.Dtos;
using Store.G04.Core.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<IEnumerable<BrandTypeDto>> GetAllBrandAsync();
        Task<IEnumerable<BrandTypeDto>> GetAllTypeAsync();
        Task<ProductDto> GetProductById(int? id);
    }
}
