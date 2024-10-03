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
        Task<BlogPost> GetBlogByTitleAsync(string title);

    }
}
