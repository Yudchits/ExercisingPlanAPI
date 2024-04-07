using AutoMapper;
using ExercisingPlanAPI.DTOs;
using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisingPlanController : Controller
    {
        private readonly IExercisingPlanService _service;
        private readonly IMapper _mapper;

        public ExercisingPlanController(IExercisingPlanService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllExercisingPlans")]
        [ProducesResponseType(200, Type = typeof(ICollection<ExercisingPlanBriefDto>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllExercisingPlansAsync()
        {
            var plans = await _service.GetAllExercisingPlansAsync();

            if (plans.Count == 0)
            {
                return NoContent();
            }

            var plansMap = _mapper.Map<ICollection<ExercisingPlanBriefDto>>(plans);

            return Ok(plansMap);
        }

        [HttpGet]
        [Route("getExercisingPlanById")]
        [ProducesResponseType(200, Type = typeof(ExercisingPlanFullDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetExercisingPlanByIdAsync([FromQuery] int id)
        {
            bool planExists = await _service.ExercisingPlanExistsAsync(id);

            if (!planExists)
            {
                return BadRequest();
            }

            var plan = await _service.GetExercisingPlanByIdAsync(id);

            if (plan == null)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during getting an exercising plan");
                return StatusCode(500, ModelState);
            }
            
            var planMap = _mapper.Map<ExercisingPlanFullDto>(plan);

            return Ok(planMap);
        }
    }
}
