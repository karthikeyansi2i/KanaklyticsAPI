using Kanaklytics.API.DTOs;
using Kanaklytics.API.Models;
using Kanaklytics.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanaklytics.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => ToDto(p));
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : ToDto(product);
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Category = productDto.Category,
                Description = productDto.Description,
                SKU = productDto.SKU,
                Price = productDto.Price
            };
            var created = await _productRepository.AddAsync(product);
            return ToDto(created);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            var product = new Product
            {
                ProductId = productDto.ProductId,
                Name = productDto.Name,
                Category = productDto.Category,
                Description = productDto.Description,
                SKU = productDto.SKU,
                Price = productDto.Price
            };
            var updated = await _productRepository.UpdateAsync(product);
            return ToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        private ProductDto ToDto(Product p)
        {
            return new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Category = p.Category,
                Description = p.Description,
                SKU = p.SKU,
                Price = p.Price,
                CreatedAt = p.CreatedAt
            };
        }
    }
}
