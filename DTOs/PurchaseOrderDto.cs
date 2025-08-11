namespace Kanaklytics.API.DTOs
{
    public class PurchaseOrderDto
    {
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public List<PurchaseOrderItemDto> Items { get; set; }
    }
    public class PurchaseOrderItemDto
    {
        public int PurchaseOrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
