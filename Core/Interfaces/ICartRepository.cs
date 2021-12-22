using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(string cartId);
        Task<Cart> UpdateCart(Cart cart);
        Task<bool> DeleteCart(string cartId);
    }
}