using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoicesController : ControllerBase
    {
        private ChoicesService _choicesService;
        public ChoicesController(ChoicesService choicesService)
        {
            _choicesService = choicesService;
        }

        [HttpPost("AddChoice")]
        public IActionResult AddChoice(Choices choice)
        {
            try
            {
                _choicesService.AddChoice(choice);
                return Ok("Choices Added Successfully");
            }
            catch
            {
                return BadRequest(400);
            }

        }

        [HttpDelete("DeleteChoice")]
        public IActionResult DeleteChoice(int choiceId)
        {
            try
            {
                _choicesService.DeleteChoice(choiceId);
                return Ok("Choices Deleted Successfully");
            }
            catch
            {
                return BadRequest(400);
            }
            
        }

        [HttpPut("UpdateChoice")]
        public IActionResult UpdateChoice(Choices choice)
        {
            try
            {
                _choicesService.UpdateChoice(choice);
                return Ok("Choices Updated Successfully");
            }
            catch
            {
                return BadRequest(400);
            }
            
        }

        [HttpGet("GetAllChoices")]
        public IEnumerable<Choices> GetAllChoices()
        {
            return _choicesService.GetAllChoices();
        }

        [HttpGet("GetChoiceById")]
        public Choices GetChoiceById(int choiceId)
        {
            return _choicesService.GetChoiceById(choiceId);
        }
    }
}
