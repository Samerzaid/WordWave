using Microsoft.AspNetCore.Mvc;
using WordWave.Domain.Entities;
using WordWave.Infrastructure.Interfaces;

namespace WordWave.API.Extensions
{
    public static class BlogEndpointExtensions
    {
        public static IEndpointRouteBuilder BlogEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/Blog");

            group.MapPost("/", AddBlog);
            group.MapGet("/", GetAllBlogs);
            group.MapGet("/id/{id}", GetBlogById);
            group.MapGet("/title/{title}", GetBlogByTitle);
            group.MapGet("/tag/{tag}", GetBlogByTag);
            group.MapPut("/id/{id}", UpdateBlog);
            group.MapDelete("/id/{id}", DeleteBlog);
            group.MapPost("/{blogPostId}/comments", AddCommentToBlogPost);
            group.MapGet("/{blogPostId}/comments", GetCommentsByBlogPostId);

            return app;
        }

        private static async Task<IResult> AddBlog([FromServices] IBlogRepository repository, [FromBody] BlogPost blog)
        {
            await repository.AddAsync(blog);
            return Results.Created($"/api/Blog/{blog.Id}", blog);
        }

        private static async Task<IResult> GetAllBlogs([FromServices] IBlogRepository repository)
        {
            var blogs = await repository.GetAllAsync();
            return Results.Ok(blogs);
        }

        private static async Task<IResult> GetBlogById([FromServices] IBlogRepository repository, [FromRoute] int id)
        {
            var blog = await repository.GetByIdAsync(id);
            return blog is not null ? Results.Ok(blog) : Results.NotFound();
        }

        private static async Task<IResult> GetBlogByTitle([FromServices] IBlogRepository repository, [FromRoute] string title)
        {
            var blog = await repository.GetBlogByTitleAsync(title);
            return blog is not null ? Results.Ok(blog) : Results.NotFound();
        }

        private static async Task<IResult> GetBlogByTag([FromServices] IBlogRepository repository, [FromRoute] string tag)
        {
            var blog = await repository.GetBlogByTagAsync(tag);
            return blog is not null ? Results.Ok(blog) : Results.NotFound();
        }

        private static async Task<IResult> UpdateBlog([FromServices] IBlogRepository repository, [FromRoute] int id, [FromBody] BlogPost blog)
        {
            var existingBlog = await repository.GetByIdAsync(id);
            if (existingBlog is null) return Results.NotFound();

            existingBlog.Title = blog.Title;
            existingBlog.Content = blog.Content;
            existingBlog.Author = blog.Author;

            await repository.UpdateAsync(existingBlog);
            return Results.NoContent();
        }

        private static async Task<IResult> DeleteBlog([FromServices] IBlogRepository repository, [FromRoute] int id)
        {
            await repository.DeleteAsync(id);
            return Results.NoContent();
        }

        private static async Task<IResult> AddCommentToBlogPost(
            [FromServices] IBlogRepository blogRepository,
            [FromServices] ICommentRepository commentRepository,
            [FromRoute] int blogPostId,
            [FromBody] Comment comment)
        {
            await blogRepository.AddCommentToBlogPostAsync(blogPostId, comment);
            return Results.Created($"/api/Blog/{blogPostId}/comments/{comment.Id}", comment);
        }

        private static async Task<IResult> GetCommentsByBlogPostId(
            [FromServices] IBlogRepository repository,
            [FromRoute] int blogPostId)
        {
            var comments = await repository.GetCommentsByBlogPostIdAsync(blogPostId);
            return Results.Ok(comments);
        }
    }
}

