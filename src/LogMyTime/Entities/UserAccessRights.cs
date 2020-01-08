using System.Runtime.Serialization;

namespace LogMyTime.Entities
{
    /// <summary>
    /// Liste von Nutzergruppen
    /// </summary>
    [DataContract]
    public enum UserAccessRights
    {
        /// <summary>
        /// Standardnutzer
        /// </summary>
        [EnumMember]
        DefaultUser = 10,

        /// <summary>
        /// Administrator
        /// </summary>
        [EnumMember]
        Administrator = 20,
    }
}
