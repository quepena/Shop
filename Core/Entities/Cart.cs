using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart
    {
        public Cart()
        {
        }

        public Cart(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}