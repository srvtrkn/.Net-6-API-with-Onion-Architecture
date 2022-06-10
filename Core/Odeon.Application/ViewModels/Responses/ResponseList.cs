using System.Runtime.Serialization;

namespace Odeon.Application.ViewModels.Responses
{
    [Serializable]
    [DataContract]
    public class ResponseList<T> : BaseResponse
    {
        [DataMember]
        public List<T> DataList { get; set; }
    }
}
