namespace UrlShortner.Web.Dtos
{
    public record ShortUrlResponse (string Url, string Code, DateTime CreatedAt, string ShortUrl);
}
