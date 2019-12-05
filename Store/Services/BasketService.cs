using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Helpers;
using Store.Models;

namespace Store.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUser user;
        private readonly DataContext dbContext;

        public BasketService(IUser user, DataContext dbContext)
        {
            this.user = user;
            this.dbContext = dbContext;
        }
        public async Task<Basket> AddAsync(Basket basket)
        {
            basket.UserId = user.Id;
            var ExistBasket = dbContext.Basket.SingleOrDefault(x => x.UserId == user.Id && x.ProductId == basket.ProductId);
            if (ExistBasket == null)
            {
                await dbContext.Basket.AddAsync(basket);
                await dbContext.SaveChangesAsync();
                return basket;
            }
            ExistBasket.Quantity += basket.Quantity;
            await dbContext.SaveChangesAsync();
            return ExistBasket;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var basket = await dbContext.Basket.SingleOrDefaultAsync(x => x.Id == id);
            if (basket == null)
                return false;
            basket.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Basket>> GetAsync()
        {
            return await dbContext.Basket.Include(x=>x.Product).Where(x=>x.UserId == user.Id).ToListAsync();
        }
    }
}
