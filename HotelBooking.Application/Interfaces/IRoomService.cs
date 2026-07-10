using HotelBooking.Core.Entities;
using HotelBooking.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IRoomService
    {

        Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomsAsync(
         int hotelId,
         DateTime checkIn,
         DateTime checkOut,
         int guests);


    }
}
