using AutoMapper;
using LabFashion.DTOs;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabFashion.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Return a list of users
        /// </summary>
        /// <returns>Returns a list of users successfully</returns>
        /// <response code=200>Returns a list of users successfully</response>
        [HttpGet("usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(usersDTO);
        }

        /// <summary>
        /// Return a specific user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a specific user successfully</returns>
        /// <response code=200>Return a specific user successfully</response>
        /// <response code=404>User not found</response>
        [HttpGet("usuarios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
    }
}
