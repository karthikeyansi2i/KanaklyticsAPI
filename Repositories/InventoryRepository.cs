using Kanaklytics.API.Data;
using Kanaklytics.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly KanaklyticsDbContext _context;
        public InventoryRepository(KanaklyticsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetByProductIdAsync(int productId)
        {
            return await _context.Inventories.Where(i => i.ProductId == productId).ToListAsync();
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }
    }
}
