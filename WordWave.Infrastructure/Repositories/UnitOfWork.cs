using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Infrastructure.DataAccess;
using WordWave.Infrastructure.Interfaces;

namespace WordWave.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _blogContext;

        public IBlogRepository BlogRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }

        public UnitOfWork(BlogDbContext blogContext)
        {
            _blogContext = blogContext;

            BlogRepository = new BlogRepository(blogContext);
            CommentRepository = new CommentRepository(blogContext);
        }

        public async Task CompleteAsync()
        {
            await _blogContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _blogContext.DisposeAsync();
        }
    }
}
