using HotelBooking.Core.Entities;
using HotelBooking.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> SearchByNameAsync(string hotelName);
        Task<Hotel?> GetHotelWithRoomsAsync(int hotelId);

    }
}
