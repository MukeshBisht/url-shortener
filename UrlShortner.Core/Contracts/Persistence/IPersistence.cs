namespace UrlShortner.Application.Servies.Persistence
{
    public interface IPersistence<T, TKey>
    {
        Task<bool> SaveAsync(T obj);
        Task<T> GetAsync(TKey key);
        Task<bool> ExistAsync(TKey key);
    }
}
