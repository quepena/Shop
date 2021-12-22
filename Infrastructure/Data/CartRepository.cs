using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase database;

        public CartRepository(IConnectionMultiplexer redis)
        {
            this.database = redis.GetDatabase();
        }

        public async Task<bool> DeleteCart(string cartId)
        {
            return await this.database.KeyDeleteAsync(cartId);
        }

        public async Task<Cart> GetCart(string cartId)
        {
            var data = await this.database.StringGetAsync(cartId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Cart>(data);
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var created = await this.database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(10));

            if(!created) return null;

            return await GetCart(cart.Id);
        }
    }
}