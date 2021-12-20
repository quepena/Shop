using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsCategoriesBrands : BaseSpecification<Product>
    {
        public ProductsCategoriesBrands(ProductSpecificationsParameters parameters) : base(x => 
            (string.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
            (!parameters.BrandId.HasValue || x.BrandId == parameters.BrandId) &&
            (!parameters.CategoryId.HasValue || x.CategoryId == parameters.CategoryId))
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
            AddOrderBy(x => x.Name);
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
            if(!string.IsNullOrEmpty(parameters.Sort))
            {
                switch(parameters.Sort)
                {
                    case "priceA":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceD":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsCategoriesBrands(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }
    }
}