using Server.Data;
using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Linq;

namespace InTouch.Data.Services
{
    public class UserService : IUserService
    {
        private readonly FungramContext _ctx;

        public UserService(FungramContext ctx)
        {
            _ctx = ctx;
        }
        public void addUser(User user)
        {
            _ctx.Add(user);
            _ctx.SaveChanges();
        }

        public IEnumerable<User> GetAllusers()
        {
            return _ctx.Users.
                        ToList();
        }

        public User GetUserById(string userId)
        {
            return _ctx.Users.
                        Where(u => u.Id == userId).
                        FirstOrDefault();
        }

       /* public User GetUserByProfile(int profileId)
        {
            return _ctx.Users.
                        Where(u => u.ProfileId == profileId).
                        FirstOrDefault();
        }   */

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;  
        }
    }
}
