using Kanaklytics.API.DTOs;
using Kanaklytics.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kanaklytics.API.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("stock-valuation")]
        public async Task<IActionResult> GetStockValuation()
        {
            var report = await _reportService.GetStockValuationAsync();
            return Ok(report);
        }

        [HttpGet("inventory-trends")]
        public async Task<IActionResult> GetInventoryTrends()
        {
            var trends = await _reportService.GetInventoryTrendsAsync();
            return Ok(trends);
        }
    }
}
