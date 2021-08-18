using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InTouch.Data.Services
{
    public class ProfileService : IProfileService
    {
        private readonly  FungramContext _ctx;

        public ProfileService(FungramContext ctx)
        {
            _ctx = ctx;
            
        }

        public void AddProfile(Profile profile)
        {
            _ctx.Add(profile);
            _ctx.SaveChanges();
        }

        public async Task<int> Create(string profilePicutre, string about, string userId)
        {
            var profile = new Profile
            {
                About = about,
                ProfilePicture = profilePicutre,
                UserId = userId

            };

            _ctx.Add(profile);

            await _ctx.SaveChangesAsync();


            return profile.ProfileId;
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return _ctx.Profiles
                        .ToList();
        }

        public Profile GetProfileById(int profileId)
        {
            return _ctx.Profiles
                         .Where(p => p.ProfileId == profileId)
                         .FirstOrDefault();
        }

        public Profile GetProfileByUser(string userId)
        {
            return _ctx.Profiles.
                Include(p => p.User)
                .Where(p => p.User.Id == userId)
                .FirstOrDefault();
        }

      
        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
