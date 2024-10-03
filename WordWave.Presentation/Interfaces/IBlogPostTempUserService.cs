using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWave.Presentation.Interfaces
{
    public interface IBlogPostTempUserService
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string City { get; set; }
        string Address { get; set; }
    }
}
