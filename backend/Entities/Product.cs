using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        [ForeignKey("BrandId")]

        public Brand Brand { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("CategoryId")]

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public long CountInStock { get; set; }

        public double Rating { get; set; }

        public long NumReviews { get; set; }
    }
}