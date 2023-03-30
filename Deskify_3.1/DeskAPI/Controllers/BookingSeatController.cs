using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSeatController : ControllerBase
    {
        
            private BookingSeatService _bookingService;

            public BookingSeatController(BookingSeatService bookingService)
            {
                _bookingService = bookingService;
            }

            [HttpPost("AddSeatBooking")]
            public int AddSeatBooking(BookingSeat bookseat)
            {
                 return _bookingService.AddSeatBooking(bookseat);
                

            }

            [HttpDelete("DeleteSeatBooking")]
            public IActionResult DeleteSeatBooking(int bookingseatId)
            {
                _bookingService.DeleteSeatBooking(bookingseatId);
                return Ok("Seat Deleted Successfully");
            }

            [HttpPut("UpdateSeatBooking")]
            public IActionResult UpdateSeatBooking(BookingSeat bookseat)
            {
                _bookingService.UpdateSeatBooking(bookseat);
                return Ok("Seat Updated Successfully");
            }

            [HttpGet("GetAllBookingSeats")]

            public IEnumerable<BookingSeat> GetAllBookingSeats()
            {
                return _bookingService.GetAllBookingSeats().ToList();
            }
            [HttpGet("GetSeatBookingById")]
            public BookingSeat GetSeatBookingById(int bookingseatId)
            {
                return _bookingService.GetSeatBookingById(bookingseatId);
            }
        }
}
