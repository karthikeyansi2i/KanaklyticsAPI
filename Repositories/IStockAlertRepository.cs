using Kanaklytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public interface IStockAlertRepository
    {
        Task<IEnumerable<StockAlert>> GetActiveAlertsAsync();
        Task<StockAlert> ConfigureAlertAsync(StockAlert alert);
    }
}
