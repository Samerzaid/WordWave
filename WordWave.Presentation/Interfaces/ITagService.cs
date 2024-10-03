using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Entities;
using WordWave.Presentation.DTOs;

namespace WordWave.Presentation.Interfaces
{
    public interface ITagService : IService<TagDto, int>
    {
        Task<Tag> GetByNameAsync(string name);
    }
}
