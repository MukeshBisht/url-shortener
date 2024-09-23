using UrlShortner.Application.Entities;
using UrlShortner.Application.Servies.Persistence;

namespace UrlShortner.Application.Contracts
{
    public interface IUrlPersistance : IPersistence<ShortUrl, string>
    {
    }
}
