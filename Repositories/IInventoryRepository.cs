using Kanaklytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetByProductIdAsync(int productId);
        Task<Inventory> UpdateAsync(Inventory inventory);
    }
}
