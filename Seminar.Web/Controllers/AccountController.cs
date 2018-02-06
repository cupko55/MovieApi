using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seminar.DAL;
using Seminar.Service.DTO;
using Seminar.Web.Helper;

namespace Seminar.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [ApiVersion("1.0")]
    public class AccountController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(MovieDbContext context, IConfiguration configuration, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            
            if (result.Succeeded)
            {                
                JwtSecurityToken token = JwsTokenCreator.CreateToken(model.Email,
                    _configuration["Auth:JwtSecurityKey"],
                    _configuration["Auth:ValidIssuer"],
                    _configuration["Auth:ValidAudience"]);

                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenStr);
            }
            
            return Unauthorized();

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);            

            if (result.Succeeded)
            {
                JwtSecurityToken token = JwsTokenCreator.CreateToken(model.Email,
                    _configuration["Auth:JwtSecurityKey"],
                    _configuration["Auth:ValidIssuer"],
                    _configuration["Auth:ValidAudience"]);

                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
                
                return Ok(tokenStr);
            }            
            return BadRequest("Something went wront");            
        }
    }
}