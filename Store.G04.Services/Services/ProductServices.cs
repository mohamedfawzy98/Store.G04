using AutoMapper;
using Store.G04.Core;
using Store.G04.Core.Dtos;
using Store.G04.Core.Dtos.Product;
using Store.G04.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrandTypeDto>> GetAllBrandAsync()
        {
            return _mapper.Map<IEnumerable<BrandTypeDto>>(await _unitOfWork.Repositiry<ProductBrand, int>().GetAllAsync());
          
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var prod = await _unitOfWork.Repositiry<Product, int>().GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(prod);
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllTypeAsync()
        {

            return _mapper.Map<IEnumerable<BrandTypeDto>>(await _unitOfWork.Repositiry<ProductType, int>().GetAllAsync());
        }

        public async Task<ProductDto> GetProductById(int? id)
        => _mapper.Map<ProductDto>(await _unitOfWork.Repositiry<Product, int>().GetAsync(id.Value));
    }
}
