using BrightApp.Shared;
using System.Net.Http.Json;

namespace BrightApp.Client.Services.BleetService
{
    public class BleetService : IBleetService
    {
        private readonly HttpClient _http;
        public BleetService(HttpClient http)
        {
            _http = http;
        }
        public List<Bleet> Bleets { get; set; } = new List<Bleet>();

        public async Task GetBleets()
        {
            var result = 
                await _http.GetFromJsonAsync<ServiceResponse<List<Bleet>>>("api/Bleet");

            if (result != null && result.Data != null)
                Bleets = result.Data;
        }
    }
}
