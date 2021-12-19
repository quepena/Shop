using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace backend.Helpers
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductImageUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.Image))
            {
                return this.configuration["ApiUrl"]+source.Image;
            }

            return null;
        }
    }
}