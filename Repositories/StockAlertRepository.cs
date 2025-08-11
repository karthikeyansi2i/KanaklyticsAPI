using Kanaklytics.API.Data;
using Kanaklytics.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public class StockAlertRepository : IStockAlertRepository
    {
        private readonly KanaklyticsDbContext _context;
        public StockAlertRepository(KanaklyticsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockAlert>> GetActiveAlertsAsync()
        {
            return await _context.StockAlerts
                .Include(a => a.Product)
                .Include(a => a.Warehouse)
                .Where(a => a.IsActive)
                .ToListAsync();
        }

        public async Task<StockAlert> ConfigureAlertAsync(StockAlert alert)
        {
            _context.StockAlerts.Update(alert);
            await _context.SaveChangesAsync();
            return alert;
        }
    }
}
