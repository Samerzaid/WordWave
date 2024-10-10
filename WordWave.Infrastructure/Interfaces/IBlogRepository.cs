using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Application.Interfaces;
using WordWave.Domain.Entities;


namespace WordWave.Infrastructure.Interfaces
{
    public interface IBlogRepository : IRepository<BlogPost, int>
    {
        // Retrieve a blog post by title
        Task<BlogPost> GetBlogByTitleAsync(string title);

        Task<BlogPost> GetBlogByTagAsync(string tag);


        // Add a comment to a specific blog post
        Task AddCommentToBlogPostAsync(int blogPostId, Comment comment);

        // Retrieve all comments for a specific blog post
        Task<IEnumerable<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId);
    }
}

