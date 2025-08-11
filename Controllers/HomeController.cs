using Microsoft.AspNetCore.Mvc;

namespace Kanaklytics.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly Data.KanaklyticsDbContext _context;
        public HomeController(Data.KanaklyticsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Kanaklytics Inventory Management API is running.");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            var totalProducts = _context.Products.Count();
            var lowStockThreshold = 5;
            var totalValue = _context.Inventories
                .Join(_context.Products, i => i.ProductId, p => p.ProductId, (i, p) => p.Price * i.Quantity)
                .Sum();
            var pendingOrders = _context.PurchaseOrders.Count(po => po.Status == "Pending");

            // Inventory overview
            var instockProducts = _context.Inventories
            .GroupBy(i => i.ProductId)
            .Where(g => g.All(i => i.Quantity > lowStockThreshold))
            .Count();
            var outOfStockProducts = _context.Inventories.Count(i => i.Quantity == 0);
            var lowStockItems = _context.Inventories.Count(i => i.Quantity <= lowStockThreshold);

            return Ok(new
            {
                totalProducts,
                lowStockItems,
                totalValue,
                pendingOrders,
                inventoryOverview = new
                {
                    instock = instockProducts,
                    lowstock = lowStockItems,
                    outofstock = outOfStockProducts
                }
            });
        }

        [HttpGet("recent-activity")]
        public IActionResult RecentActivity()
        {
            var activities = new List<dynamic>();

            // Recent product updates
            var recentProduct = _context.Products.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (recentProduct != null)
                activities.Add(new { type = "Product", id = recentProduct.ProductId, name = recentProduct.Name, date = recentProduct.CreatedAt });

            // Recent inventory update
            var recentInventory = _context.Inventories.OrderByDescending(i => i.LastUpdated).FirstOrDefault();
            if (recentInventory != null)
                activities.Add(new { type = "Inventory", id = recentInventory.InventoryId, productId = recentInventory.ProductId, warehouseId = recentInventory.WarehouseId, date = recentInventory.LastUpdated });

            // Recent purchase order
            var recentOrder = _context.PurchaseOrders.OrderByDescending(po => po.OrderDate).FirstOrDefault();
            if (recentOrder != null)
                activities.Add(new { type = "PurchaseOrder", id = recentOrder.PurchaseOrderId, status = recentOrder.Status, date = recentOrder.OrderDate });

            // Recent stock alert (no date property, so skip or use a fallback)
            // If you add a CreatedAt/UpdatedAt to StockAlert, use it here. For now, skip from sorting.

            // Recent user registration
            var recentUser = _context.Users.OrderByDescending(u => u.CreatedAt).FirstOrDefault();
            if (recentUser != null)
                activities.Add(new { type = "User", id = recentUser.UserId, username = recentUser.Username, date = recentUser.CreatedAt });

            // Sort all by date descending (if available)
            var sorted = activities.OrderByDescending(a => a.date).Take(5);
            return Ok(sorted);
        }

        [HttpGet("suppliers")]
        public IActionResult GetSuppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            return Ok(suppliers);
        }
    }
}
