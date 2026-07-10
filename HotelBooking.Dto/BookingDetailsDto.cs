using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Dto
{
    public class BookingDetailsDto
    {
        public string BookingReference { get; set; } = string.Empty;

        public string HotelName { get; set; } = string.Empty;

        public int RoomNumber { get; set; }

        public string RoomType { get; set; } = string.Empty;

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NumberOfGuests { get; set; }
    }
}
