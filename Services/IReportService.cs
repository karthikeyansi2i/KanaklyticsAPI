using Kanaklytics.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IReportService
    {
        Task<StockValuationReportDto> GetStockValuationAsync();
        Task<IEnumerable<InventoryTrendDto>> GetInventoryTrendsAsync();
    }
}
