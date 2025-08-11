using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kanaklytics.API.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Location { get; set; }
        public int Capacity { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<StockAlert> StockAlerts { get; set; }
    }
}
