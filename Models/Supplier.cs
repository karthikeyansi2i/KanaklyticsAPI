using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kanaklytics.API.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string ContactEmail { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
