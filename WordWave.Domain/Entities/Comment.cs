using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Domain.Entities
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; }
        public ICollection<BlogPostComment> BlogPostComments { get; set; } = new List<BlogPostComment>();

    }
}
