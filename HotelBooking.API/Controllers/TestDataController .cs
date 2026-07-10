using HotelBooking.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/test-data")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        private readonly IDataSeeder _dataSeeder;

        public TestDataController(IDataSeeder dataSeeder)
        {
            _dataSeeder = dataSeeder;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            await _dataSeeder.SeedAsync();

            return Ok(new
            {
                Message = "Database seeded successfully."
            });
        }

        [HttpDelete("reset")]
        public async Task<IActionResult> Reset()
        {
            await _dataSeeder.ResetAsync();

            return Ok(new
            {
                Message = "Database reset successfully."
            });
        }
    }
}
