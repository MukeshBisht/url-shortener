using UrlShortner.Application.Contracts;
using UrlShortner.Application.Entities;
using UrlShortner.Application.Exceptions;

namespace UrlShortner.Application
{
    public class UrlShortener
    {
        private readonly IUrlShortner urlShortner;
        private readonly IUrlPersistance urlPersistance;
        private readonly IUrlResolver urlResolver;

        public UrlShortener(IUrlShortner urlShortner, IUrlPersistance urlPersistance, IUrlResolver urlResolver)
        {
            this.urlShortner = urlShortner;
            this.urlPersistance = urlPersistance;
            this.urlResolver = urlResolver;
        }

        public async Task<ShortUrl> SaveAsync(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? _))
            {
                throw new BadUrlException("bad url");
            }

            string code = await urlShortner.GetShortCodeAsync(url);
            ShortUrl shortUrl = new ShortUrl()
            {
                Code = code,
                CreatedAt = DateTime.UtcNow,
                Url = url
            };
            
            var success = await urlPersistance.SaveAsync(shortUrl);
            if (!success)
            {
                throw new CollisionException();
            }

            return shortUrl;
        }

        public async Task<string> GetUrlAsync(string code) => await urlResolver.ResolveUrlAsync(code);
    }
}
