using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private FloorService _floorService;
        public FloorController(FloorService floorService)
        {
            _floorService = floorService;
        }


        #region GET FLOOR

        [HttpGet("GetFloor")]
        public IEnumerable<Floor> GetFloor()
        {
            return _floorService.GetFloor();
        }

        #endregion

        #region GET FLOORBYID

        [HttpGet("GetFloorById")]
        public Floor GetFloorById(int floorId)
        {
            return _floorService.GetFloorById(floorId);
        }

        #endregion

        #region ADD FLOOR

        [HttpPost("AddFloor")]
        public IActionResult AddFloor([FromBody] Floor floor)
        {
            try
            {
                _floorService.AddFloor(floor);
                return Ok("Floor Created successfully");
            }
            catch
            {
                return BadRequest(400);
            }
            
        }

        #endregion

        #region DELETE FLOOR

        [HttpDelete("DeleteFloor")]
        public IActionResult DeleteFloor(int floorId)
        {
            try
            {
                _floorService.DeleteFloor(floorId);
                return Ok("Message Deleted sucessfully!!!");
            }
            
            catch
            {
                return BadRequest(400);
            }
        }

        #endregion

        #region UPDATE FLOOR

        [HttpPut("UpdateFloor")]
        public IActionResult UpdateFloor([FromBody] Floor floor)
        {
            try
            {
                _floorService.UpdateFloor(floor);
                return Ok("Floor Updated successfully");
            }
            catch
            {
                return BadRequest(400);
            }
            

        }

        #endregion
    }
}
