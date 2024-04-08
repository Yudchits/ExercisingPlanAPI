using AutoMapper;
using ExercisingPlanAPI.DTOs;
using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisingPlanController : Controller
    {
        private readonly IExercisingPlanService _planService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ExercisingPlanController(IExercisingPlanService planService, IUserService userService, IMapper mapper)
        {
            _planService = planService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllExercisingPlans")]
        [ProducesResponseType(200, Type = typeof(ICollection<ExercisingPlanBriefDto>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllExercisingPlansAsync()
        {
            var plans = await _planService.GetAllExercisingPlansAsync();

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
            bool planExists = await _planService.ExercisingPlanExistsAsync(id);

            if (!planExists)
            {
                return BadRequest();
            }

            var plan = await _planService.GetExercisingPlanByIdAsync(id);

            if (plan == null)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during getting an exercising plan");
                return StatusCode(500, ModelState);
            }

            var planMap = _mapper.Map<ExercisingPlanFullDto>(plan);

            return Ok(planMap);
        }

        [HttpGet]
        [Route("getExercisingPlansOfOwner")]
        [ProducesResponseType(200, Type = typeof(ICollection<ExercisingPlanBriefDto>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetExercisingPlansOfOwnerAsync([FromQuery] int id)
        {
            bool userExists = await _userService.UserExistsAsync(id);

            if (!userExists)
            {
                return BadRequest();
            }

            var plans = await _planService.GetExercisingPlansOfOwnerAsync(id);

            if (plans.Count == 0)
            {
                return NoContent();
            }

            var plansMap = _mapper.Map<ICollection<ExercisingPlanBriefDto>>(plans);

            return Ok(plansMap);
        }

        [HttpGet]
        [Route("getAvailableExercisingPlans")]
        [ProducesResponseType(200, Type = typeof(ICollection<ExercisingPlanBriefDto>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAvailableExercisingPlansAsync([FromQuery] int userId)
        {
            bool userExists = await _userService.UserExistsAsync(userId);

            if (!userExists)
            {
                return BadRequest();
            }

            var availablePlans = await _planService.GetAvailableExercisingPlansAsync(userId);

            if (availablePlans.Count == 0)
            {
                return NoContent();
            }

            var availablePlansMap = _mapper.Map<ICollection<ExercisingPlanBriefDto>>(availablePlans);

            return Ok(availablePlansMap);
        }

        [HttpPost]
        [Route("makePlanAvailableForUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> MakeExercisingPlanAvailableForUserAsync([FromQuery] int planId, [FromBody] int userId)
        {
            bool planExists = await _planService.ExercisingPlanExistsAsync(planId);
            bool userExists = await _userService.UserExistsAsync(userId);

            if (!planExists || !userExists)
            {
                ModelState.AddModelError("BodyError", "There's no user/plan with such 'id'");
                return BadRequest(ModelState);
            }

            var availablePlans = await _planService.GetAvailableExercisingPlansAsync(userId);
            var isAlreadyAvailable = availablePlans.Any(ep => ep.Id == planId);

            if (isAlreadyAvailable)
            {
                ModelState.AddModelError("BodyError", "The plan is already available");
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserByIdAsync(userId);
            var plan = await _planService.GetExercisingPlanByIdAsync(planId);

            var userPlan = new UserExercisingPlan
            {
                User = user,
                ExercisingPlan = plan
            };

            bool isSaved = await _planService.MakeExercisingPlanAvailableForUserAsync(userPlan);

            if (!isSaved)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during saving the entity");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPost]
        [Route("deleteAccessToExercisingPlan")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteAccessToExercisingPlanAsync([FromQuery] int planId, [FromBody] int userId)
        {
            bool planExists = await _planService.ExercisingPlanExistsAsync(planId);
            bool userExists = await _userService.UserExistsAsync(userId);

            if (!planExists || !userExists)
            {
                ModelState.AddModelError("BodyError", "There's no user/plan with such 'id'");
                return BadRequest(ModelState);
            }

            var availablePlans = await _planService.GetAvailableExercisingPlansAsync(userId);
            var isAvailable = availablePlans.Any(ep => ep.Id == planId);

            if (!isAvailable)
            {
                ModelState.AddModelError("BodyError", "The plan haven't been available");
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserByIdAsync(userId);
            var plan = await _planService.GetExercisingPlanByIdAsync(planId);

            var userPlan = new UserExercisingPlan
            {
                User = user,
                ExercisingPlan = plan
            };

            bool isDeleted = await _planService.DeleteAccessToExercisingPlanAsync(userPlan);

            if (!isDeleted)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during deleting the entity");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
