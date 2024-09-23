using System.Text;
using UrlShortner.Application.Contracts;

namespace UrlShortner.Application.Services.Memory
{
    public class UrlShorteningService : IUrlShortner
    {
        private readonly IUrlPersistance persistance;
        private string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public UrlShorteningService(IUrlPersistance persistance)
        {
            this.persistance = persistance;
        }

        public async Task<string> GetShortCodeAsync(string url)
        {
            Random rnd = new Random();
            StringBuilder sb;
            while (true) {
            
                sb = new StringBuilder();
                for (int i = 0; i < 7; i++)
                {
                    int idx = rnd.Next(allowedChars.Length);
                    sb.Append(allowedChars[idx]);
                }

                var str = sb.ToString();
                var exist = await persistance.ExistAsync(str);
                if(!exist) return str;
            }
        }

    }
}
