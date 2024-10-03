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
    public class CommentRepository(BlogDbContext context) : ICommentRepository
    {
        public async Task<Comment> GetByIdAsync(int id)
        {
            return await context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task AddAsync(Comment entity)
        {
            await context.Comments.AddAsync(entity);
        }

        public async Task UpdateAsync(Comment entity)
        {
            context.Comments.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await GetByIdAsync(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
            }
        }
    }
}
