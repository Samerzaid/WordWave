using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWave.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository BlogRepository { get; }
        ICommentRepository CommentRepository { get; }
        ITagRepository TagRepository { get; }
        Task CompleteAsync();
    }
}
