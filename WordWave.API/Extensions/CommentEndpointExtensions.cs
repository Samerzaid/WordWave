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

            group.MapPost("/", AddComment);
            group.MapGet("/", GetAllComments);
            group.MapGet("/id/{id}", GetCommentById);
            group.MapPut("/id/{id}", UpdateComment);
            group.MapDelete("/id/{id}", DeleteComment);
            group.MapGet("/{commentId}/blogposts", GetBlogPostsByCommentId);

            return app;
        }

        private static async Task<IResult> AddComment([FromServices] ICommentRepository repository, [FromBody] Comment comment)
        {
            await repository.AddAsync(comment);
            return Results.Created($"/api/Comment/{comment.Id}", comment);
        }

        private static async Task<IResult> GetAllComments([FromServices] ICommentRepository repository)
        {
            var comments = await repository.GetAllAsync();
            return Results.Ok(comments);
        }

        private static async Task<IResult> GetCommentById([FromServices] ICommentRepository repository, [FromRoute] int id)
        {
            var comment = await repository.GetByIdAsync(id);
            return comment is not null ? Results.Ok(comment) : Results.NotFound();
        }

        private static async Task<IResult> UpdateComment([FromServices] ICommentRepository repository, [FromRoute] int id, [FromBody] Comment comment)
        {
            var existingComment = await repository.GetByIdAsync(id);
            if (existingComment is null) return Results.NotFound();

            existingComment.Content = comment.Content;
            existingComment.Author = comment.Author;

            await repository.UpdateAsync(existingComment);
            return Results.NoContent();
        }

        private static async Task<IResult> DeleteComment([FromServices] ICommentRepository repository, [FromRoute] int id)
        {
            await repository.DeleteAsync(id);
            return Results.NoContent();
        }

        private static async Task<IResult> GetBlogPostsByCommentId([FromServices] ICommentRepository repository, [FromRoute] int commentId)
        {
            var blogPosts = await repository.GetBlogPostsByCommentIdAsync(commentId);
            return Results.Ok(blogPosts);
        }


    }
}

