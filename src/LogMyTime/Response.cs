using System.Runtime.Serialization;

namespace LogMyTime
{
    [DataContract]
    public sealed class Response<T>
    {
        [DataMember(Name = "d")]
        public Result<T> D { get; set; }
    }
}
