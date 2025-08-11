namespace Kanaklytics.API.DTOs
{
    public class StockValuationReportDto
    {
        public decimal TotalStockValue { get; set; }
        public List<StockItemValueDto> Items { get; set; }
    }
    public class StockItemValueDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
    public class InventoryTrendDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public List<int> Quantities { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
