using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);

        Task<IReadOnlyList<Product>> GetProducts();

        Task<IReadOnlyList<Product>> GetProductsByCategory(int id);

        Task<IReadOnlyList<Brand>> GetBrands();

        Task<IReadOnlyList<Category>> GetCategories();
    }
}