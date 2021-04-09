using Lec2021.Models;
using Lec2021.Models.Input;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lec2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class AccountController : ControllerBase
    {
        private readonly TestDbConxextcs _context;
        private readonly SignInManager<UserTest> _signInManager;
        private readonly UserManager<UserTest> _userManager;
        public AccountController(TestDbConxextcs context, UserManager<UserTest> userManager, SignInManager<UserTest> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        [HttpPost]
        public async Task<IActionResult> Register(UserTestInput model)
        {
            UserTest user = new UserTest() { Email = model.Email, UserName = model.UserName };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, model.Password);
            
            return new JsonResult(result);
        }

       [HttpPost("/token")]
        public async Task<IActionResult> Token(string username, string password)
        {
            var identity = await GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        notBefore: now,
        claims: identity.Claims,
        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return new JsonResult(response);
        }
        private async  Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            UserTest user = _context.Users.FirstOrDefault(i => i.UserName == username);
            // добавляем пользователя
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (user != null && result)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            // если пользователя не найдено
            return null;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("getlogin")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }
        [Route("getlogin2")]
        [HttpGet]
        public IActionResult GetLogin2()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }
    }
}
