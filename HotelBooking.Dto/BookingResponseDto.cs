using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Dto
{
    public class BookingResponseDto
    {
        public string BookingReference { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }

}
