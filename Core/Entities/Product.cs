using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public Brand Brand { get; set; }

        public int BrandId { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public long CountInStock { get; set; }

        public double Rating { get; set; }

        public long NumReviews { get; set; }
    }
}