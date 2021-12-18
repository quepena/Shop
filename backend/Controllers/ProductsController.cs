using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace backend.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =  await this.repository.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await this.repository.GetProduct(id);
        }

        
        [HttpGet("category/{id}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(int id)
        {
            var products = await this.repository.GetProductsByCategory(id);

            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetBrands()
        {
            var brands = await this.repository.GetBrands();
            
            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetCategories()
        {
            var categories = await this.repository.GetCategories();
            
            return Ok(categories);
        }
    }
}