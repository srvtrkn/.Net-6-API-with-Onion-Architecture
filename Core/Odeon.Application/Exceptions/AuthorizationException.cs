
namespace Odeon.Application.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException() : base("Bu metod için yetkiniz bulunmamaktadır") { }
    }
}
