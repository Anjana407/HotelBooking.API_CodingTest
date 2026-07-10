using HotelBooking.Application.Interfaces;
using HotelBooking.Core.Entities;
using HotelBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public  class DataSeeder :IDataSeeder
    {

        private readonly HotelDbContext _context;

        public DataSeeder(HotelDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (_context.Hotels.Any())
                return;

            var hotel1 = new Hotel
            {
                Name = "Grand Palace",
                Address = "London",
                Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = 101,
                    RoomType = "Standard",
                    PricePerNight = 100,
                    Capacity = 2
                },
                new Room
                {
                    RoomNumber = 102,
                    RoomType = "Deluxe",
                    PricePerNight = 180,
                    Capacity = 3
                }
            }
            };

            var hotel2 = new Hotel
            {
                Name = "Royal Inn",
                Address = "Manchester",
                Rooms = new List<Room>
            {
                new Room
                {
                    RoomNumber = 201,
                    RoomType = "Suite",
                    PricePerNight = 250,
                    Capacity = 4
                }
            }
            };

            _context.Hotels.AddRange(hotel1, hotel2);

            await _context.SaveChangesAsync();

            var booking = new Booking
            {
                CustomerName = "John Smith",
                RoomId = _context.Rooms.First().Id,
                CheckInDate = DateTime.Today.AddDays(2),
                CheckOutDate = DateTime.Today.AddDays(5),
                BookingReference= "GPH-202607-0001"
            };

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();
        }

        public async Task ResetAsync()
        {
            _context.Bookings.RemoveRange(_context.Bookings);
            _context.Rooms.RemoveRange(_context.Rooms);
            _context.Hotels.RemoveRange(_context.Hotels);

            await _context.SaveChangesAsync();
        }
    }
}
