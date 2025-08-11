using Kanaklytics.API.DTOs;
using Kanaklytics.API.Models;
using Kanaklytics.API.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<PurchaseOrderDto> CreateAsync(PurchaseOrderDto orderDto)
        {
            var order = new PurchaseOrder
            {
                SupplierId = orderDto.SupplierId,
                Status = orderDto.Status,
                Items = orderDto.Items?.Select(i => new PurchaseOrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
            var created = await _purchaseOrderRepository.CreateAsync(order);
            return ToDto(created);
        }

        public async Task<PurchaseOrderDto> GetByIdAsync(int id)
        {
            var order = await _purchaseOrderRepository.GetByIdAsync(id);
            return order == null ? null : ToDto(order);
        }

        private PurchaseOrderDto ToDto(PurchaseOrder o)
        {
            return new PurchaseOrderDto
            {
                PurchaseOrderId = o.PurchaseOrderId,
                SupplierId = o.SupplierId,
                OrderDate = o.OrderDate,
                Status = o.Status,
                Items = o.Items?.Select(i => new PurchaseOrderItemDto
                {
                    PurchaseOrderItemId = i.PurchaseOrderItemId,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}
