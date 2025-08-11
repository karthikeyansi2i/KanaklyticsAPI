using Kanaklytics.API.Data;
using Kanaklytics.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly KanaklyticsDbContext _context;
        public PurchaseOrderRepository(KanaklyticsDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseOrder> CreateAsync(PurchaseOrder order)
        {
            _context.PurchaseOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<PurchaseOrder> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrders.Include(o => o.Items).FirstOrDefaultAsync(o => o.PurchaseOrderId == id);
        }
    }
}
