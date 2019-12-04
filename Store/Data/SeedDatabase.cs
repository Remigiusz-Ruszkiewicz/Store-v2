using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public static class SeedDatabase
    {
        public static async Task SeedUserAsync(IServiceScope serviceScope)
        {            
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = new IdentityUser { UserName = "admin@admin.pl" };
            var password = "Admin1337!";
            if (await userManager.FindByNameAsync(user.UserName) == null)
            {
                var result = await userManager.CreateAsync(user, password);
            }
            
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var admin = new IdentityRole { Name = "Admin" };
            if (!await roleManager.RoleExistsAsync(admin.Name))
            {
                var result = await roleManager.CreateAsync(admin);
            }
            
            await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user.UserName), admin.Name);
        }
        public static async Task SeedProductAsync(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            if (!await dbContext.Categories.AnyAsync() || !await dbContext.Products.AnyAsync())
            {
                var category = new Category { Name = "Art" };
                await dbContext.Categories.AddAsync(category);
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category,
                    Name = "Litle",
                    Price = 50
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category,
                    Name = "Medium",
                    Price = 100
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category,
                    Name = "Large",
                    Price = 150
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category,
                    Name = "ExtraLarge",
                    Price = 200
                });
                var category2 = new Category { Name = "PaintColor" };
                await dbContext.Categories.AddAsync(category2);
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category2,
                    Name = "Pink",
                    Price = 200
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category2,
                    Name = "White",
                    Price = 200
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category2,
                    Name = "Green",
                    Price = 200
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category2,
                    Name = "Blue",
                    Price = 200
                });
                await dbContext.Products.AddAsync(new Product
                {
                    Category = category2,
                    Name = "Red",
                    Price = 200
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
