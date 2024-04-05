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
        private const string USER_NOT_EXISTED_ERROR_MESSAGE = "User with such id doesn't exist";
        private const string ZERO_ID_ERROR_MESSAGE = "Id can't be less than 1";

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
        [Route("getUserSubscribers")]
        [ProducesResponseType(200, Type = typeof(ICollection<UserDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserSubscribersAsync([FromQuery] int id)
        {
            bool isUserExisted = await _service.IsUserExistedAsync(id);

            if (!isUserExisted)
            {
                ModelState.AddModelError("BodyError", USER_NOT_EXISTED_ERROR_MESSAGE);
                return BadRequest(ModelState);
            }

            var subscribers = await _service.GetUserSubscribersAsync(id);

            if (subscribers.Count == 0)
            {
                return NoContent();
            }

            var subscribersMap = _mapper.Map<ICollection<UserDto>>(subscribers);

            return Ok(subscribersMap);
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
                ModelState.AddModelError("BodyError", USER_NOT_EXISTED_ERROR_MESSAGE);
                return BadRequest(ModelState);
            }

            var userPupils = await _service.GetUserPupilsAsync(id);

            if (userPupils.Count == 0)
            {
                return NoContent();
            }

            var userPupilsMap = _mapper.Map<ICollection<UserDto>>(userPupils);

            return Ok(userPupilsMap);
        }

        [HttpPost]
        [Route("createUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
        {
            if (userDto.Id > 0)
            {
                ModelState.AddModelError("BodyError", "You can't specify 'id' manually. Id must be 0");
                return StatusCode(400, ModelState);
            }

            var user = _mapper.Map<User>(userDto);

            var isSaved = await _service.CreateUserAsync(user);

            if (!isSaved)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during saving the user");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut]
        [Route("updateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto userDto)
        {
            if (userDto.Id < 1)
            {
                ModelState.AddModelError("BodyError", ZERO_ID_ERROR_MESSAGE);
                return BadRequest(ModelState);
            }

            bool isUserExisted = await _service.IsUserExistedAsync(userDto.Id);

            if (!isUserExisted)
            {
                ModelState.AddModelError("BodyError", USER_NOT_EXISTED_ERROR_MESSAGE);
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(userDto);

            var isUpdated = await _service.UpdateUserAsync(user);

            if (!isUpdated)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during updating the user");
                return StatusCode(500);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteUserById")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUserByIdAsync([FromBody] int id)
        {
            if (id < 1)
            {
                ModelState.AddModelError("BodyError", ZERO_ID_ERROR_MESSAGE);
                return BadRequest(ModelState);
            }

            bool isUserExisted = await _service.IsUserExistedAsync(id);

            if (!isUserExisted)
            {
                ModelState.AddModelError("Body error", USER_NOT_EXISTED_ERROR_MESSAGE);
                return BadRequest(ModelState);
            }

            var user = await _service.GetUserByIdAsync(id);

            bool isDeleted = await _service.DeleteUserAsync(user);

            if (!isDeleted)
            {
                ModelState.AddModelError("SqlError", "Something went wrong during deleting the user");
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}
