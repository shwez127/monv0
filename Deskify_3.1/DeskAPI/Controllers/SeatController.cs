using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private SeatService _seatService;

        public SeatController(SeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpPost("AddSeat")]
        public IActionResult AddSeat(Seat seat)
        {
            _seatService.AddSeat(seat);
            return Ok("Seat Added Successfully");

        }

        [HttpDelete("DeleteSeat")]
        public IActionResult DeleteSeat(int seatId)
        {
            _seatService.DeleteSeat(seatId);
            return Ok("Seat Deleted Successfully");
        }

        [HttpPut("UpdateSeat")]
        public IActionResult UpdateSeat(Seat seat)
        {
            _seatService.UpdateSeat(seat);
            return Ok("Seat Updated Successfully");
        }

        [HttpGet("GetAllSeats")]

        public IEnumerable<Seat> GetAllSeats()
        {
            return _seatService.GetAllSeats();
        }
        [HttpGet("GetSeatsById")]
        public Seat GetSeatById(int seatId)
        {
            return _seatService.GetSeatsById(seatId);
        }
    }
}
