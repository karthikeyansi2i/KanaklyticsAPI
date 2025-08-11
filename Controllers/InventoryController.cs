using Kanaklytics.API.DTOs;
using Kanaklytics.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kanaklytics.API.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var inventory = await _inventoryService.GetByProductIdAsync(productId);
            return Ok(inventory);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(InventoryDto dto)
        {
            var updated = await _inventoryService.UpdateAsync(dto);
            return Ok(updated);
        }
    }
}
