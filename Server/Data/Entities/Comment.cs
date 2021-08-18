using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentBody { get; set; }
     
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public  virtual Profile Profile { get; set; }
 
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }


    }
}
