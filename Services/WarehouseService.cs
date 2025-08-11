using Kanaklytics.API.DTOs;
using Kanaklytics.API.Models;
using Kanaklytics.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsync();
            return warehouses.Select(ToDto);
        }

        private WarehouseDto ToDto(Warehouse w)
        {
            return new WarehouseDto
            {
                WarehouseId = w.WarehouseId,
                Name = w.Name,
                Location = w.Location,
                // Inventories = w.Inventories?.Select(i => new InventoryDto
                // {
                //     InventoryId = i.InventoryId,
                //     ProductId = i.ProductId,
                //     WarehouseId = i.WarehouseId,
                //     Quantity = i.Quantity
                // }).ToList(),
                // StockAlerts = w.StockAlerts?.Select(sa => new StockAlertDto
                // {
                //     AlertId = sa.AlertId,
                //     ProductId = sa.ProductId,
                //     WarehouseId = sa.WarehouseId,
                //     Threshold = sa.Threshold,
                //     IsActive = sa.IsActive
                // }).ToList(),
                TotalCount = w.Inventories?.Sum(i => i.Quantity) ?? 0,
                Capacity = w.Capacity
            };
        }
    }
}
