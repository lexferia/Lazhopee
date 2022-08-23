using Lazhopee.Common.Enums;
using Lazhopee.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazhopee.Infrastracture
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }

            if (!context.Products.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                var productId = Guid.NewGuid();

                context.AddRange(
                    new Product { Id = productId, ProductName = "Oppo Reno 7", ProductDescription = "test desc", DefaultPrice = 40.00, Quantity = 50, Status = (int)ProductStatus.InStock, CreatedBy = "API", CreatedAt = DateTime.UtcNow },
                    new Product { ProductName = "IPhone 13", ProductDescription = "test desc", DefaultPrice = 84.00, Quantity = 10, Status = (int)ProductStatus.InStock, CreatedBy = "API", CreatedAt = DateTime.UtcNow },
                    new Product { ProductName = "Samsung Galaxy", ProductDescription = "test desc", DefaultPrice = 61.00, Quantity = 30, Status = (int)ProductStatus.OutOfStock, CreatedBy = "API", CreatedAt = DateTime.UtcNow }
                );

                context.SaveChanges();

                var orderId = Guid.NewGuid();

                context.AddRange(
                    new Order { Id = orderId, ShippingAddress = "test address", ShippingAmount = 100.00, SubTotal = 40.00, TaxAmount = 10.00, TotalAmount = 150.00, CreatedBy = "API", CreatedAt = DateTime.UtcNow, 
                                Items = new List<OrderItem>() { 
                                    new OrderItem { OrderId = orderId, Price = 40.00, ProductId = productId, Quantity = 1 }
                                } 
                    }   
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
