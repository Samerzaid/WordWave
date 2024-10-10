using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WordWave.Presentation.DTOs;
using WordWave.Presentation.Interfaces;

namespace WordWave.Presentation.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;

        public BlogService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("WordWaveApi");
        }

        public async Task<BlogPostDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BlogPostDto>($"api/Blog/id/{id}");
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogPostDto>>("api/Blog");
        }

        public async Task AddAsync(BlogPostDto blogPost)
        {
            await _httpClient.PostAsJsonAsync("api/Blog", blogPost);
        }

        public async Task UpdateAsync(BlogPostDto blogPost, int id)
        {
            await _httpClient.PutAsJsonAsync($"api/Blog/id/{id}", blogPost);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Blog/id/{id}");
        }

        // New method for adding a comment to a blog post
        public async Task AddCommentToBlogPostAsync(int blogPostId, CommentDto comment)
        {
            await _httpClient.PostAsJsonAsync($"api/Blog/{blogPostId}/comments", comment);
        }

        // New method for retrieving comments by blog post ID
        public async Task<IEnumerable<CommentDto>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CommentDto>>($"api/Blog/{blogPostId}/comments");
        }
    }
}
