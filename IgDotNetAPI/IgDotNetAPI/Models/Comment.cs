using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.Models
{
    public class Comment
    {
        [Key]
        public string CommentId { get; set; }
        public string PostId { get; set; }
        public Person User { get; set; }
        public string Message { get; set; }
    }
}
