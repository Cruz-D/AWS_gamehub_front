namespace AWS_gamehub_front.Models.DTOs
{
    public struct SendCommentDTO
    {
        public string? userId { get; set; }
        public string? videogameId { get; set; }
        public string? content { get; set; }
        public string? score { get; set; }
    }
}
