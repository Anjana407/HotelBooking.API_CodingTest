using HotelBooking.Core.Entities;
using HotelBooking.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Interfaces
{
    public interface  IBookingRepository
    {
        Task<Booking?> GetByReferenceAsync(string bookingReference);

        Task<bool> IsRoomAvailableAsync(
            int roomId,
            DateTime checkIn,
            DateTime checkOut);

        Task<BookingResponseDto> AddBookingDetails(Booking bookingDetails);
    }
}
