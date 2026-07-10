using HotelBooking.Application.Interfaces;
using HotelBooking.Core.Entities;
using HotelBooking.Core.Interfaces;
using HotelBooking.Dto;
using HotelBooking.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;
        public HotelService(IHotelRepository repository)
        {
            _repository = repository;
        }
    

        public async Task<IEnumerable<HotelResponseDto>> SearchHotelAsync(string hotelName)
        {
            if (string.IsNullOrWhiteSpace(hotelName))
                return Enumerable.Empty<HotelResponseDto>();
          
            var hotel= await _repository.SearchByNameAsync(hotelName);

            if (hotel.Count() ==0)
            {
                throw new NotFoundException(
                    $"Hotel with name '{hotelName}' was not found.");
            }

            return hotel.Select(h => new HotelResponseDto
            {
                Id = h.Id,
                Name = h.Name
            });
        }

    }
}
