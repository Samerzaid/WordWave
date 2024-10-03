using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Domain.Entities
{
    public class BlogPostTag : IEntity<int>
    {
        public int Id { get; set; }
        public BlogPost BlogPost { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
