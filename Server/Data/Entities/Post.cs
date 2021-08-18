using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostDescription { get; set; }
        public string? ImageUrl { get; set; }
        
        public int ProfileId { get; set; }
        //[ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        public int NumberOfReactions { get; set; }
        public  virtual ICollection<Reaction> Reactions { get; set; }
        public  virtual ICollection<Comment> Comments { get; set; }


    }
}
