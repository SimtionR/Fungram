using Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PostDetailModel : FeedListModel

    {
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public int NumberOfReactions { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
