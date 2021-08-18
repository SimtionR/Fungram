using InTouch.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(ProfileModel model)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

           var id= await _profileService.Create(model.ProfilePicture, model.About, userId);

            return Created(nameof(this.Create), id);
        }
    }
}
