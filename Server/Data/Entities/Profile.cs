using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities
{
    public class Profile
    {

        public int ProfileId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        /*  public ICollection<Follower> FollowersList { get; set; }
          public ICollection<Follower> FollowingList { get; set; }*/
        [Required]
        [MaxLength(1500)]
        public string About { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
    }
}
