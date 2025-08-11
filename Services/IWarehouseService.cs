using Kanaklytics.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();
    }
}
