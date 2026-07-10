using HotelBooking.Application.Interfaces;
using HotelBooking.Core.Entities;
using HotelBooking.Core.Exceptions;
using HotelBooking.Core.Interfaces;
using HotelBooking.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AvailableRoomDto>> GetAvailableRoomsAsync(
        int hotelId,
        DateTime checkIn,
        DateTime checkOut,
        int guests)
        {
            var rooms = await _repository.GetAvailableRoomsAsync(
                hotelId,
                checkIn,
                checkOut,
                guests);

            if(rooms.Count()==0)
            {

                throw new NotFoundException(
                  $"Rooms are not Available");
            }

            return rooms.Select(r => new AvailableRoomDto
            {
                RoomId = r.Id,
                RoomNumber = r.RoomNumber,
                RoomType = r.RoomType.ToString(),
                Capacity = r.Capacity
            });
        }



     
    }

    
}
