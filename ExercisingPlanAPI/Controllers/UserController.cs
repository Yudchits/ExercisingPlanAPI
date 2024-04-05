using AutoMapper;
using ExercisingPlanAPI.DTOs;
using ExercisingPlanAPI.Models;
using ExercisingPlanAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllUsers")]
        [ProducesResponseType(200, Type = typeof(ICollection<UserDto>))]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = await _service.GetAllUsersAsync();

            if (allUsers.Count == 0)
            {
                return NoContent();
            }

            var allUsersMap = _mapper.Map<ICollection<UserDto>>(allUsers);

            return Ok(allUsersMap);
        }

        [HttpGet]
        [Route("getUserById")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] int id)
        {
            bool isUserExisted = await _service.IsUserExistedAsync(id);

            if (!isUserExisted)
            {
                return BadRequest();
            }

            var user = await _service.GetUserByIdAsync(id);

            if (user == null)
            {
                ModelState.AddModelError("SqlError", "Internal Error While Getting User From Database");
                return StatusCode(500, ModelState);
            }

            var userMap = _mapper.Map<UserDto>(user);

            return Ok(userMap);
        }

        [HttpGet]
        [Route("getUserByLastName")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserByLastName([FromQuery] string lastName)
        {
            var user = await _service.GetUserByLastNameAsync(lastName);

            if (user == null)
            {
                return BadRequest();
            }

            var userMap = _mapper.Map<UserDto>(user);

            return Ok(userMap);
        }

        [HttpGet]
        [Route("getCoachPupils")]
        [ProducesResponseType(200, Type = typeof(ICollection<UserDto>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCoachPupilsAsync([FromQuery] int id)
        {
            var isUserExisted = await _service.IsUserExistedAsync(id);

            if (!isUserExisted)
            {
                return BadRequest();
            }

            var userPupils = await _service.GetUserPupilsAsync(id);

            if (userPupils.Count == 0)
            {
                return NoContent();
            }

            var userPupilsMap = _mapper.Map<ICollection<UserDto>>(userPupils);

            return Ok(userPupilsMap);
        }

    }
}
