using System.Runtime.Serialization;

namespace LogMyTime.Entities
{
    /// <summary>
    /// Base class for all entities with an index
    /// </summary>
    /// <typeparam name="T">index type</typeparam>
    [DataContract]
    public abstract class IndexedEntity<T> : Entity
    {
        /// <summary>
        /// Entity Index
        /// </summary>
        [DataMember(Name = "ID")]
        public T Id { get; set; }
    }
}
