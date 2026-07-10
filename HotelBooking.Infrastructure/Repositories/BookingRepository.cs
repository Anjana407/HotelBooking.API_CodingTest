using HotelBooking.Core.Entities;
using HotelBooking.Core.Interfaces;
using HotelBooking.Dto;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly HotelDbContext dbContext;
        public BookingRepository(HotelDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Booking?> GetByReferenceAsync(string bookingReference)
        {
            return await dbContext.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
                .FirstOrDefaultAsync(b =>
                    b.BookingReference == bookingReference);
        }

        public async Task<bool> IsRoomAvailableAsync(
           int roomId,
           DateTime checkIn,
           DateTime checkOut)
        {
            return !await dbContext.Bookings.AnyAsync(x =>
                x.RoomId == roomId &&
                 checkIn < x.CheckInDate && checkOut > x.CheckOutDate);
        }

        public async Task<BookingResponseDto>  AddBookingDetails(Booking bookingDetails)
        {
            try
            {
                await dbContext.Bookings.AddAsync(bookingDetails);
                await dbContext.SaveChangesAsync();
              
            }
            catch(Exception ex)
            {


            }
            return new BookingResponseDto
            {
                BookingReference = bookingDetails.BookingReference,
                Message = "Booking created successfully."
            };

        }

       
    }
}
