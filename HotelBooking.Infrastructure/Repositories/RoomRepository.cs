using HotelBooking.Core.Entities;
using HotelBooking.Core.Interfaces;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext dbContext;
        public RoomRepository(HotelDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Room>> GetAvailableRoomsAsync(int hotelId, DateTime checkIn, DateTime checkOut, int guests)
        {
            return await dbContext.Rooms
            .Include(r => r.Bookings)
            .Where(r =>
                r.HotelId == hotelId &&
                r.Capacity >= guests)
            .Where(r =>
                !r.Bookings.Any(b =>
                    checkIn < b.CheckInDate &&
                    checkOut > b.CheckOutDate))
            .ToListAsync();
        }

        public async Task<Room?> GetRoom(int roomNumber)
        {
            return await dbContext.Rooms.FirstOrDefaultAsync(x =>
                x.RoomNumber == roomNumber);
        }
    }
}
