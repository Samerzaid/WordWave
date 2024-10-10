using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Presentation.DTOs;

namespace WordWave.Presentation.Interfaces
{
    public interface IBlogService : IService<BlogPostDto, int>
    {
        Task AddCommentToBlogPostAsync(int blogPostId, CommentDto comment);
        Task<IEnumerable<CommentDto>> GetCommentsByBlogPostIdAsync(int blogPostId);

    }
}

