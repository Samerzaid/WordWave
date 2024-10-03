using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Entities;
using WordWave.Infrastructure.DataAccess;
using WordWave.Infrastructure.Interfaces;

namespace WordWave.Infrastructure.Repositories
{
    public class TagRepository(BlogDbContext context) : ITagRepository
    {
        public Task<Tag> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> GetByNameAsync(string name)
        {
            return await context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        }
        public Task<IEnumerable<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Tag entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
