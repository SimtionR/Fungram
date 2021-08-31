using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class CommentModel
    {
        [Required]
        public string CommentBody { get; set; }
    }
}
