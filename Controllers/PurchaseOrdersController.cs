using Kanaklytics.API.DTOs;
using Kanaklytics.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kanaklytics.API.Controllers
{
    [ApiController]
    [Route("api/purchase-orders")]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderDto dto)
        {
            var created = await _purchaseOrderService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.PurchaseOrderId }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _purchaseOrderService.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
