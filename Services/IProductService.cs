using Kanaklytics.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task<ProductDto> UpdateAsync(ProductDto productDto);
        Task<bool> DeleteAsync(int id);
    }
}
