using Kanaklytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder> CreateAsync(PurchaseOrder order);
        Task<PurchaseOrder> GetByIdAsync(int id);
    }
}
