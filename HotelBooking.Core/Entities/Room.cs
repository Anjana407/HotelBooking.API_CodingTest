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
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomType { get; set; } = string.Empty; // Standard, Deluxe, Suite

        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerNight { get; set; }

        [Range(1, 4)]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation Properties
        public Hotel? Hotel { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
