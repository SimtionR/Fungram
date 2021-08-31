using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ProfileModel
    {
        public int ProfileId { get; set; }
        //[Required]
        public string FirsName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        [MaxLength(1500)]
        public string About { get; set; }
        //[Required]
        public string ProfilePicture { get; set; }
    }
}
