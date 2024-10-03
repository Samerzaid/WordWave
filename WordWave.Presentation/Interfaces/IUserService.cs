using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Presentation.DTOs;

namespace WordWave.Presentation.Interfaces
{
    public interface IUserService : IService<UserDto, string>
    {
        Task<UserDto> GetByEmailAsync(string email);
    }
}
