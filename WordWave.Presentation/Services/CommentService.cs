using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WordWave.Presentation.DTOs;
using WordWave.Presentation.Interfaces;

namespace WordWave.Presentation.Services
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("WordWaveApi");
        }

        public async Task<CommentDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CommentDto>($"api/Comment/id/{id}");
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CommentDto>>("api/Comment");
        }

        public async Task AddAsync(CommentDto comment)
        {
            await _httpClient.PostAsJsonAsync("api/Comment", comment);
        }

        public async Task UpdateAsync(CommentDto comment, int id)
        {
            await _httpClient.PutAsJsonAsync($"api/Comment/id/{id}", comment);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Comment/id/{id}");
        }

        public async Task<IEnumerable<BlogPostDto>> GetBlogPostsByCommentIdAsync(int commentId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BlogPostDto>>($"api/Comment/{commentId}/blogposts");
        }
    }
}

