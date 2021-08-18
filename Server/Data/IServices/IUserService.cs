using Server.Data.Entities;
using System.Collections.Generic;
namespace Server.Data.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAllusers();
        User GetUserById(string userId);
      //  User GetUserByProfile(int profileId);
        void addUser(User user);
        bool SaveChanges();
    }
}
