using Kanaklytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Repositories
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
    }
}
