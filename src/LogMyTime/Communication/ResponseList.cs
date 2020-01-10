using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LogMyTime.Communication
{
    [DataContract]
    internal sealed class ResponseList<T>
    {

        [DataMember(Name = "results")]
        public List<T> Results { get; set; }
    }
}
