using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;
using System.Security.Claims;
using TaskApi.Services;

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
        [Authorize]
        [Authorize(Roles = "Senior Engineer")]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            List<UserModel> users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("test")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {ClaimTypes.NameIdentifier}";

        [HttpGet("user/{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetUser(Guid id)
        {
            UserModel user = await _userRepository.GetUserById(id);

            return Ok(user);
        }

        [HttpPost("newUser")]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel user)
        {
            user.Password = PasswordHash.PasswordHashed(user.Password);

            UserModel newUser = await _userRepository.CreateUser(user);

            return Ok(newUser);
        }

        [HttpPost("auth")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginModel userLogin)
        {
            var user = await _userRepository.GetUserByEmail(userLogin.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Usuário não encontado" });
            }

            bool isPasswordValid = PasswordHash.VerifyPassword(userLogin.Password, user.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Usuário ou senha inválido");
            }

            var token = TokenJWT.GenerateToken(user);

            return new { token = token };
        }


        [HttpPut("user/{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, Guid id)
        {
            user.Id = id;

            UserModel changedUser = await _userRepository.UpdateUser(user, id);
            return Ok(changedUser);
        }

        [HttpDelete("user/{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> DeleteUser(Guid id)
        {
            Boolean deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
