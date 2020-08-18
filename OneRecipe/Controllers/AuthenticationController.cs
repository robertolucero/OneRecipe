using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneRecipe.Application.DTOs;
using OneRecipe.Application.Interfaces;
using OneRecipe.Helpers;
using OneRecipe.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace OneRecipe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService service;
        private readonly AppSettings settings;
        public AuthenticationController(IUserService service, IOptions<AppSettings> appSetting)
        {
            this.service = service;
            this.settings = appSetting.Value;
        }
        /// <summary>
        /// Authenticate an user
        /// </summary>
        /// <param name="user">UserDto</param>
        /// <returns>Returns a token for a valid user.</returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([System.Web.Http.FromBody] UserDto user)
        {
            var userDto = this.service.Authenticate(user.Email, user.Password);

            if (userDto == null)
            {
                return Unauthorized("Invalid user.");
            }

            var token = BuildToken(userDto);

            var response = new AuthenticationResponse
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Token = token,
                TokenExpirationDate = DateTime.Now.AddMinutes(25)
            };

            return Ok(response);
        }

        private string BuildToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userDto.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = settings.Issuer,
                Audience = settings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
