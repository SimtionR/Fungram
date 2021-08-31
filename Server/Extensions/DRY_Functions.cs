using Server.Data.Entities;
using Server.Data.IServices;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Extensions
{
    public static class DRY_Functions
    {

        public static  async Task<ProfileModel> GetPorifleUser (IEnumerable<Claim> Claims, IProfileService profileService )
        {
            var userId =Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var profile = await profileService.GetProfileByUser(userId);

            if (profile != null)
            {
                return profile;
            }


            else return null;
            
        }

        
    }
}
