using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LogMyTime
{
    [DataContract]
    public sealed class Result<T>
    {

        [DataMember(Name = "results")]
        public List<T> Results { get; set; }
    }
}
