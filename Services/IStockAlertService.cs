using Kanaklytics.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IStockAlertService
    {
        Task<IEnumerable<StockAlertDto>> GetActiveAlertsAsync();
        Task<StockAlertDto> ConfigureAlertAsync(StockAlertDto alertDto);
    }
}
