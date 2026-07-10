using HotelBooking.Application.Interfaces;
using HotelBooking.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("BookRoom")]
        public async Task<IActionResult> BookRoom(
            [FromBody] CreateBookingRequestDto request)
        {
            var response = await _bookingService.BookRoomAsync(request);

            return Ok(response);
        }

        [HttpGet("{bookingReference}")]
        public async Task<IActionResult> GetBooking(
            string bookingReference)
        {
            var booking =
                await _bookingService.GetBookingByReferenceAsync(
                    bookingReference);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }
    }
}

