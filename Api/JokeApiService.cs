using System.Net.Http.Json;

namespace CommandLineTool.Api
{
    public class JokeApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JokeApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Joke?> GetRandomJokeAsync()
        {
            var client = _httpClientFactory.CreateClient(nameof(JokeApiService));

            return await client.GetFromJsonAsync<Joke>("/random_joke");
        }
    }

    public class Joke
    {
        public string Type { get; set; } = string.Empty;
        public string Setup { get; set; } = string.Empty;
        public string Punchline { get; set; } = string.Empty;
    }
}
