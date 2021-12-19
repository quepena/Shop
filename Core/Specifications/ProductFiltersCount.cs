using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductFiltersCount : BaseSpecification<Product>
    {
        public ProductFiltersCount(ProductSpecificationsParameters parameters) : base(x => 
            (string.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
            (!parameters.BrandId.HasValue || x.BrandId == parameters.BrandId) &&
            (!parameters.CategoryId.HasValue || x.CategoryId == parameters.CategoryId))
        {
            
        }
    }
}