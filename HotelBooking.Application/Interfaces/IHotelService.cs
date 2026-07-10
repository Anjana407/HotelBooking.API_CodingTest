using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Dto;

namespace HotelBooking.Application.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelResponseDto>> SearchHotelAsync(string hotelName);

        //Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomsAsync(
        //    int hotelId,
        //    DateTime checkIn,
        //    DateTime checkOut,
        //    int guests);
    }
}
