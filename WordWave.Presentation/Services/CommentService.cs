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
        private ICommentService _commentServiceImplementation;

        public CommentService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("WordWaveApi");
        }
        public async Task<CommentDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Comment/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<CommentDto>();
            return result;
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/api/Comment");

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<CommentDto>();

            }
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<CommentDto>>();
            return result ?? Enumerable.Empty<CommentDto>();
        }

        public async Task AddAsync(CommentDto entity)
        {

            throw new NotImplementedException();
        }

        public async Task AddCommentToPostAsync(CommentDto entity, int blogPostId)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Comment/blogPostId/{blogPostId}", entity);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public Task UpdateAsync(CommentDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int commentId)
        {
            var response = await _httpClient.DeleteAsync($"/api/Comment/CommentId/{commentId}");

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }
    }
}
