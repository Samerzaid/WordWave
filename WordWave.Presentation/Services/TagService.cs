using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Entities;
using WordWave.Presentation.DTOs;
using WordWave.Presentation.Interfaces;

namespace WordWave.Presentation.Services
{
    public class TagService : ITagService
    {
        public Task<TagDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TagDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TagDto entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TagDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
