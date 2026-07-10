namespace HotelBookingTest
{
    using HotelBooking.API;
    using HotelBooking.API.Controllers;
    using HotelBooking.Application.Interfaces;
    using HotelBooking.Core.Entities;
    using HotelBooking.Dto;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class HotelsControllerTest
    {
        private readonly Mock<IHotelService> _hotelServiceMock;
        public HotelsControllerTest() 
        {
            _hotelServiceMock = new Mock<IHotelService>();
        }
        [Fact]
        public async Task SearchHotel_ReturnsHotels_WhenHotelExists()
        {
            // Arrange
            var name = "Hilton";

            HotelsController hotelsController = new HotelsController(_hotelServiceMock.Object);

            var hotels = new List<HotelResponseDto>
            {
             new HotelResponseDto
             {
              Id = 1,
              Name = "Hilton"
             },
             new HotelResponseDto
             {
              Id = 2,
              Name = "Hilton Garden Inn",
             }
             };

            _hotelServiceMock
                .Setup(x => x.SearchHotelAsync(name))
                .ReturnsAsync(hotels);

            // Act
            var result = await hotelsController.Search(name);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHotelByName_ShouldThrowException_WhenNotExist()
        {
            // Arrange
            var name = "Hilton";

            HotelsController hotelsController = new HotelsController(_hotelServiceMock.Object);
           _hotelServiceMock
           .Setup(x => x.SearchHotelAsync(name))
           .ReturnsAsync(new List<HotelResponseDto>());

            // Act
            var result = await hotelsController.Search(name);
            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var hotels = Assert.IsAssignableFrom<IEnumerable<HotelResponseDto>>(okResult.Value);
            Assert.Empty(hotels);


        }

    }
}