using UrlShortner.Application.Contracts;

namespace UrlShortner.Application.Services.Memory
{
    public class UrlResolverService : IUrlResolver
    {
        private readonly IUrlPersistance persistance;

        public UrlResolverService(IUrlPersistance persistance)
        {
            this.persistance = persistance;
        }

        public async Task<string> ResolveUrlAsync(string code)
        {
            var urlData = await persistance.GetAsync(code);
            if (urlData == null)
            {
                throw new KeyNotFoundException("the specified path does not exist or expired");
            }
            return urlData.Url;
        }
    }
}
