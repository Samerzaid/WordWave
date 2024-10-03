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
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _context.BlogPosts
                .Include(b => b.Comments)
                .Include(b => b.BlogPostTags)
                    .ThenInclude(bpt => bpt.Tag)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BlogPost> GetBlogByTitleAsync(string title)
        {
            var blogTitle = await _context.BlogPosts
                .Include(b => b.Comments)
                .Include(b => b.BlogPostTags)
                    .ThenInclude(bpt => bpt.Tag)
                .FirstOrDefaultAsync(x => x.Title.ToLower().Equals(title.ToLower()));

            if (blogTitle is null)
            {
                return null;
            }

            return blogTitle;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts
                .Include(b => b.Comments)
                .Include(b => b.BlogPostTags)
                    .ThenInclude(bpt => bpt.Tag)
                .ToListAsync();
        }

        public async Task AddAsync(BlogPost entity)
        {
            if (entity.Comments != null)
            {
                foreach (var comment in entity.Comments)
                {
                    _context.Entry(comment).State = EntityState.Added;
                }
            }

            if (entity.BlogPostTags != null)
            {
                foreach (var blogPostTag in entity.BlogPostTags)
                {
                    _context.Entry(blogPostTag).State = EntityState.Added;
                }
            }

            await _context.BlogPosts.AddAsync(entity);
        }

        public async Task UpdateAsync(BlogPost entity)
        {
            var updateBlog = await _context.BlogPosts
                .Include(b => b.Comments)
                .Include(b => b.BlogPostTags)
                .FirstOrDefaultAsync(b => b.Id == entity.Id);

            if (updateBlog is null)
            {
                return;
            }

            updateBlog.Title = entity.Title;
            updateBlog.Content = entity.Content;
            updateBlog.DateCreated = entity.DateCreated;
            updateBlog.Author = entity.Author;

            if (entity.Comments != null)
            {
                foreach (var comment in entity.Comments)
                {
                    _context.Entry(comment).State = comment.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            if (entity.BlogPostTags != null)
            {
                foreach (var blogPostTag in entity.BlogPostTags)
                {
                    _context.Entry(blogPostTag).State = blogPostTag.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
            }

            _context.BlogPosts.Update(updateBlog);
        }

        public async Task DeleteAsync(int id)
        {
            var blogToDelete = await GetByIdAsync(id);
            _context.BlogPosts.Remove(blogToDelete);
        }
    }
}
