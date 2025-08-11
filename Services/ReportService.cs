using Kanaklytics.API.DTOs;
using Kanaklytics.API.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public class ReportService : IReportService
    {
        private readonly KanaklyticsDbContext _context;
        public ReportService(KanaklyticsDbContext context)
        {
            _context = context;
        }

        public async Task<StockValuationReportDto> GetStockValuationAsync()
        {
            var items = _context.Inventories
                .Join(_context.Products,
                    i => i.ProductId,
                    p => p.ProductId,
                    (i, p) => new StockItemValueDto
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = i.Quantity,
                        Value = p.Price * i.Quantity
                    })
                .ToList();
            var totalValue = items.Sum(x => x.Value);
            return new StockValuationReportDto
            {
                TotalStockValue = totalValue,
                Items = items
            };
        }

        public async Task<IEnumerable<InventoryTrendDto>> GetInventoryTrendsAsync()
        {
            // Placeholder: implement actual trend logic
            return new List<InventoryTrendDto>();
        }
    }
}
