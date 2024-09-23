namespace UrlShortner.Application.Entities
{
    public class ShortUrl
    {
        public string Code { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
