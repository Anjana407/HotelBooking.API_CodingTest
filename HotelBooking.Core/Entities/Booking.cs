using HotelBooking.Core.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Entities
{   
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }


        public string? BookingReference { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int NumberOfGuests { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        // Foreign Key
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }

        // Navigation Property
        public Room Room { get; set; } = null!;
    }


}
