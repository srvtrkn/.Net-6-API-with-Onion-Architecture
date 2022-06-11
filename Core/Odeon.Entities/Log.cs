using Odeon.Entities.Common;

namespace Odeon.Entities
{
    public class Log : BaseEntity
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
