using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BrightApp.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public async Task Login(UserLogin user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", user);
            var token = await result.Content.ReadAsStringAsync();
            await _localStorage.SetItemAsync("token", token);
        }

        public async Task Register(User user)
        {
            await _httpClient.PostAsJsonAsync("api/auth/register", user);
        }
    }
}
