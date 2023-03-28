using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeskEntity.Model
{
    public class ReservedSeat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservedSeatId { get; set; }

        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        [ForeignKey("BookingSeat")]
        public int BookingSeatId { get; set; }
        public BookingSeat BookingSeat { get; set; }
    }
}
