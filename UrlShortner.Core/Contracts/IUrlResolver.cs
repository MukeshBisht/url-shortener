namespace UrlShortner.Application.Contracts
{
    public interface IUrlResolver
    {
        Task<string> ResolveUrlAsync(string code);
    }
}
