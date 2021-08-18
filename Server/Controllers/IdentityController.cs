using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IIdentityService _identityService;
        private readonly ApplicationSettings _appSettings;

        public IdentityController(UserManager<User> userManager,
            IOptions<ApplicationSettings> appSettings,
            IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
            _appSettings = appSettings.Value;
        }
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await this._userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);

        }
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginUserModel model)
        {
            var user = await this._userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }


            var encryptedToken = _identityService.GenerateJwtToken(user.Id, user.UserName, _appSettings.Secret);

            return new
            {
                Token = encryptedToken
            };
           
        }
       
    }
}
