using Microsoft.EntityFrameworkCore;
using Store.Common.Data.Domain;
using Store.Common.Data.Domain.Configuration;

namespace Store.Common.Data
{
    public sealed class OrdersContext(DbContextOptions<OrdersContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}