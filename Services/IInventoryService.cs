using Kanaklytics.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryDto>> GetByProductIdAsync(int productId);
        Task<InventoryDto> UpdateAsync(InventoryDto inventoryDto);
    }
}
