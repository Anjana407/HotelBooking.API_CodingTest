using HotelBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAvailableRoomsAsync(
            int hotelId,
            DateTime checkIn,
            DateTime checkOut,
            int guests);

        Task<Room> GetRoom(int roomID);
    }
}
