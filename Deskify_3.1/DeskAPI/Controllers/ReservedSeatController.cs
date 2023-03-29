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
    public class ReservedSeatController : ControllerBase
    {
        ReservedSeatService _reservedSeatService;
        public ReservedSeatController(ReservedSeatService reservedSeatService)
        {
            _reservedSeatService = reservedSeatService;
        }

        [HttpPost("AddReservedSeat")]
        public IActionResult AddReservedSeat(ReservedSeat reservedSeat)
        {
            _reservedSeatService.AddReservedSeat(reservedSeat);
            return Ok("Reserved Seat Added Successfully");

        }

        [HttpDelete("DeleteReservedSeat")]
        public IActionResult DeleteReservedSeat(int reservedseatId)
        {
            _reservedSeatService.DeleteReservedSeat(reservedseatId);
            return Ok("Reserved Seat Deleted Successfully");
        }

        [HttpPut("UpdateReservedSeat")]
        public IActionResult UpdateReservedSeat(ReservedSeat reservedseat)
        {
            _reservedSeatService.UpdateReservedSeat(reservedseat);
            return Ok("Reserved Seat Updated Successfully");
        }

        [HttpGet("GetAllReservedSeats")]
        public IEnumerable<ReservedSeat> GetAllReservedSeats()
        {
            return _reservedSeatService.GetAllReservedSeats().ToList();
        }

        [HttpGet("GetReservedSeatById")]
        public ReservedSeat GetReservedSeatById(int reservedseatId)
        {
            return _reservedSeatService.GetReservedSeatsById(reservedseatId);
        }
    }
}
