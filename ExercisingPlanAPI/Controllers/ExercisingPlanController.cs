using AutoMapper;
using ExercisingPlanAPI.DTOs;
using ExercisingPlanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [ProducesResponseType(200, Type = typeof(ICollection<ExercisingPlanDto>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllExercisingPlans()
        {
            var plans = await _service.GetAllExercisingPlansAsync();

            if (plans.Count == 0)
            {
                return NoContent();
            }

            var plansMap = _mapper.Map<ICollection<ExercisingPlanDto>>(plans);

            return Ok(plansMap);
        }
    }
}
