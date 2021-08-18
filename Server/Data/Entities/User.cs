using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities
{
    public class User : IdentityUser
    {

     
        public string FirsName { get; set; }
        public string LastName { get; set; }

        public int ProfileId { get; set; }
       
        public virtual Profile Profile { get; set; }


    }
}
