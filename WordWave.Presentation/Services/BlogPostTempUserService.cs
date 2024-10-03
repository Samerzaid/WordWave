using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Presentation.Interfaces;

namespace WordWave.Presentation.Services
{
    public class BlogPostTempUserService : IBlogPostTempUserService
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
