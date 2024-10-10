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
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("WordWaveApi");
        }
        public async Task<UserDto> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/users/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<UserDto>();
            return result ?? null;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/api/users/");

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<UserDto>();

            }

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
            return result ?? Enumerable.Empty<UserDto>();
        }

        public async Task AddAsync(UserDto entity)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users/", entity);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task UpdateAsync(UserDto entity, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/users/{entity.Id}", entity);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"/api/users/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var response = await _httpClient.GetAsync($"/api/users/email/{email}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = await response.Content.ReadFromJsonAsync<UserDto>();
            return result ?? null;
        }

        public Task UpdateAsync(UserDto entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
