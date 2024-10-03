using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Presentation.DTOs
{
    public class UserDto : IEntity<string>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; } //TODO: TEMPORARY


        public string Address { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public virtual List<int>? BlogPostsIds { get; set; }

        //public string Role { get; set; }
    }
}
