using System.Runtime.Serialization;

namespace Odeon.Application.ViewModels.Responses
{
    [Serializable]
    [DataContract]
    public class Response<T> : BaseResponse
    {
        [DataMember]
        public T Data { get; set; }
    }
}
