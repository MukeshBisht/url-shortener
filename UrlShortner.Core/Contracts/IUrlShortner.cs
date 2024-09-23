namespace UrlShortner.Application.Contracts
{
    public interface IUrlShortner
    {
        Task<string> GetShortCodeAsync(string url);
    }
}
