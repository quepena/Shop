using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class ProductsModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public long CountInStock { get; set; }

        public double Rating { get; set; }

        public long NumReviews { get; set; }
    }
}