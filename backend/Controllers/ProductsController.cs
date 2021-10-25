using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ShopDB"));

            var productsList = dbClient.GetDatabase("Shop").GetCollection<ProductsModel>("Products").AsQueryable(); 

            return new JsonResult(productsList);
        }
    }
}