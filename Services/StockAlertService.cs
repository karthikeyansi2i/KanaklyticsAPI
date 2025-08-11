using Kanaklytics.API.DTOs;
using Kanaklytics.API.Models;
using Kanaklytics.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public class StockAlertService : IStockAlertService
    {
        private readonly IStockAlertRepository _stockAlertRepository;
        private readonly Kanaklytics.API.Data.KanaklyticsDbContext _context;
        public StockAlertService(IStockAlertRepository stockAlertRepository, Kanaklytics.API.Data.KanaklyticsDbContext context)
        {
            _stockAlertRepository = stockAlertRepository;
            _context = context;
        }

        public async Task<IEnumerable<StockAlertDto>> GetActiveAlertsAsync()
        {
            var alerts = await _stockAlertRepository.GetActiveAlertsAsync();
            var dtos = new List<StockAlertDto>();
            foreach (var a in alerts)
            {
                var dto = ToDto(a);
                dto.ProductName = a.Product?.Name;
                dto.WarehouseName = a.Warehouse?.Location;
                // Query inventory directly for correct stock level
                var inventory = _context.Inventories.FirstOrDefault(i => i.ProductId == a.ProductId && i.WarehouseId == a.WarehouseId);
                dto.StockLevel = inventory?.Quantity ?? 0;
                dtos.Add(dto);
            }
            return dtos;
        }

        public async Task<StockAlertDto> ConfigureAlertAsync(StockAlertDto alertDto)
        {
            var alert = new StockAlert
            {
                AlertId = alertDto.AlertId,
                ProductId = alertDto.ProductId,
                WarehouseId = alertDto.WarehouseId,
                Threshold = alertDto.Threshold,
                IsActive = alertDto.IsActive
            };
            var configured = await _stockAlertRepository.ConfigureAlertAsync(alert);
            return ToDto(configured);
        }

        private StockAlertDto ToDto(StockAlert a)
        {
            return new StockAlertDto
            {
                AlertId = a.AlertId,
                ProductId = a.ProductId,
                WarehouseId = a.WarehouseId,
                Threshold = a.Threshold,
                IsActive = a.IsActive
            };
        }
    }
}
