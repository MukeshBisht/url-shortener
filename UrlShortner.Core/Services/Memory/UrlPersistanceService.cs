using System.Collections.Concurrent;
using UrlShortner.Application.Contracts;
using UrlShortner.Application.Entities;

namespace UrlShortner.Application.Services.Memory
{
    public class UrlPersistanceService : IUrlPersistance
    {
        private ConcurrentDictionary<string, ShortUrl> store;

        public UrlPersistanceService()
        {
            store = new ConcurrentDictionary<string, ShortUrl>();
        }

        public async Task<bool> ExistAsync(string key) => store.ContainsKey(key);

        public async Task<ShortUrl> GetAsync(string key) => store.GetValueOrDefault(key);

        public async Task<bool> SaveAsync(ShortUrl obj) => store.TryAdd(obj.Code, obj);
    }
}