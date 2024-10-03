using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Domain.Entities
{
    public class Tag : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<BlogPostTag> BlogPostTags { get; set; }
    }
}
