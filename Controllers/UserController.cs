using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Controllers
{
    [Route("api")] //route to access the controller 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            List<UserModel> users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserModel>> GetUser(Guid id)
        {
            UserModel user = await _userRepository.GetUserById(id);

            return Ok(user);
        }

        [HttpPost("newUser")]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel user)
        {
            UserModel newUser = await _userRepository.CreateUser(user);

            return Ok(newUser);
        }

        [HttpPut("user/{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, Guid id)
        {
            user.Id = id;

            UserModel changedUser = await _userRepository.UpdateUser(user, id);
            return Ok(changedUser);
        }

        [HttpDelete("user/{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(Guid id)
        {
            Boolean deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
