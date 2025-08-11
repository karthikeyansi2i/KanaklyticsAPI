namespace Kanaklytics.API.DTOs
{
    public class StockAlertDto
    {
        public int AlertId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Threshold { get; set; }
        public bool IsActive { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public int StockLevel { get; set; }
    }
}
