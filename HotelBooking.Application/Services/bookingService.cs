using HotelBooking.Application.Interfaces;
using HotelBooking.Core.Entities;
using HotelBooking.Core.Interfaces;
using HotelBooking.Dto;
using HotelBooking.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingrepository;
        private readonly IRoomRepository _roomRepository;
        public BookingService(IBookingRepository repository,IRoomRepository roomRepository)
        {
            _bookingrepository = repository;
            _roomRepository = roomRepository;
        }

     
        public async Task<BookingResponseDto> BookRoomAsync(
           CreateBookingRequestDto request)
        {
            if (request.CheckIn >= request.CheckOut)
                throw new ArgumentException(
                    "Check-out date must be after check-in.");

            if (request.NumberOfGuests <= 0)
                throw new ArgumentException(
                    "Invalid number of guests.");

            var room = await _roomRepository.GetRoom(request.RoomId);

            if (room == null)
                throw new KeyNotFoundException("Room not found.");

            if (room.HotelId != request.HotelId)
                throw new Exception("Room does not belong to the selected hotel.");

            if (room.Capacity < request.NumberOfGuests)
                throw new Exception("Room capacity exceeded.");

            bool available =
                await _bookingrepository.IsRoomAvailableAsync(
                    request.RoomId,
                    request.CheckIn,
                    request.CheckOut);

            if (!available)
                throw new Exception(
                    "Room is already booked for the selected dates.");

            var booking = new Booking
            {
                BookingReference = $"BK-{Guid.NewGuid():N}".Substring(0, 11).ToUpper(),
                CheckInDate = request.CheckIn,
                CheckOutDate = request.CheckOut,
                NumberOfGuests = request.NumberOfGuests,
                CustomerName="xyz",
                CustomerEmail="xyz@gmail.com",
                RoomId = room.Id
            };
            return await _bookingrepository.AddBookingDetails(booking);


        }

        public async Task<BookingDetailsDto?> GetBookingByReferenceAsync(
            string bookingReference)
        {
            var booking =
                await _bookingrepository.GetByReferenceAsync(
                    bookingReference);

            if (booking == null)
                return null;

            return new BookingDetailsDto
            {
                BookingReference = booking.BookingReference,
                HotelName = booking.Room.Hotel.Name,
                RoomNumber = booking.Room.RoomNumber,
                RoomType = booking.Room.RoomType.ToString(),
                CheckIn = booking.CheckInDate,
                CheckOut = booking.CheckOutDate,
                NumberOfGuests = booking.NumberOfGuests
            };
        }


    }
}
