using System.Runtime.Serialization;

namespace LogMyTime.Entities
{
    /// <summary>
    /// Liste möglicher Zeiteintragstypen
    /// </summary>
    [DataContract]
    public enum TimeEntryType
    {
        /// <summary>
        /// Standard Eintrag
        /// </summary>
        Default = 0,

        /// <summary>
        /// Dauer-Zeiteintrag
        /// </summary>
        [EnumMember]
        Permanent = 1,

        /// <summary>
        /// Start/Ende 
        /// </summary>
        [EnumMember]
        StartEnd = 2,
    }
}
