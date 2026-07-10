using HotelBooking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [ApiController]
    [Route("api/Hotels")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            var hotels = await _hotelService.SearchHotelAsync(name);
            return Ok(hotels);
        }
    }
}
