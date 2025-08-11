using Kanaklytics.API.DTOs;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrderDto> CreateAsync(PurchaseOrderDto orderDto);
        Task<PurchaseOrderDto> GetByIdAsync(int id);
    }
}
