namespace UrlShortner.Application.Exceptions
{
    public class BadUrlException : Exception
    {
        public BadUrlException(string msg) : base(msg) { }
        public BadUrlException() { }
    }
}
