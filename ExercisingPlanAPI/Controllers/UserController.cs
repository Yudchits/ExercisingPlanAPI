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
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = await _service.GetAllUsersAsync();

            var allUsersMap = _mapper.Map<ICollection<UserDto>>(allUsers);

            return Ok(allUsersMap);
        }
    }
}
