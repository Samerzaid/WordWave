using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Presentation.DTOs
{
    public class TagDto : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BlogPostDto> BlogPostDtos { get; set; }
        public ICollection<BlogPostTagDto> BlogPostTagDtos { get; set; }
    }
}
