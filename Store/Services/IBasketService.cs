using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IBasketService
    {
        Task<Basket> AddAsync(Basket basket);
        Task<IEnumerable<Basket>> GetAsync();
        Task<bool> DeleteAsync(Guid id);
    }
}
