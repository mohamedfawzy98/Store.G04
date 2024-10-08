﻿using AutoMapper;
using Store.G04.Core;
using Store.G04.Core.Dtos;
using Store.G04.Core.Dtos.Product;
using Store.G04.Core.Entites;
using Store.G04.Core.Helper;
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

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BrandTypeDto>> GetAllBrandAsync()
        {
            return _mapper.Map<IEnumerable<BrandTypeDto>>(await _unitOfWork.Repositiry<ProductBrand, int>().GetAllAsync());

        }

        public async Task<PagnationResponse<ProductDto>> GetAllProductAsync(string ? sort , int? brandid, int? typeid, int? pagesize, int? pageindex , string search)
        {
            var spec = new ProductSpectifcation(sort , brandid , typeid, pagesize.Value, pageindex.Value , search);
            var prod = await _unitOfWork.Repositiry<Product, int>().GetAllwithspecAsync(spec);
            var productmapped = _mapper.Map<IEnumerable<ProductDto>>(prod);

            var countspec = new ProductWithCount(sort, brandid, typeid, pagesize.Value, pageindex.Value , search);
            var count = await _unitOfWork.Repositiry<Product, int>().GetCountAsync(countspec);
            return new PagnationResponse<ProductDto>(pagesize.Value,pageindex.Value, count , productmapped);
        }

        public async Task<IEnumerable<BrandTypeDto>> GetAllTypeAsync()
        {

            return _mapper.Map<IEnumerable<BrandTypeDto>>(await _unitOfWork.Repositiry<ProductType, int>().GetAllAsync());
        }

        public async Task<ProductDto> GetProductById(int? id)
        {
            var spec = new ProductSpectifcation(id.Value);
            return _mapper.Map<ProductDto>(await _unitOfWork.Repositiry<Product, int>().GetwithspecAsync(spec));
        }
    }
}
