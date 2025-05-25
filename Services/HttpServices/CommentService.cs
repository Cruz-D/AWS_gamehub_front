using AWS_gamehub_front.Models.DTOs;

namespace AWS_gamehub_front.Services.HttpServices
{
    public class CommentsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CommentsService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<List<CommentDto>?> GetCommentsByVideogameIdAsync(string videogameId, int page = 1, int size = 10)
        {
            var url = $"{_baseUrl}/{videogameId}?page={page}&size={size}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CommentDto>>();
            }
            else
            {
                // Manejo de error según necesidad
                return null;
            }
        }
    }
}
