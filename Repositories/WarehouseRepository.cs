using Kanaklytics.API.Data;
using Kanaklytics.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly KanaklyticsDbContext _context;
        public WarehouseRepository(KanaklyticsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses
                .Include(w => w.Inventories)
                .ToListAsync();
        }
    }
}
