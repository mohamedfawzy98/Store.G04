﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.G04.Core.Dtos.Product;
using Store.G04.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Mapping
{
    public class ProductResolve : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductResolve(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["BASEURL"]}{source.PictureUrl}";
            }

            return string.Empty;
        }
    }
}
