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
    public class HotelRepository :IHotelRepository
    {
        private readonly HotelDbContext dbContext;
        public HotelRepository(HotelDbContext _dbContext)
        {
            dbContext = _dbContext;
        } 
        public async Task<IEnumerable<Hotel>> SearchByNameAsync(string name)
        {
            return await dbContext.Hotels
                .Where(h => h.Name.Contains(name))
                .ToListAsync();
        }
        public async Task<Hotel?> GetHotelWithRoomsAsync(int hotelId)
        {
            return await dbContext.Hotels
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

    }
}
