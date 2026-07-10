using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Services;
using HotelBooking.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;

        }

      

         [HttpGet("GetAvailableRooms")]
        public async Task<IActionResult> AvailableRooms(int hotelId,DateTime checkIn,DateTime checkOut,int noOfguests)
        {
           var rooms = await _roomService.GetAvailableRoomsAsync(hotelId,checkIn,checkOut, noOfguests);
            return Ok(rooms);
        }




    }
}
