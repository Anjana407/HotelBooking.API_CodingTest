using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Services;
using HotelBooking.Core.Interfaces;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IDataSeeder, DataSeeder>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }
    }
}
