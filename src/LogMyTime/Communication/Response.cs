using System.Runtime.Serialization;

namespace LogMyTime.Communication
{
    [DataContract]
    internal sealed class Response<T>
    {
        [DataMember(Name = "d")]
        public T D { get; set; }
    }
}
