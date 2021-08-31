using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class FeedListModel
    {

        public int PostId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string PostDescription { get; set; }
        public string? ImageUrl { get; set; }
        public int NumberOfReactions { get; set; }

    }
}
