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
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        public BlogService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("WordWaveApi");
        }

        public async Task<BlogPostDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Blog/id/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<BlogPostDto>();
            return result ?? null;
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/api/Blog/");

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<BlogPostDto>();

            }
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<BlogPostDto>>();
            return result ?? Enumerable.Empty<BlogPostDto>();
        }

        public async Task AddAsync(BlogPostDto entity)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Blog/", entity);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task UpdateAsync(BlogPostDto entity, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Blog/id/{id}", entity);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Blog/id/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task<BlogPostDto> GetBlogByTitleAsync(string title)
        {
            var response = await _httpClient.GetAsync($"/api/Blog/title/{title}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<BlogPostDto>();
            return result ?? null;
        }
    }
}
