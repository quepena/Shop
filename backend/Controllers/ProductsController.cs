using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using backend.DTOs;
using AutoMapper;
using backend.Errors;
using Microsoft.AspNetCore.Http;
using backend.Helpers;

namespace backend.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepository;
        private readonly IGenericRepository<Brand> brandsRepository;
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productsRepository, IGenericRepository<Brand> brandsRepository, 
        IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.brandsRepository = brandsRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery]ProductSpecificationsParameters parameters)
        {
            var specification = new ProductsCategoriesBrands(parameters);

            var countSpecification = new ProductFiltersCount(parameters);

            var totalItems = await productsRepository.CountAsync(countSpecification);

            var products =  await this.productsRepository.ListAsync(specification);

            var data = this.mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(parameters.PageIndex, parameters.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var specification = new ProductsCategoriesBrands(id);

            var product = await this.productsRepository.GetEntityWithSpecification(specification);

            if(product == null) return NotFound(new ApiResponse(404));

            return this.mapper.Map<Product, ProductDto>(product);
        }

        
        // [HttpGet("category/{id}")]
        // public async Task<ActionResult<List<Product>>> GetProductsByCategory(int id)
        // {
        //     var products = await this.repository.GetProductsByCategory(id);

        //     return Ok(products);
        // }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetBrands()
        {
            var brands = await this.brandsRepository.List();
            
            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetCategories()
        {
            var categories = await this.categoryRepository.List();
            
            return Ok(categories);
        }
    }
}