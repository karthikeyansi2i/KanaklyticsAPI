using Microsoft.EntityFrameworkCore;
using Kanaklytics.API.Models;

namespace Kanaklytics.API.Data
{
    public class KanaklyticsDbContext : DbContext
    {
        public KanaklyticsDbContext() { }
        public KanaklyticsDbContext(DbContextOptions<KanaklyticsDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<StockAlert> StockAlerts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.SKU).IsUnique();
            // ...existing code...
        }
    }
}
