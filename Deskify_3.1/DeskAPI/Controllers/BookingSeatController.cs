using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                try
                {
                    _bookingService.DeleteSeatBooking(bookingseatId);
                    return Ok("Seat Deleted Successfully");
                }
                catch
                {
                    return BadRequest(400);
                }             
            }

            [HttpPut("UpdateSeatBooking")]
            public IActionResult UpdateSeatBooking(BookingSeat bookseat)
            {
                try
                {
                    _bookingService.UpdateSeatBooking(bookseat);
                    return Ok("Seat Updated Successfully");
                }
                catch
                {
                    return BadRequest(400);
                }
                
            }

            [HttpGet("GetAllBookingSeats")]
            public IEnumerable<BookingSeat> GetAllBookingSeats()
            {
                return _bookingService.GetAllBookingSeats();
            }

            [HttpGet("GetSeatBookingById")]
            public BookingSeat GetSeatBookingById(int bookingseatId)
            {
                return _bookingService.GetSeatBookingById(bookingseatId);
            }

            [HttpGet("GetSeatBookingByEmployeeId")]
          

            public BookingSeat GetSeatBookingByEmployeeId(int employeeid)
        {
            return _bookingService.GetBookingSeatByEmployeeId(employeeid);

        }

    }
}
