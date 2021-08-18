using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.IServices
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
