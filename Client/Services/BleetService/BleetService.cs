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
        public Bleet CreatedBleet = new();

        public async Task CreateBleet(Bleet bleet)
        {
            await _http.PostAsJsonAsync("api/Bleet", bleet);
        }

        public async Task GetBleets()
        {
            var result = 
                await _http.GetFromJsonAsync<List<Bleet>>("api/Bleet");

            if (result != null)
                Bleets = result;
        }
    }
}
