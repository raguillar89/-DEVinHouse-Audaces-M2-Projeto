using AutoMapper;
using LabFashion.DTOs;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabFashion.Controllers
{
    [Route("api/v{version:apiVersion}/")]
    [ApiController]
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

        /// <summary>
        /// Create an user
        /// </summary>
        /// <returns>Create an user successfully</returns>
        /// <response code=201>Create an user successfully</response>
        /// <response code=400>Bad Request</response>
        [HttpPost("createUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostUser([FromBody] UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _userRepository.CreateUser(user);
            if (await _userRepository.SaveAllAsync())
            {
                return Ok("User created successfully.");
            }
            return BadRequest();
        }

        /// <summary>
        /// Update a specific user
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns>Update a specific user successfully</returns>
        /// <response code=200>Update a specific user successfully</response>
        /// <response code=400>Bad Request</response>
        /// <response code=404>User Not Found</response>
        [HttpPut("{IdUser}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutTheater([FromRoute] int IdUser, [FromBody] UserDTO userDTO)
        {
            if (userDTO.IdUser == 0)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userDTO);
            _userRepository.UpdateUser(user);
            if (userDTO.IdUser == null)
            {
                return NotFound("User not found.");
            }

            if (await _userRepository.SaveAllAsync())
            {
                return Ok("Update user successfully.");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a specific theater
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete a specific theater successfully</returns>
        /// <response code=200>Delete a specific theater successfully</response>
        /// <response code=404>Theater not found</response>
        [HttpDelete("deleteUser/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTheater(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound("Filme não encontrado");
            }

            _userRepository.DeleteUser(user);
            if (await _userRepository.SaveAllAsync())
            {
                return Ok("User delete successfully.");
            }
            return BadRequest();
        }
    }
}
