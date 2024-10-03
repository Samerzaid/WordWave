using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Presentation.DTOs
{
    public class BlogPostTagDto : IEntity<int>
    {
        public int Id { get; set; }
        public BlogPostDto BlogPostDtos { get; set; }
        public int TagId { get; set; }
        public TagDto TagDtos { get; set; }
    }
}
