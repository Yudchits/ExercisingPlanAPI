using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeekdayController : Controller
    {
        private readonly IWeekdayService _service;

        public WeekdayController(IWeekdayService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAllWeekdays")]
        [ProducesResponseType(200, Type = typeof(ICollection<Weekday>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllWeekdaysAsync() 
        {
            var weekdays = await _service.GetAllWeekdaysAsync();

            if (weekdays == null)
            {
                ModelState.AddModelError("SqlError", "Error during getting a list of weekdays");
                return StatusCode(500, ModelState);
            }

            return Ok(weekdays);
        }

        [HttpGet]
        [Route("getWeekdayById")]
        [ProducesResponseType(200, Type = typeof(Weekday))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetWeekdayByIdAsync([FromQuery] int id)
        {
            var weekdayIdExists = await _service.WeekdayIdExists(id);

            if (!weekdayIdExists)
            {
                ModelState.AddModelError("BodyError", "There's no weekday with such 'id'");
                return BadRequest();
            }

            var weekday = await _service.GetWeekdayByIdAsync(id);

            if (weekday == null)
            {
                ModelState.AddModelError("SqlError", "Error during getting weekday");
                return StatusCode(500, ModelState);
            }

            return Ok(weekday);
        }

        [HttpPost]
        [Route("insertWeekday")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> InsertWeekdayAsync([FromBody] Weekday weekday)
        {
            var weekdayNameExists = await _service.WeekdayNameExists(weekday.Name);

            if (weekdayNameExists)
            {
                ModelState.AddModelError("BodyError", "Weekday already exists");
                return BadRequest(ModelState);
            }

            var isInserted = await _service.InsertWeekdayAsync(weekday);

            if (!isInserted)
            {
                ModelState.AddModelError("SqlError", "Error during inserting weekday");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut]
        [Route("updateWeekday")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateWeekdayAsync([FromBody] Weekday weekday)
        {
            var weekdayIdExists = await _service.WeekdayIdExists(weekday.Id);

            if (!weekdayIdExists)
            {
                ModelState.AddModelError("BodyError", "Weekday doesn't exist yet");
                return BadRequest(ModelState);
            }

            var isUpdated = await _service.UpdateWeekdayAsync(weekday);

            if (!isUpdated)
            {
                ModelState.AddModelError("SqlError", "Error during updating weekday");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteWeekdayById")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteWeekdayByIdAsync([FromBody] int id)
        {
            var weekdayIdExists = await _service.WeekdayIdExists(id);

            if (!weekdayIdExists)
            {
                ModelState.AddModelError("BodyError", "Weekday doesn't exist yet");
                return BadRequest(ModelState);
            }

            var isDeleted = await _service.DeleteWeekdayByIdAsync(id);

            if (!isDeleted)
            {
                ModelState.AddModelError("SqlError", "Error during deleting weekday");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
