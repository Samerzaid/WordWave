using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WordWave.Domain.Interfaces;

namespace WordWave.Domain.Entities
{
    public class BlogPost : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }

        public ICollection<Comment> Comments { get; set; }
      
        public ICollection<BlogPostComment> BlogPostComments { get; set; } = new List<BlogPostComment>();

    }
}
