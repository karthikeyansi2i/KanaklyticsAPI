using Kanaklytics.API.DTOs;
using Kanaklytics.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kanaklytics.API.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    public class StockAlertsController : ControllerBase
    {
        private readonly IStockAlertService _stockAlertService;
        public StockAlertsController(IStockAlertService stockAlertService)
        {
            _stockAlertService = stockAlertService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActive()
        {
            var alerts = await _stockAlertService.GetActiveAlertsAsync();
            return Ok(alerts);
        }
    }
}
