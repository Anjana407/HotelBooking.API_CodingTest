using HotelBooking.API.Controllers;
using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Services;
using HotelBooking.Core.Entities;
using HotelBooking.Core.Exceptions;
using HotelBooking.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HotelBooking.Test
{
    public class BookingsControllerTest
    {

        private readonly Mock<IBookingService> _bookingServiceMock;
        public BookingsControllerTest()
        {
            _bookingServiceMock = new Mock<IBookingService>();
        }

        [Fact]
        public async Task CreateBooking_ShouldReturnCreated_WhenBookingCreated()
        {
            // Arrange
            BookingsController bookingsController = new BookingsController(_bookingServiceMock.Object);

            var createBookingRequest = new CreateBookingRequestDto
            {
                HotelId=1,
                RoomId=101,
                CheckIn=DateTime.Today.AddDays(2),
                CheckOut= DateTime.Today.AddDays(5),
                NumberOfGuests=2
            };
            var response= new BookingResponseDto
             {
                BookingReference = "BK10001",
                Message = "Booking created successfully."
             };

            _bookingServiceMock
                .Setup(x => x.BookRoomAsync(createBookingRequest))
                .ReturnsAsync(response);

            // Act
            var result = await bookingsController.BookRoom(createBookingRequest);

            // Assert
            var createdResult = Assert.IsType<OkObjectResult>(result);

            var booking = Assert.IsType<BookingResponseDto>(createdResult.Value);

            Assert.Equal("BK10001", booking.BookingReference);
        }


        [Fact]
        public async Task CreateBookingAsync_ShouldThrowNotFound_WhenRoomDoesNotExist()
        {
            // Arrange

            BookingsController bookingsController = new BookingsController(_bookingServiceMock.Object);

            var createBookingRequest = new CreateBookingRequestDto
            {
                HotelId = 1,
                RoomId = 106,
                CheckIn = DateTime.Today.AddDays(2),
                CheckOut = DateTime.Today.AddDays(5),
                NumberOfGuests = 2
            };

            _bookingServiceMock.Setup(x => x.BookRoomAsync(createBookingRequest)).ReturnsAsync(new BookingResponseDto { BookingReference="",Message= "Room not found." });
            
            // Act
            var bookingResponse = await bookingsController.BookRoom(createBookingRequest);

            // Assert
            var createdResult = Assert.IsType<OkObjectResult>(bookingResponse);
            var booking = Assert.IsType<BookingResponseDto>(createdResult.Value);
            Assert.Equal("Room not found.", booking.Message);
        }
    }
}
