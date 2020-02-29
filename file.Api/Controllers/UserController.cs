using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using file.Api.Extensions;
using file.Api.Resources;
using file.Core.Models;
using file.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace file.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            var usersResult = _mapper.Map<IEnumerable<User>,IEnumerable<UserResource>>(users);
            return Ok(usersResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetUserWithFilesById(int id)
        {
            var user = await _userService.GetUserWithFilesById(id);
            var usersResult = _mapper.Map<User, UserResource>(user);
            return Ok(usersResult);
        }

        [HttpPost]
        public async Task<ActionResult<UserResource>> CreateUser([FromForm] SaveUserResource userResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(userResource);
            var newUser = await _userService.CreateUser(user);
            var createdUser = await _userService.GetUserById(newUser.id);
            var userResult = _mapper.Map<User, UserResource>(createdUser);
            return Ok(userResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResource>> UpdateUser(int id, [FromForm] UserResource userResource)
        {
            // Verifying if model is valid
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            // Get actual User by ID
            var userToUpdate = await _userService.GetUserById(id);
            if(userToUpdate == null)
                return NotFound();
            
            // Mapping user resource to user entity
            var user = _mapper.Map<UserResource, User>(userResource);

            // Update user with params from body
            await _userService.UpdateUser(userToUpdate, user);

            var updatedUser = await _userService.GetUserById(id);
            var userResult = _mapper.Map<User, UserResource>(updatedUser);
            return Ok(userResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (id == 0)
                return BadRequest();
            
            var user = await _userService.GetUserById(id);

            if(user == null)
                return NotFound();
            
            await _userService.DeleteUser(user);
            return NoContent();
        }
    }
}