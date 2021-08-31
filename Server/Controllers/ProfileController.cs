using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.IServices;
using Server.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Server.Extensions.DRY_Functions;

namespace Server.Controllers
{
    [Authorize]
    public class ProfileController : ApiController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]

        public async Task<ActionResult> Create(ProfileModel model)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

           var id= await _profileService.Create(model.ProfilePicture, model.About, userId, model.FirsName, model.LastName);

            return Created(nameof(this.Create), id);
        }

        [HttpGet]
        public async Task<ActionResult<ProfileModel>> Get()
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);

            if (profile == null)
            {
                return BadRequest();
            }

            return profile;
        }
    }
}
