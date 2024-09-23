namespace UrlShortner.Application.Exceptions
{
    public class CollisionException : Exception
    {
        public CollisionException(string msg) : base(msg) { }
        public CollisionException() { }
    }
}
