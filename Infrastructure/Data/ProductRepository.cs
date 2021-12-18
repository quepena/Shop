using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<Brand>> GetBrands()
        {
            return await this.context.Brands.ToListAsync();
        }

        public async Task<IReadOnlyList<Category>> GetCategories()
        {
            return await this.context.Categories.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await this.context.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await this.context.Products.Include(p => p.Brand).Include(p => p.Category).ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsByCategory(int id)
        {
            return await this.context.Products.Where(d => d.CategoryId == id).ToListAsync();
        }
    }
}