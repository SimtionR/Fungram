using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Models;
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

        public async Task<int> Create(string profilePicutre, string about, string userId, string firstName, string lastName)
        {
            var profile = new Profile
            {
                FirsName=firstName,
                LastName=lastName,
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

        public async Task<ProfileModel> GetProfileByUser(string userId)
        {
            return await _ctx.Profiles.
                Include(p => p.User)
                .Where(p => p.User.Id == userId)
                .Select( p=> new ProfileModel
                {
                    ProfileId=p.ProfileId,
                    ProfilePicture=p.ProfilePicture,
                    About=p.About,
                    FirsName=p.FirsName,
                    LastName=p.LastName
                })
                .FirstOrDefaultAsync();
        }

      
        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
