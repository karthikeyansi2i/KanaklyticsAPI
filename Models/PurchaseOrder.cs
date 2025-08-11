using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kanaklytics.API.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [MaxLength(50)]
        public string Status { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<PurchaseOrderItem> Items { get; set; }
    }
}
