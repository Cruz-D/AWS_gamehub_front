namespace AWS_gamehub_front.Models.DTOs
{
    public class LoginResponseDto
    {
        public string userId { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public string tokenExpiry { get; set; }
        public string tokenCreatedAt { get; set; }
    }
}
