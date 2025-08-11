using Kanaklytics.API.DTOs;
using Kanaklytics.API.Models;
using Kanaklytics.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<InventoryDto>> GetByProductIdAsync(int productId)
        {
            var inventories = await _inventoryRepository.GetByProductIdAsync(productId);
            return inventories.Select(ToDto);
        }

        public async Task<InventoryDto> UpdateAsync(InventoryDto inventoryDto)
        {
            var inventory = new Inventory
            {
                InventoryId = inventoryDto.InventoryId,
                ProductId = inventoryDto.ProductId,
                WarehouseId = inventoryDto.WarehouseId,
                Quantity = inventoryDto.Quantity
            };
            var updated = await _inventoryRepository.UpdateAsync(inventory);
            return ToDto(updated);
        }

        private InventoryDto ToDto(Inventory i)
        {
            return new InventoryDto
            {
                InventoryId = i.InventoryId,
                ProductId = i.ProductId,
                WarehouseId = i.WarehouseId,
                Quantity = i.Quantity,
                LastUpdated = i.LastUpdated
            };
        }
    }
}
