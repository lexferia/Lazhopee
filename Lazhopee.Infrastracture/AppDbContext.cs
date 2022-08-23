using Lazhopee.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lazhopee.Infrastracture
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(orderItem => new { orderItem.Id, orderItem.OrderId, orderItem.ProductId });
        }
    }
}
