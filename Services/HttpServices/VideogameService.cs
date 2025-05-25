using AWS_gamehub_front.Models;
using System.Text.Json;

namespace AWS_gamehub_front.Services.HttpServices
{
    public class VideogameService
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseUrl = "http://gamehu-recip-duqgxohmiw6e-1943613613.eu-north-1.elb.amazonaws.com/api/Videogames";

        public VideogameService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<List<Videogame>> GetAllVideogamesAsync()
        {

            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Videogame>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<Videogame>();
            }
            catch (Exception ex)
            {

                throw new Exception("error al obtener videojuegos ----> " + ex);
            }
        }

        public async Task<Videogame> GetVideogameByIdAsync(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Videogame>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                throw new Exception("error al obtener videojuego por ID ----> " + ex);
            }
        }
    }
}
