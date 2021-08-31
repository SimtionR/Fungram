using Server.Data.Entities;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Data.IServices
{
    public interface IProfileService
    {

        IEnumerable<Profile> GetAllProfiles();
        Profile GetProfileById(int profileId);
        Task<ProfileModel> GetProfileByUser(string userId);
        void AddProfile(Profile profile);
        public Task<int> Create(string profilePicutre, string about, string userId, string firstName, string lastName);
        
        bool SaveChanges();
   

    }
}
