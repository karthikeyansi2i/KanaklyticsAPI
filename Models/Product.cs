using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanaklytics.API.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string SKU { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public ICollection<StockAlert> StockAlerts { get; set; }
    }
}
