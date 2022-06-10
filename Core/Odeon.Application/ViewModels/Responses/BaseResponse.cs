using System.Runtime.Serialization;

namespace Odeon.Application.ViewModels.Responses
{
    [Serializable]
    [DataContract]
    public abstract class BaseResponse
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
