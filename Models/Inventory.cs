using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanaklytics.API.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
