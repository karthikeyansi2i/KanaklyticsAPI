namespace Kanaklytics.API.DTOs
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<InventoryDto> Inventories { get; set; }
        public ICollection<StockAlertDto> StockAlerts { get; set; }
        public int TotalCount { get; set; }
        public int Capacity { get; set; }
    }
}
