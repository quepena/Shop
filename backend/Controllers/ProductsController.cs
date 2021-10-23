using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        // IMongoCollection<Products> Products;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        // [HttpGet]
        // public async Task<IEnumerable<ProductsModel>> GetProducts()
        // {
        //     return await Products.ToListAsync();
        // }
    }
}