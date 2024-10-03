using Microsoft.AspNetCore.Mvc;
using WordWave.Domain.Entities;
using WordWave.Infrastructure.Interfaces;

namespace WordWave.API.Extensions
{
    public static class CommentEndpointExtensions
    {
        public static IEndpointRouteBuilder CommentEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/Comment");

            group.MapPost("/blogPostId/{blogPostId}", AddComment);
            group.MapDelete("/CommentId/{commentId}", DeleteComment);

            return app;
        }

        private static async Task<IResult> AddComment(IUnitOfWork unit, int blogPostId, [FromBody] Comment comment)
        {
            var blogPost = await unit.BlogRepository.GetByIdAsync(blogPostId);
            if (blogPost == null)
            {
                return Results.NotFound("Blog post not found");
            }

            comment.BlogPostId = blogPostId;
            await unit.CommentRepository.AddAsync(comment);
            await unit.CompleteAsync();

            return Results.Ok(comment);
        }

        private static async Task<IResult> DeleteComment(IUnitOfWork unit, int commentId)
        {
            var comment = await unit.CommentRepository.GetByIdAsync(commentId);
            if (comment == null)
            {
                return Results.NotFound("Comment not found");
            }

            await unit.CommentRepository.DeleteAsync(commentId);
            await unit.CompleteAsync();

            return Results.Ok();
        }
    }
}
