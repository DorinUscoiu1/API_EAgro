using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.DTOs;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Authorization;
using API.Models;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager userManager;
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            userManager = new UserManager();
            this._configuration = configuration;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(userManager.GetAllUsers());
        }
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = userManager.GetUser(id);
            if (user != null)
                return Ok(user);
            return NotFound($"User with id " + id + " was not found.");
        }
        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            try
            {
                userManager.AddUser(user);
                return Created();
            }
            catch
            {
                return BadRequest($"An error occured. The user was not added.");
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            try
            {
                userManager.UpdateUser(user);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest($"The request is not valid.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                userManager.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest($"The request is not valid.");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = userManager.Login(loginDto);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token,
                userId = user.Id,
                role = user.Role
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            try
            {
                var user = userManager.Register(userDto);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "An internal server occured");
            }
        }

        private string GenerateJwtToken(UserDto user)
        {
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(48),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
