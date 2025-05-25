using AWS_gamehub_front.Models.DTOs;

namespace AWS_gamehub_front.Services.HttpServices
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseUrl = "http://gamehu-recip-duqgxohmiw6e-1943613613.eu-north-1.elb.amazonaws.com/api/Auth";

        public AuthService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<HttpResponseMessage> RegisterAsync(RegisterDto dto)
        {
            try
            {
                var url = $"{_baseUrl}/register";
                return await _httpClient.PostAsJsonAsync(url, dto);
            }
            catch (Exception ex)
            {

                throw new Exception("error al enviar los datos de crear usuario ---> ", ex);
            }
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDTO dto)
        {
            try
            {
                var url = $"{_baseUrl}/login";
                var response = await _httpClient.PostAsJsonAsync(url, dto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                }
                else
                {
                    // Puedes manejar el error como prefieras (null, excepción, etc.)
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("erro al hacer login -----> " + ex);
            }
        }

    }
}
