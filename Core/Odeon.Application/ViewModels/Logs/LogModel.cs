namespace Odeon.Application.ViewModels.Logs
{
    public class LogModel
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
