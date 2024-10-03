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
            group.MapPut("/id/{id}", UpdateBlog);
            group.MapDelete("/id/{id}", DeleteBlog);

            return app;
        }

        private static async Task<IResult> DeleteBlog(IUnitOfWork unit, int id)
        {
            var blogs = await unit.BlogRepository.GetByIdAsync(id);

            if (blogs is null)
            {
                Results.NotFound("Post not found");
            }

            await unit.BlogRepository.DeleteAsync(id);
            await unit.CompleteAsync();

            return Results.Ok();
        }

        private static async Task<IResult> UpdateBlog(IUnitOfWork unit, BlogPost entity, int id)
        {
            var blogs = await unit.BlogRepository.GetByIdAsync(id);
            if (blogs is null)
            {
                Results.NotFound("Event not found");
            }

            await unit.BlogRepository.UpdateAsync(entity);

            await unit.CompleteAsync();
            return Results.Ok();
        }

        private static async Task<BlogPost> GetBlogByTitle(IUnitOfWork unit, string title)
        {
            var blogs = await unit.BlogRepository.GetBlogByTitleAsync(title);
            if (blogs is null)
            {
                Results.NotFound("Post not found");
                return null;
            }

            Results.Ok(blogs);
            return blogs;
        }

        private static async Task<BlogPost> GetBlogById(IUnitOfWork unit, int id)
        {
            var blogs = await unit.BlogRepository.GetByIdAsync(id);

            if (blogs is null)
            {
                Results.NotFound("Post not found");
                return null;
            }

            Results.Ok(blogs);
            return blogs;
        }

        private static async Task<IEnumerable<BlogPost>> GetAllBlogs(IUnitOfWork unit)
        {
            var blogs = await unit.BlogRepository.GetAllAsync();

            var allBlogs = blogs.ToList();

            if (allBlogs.Count() == 0)
            {
                Results.NotFound("No posts found");
                return null;
            }

            Results.Ok(allBlogs);
            return allBlogs;
        }

        private static async Task<IResult> AddBlog(IUnitOfWork unit, [FromBody] BlogPost entity)
        {
            //await unit.BlogRepository.AddAsync(entity);

            //await unit.CompleteAsync();

            //return Results.Ok();

            if (entity.Tags != null && entity.Tags.Any())
            {
                foreach (var tag in entity.Tags)
                {
                    var existingTag = await unit.TagRepository.GetByNameAsync(tag.Name);
                    if (existingTag != null)
                    {
                        // Use the existing tag
                        tag.Id = existingTag.Id;
                    }
                }
            }

            await unit.BlogRepository.AddAsync(entity);
            await unit.CompleteAsync();

            return Results.Ok(entity);
        }
    }
}
