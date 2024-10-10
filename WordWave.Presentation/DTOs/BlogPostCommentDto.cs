using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWave.Presentation.DTOs
{
 public class BlogPostCommentDto
 {
        public int BlogPostId { get; set; }
        public int CommentId { get; set; }
        public DateTime DateCreated { get; set; }
 }
}
