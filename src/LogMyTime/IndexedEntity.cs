using System.Runtime.Serialization;

namespace LogMyTime
{
    [DataContract]
    public abstract class IndexedEntity<T> : Entity
    {
        [DataMember(Name = "ID")]
        public T Id { get; set; }
    }
}
