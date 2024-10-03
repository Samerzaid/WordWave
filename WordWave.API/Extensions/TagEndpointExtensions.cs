using Microsoft.AspNetCore.Mvc;
using WordWave.Domain.Entities;
using WordWave.Infrastructure.Interfaces;

namespace WordWave.API.Extensions
{
    public static class TagEndpointExtensions
    {
        public static IEndpointRouteBuilder TagEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/Tag");

            group.MapPost("/", AddTag);
            group.MapGet("/", GetAllTags);
            group.MapGet("/id/{id}", GetTagById);
            group.MapPut("/{id}", UpdateTag);
            group.MapDelete("/{id}", DeleteTag);

            return app;
        }

        private static Task DeleteTag(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private static Task UpdateTag(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private static Task GetTagByTitle(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private static Task GetTagById(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private static Task GetAllTags(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private static Task AddTag(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}

