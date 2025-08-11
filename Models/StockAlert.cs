using System.ComponentModel.DataAnnotations;

namespace Kanaklytics.API.Models
{
    public class StockAlert
    {
        [Key]
        public int AlertId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Threshold { get; set; }
        public bool IsActive { get; set; } = true;
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
