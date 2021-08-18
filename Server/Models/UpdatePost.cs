using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class UpdatePost
    {
        public int PostId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
