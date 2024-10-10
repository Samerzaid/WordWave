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

        public async Task AddAsync(BlogPost entity)
        {
            _context.BlogPosts.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts
                .Include(bp => bp.BlogPostComments)
                    .ThenInclude(bc => bc.Comment)
                .ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _context.BlogPosts
                .Include(bp => bp.BlogPostComments)
                    .ThenInclude(bc => bc.Comment)
                .FirstOrDefaultAsync(bp => bp.Id == id);
        }

        public async Task UpdateAsync(BlogPost entity)
        {
            _context.BlogPosts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddCommentToBlogPostAsync(int blogPostId, Comment comment)
        {
            var blogPost = await _context.BlogPosts.FindAsync(blogPostId);
            if (blogPost == null) throw new KeyNotFoundException("Blog post not found.");

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            _context.BlogPostComments.Add(new BlogPostComment
            {
                BlogPostId = blogPostId,
                CommentId = comment.Id
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            return await _context.BlogPostComments
                .Where(bc => bc.BlogPostId == blogPostId)
                .Select(bc => bc.Comment)
                .ToListAsync();
        }

        public async Task<BlogPost> GetBlogByTitleAsync(string title)
        {
            return await _context.BlogPosts
                .Include(bp => bp.BlogPostComments) // Include related comments if needed
                    .ThenInclude(bc => bc.Comment)
                .FirstOrDefaultAsync(bp => bp.Title == title);
        }

        public async Task<BlogPost> GetBlogByTagAsync(string tag)
        {
            return await _context.BlogPosts
                .Include(bp => bp.BlogPostComments) // Include related comments if needed
                    .ThenInclude(bc => bc.Comment)
                .FirstOrDefaultAsync(bp => bp.Tag == tag);
        }
    }
}
