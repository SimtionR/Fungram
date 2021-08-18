﻿using Server.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Data.IServices
{
    public interface IProfileService
    {

        IEnumerable<Profile> GetAllProfiles();
        Profile GetProfileById(int profileId);
        Profile GetProfileByUser(string userId);
        void AddProfile(Profile profile);
        public Task<int> Create(string profilePicutre, string about, string userId);
        
        bool SaveChanges();
   

    }
}