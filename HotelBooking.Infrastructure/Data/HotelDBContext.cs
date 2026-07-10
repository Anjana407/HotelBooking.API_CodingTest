using HotelBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Hotel> Hotels => Set<Hotel>();

        public DbSet<Room> Rooms => Set<Room>();

        public DbSet<Booking> Bookings => Set<Booking>();


    }
}
