using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.Models
{
    [Table("posts")]
    public class Post
    {
        [Key]
        public string PostId { get; set; }
        public Person User { get; set; }
        public string Description { get; set; }
        public string MediaURL { get; set; }
        public IEnumerable<Like> Likes { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
